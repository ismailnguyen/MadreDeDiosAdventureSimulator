using FluentAssertions;
using MadreDeDiosAdventure;
using NSubstitute;
using System.Collections.Generic;
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

        [Theory]
        [InlineData("T - 0 - 3 - 2", 0, 3, 2)]
        [InlineData("T - 1 - 3 - 1", 1, 3, 1)]
        public void Should_map_treasure_of_map(string stringContent, int expectedHorizontalAxis, int expectedVerticalAxis, int expectedCount)
        {
            // Given :
            var stringMapper = new StringMapper(stringContent);

            // When :
            Map map = stringMapper.Map();

            // Then :
            map.Treasures.Should().Contain(new Treasure(expectedHorizontalAxis, expectedVerticalAxis, expectedCount));
        }

        [Fact]
        public void Should_map_adventurers_of_map()
        {
            // Given :
            string stringContent = "A - Indiana - 1 - 1 - S - AADADA";
            var stringMapper = new StringMapper(stringContent);

            // When :
            Map map = stringMapper.Map();

            // Then :
            string expectedName = "Indiana";
            int expectedHorizontalAxis = 1;
            int expectedVerticalAxis = 1;
            Orientation expectedOrientation = Orientation.South;
            IEnumerable<Motion> expectedMotionSequence = new List<Motion>
            {
                Motion.MoveForward,
                Motion.MoveForward,
                Motion.TurnRight,
                Motion.MoveForward,
                Motion.TurnRight,
                Motion.MoveForward,
            };

            map.Adventurers.Should().Contain(
                new Adventurer(
                    expectedName,
                    expectedHorizontalAxis,
                    expectedVerticalAxis,
                    expectedOrientation,
                    expectedMotionSequence
                ));
        }
    }
}
