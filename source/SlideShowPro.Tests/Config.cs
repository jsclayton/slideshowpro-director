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