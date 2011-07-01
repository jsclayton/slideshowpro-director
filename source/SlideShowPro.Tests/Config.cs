// Copyright(c) 2011 John Clayton - http://codemonkeylabs.com
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License. 

using System;
using System.Configuration;

namespace SlideShowPro
{
    internal static class Config
    {
        public static long NonEmptyAlbumId { get { return Convert.ToInt64(ConfigurationManager.AppSettings["director.nonemptyalbumid"]); } }

        public static long NonEmptyGalleryId { get { return Convert.ToInt64(ConfigurationManager.AppSettings["director.nonemptygalleryid"]); } }

        public static long NonEmptyContentId { get { return Convert.ToInt64(ConfigurationManager.AppSettings["director.nonemptycontentid"]); } }

        public static string Path { get { return ConfigurationManager.AppSettings["director.path"]; } }
    }
}