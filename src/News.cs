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
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml.Serialization;
using static HXE.Net.DefaultHttpClient;
using SPV3.Annotations;

namespace SPV3
{
	public class News : INotifyPropertyChanged
	{
		private const string Address = "https://github.com/HaloSPV3/HCE/raw/meta/news.xml";
		private string _content;
		private string _link;
		private Visibility _visibility = Visibility.Collapsed;

		[XmlIgnore]
		public Visibility Visibility
		{
			get => _visibility;
			set
			{
				if (value == _visibility) return;
				_visibility = value;
				OnPropertyChanged();
			}
		}

		public string Content
		{
			get => _content;
			set
			{
				if (value == _content) return;
				_content = value;
				OnPropertyChanged();
			}
		}

		public string Link
		{
			get => _link;
			set
			{
				if (value == _link) return;
				_link = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public async void Initialise()
		{
			try
			{
				using (HttpResponseMessage responseMessage = await Client.GetAsync(Address).ConfigureAwait(false))
				using (Stream contentStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
				using (var sr = new StreamReader(contentStream))
				using (var reader = new StringReader(sr.ReadToEnd()))
				{
					var news = (News) new XmlSerializer(typeof(News)).Deserialize(reader);
					Content = news.Content;
					Link = news.Link;
					Visibility = Visibility.Visible;
				}
			}
			catch (HttpRequestException e)
			{
				throw new HttpRequestException("No response for manifest.", e);
			}
			catch (Exception)
			{
				Visibility = Visibility.Collapsed;
			}
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
