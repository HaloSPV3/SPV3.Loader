/**
 * Copyright (c) 2019 Emilian Roman
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using Semver;
using SPV3.Annotations;
using static HXE.Net.DefaultHttpClient;

namespace SPV3
{
  public partial class Version
  {
    public class VersionUpstream : INotifyPropertyChanged
    {
      private const string Latest = "https://github.com/HaloSPV3/HCE/raw/meta/latest.xml";

      /// <summary> Needed for releases and pre-releases. Append '/latest' for latest release. </summary>
      private const string API_GITHUB_HALOSPV3_SPV3LOADER_RELEASES_URI =
        "https://api.github.com/repos/HaloSPV3/SPV3.Loader/releases";

      // default state must be null for initial comparison to AllowPreReleaseUpdates; Otherwise, !AllowPreReleases would be Initialise() is (almost) never called.
      private static bool? s_allowPreReleaseUpdates;
      private static bool s_isInitialiseRunning;
      private static long s_rateLimitResetUtcEpochSeconds;

      private static long GetSecondsUntilRateLimitReset()
      {
        return (long)DateTimeOffset.FromUnixTimeSeconds(s_rateLimitResetUtcEpochSeconds)
          .Subtract(DateTimeOffset.UtcNow)
          .TotalSeconds + 1; // +1 for margin of error
      }

      /// <summary>
      /// We fetch releases once per process and cache them in-memory. This list is later filtered as needed.
      /// </summary>
      private static List<GitHubTypes.ReleaseLite> CachedReleasesList { get; } = [];

      public VersionUpstream()
      {
        Kernel.ConfigChanged += RecheckUpdates;
      }

      public Visibility Visibility
      {
        get;
        set
        {
          if (value == field) return;
          field = value;
          OnPropertyChanged();
        }
      } = Visibility.Collapsed;

      /// <summary> A very short status message (~25 character limit) or the latest version at the remote URI.</summary>
      [StringLength(25, ErrorMessage = "Upstream Version's Label can fit approximately {1} characters")]
      public string Content
      {
        get;
        set
        {
          if (value == field) return;
          field = value;
          OnPropertyChanged();
        }
      } = string.Empty;

      public string Tooltip
      {
        get;
        set
        {
          if (value == field) return;
          field = value;
          OnPropertyChanged();
        }
      } = string.Empty;

      public string Address
      {
        get;
        set
        {
          if (value == field) return;
          field = value;
          OnPropertyChanged();
        }
      } = string.Empty;

      [Obsolete($"Superseded by {nameof(SemVersion)}")]
      public System.Version Version
      {
        get;
        set
        {
          if (value == field) return;
          field = value;
          OnPropertyChanged();
        }
      } = new();

      public SemVersion SemVersion
      {
        get;
        set
        {
          if (value == field) return;
          field = value;
          OnPropertyChanged();
        }
      } = new(0);

      /// <summary>
      /// "https://github.com/HaloSPV3/SPV3.Loader/blob/main/CHANGELOG.md" -OR-<br/>
      /// "https://github.com/HaloSPV3/SPV3.Loader/blob/develop/CHANGELOG.md"
      ///  </summary>
      public string GitChangeLogUrl => "https://github.com/HaloSPV3/SPV3.Loader/blob/develop/CHANGELOG.md";

      public event PropertyChangedEventHandler? PropertyChanged;

      public async Task Initialise()
      {
        const string MsgPrefix =
          $"[{nameof(SPV3)}.{nameof(SPV3.Version)}.{nameof(VersionUpstream)}.{nameof(Initialise)}] ";
        const string MsgFormat = MsgPrefix + "{0}: {1}";
        const string MsgRateLimitedFormat = MsgPrefix + "Rate-limited. Wait {0} seconds before checking for updates.";

        if (s_isInitialiseRunning)
        {
          var log = (HXE.File)Paths.Exception;
          const string MessageIsInitialiseRunning =
            $"{MsgPrefix}Already running. Skipping this {nameof(Initialise)}() call...";
          HXE.Console.Info(MessageIsInitialiseRunning);
          log.AppendAllText(MessageIsInitialiseRunning + "\n");
        }

        try
        {
          var secondsRemaining = GetSecondsUntilRateLimitReset();
          if (secondsRemaining > 0)
          {
            LogError(string.Format(MsgRateLimitedFormat, secondsRemaining));
            return;
          }

          s_isInitialiseRunning = true;
          Content = "Checking For Updates";
          Tooltip = $"Checking for updates at {API_GITHUB_HALOSPV3_SPV3LOADER_RELEASES_URI}";


          /* initialize CachedReleasesList if empty */
          if (CachedReleasesList.Count == 0)
          {
            /*
             # User agent required

             Requests without a valid User-Agent header will be rejected. You
             should use your username or the name of your application for the
             User-Agent value.

             curl sends a valid User-Agent header by default.
             */
            string userAgentString;
            {
              System.Text.StringBuilder userAgentStringBuilder = new("Mozilla/5.0 (");
              userAgentStringBuilder.Append(
                OperatingSystem.IsWindows()
                  ? $"Windows NT {Environment.OSVersion.Version.Major}.{Environment.OSVersion.Version.Minor}; {"Win" + (Environment.Is64BitOperatingSystem ? "64; x64" : "32")}"
                  : "Linux x86_64"
              );
              userAgentStringBuilder.Append(
                $"; rv:{GitVersionInformation.Major}.{GitVersionInformation.Minor}) SPV3.Loader/{GitVersionInformation.Major}.{GitVersionInformation.Minor}");
              userAgentString = userAgentStringBuilder.ToString();
            }

            using var request = new HttpRequestMessage(HttpMethod.Get, API_GITHUB_HALOSPV3_SPV3LOADER_RELEASES_URI);
            request.Headers.Add("User-Agent", userAgentString);
            request.Headers.Add("Accept", "application/vnd.github+json");
            request.Headers.Add("Accept", "application/json; charset=utf-8");
            request.Headers.Add("X-GitHub-Api-Version", "2026-03-10");
            using var response = await Client.SendAsync(request, HttpCompletionOption.ResponseContentRead);

            /* # [Rate limit errors](https://docs.github.com/rest/using-the-rest-api/troubleshooting-the-rest-api?apiVersion=2026-03-10#rate-limit-errors)

              GitHub enforces rate limits to ensure that the API stays available
              for all users. For more information, see [Rate limits for the REST
              API](https://docs.github.com/rest/using-the-rest-api/rate-limits-for-the-rest-api).

              If you exceed your primary rate limit, you will receive a `403
              Forbidden` or `429 Too Many Requests` response, and the
              `x-ratelimit-remaining` header will be `0`. If you exceed a
              secondary rate limit, you will receive a `403 Forbidden` or `429
              Too Many Requests` response and an error message that indicates
              that you exceeded a secondary rate limit.

              If you receive a rate limit error, you should stop making requests
              temporarily according to these guidelines:

              - If the retry-after response header is present, you should not
                retry your request until after that many seconds has elapsed.
              - If the x-ratelimit-remaining header is 0, you should not make
                another request until after the time specified by the
                x-ratelimit-reset header. The x-ratelimit-reset header is in UTC
                epoch seconds.
              - Otherwise, wait for at least one minute before retrying. If your
                request continues to fail due to a secondary rate limit, wait
                for an exponentially increasing amount of time between retries,
                and throw an error after a specific number of retries.

              Continuing to make requests while you are rate limited may result
              in the banning of your integration.

              # [Primary rate limit for unauthenticated users](https://docs.github.com/rest/using-the-rest-api/rate-limits-for-the-rest-api#primary-rate-limit-for-unauthenticated-users)

              The primary rate limit for unauthenticated requests is 60 requests per hour.
            */
            if (response.Headers.TryGetValues("x-ratelimit-remaining", out var rateLimitHeaders)
                && rateLimitHeaders.Any(rateLimit => rateLimit == "0")
                && response.Headers.TryGetValues("x-ratelimit-reset", out var rateLimitResetUtcEpochSecondsString)
                && long.TryParse(rateLimitResetUtcEpochSecondsString.FirstOrDefault() ?? "0",
                  out var rateLimitResetUtcEpochSeconds))
            {
              s_rateLimitResetUtcEpochSeconds = rateLimitResetUtcEpochSeconds;
              LogError(string.Format(MsgRateLimitedFormat, GetSecondsUntilRateLimitReset()));
              // this can result in recursive loop until the stack overflows. Need a better way to cancel and restart after some time.
              return;
            }

            response.EnsureSuccessStatusCode();
#if NET6_0_OR_GREATER
          await // asynchronously dispose the content stream; unavailable in .NET Framework
#endif
            using var rs = await response.Content.ReadAsStreamAsync();


            GitHubTypes.Release[]? deserializedArray = await JsonSerializer.DeserializeAsync(
              rs,
              GitHubReleaseContext.Default.ReleaseArray
            );
            // WARNING: if CacheReleasesList is empty and deserializedArray continues to be null, API rate limiting may occur
            if (deserializedArray == null)
            {
              LogError("Unable to parse HTTP Response");
              return;
            }

            foreach (var release in deserializedArray)
            {
              // exclude draft releases
              if (release.draft) continue;
              // add published releases and prereleases to cache
              CachedReleasesList.Add((GitHubTypes.ReleaseLite)release);
            }
          }

          List<GitHubTypes.ReleaseLite> filteredReleases =
          [
            .. CachedReleasesList.Where(release =>
              // filter for full releases and prereleases (if AllowPreReleaseUpdates is true)
              !release.prerelease || s_allowPreReleaseUpdates == true)
          ];

          // There should be at least one release. If there are zero releases, something's wrong.
          if (filteredReleases.Count == 0)
          {
            LogError(s_allowPreReleaseUpdates == true ? "No releases or pre-releases found" : "No releases found");
            return;
          }

          var clientVersion = SemVersion.Parse(GitVersionInformation.FullSemVer, SemVersionStyles.Strict);
          var latestVersion = new SemVersion(0);
          var latestRelease = filteredReleases[0];

          foreach (var release in filteredReleases)
          {
            if (!SemVersion.TryParse(release.tag_name.Replace("v", ""), out var result)
                || result.CompareSortOrderTo(latestVersion) <= 0)
            {
              continue;
            }

            latestVersion = result;
            latestRelease = release;
          }

          if (latestRelease == null)
          {
            LogError("Releases found; failed to determine latest version");
            return;
          }

          var prereleaseNumber = latestVersion.PrereleaseIdentifiers
            .FirstOrDefault(v => v.NumericValue != null).NumericValue ?? 0;

#pragma warning disable CS0618 // Type or member is obsolete
          Version = new(
#pragma warning restore CS0618 // Type or member is obsolete
            (int)latestVersion.Major,
            (int)latestVersion.Minor,
            (int)latestVersion.Patch,
            (int)prereleaseNumber
          );
          SemVersion = latestVersion;

          if (clientVersion.CompareSortOrderTo(latestVersion) >= 0)
          {
            Content = "Up-to-date!";
            LogInfo("Current version is greater than or equal to latest release.");
            Visibility = Visibility.Collapsed;
            Address = "https://github.com/HaloSPV3/SPV3.Loader/releases/tag/v" + GitVersionInformation.FullSemVer;
            return;
          }

          Content = $"Update loader to {latestVersion}";
          // also sets Tooltip = latestRelease.html_url
          LogInfo(latestRelease.html_url);
          Visibility = Visibility.Visible;
          Address = latestRelease.html_url;
        }
        catch (Exception exception)
        {
          LogError(exception.ToString());
        }
        finally
        {
          s_isInitialiseRunning = false;
        }

        return;

        void LogError(string tooltip)
        {
          Content = "Error";
          Tooltip = tooltip;
          var log = (HXE.File)Paths.Exception;
          var msg = string.Format(MsgFormat, Content, Tooltip);
          HXE.Console.Error(msg);
          log.AppendAllText(msg + "\n");
          Visibility = Debug.IsDebug ? Visibility.Visible : Visibility.Collapsed;
        }

        void LogInfo(string tooltip)
        {
          // Content = "Error";
          Tooltip = tooltip;
          var log = (HXE.File)Paths.Exception;
          var msg = string.Format(MsgFormat, Content, Tooltip);
          HXE.Console.Info(msg);
          log.AppendAllText(msg + "\n");
          // Visibility = Debug.IsDebug ? Visibility.Visible : Visibility.Collapsed;
        }
      }

      private void RecheckUpdates(object? sender, EventArgs e)
      {
        if (s_allowPreReleaseUpdates == Kernel.spv3.AllowPrereleaseUpdates)
          return;
        s_allowPreReleaseUpdates = Kernel.spv3.AllowPrereleaseUpdates;
        // https://stackoverflow.com/a/22629216/14894786
        Task.Run(() => Initialise()).ContinueWith(_ => true).GetAwaiter().GetResult();
      }

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    [JsonSerializable(typeof(bool))]
    [JsonSerializable(typeof(GitHubTypes.Asset))]
    [JsonSerializable(typeof(GitHubTypes.Author))]
    [JsonSerializable(typeof(GitHubTypes.Release[]))]
    [JsonSerializable(typeof(GitHubTypes.Uploader))]
    [JsonSerializable(typeof(int))]
    [JsonSerializable(typeof(string))]
    internal partial class GitHubReleaseContext : JsonSerializerContext;

#pragma warning disable IDE1006 // Naming Styles
    internal static class GitHubTypes
    {
      /// <summary>GitHub Release metadata object from https://api.github.com/repos/OWNER/REPO/releases</summary>
      /// <param name="url">"https://api.github.com/repos/HaloSPV3/SPV3.Loader/releases/359025695"</param>
      /// <param name="assets_url">"https://api.github.com/repos/HaloSPV3/SPV3.Loader/releases/359025695/assets"</param>
      /// <param name="upload_url">"https://uploads.github.com/repos/HaloSPV3/SPV3.Loader/releases/359025695/assets{?name,label}"</param>
      /// <param name="html_url">"https://github.com/HaloSPV3/SPV3.Loader/releases/tag/v2.3.0-alpha.2"</param>
      /// <param name="id">359025695</param>
      /// <param name="author">Metadata object describing the author of the release</param>
      /// <param name="node_id">"RE_kwDOFv9Y0s4VZkwf",</param>
      /// <param name="tag_name">"v2.3.0-alpha.2",</param>
      /// <param name="target_commitish">"develop",</param>
      /// <param name="name">"v2.3.0-alpha.2",</param>
      /// <param name="draft">false,</param>
      /// <param name="immutable">false,</param>
      /// <param name="prerelease">true,</param>
      /// <param name="created_at">"2026-07-24T00:50:44Z",</param>
      /// <param name="updated_at">"2026-07-24T00:59:24Z",</param>
      /// <param name="published_at">"2026-07-24T00:51:41Z",</param>
      /// <param name="assets">Array of <see cref="Asset"/> metadata objects for the release's assets files</param>
      /// <param name="tarball_url">"https://api.github.com/repos/HaloSPV3/SPV3.Loader/tarball/v2.3.0-alpha.2"</param>
      /// <param name="zipball_url">"https://api.github.com/repos/HaloSPV3/SPV3.Loader/zipball/v2.3.0-alpha.2"</param>
      /// <param name="body">The release's text body</param>
      internal class Release(
        string url,
        string assets_url,
        string upload_url,
        string html_url,
        int id,
        Author author,
        string node_id,
        string tag_name,
        string target_commitish,
        string name,
        bool draft,
        bool immutable,
        bool prerelease,
        string created_at,
        string updated_at,
        string published_at,
        Asset[] assets,
        string tarball_url,
        string zipball_url,
        string body
      )
      {
        public string url { get; set; } = url;
        public string assets_url { get; set; } = assets_url;
        public string upload_url { get; set; } = upload_url;
        public string html_url { get; set; } = html_url;
        public int id { get; set; } = id;
        public Author author { get; set; } = author;
        public string node_id { get; set; } = node_id;
        public string tag_name { get; set; } = tag_name;
        public string target_commitish { get; set; } = target_commitish;
        public string name { get; set; } = name;
        public bool draft { get; set; } = draft;
        public bool immutable { get; set; } = immutable;
        public bool prerelease { get; set; } = prerelease;
        public string created_at { get; set; } = created_at;
        public string updated_at { get; set; } = updated_at;
        public string published_at { get; set; } = published_at;
        public Asset[] assets { get; set; } = assets;
        public string tarball_url { get; set; } = tarball_url;
        public string zipball_url { get; set; } = zipball_url;
        public string body { get; set; } = body;
      }

      /// <summary>
      /// Because keeping a collection of full <see cref="Release"/> objects in memory at <see cref="VersionUpstream.CachedReleaseList"/> seems wasteful. Strings and collections can unexpectedly become memory-hogs.
      /// </summary>
      internal class ReleaseLite(
        string html_url,
        string tag_name,
        string target_commitish,
        string name,
        bool draft,
        bool prerelease,
        string published_at,
        Asset[] assets,
        string body
      )
      {
        public string html_url { get; set; } = html_url;
        public string tag_name { get; set; } = tag_name;
        public string target_commitish { get; set; } = target_commitish;
        public string name { get; set; } = name;
        public bool draft { get; set; } = draft;
        public bool prerelease { get; set; } = prerelease;
        public string published_at { get; set; } = published_at;
        public Asset[] assets { get; set; } = assets;
        public string body { get; set; } = body;

        public static explicit operator ReleaseLite(Release release) => new(
          release.html_url,
          release.tag_name,
          release.target_commitish,
          release.name,
          release.draft,
          release.prerelease,
          release.published_at,
          release.assets,
          release.body
        );
      }

      /// <summary>The author information in a release</summary>
      /// <param name="login">"github-actions[bot]"</param>
      /// <param name="id">41898282</param>
      /// <param name="node_id">"MDM6Qm90NDE4OTgyODI="</param>
      /// <param name="avatar_url">"https://avatars.githubusercontent.com/in/15368?v=4"</param>
      /// <param name="gravatar_id">""</param>
      /// <param name="url">"https://api.github.com/users/github-actions%5Bbot%5D"</param>
      /// <param name="html_url">"https://github.com/apps/github-actions"</param>
      /// <param name="followers_url">"https://api.github.com/users/github-actions%5Bbot%5D/followers"</param>
      /// <param name="following_url">"https://api.github.com/users/github-actions%5Bbot%5D/following{/other_user}"</param>
      /// <param name="gists_url">"https://api.github.com/users/github-actions%5Bbot%5D/gists{/gist_id}"</param>
      /// <param name="starred_url">"https://api.github.com/users/github-actions%5Bbot%5D/starred{/owner}{/repo}"</param>
      /// <param name="subscriptions_url">"https://api.github.com/users/github-actions%5Bbot%5D/subscriptions"</param>
      /// <param name="organizations_url">"https://api.github.com/users/github-actions%5Bbot%5D/orgs"</param>
      /// <param name="repos_url">"https://api.github.com/users/github-actions%5Bbot%5D/repos"</param>
      /// <param name="events_url">"https://api.github.com/users/github-actions%5Bbot%5D/events{/privacy}"</param>
      /// <param name="received_events_url">"https://api.github.com/users/github-actions%5Bbot%5D/received_events"</param>
      /// <param name="type">"Bot"</param>
      /// <param name="user_view_type">"public"</param>
      /// <param name="site_admin">false</param>
      /// <returns></returns>
      public class Author(
        string login,
        int id,
        string node_id,
        string avatar_url,
        string gravatar_id,
        string url,
        string html_url,
        string followers_url,
        string following_url,
        string gists_url,
        string starred_url,
        string subscriptions_url,
        string organizations_url,
        string repos_url,
        string events_url,
        string received_events_url,
        string type,
        string user_view_type,
        bool site_admin
      )
      {
        public string login { get; set; } = login;
        public int id { get; set; } = id;
        public string node_id { get; set; } = node_id;
        public string avatar_url { get; set; } = avatar_url;
        public string gravatar_id { get; set; } = gravatar_id;
        public string url { get; set; } = url;
        public string html_url { get; set; } = html_url;
        public string followers_url { get; set; } = followers_url;
        public string following_url { get; set; } = following_url;
        public string gists_url { get; set; } = gists_url;
        public string starred_url { get; set; } = starred_url;
        public string subscriptions_url { get; set; } = subscriptions_url;
        public string organizations_url { get; set; } = organizations_url;
        public string repos_url { get; set; } = repos_url;
        public string events_url { get; set; } = events_url;
        public string received_events_url { get; set; } = received_events_url;
        public string type { get; set; } = type;
        public string user_view_type { get; set; } = user_view_type;
        public bool site_admin { get; set; } = site_admin;
      }

      /// <summary>GitHub Release asset's metadata<br/>
      /// See <see cref="Release" path="/param[@name=assets]">Release.assets</see>
      /// </summary>
      /// <param name="url">"https://api.github.com/repos/HaloSPV3/SPV3.Loader/releases/assets/487820956"</param>
      /// <param name="id">487820956</param>
      /// <param name="node_id">"RA_kwDOFv9Y0s4dE46c"</param>
      /// <param name="name">"SPV3.Loader.2.3.0-alpha.31.net462.win-x86.zip"</param>
      /// <param name="label">""</param>
      /// <param name="uploader">Metadata object identifying the user/bot who uploaded the asset</param>
      /// <param name="content_type">"application/zip",</param>
      /// <param name="state">"uploaded",</param>
      /// <param name="size">8569873,</param>
      /// <param name="digest">"sha256:6102e7152247587e67b82ad6409940ea90d2d471f04aebcfde5af0d075ed1564",</param>
      /// <param name="download_count">0,</param>
      /// <param name="created_at">"2026-07-24T00:51:36Z",</param>
      /// <param name="updated_at">"2026-07-24T00:51:37Z",</param>
      /// <param name="browser_download_url">"https://github.com/HaloSPV3/SPV3.Loader/releases/download/v2.3.0-alpha.2/SPV3.Loader.2.3.0-alpha.31.net462.win-x86.zip"</param>
      public class Asset(
        string url,
        int id,
        string node_id,
        string name,
        string label,
        Uploader uploader,
        string content_type,
        string state,
        int size,
        string digest,
        int download_count,
        string created_at,
        string updated_at,
        string browser_download_url
      )
      {
        public string url { get; set; } = url;
        public int id { get; set; } = id;
        public string node_id { get; set; } = node_id;
        public string name { get; set; } = name;
        public string label { get; set; } = label;
        public Uploader uploader { get; set; } = uploader;
        public string content_type { get; set; } = content_type;
        public string state { get; set; } = state;
        public int size { get; set; } = size;
        public string digest { get; set; } = digest;
        public int download_count { get; set; } = download_count;
        public string created_at { get; set; } = created_at;
        public string updated_at { get; set; } = updated_at;
        public string browser_download_url { get; set; } = browser_download_url;
      };

      /// <summary>
      /// The base of type <see cref="Asset"/>. This type has only the properties we use or may use.
      /// </summary>
      public class AssetLite(
        string name,
        string label,
        string content_type,
        int size,
        string digest,
        string updated_at,
        string browser_download_url
      )
      {
        public string name { get; set; } = name;
        public string label { get; set; } = label;
        public string content_type { get; set; } = content_type;
        public int size { get; set; } = size;
        public string digest { get; set; } = digest;
        public string updated_at { get; set; } = updated_at;
        public string browser_download_url { get; set; } = browser_download_url;

        public static explicit operator AssetLite(Asset asset) => new(
          asset.name,
          asset.label,
          asset.content_type,
          asset.size,
          asset.digest,
          asset.updated_at,
          asset.browser_download_url);
      };

      /// <summary><inheritdoc cref="Asset" path="/param[@name='uploader']"/></summary>
      /// <param name="login">"github-actions[bot]"</param>
      /// <param name="id">41898282</param>
      /// <param name="node_id">"MDM6Qm90NDE4OTgyODI="</param>
      /// <param name="avatar_url">"https://avatars.githubusercontent.com/in/15368?v=4"</param>
      /// <param name="gravatar_id">""</param>
      /// <param name="url">"https://api.github.com/users/github-actions%5Bbot%5D"</param>
      /// <param name="html_url">"https://github.com/apps/github-actions"</param>
      /// <param name="followers_url">"https://api.github.com/users/github-actions%5Bbot%5D/followers"</param>
      /// <param name="following_url">"https://api.github.com/users/github-actions%5Bbot%5D/following{/other_user}"</param>
      /// <param name="gists_url">"https://api.github.com/users/github-actions%5Bbot%5D/gists{/gist_id}"</param>
      /// <param name="starred_url">"https://api.github.com/users/github-actions%5Bbot%5D/starred{/owner}{/repo}"</param>
      /// <param name="subscriptions_url">"https://api.github.com/users/github-actions%5Bbot%5D/subscriptions"</param>
      /// <param name="organizations_url">"https://api.github.com/users/github-actions%5Bbot%5D/orgs"</param>
      /// <param name="repos_url">"https://api.github.com/users/github-actions%5Bbot%5D/repos"</param>
      /// <param name="events_url">"https://api.github.com/users/github-actions%5Bbot%5D/events{/privacy}"</param>
      /// <param name="received_events_url">"https://api.github.com/users/github-actions%5Bbot%5D/received_events"</param>
      /// <param name="type">"Bot"</param>
      /// <param name="user_view_type">"public"</param>
      /// <param name="site_admin">false</param>
      public class Uploader(
        string login,
        int id,
        string node_id,
        string avatar_url,
        string gravatar_id,
        string url,
        string html_url,
        string followers_url,
        string following_url,
        string gists_url,
        string starred_url,
        string subscriptions_url,
        string organizations_url,
        string repos_url,
        string events_url,
        string received_events_url,
        string type,
        string user_view_type,
        bool site_admin
      )
      {
        public string login { get; set; } = login;
        public int id { get; set; } = id;
        public string node_id { get; set; } = node_id;
        public string avatar_url { get; set; } = avatar_url;
        public string gravatar_id { get; set; } = gravatar_id;
        public string url { get; set; } = url;
        public string html_url { get; set; } = html_url;
        public string followers_url { get; set; } = followers_url;
        public string following_url { get; set; } = following_url;
        public string gists_url { get; set; } = gists_url;
        public string starred_url { get; set; } = starred_url;
        public string subscriptions_url { get; set; } = subscriptions_url;
        public string organizations_url { get; set; } = organizations_url;
        public string repos_url { get; set; } = repos_url;
        public string events_url { get; set; } = events_url;
        public string received_events_url { get; set; } = received_events_url;
        public string type { get; set; } = type;
        public string user_view_type { get; set; } = user_view_type;
        public bool site_admin { get; set; } = site_admin;
      }
    }
#pragma warning restore IDE1006 // Naming Styles
  }
}
