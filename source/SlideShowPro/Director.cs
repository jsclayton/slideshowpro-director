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
using System.Collections.Generic;
using System.Net;
using RestSharp;
using SlideShowPro.Api;

namespace SlideShowPro
{
    public class Director
    {
        public Director(string path)
        {
            if (String.IsNullOrEmpty(path)) throw new ArgumentNullException("path");

            Path = path;
        }

        public string Path { get; private set; }

        public Album GetAlbum(long albumId, Format preview = null)
        {
            if (albumId <= 0) throw new ArgumentException("albumId");

            var client = CreateClient();
            var request = new RestRequest("get_album") { RequestFormat = DataFormat.Json };
            request.AddParameter("album_id", albumId.ToString());
            if (preview != null)
                request.AddParameter("preview", String.Join(",", preview.Width, preview.Height, preview.Crop ? 1 : 0, preview.Quality, preview.Sharpening ? 1 : 0));
            var response = client.Execute<Response<Album>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response.Data.Data;

            throw new SlideShowProException(response);
        }

        public IEnumerable<Album> GetAlbums()
        {
            var client = CreateClient();
            var request = new RestRequest("get_album_list") { RequestFormat = DataFormat.Json };
            var response = client.Execute<Response<AlbumListResponse>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response.Data.Data.Albums;

            throw new SlideShowProException(response);
        }

        public Content GetContent(long contentId)
        {
            var client = CreateClient();
            var request = new RestRequest("get_content") { RequestFormat = DataFormat.Json };
            request.AddParameter("content_id", contentId);
            var response = client.Execute<Response<Content>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response.Data.Data;

            throw new SlideShowProException(response);
        }

        public IEnumerable<Content> GetContents(int? limit = null, bool? imagesOnly = null)
        {
            var client = CreateClient();
            var request = new RestRequest("get_content_list") { RequestFormat = DataFormat.Json };
            if (limit != null)
                request.AddParameter("limit", limit.ToString());
            if (imagesOnly != null)
                request.AddParameter("only_images", imagesOnly.ToString());
            var response = client.Execute<Response<ContentListResponse>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response.Data.Data.Contents;

            throw new SlideShowProException(response);
        }

        public IEnumerable<Gallery> GetGalleries()
        {
            var client = CreateClient();
            var request = new RestRequest("get_gallery_list") { RequestFormat = DataFormat.Json };
            var response = client.Execute<Response<GalleryListResponse>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response.Data.Data.Galleries;

            throw new SlideShowProException(response);
        }

        public Gallery GetGallery(long galleryId, Format preview = null)
        {
            if (galleryId <= 0) throw new ArgumentException("galleryId");

            var client = CreateClient();
            var request = new RestRequest("get_gallery") { RequestFormat = DataFormat.Json };
            request.AddParameter("gallery_id", galleryId.ToString());
            if (preview != null)
                request.AddParameter("preview", String.Join(",", preview.Width, preview.Height, preview.Crop ? 1 : 0, preview.Quality, preview.Sharpening ? 1 : 0));
            var response = client.Execute<Response<Gallery>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response.Data.Data;

            throw new SlideShowProException(response);
        }

        private RestClient CreateClient()
        {
            var client = new RestClient(String.Format("http://{0}/api/", Path));
            client.AddHandler("text/javascript", new JsonDeserializerWithEpochDates());
            return client;
        }
    }
}