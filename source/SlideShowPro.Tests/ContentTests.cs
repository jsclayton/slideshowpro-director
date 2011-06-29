using FluentAssertions;
using Xunit;

namespace SlideShowPro
{
    public class ContentTests
    {
        public ContentTests()
        {
            Director = new Director(Config.Path);
        }

        public Director Director { get; private set; }

        [Fact]
        public void CanGetAllContent()
        {
            var contents = Director.GetContents();
            contents.Should().NotBeNull();
            contents.Should().NotBeEmpty();
        }

        [Fact]
        public void CanGetContent()
        {
            var content = Director.GetContent(Config.NonEmptyContentId);
            content.Should().NotBeNull();
        }

        [Fact]
        public void CanLimitContent()
        {
            var contents = Director.GetContents(limit: 5);
            contents.Should().NotBeNull();
            contents.Should().NotBeEmpty();
            contents.Should().HaveCount(5);
        }
    }
}