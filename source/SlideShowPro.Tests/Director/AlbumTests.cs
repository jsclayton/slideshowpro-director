﻿// Copyright(c) 2011 John Clayton - http://codemonkeylabs.com
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

using FluentAssertions;
using Xunit;

namespace SlideShowPro.Director
{
    public class AlbumTests
    {
        public AlbumTests()
        {
            Director = new Director(Config.Path);
        }

        public Director Director { get; private set; }

        [Fact]
        public void CanGetAllAlbums()
        {
            var albums = Director.GetAlbums();
            albums.Should().NotBeNull();
            albums.Should().NotBeEmpty();
        }

        [Fact]
        public void CanGetSingleAlbum()
        {
            var album = Director.GetAlbum(Config.NonEmptyAlbumId);
            album.Should().NotBeNull();
            album.Preview.Should().BeNull();
        }

        [Fact]
        public void CanGetSingleAlbumWithPreview()
        {
            var preview = new Format { Width = 720, Height = 405, Crop = true, Quality = 85, Sharpening = true };
            var album = Director.GetAlbum(Config.NonEmptyAlbumId, preview);
            album.Should().NotBeNull();
            album.Preview.Should().NotBeNull();
        }
    }
}