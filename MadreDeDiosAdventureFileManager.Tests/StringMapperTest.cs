﻿using FluentAssertions;
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
        public void Should_map_width_of_map(string stringContent, int expectedWidth)
        {
            // Given :
            var stringMapper = new StringMapper(stringContent);

            // When :
            Map map = stringMapper.Map();

            // Then :
            map.Width.Should().Be(expectedWidth);
        }

        [Theory]
        [InlineData("C - 3 - 4", 4)]
        [InlineData("C - 7 - 9", 9)]
        public void Should_map_height_of_map(string stringContent, int expectedHeight)
        {
            // Given :
            var stringMapper = new StringMapper(stringContent);

            // When :
            Map map = stringMapper.Map();

            // Then :
            map.Height.Should().Be(expectedHeight);
        }

        [Theory]
        [InlineData("M - 1 - 1", 1, 1)]
        [InlineData("M - 2 - 2", 2, 2)]
        public void Should_map_mountains_of_map(string stringContent, int expectedHorizontalAxis, int expectedVerticalAxis)
        {
            // Given :
            var stringMapper = new StringMapper(stringContent);

            // When :
            Map map = stringMapper.Map();

            // Then :
            map.Mountains.Should().Contain(new Mountain(expectedHorizontalAxis, expectedVerticalAxis));
        }
    }
}
