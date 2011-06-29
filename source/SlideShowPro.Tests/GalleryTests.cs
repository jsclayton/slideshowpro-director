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