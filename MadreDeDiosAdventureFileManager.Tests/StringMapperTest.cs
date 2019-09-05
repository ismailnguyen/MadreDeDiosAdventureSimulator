using FluentAssertions;
using MadreDeDiosAdventure;
using NSubstitute;
using Xunit;

namespace MadreDeDiosAdventureFileManager.Tests
{
    public class StringMapperTest
    {
        [Fact]
        public void Should_convert_string_to_MadreDeDios_map()
        {
            // Given :
            string content = "";
            var stringMapper = new StringMapper(content);

            // When :
            Map map = stringMapper.Map();

            // Then :
            map.Should().NotBeNull();
        }

        [Theory]
        [InlineData("C - 3 - 4", 3)]
        [InlineData("C - 7 - 4", 7)]
        public void Should_map_witdh_of_map(string stringContent, int expectedWidth)
        {
            // Given :
            var stringMapper = new StringMapper(stringContent);

            // When :
            Map map = stringMapper.Map();

            // Then :
            map.Width.Should().Be(expectedWidth);
        }
    }
}
