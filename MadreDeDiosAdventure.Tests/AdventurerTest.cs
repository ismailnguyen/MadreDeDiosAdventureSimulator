using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace MadreDeDiosAdventure.Tests
{
    public class AdventurerTest
    {
        [Theory]
        [InlineData(0, 1)]
        public void GoUp_should_increment_vertical_axis(int initialVerticalAxis, int finalExpectedVerticalAxis)
        {
            // Given :
            Adventurer adventurer = new Adventurer(
                "Ismaïl",
                0,
                initialVerticalAxis,
                Orientation.North,
                new List<Motion> { }
            );

            // When :
            adventurer.GoUp();

            // Then :
            adventurer.VerticalAxis.Should().Be(finalExpectedVerticalAxis);
        }

        [Theory]
        [InlineData(0, -1)]
        public void GoDown_should_decrement_vertical_axis(int initialVerticalAxis, int finalExpectedVerticalAxis)
        {
            // Given :
            Adventurer adventurer = new Adventurer(
                "Ismaïl",
                0,
                initialVerticalAxis,
                Orientation.North,
                new List<Motion> { }
            );

            // When :
            adventurer.GoDown();

            // Then :
            adventurer.VerticalAxis.Should().Be(finalExpectedVerticalAxis);
        }

        [Theory]
        [InlineData(0, 1)]
        public void GoRight_should_increment_horizontal_axis(int initialHorizontalAxis, int finalExpectedHorizontalAxis)
        {
            // Given :
            Adventurer adventurer = new Adventurer(
                "Ismaïl",
                initialHorizontalAxis,
                0,
                Orientation.North,
                new List<Motion> { }
            );

            // When :
            adventurer.GoRight();

            // Then :
            adventurer.HorizontalAxis.Should().Be(finalExpectedHorizontalAxis);
        }

        [Theory]
        [InlineData(0, -1)]
        public void GoLeft_should_decrement_horizontal_axis(int initialHorizontalAxis, int finalExpectedHorizontalAxis)
        {
            // Given :
            Adventurer adventurer = new Adventurer(
                "Ismaïl",
                initialHorizontalAxis,
                0,
                Orientation.North,
                new List<Motion> { }
            );

            // When :
            adventurer.GoLeft();

            // Then :
            adventurer.HorizontalAxis.Should().Be(finalExpectedHorizontalAxis);
        }

        [Fact]
        public void CollecTreasure_should_increment_found_treasures_counter()
        {
            // Given :
            Adventurer adventurer = new Adventurer(
                "Ismaïl",
                0,
                0,
                Orientation.North,
                new List<Motion> { }
            );

            // When :
            adventurer.CollectTreasure();

            // Then :
            adventurer.FoundTreasuresCount.Should().Be(1);
        }

        [Fact]
        public void Turn_should_update_orientation_by_given_orientation()
        {
            // Given :
            Adventurer adventurer = new Adventurer(
                "Ismaïl",
                0,
                0,
                Orientation.North,
                new List<Motion> { }
            );

            // When :
            adventurer.Turn(Orientation.Est);

            // Then :
            adventurer.Orientation.Should().Be(Orientation.Est);
        }
    }
}
