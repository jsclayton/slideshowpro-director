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