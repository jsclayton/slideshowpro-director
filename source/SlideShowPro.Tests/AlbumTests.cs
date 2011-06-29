using FluentAssertions;
using Xunit;

namespace SlideShowPro
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