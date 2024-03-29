﻿using FluentAssertions;
using MadreDeDiosAdventure;
using System.Collections.Generic;
using Xunit;

namespace MadreDeDiosAdventureFileManager.Tests
{
    public class StringParserTest
    {
        [Fact]
        public void Should_convert_string_to_MadreDeDios_map()
        {
            // Given :
            string content = "";
            var stringParser = new StringParser();

            // When :
            Map map = stringParser.Parse(content);

            // Then :
            map.Should().NotBeNull();
        }

        [Theory]
        [InlineData("C - 3 - 4", 3)]
        [InlineData("C - 7 - 4", 7)]
        public void Should_parse_width_of_map(string stringContent, int expectedWidth)
        {
            // Given :
            var stringParser = new StringParser();

            // When :
            Map map = stringParser.Parse(stringContent);

            // Then :
            map.Width.Should().Be(expectedWidth);
        }

        [Theory]
        [InlineData("C - 3 - 4", 4)]
        [InlineData("C - 7 - 9", 9)]
        public void Should_parse_height_of_map(string stringContent, int expectedHeight)
        {
            // Given :
            var stringParser = new StringParser();

            // When :
            Map map = stringParser.Parse(stringContent);

            // Then :
            map.Height.Should().Be(expectedHeight);
        }

        [Theory]
        [InlineData("M - 1 - 1", 1, 1)]
        [InlineData("M - 2 - 2", 2, 2)]
        public void Should_parse_mountains_of_map(string stringContent, int expectedHorizontalAxis, int expectedVerticalAxis)
        {
            // Given :
            var stringParser = new StringParser();

            // When :
            Map map = stringParser.Parse(stringContent);

            // Then :
            map.Mountains.Should().Contain(new Mountain(new Position(expectedHorizontalAxis, expectedVerticalAxis)));
        }

        [Theory]
        [InlineData("T - 0 - 3 - 2", 0, 3, 2)]
        [InlineData("T - 1 - 3 - 1", 1, 3, 1)]
        public void Should_parse_treasure_of_map(string stringContent, int expectedHorizontalAxis, int expectedVerticalAxis, int expectedCount)
        {
            // Given :
            var stringParser = new StringParser();

            // When :
            Map map = stringParser.Parse(stringContent);

            // Then :
            map.Treasures.Should().Contain(new Treasure(new Position(expectedHorizontalAxis, expectedVerticalAxis), expectedCount));
        }

        [Fact]
        public void Should_parse_adventurers_of_map()
        {
            // Given :
            string stringContent = "A - Indiana - 1 - 1 - S - AADADA";
            var stringParser = new StringParser();

            // When :
            Map map = stringParser.Parse(stringContent);

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
                    new Position(expectedHorizontalAxis, expectedVerticalAxis),
                    expectedOrientation,
                    expectedMotionSequence
                ));
        }

        [Fact]
        public void Should_parse_multiple_lines_of_string_to_map()
        {
            // Given :
            string multipleLinesStringContent = @"C - 3 - 4
M - 1 - 0
M - 2 - 1
T - 0 - 3 - 2
T - 1 - 3 - 3
A - Lara - 1 - 1 - S - AADADAGGA";
            var stringParser = new StringParser();

            // When :
            Map map = stringParser.Parse(multipleLinesStringContent);

            // Then :
            Map expectedMap = new Map
            (
                3,
                4,
                new List<Mountain>
                {
                    new Mountain(new Position(1, 0)),
                    new Mountain(new Position(2, 1))
                },
                new List<Treasure>
                {
                    new Treasure(new Position(0, 3), 2),
                    new Treasure(new Position(1, 3), 3)
                },
                new List<Adventurer>
                {
                    new Adventurer(
                        "Lara",
                        new Position(1, 1), 
                        Orientation.South, 
                        new List<Motion>
                        {
                            Motion.MoveForward,
                            Motion.MoveForward,
                            Motion.TurnRight,
                            Motion.MoveForward,
                            Motion.TurnRight,
                            Motion.MoveForward,
                            Motion.TurnLeft,
                            Motion.TurnLeft,
                            Motion.MoveForward
                        }
                    )
                }
            );

            map.Should().Be(expectedMap);
        }
    }
}
