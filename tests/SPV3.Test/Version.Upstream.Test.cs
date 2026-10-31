using System.Windows;
using Semver;

namespace SPV3.Test;

[TestClass]
public sealed class TestVersionUpstream
{
  /// <summary>
  /// Gets or sets the test context which provides information about and
  /// functionality for the current test run.
  /// </summary>
  public required TestContext TestContext { get; set; }

  [TestMethod]
  public async Task TestInitialize()
  {
    var upstreamVersion = new Version.VersionUpstream();
    await upstreamVersion.Initialise();
    if (upstreamVersion.Tooltip != "Current version is greater than or equal to latest release.")
      Assert.StartsWith("https://github.com/HaloSPV3/SPV3.Loader/releases/tag/", upstreamVersion.Tooltip);
    if (upstreamVersion.Content != "Up-to-date!")
      Assert.StartsWith("Update loader to ", upstreamVersion.Content);
    Assert.AreEqual(Visibility.Collapsed, upstreamVersion.Visibility);

    // if on main, the current version may be greater-than or less-than the latest prerelease.
    if (GitVersionInformation.BranchName != "main")
    {
      var version = SemVersion.Parse(GitVersionInformation.FullSemVer);
      Kernel.spv3.AllowPrereleaseUpdates = true;
      Kernel.Save();

      // these will break if publishing a prerelease for an older release channel e.g. backporting
      Assert.IsGreaterThanOrEqualTo(version.Major, upstreamVersion.SemVersion.Major);
      Assert.IsGreaterThanOrEqualTo(version.Minor, upstreamVersion.SemVersion.Minor);
      Assert.IsGreaterThanOrEqualTo(version.Patch, upstreamVersion.SemVersion.Patch);

      if (version.Major == upstreamVersion.SemVersion.Major
          && version.Minor == upstreamVersion.SemVersion.Minor
          && version.Patch == upstreamVersion.SemVersion.Patch)
      {
        var versionPre = version.PrereleaseIdentifiers.FirstOrDefault(v => v.NumericValue != null);
        var upVersionPre = upstreamVersion.SemVersion.PrereleaseIdentifiers.FirstOrDefault(v => v.NumericValue != null);
        Assert.IsGreaterThan(
          upVersionPre,
          versionPre
        );
      }
    }
  }
}
