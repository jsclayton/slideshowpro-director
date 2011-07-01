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

using FluentAssertions;
using Xunit;

namespace SlideShowPro
{
    public class GalleryTests
    {
        public GalleryTests()
        {
            Director = new Director(Config.Path);
        }

        public Director Director { get; private set; }

        [Fact]
        public void CanGetAllGalleries()
        {
            var galleries = Director.GetGalleries();
            galleries.Should().NotBeNull();
            galleries.Should().NotBeEmpty();
        }

        [Fact]
        public void CanGetSingleGallery()
        {
            var gallery = Director.GetGallery(Config.NonEmptyGalleryId);
            gallery.Should().NotBeNull();

            var albums = gallery.Albums;
            albums.Should().NotBeNull();
            albums.Should().NotBeEmpty();
            albums.Should().OnlyContain(a => a.Preview == null);
        }

        [Fact]
        public void CanGetSingleGalleryWithPreview()
        {
            var preview = new Format { Width = 720, Height = 405, Crop = true, Quality = 85, Sharpening = true };
            var gallery = Director.GetGallery(Config.NonEmptyGalleryId, preview);
            gallery.Should().NotBeNull();

            var albums = gallery.Albums;
            albums.Should().NotBeNull();
            albums.Should().NotBeEmpty();
            albums.Should().OnlyContain(a => a.Preview != null);
        }
    }
}