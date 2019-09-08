using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace MadreDeDiosAdventure.Tests
{
    public class AdventurerTest
    {
        [Fact]
        public void Move_should_update_position()
        {
            // Given :
            Adventurer adventurer = new Adventurer(
                "Ismaïl",
                new Position(0, 0),
                Orientation.North,
                new List<Motion> { }
            );

            // When :
            var positionToMove = new Position(0, 1);
            adventurer.Move(positionToMove);

            // Then :
            adventurer.Position.Should().Be(positionToMove);
        }

        [Fact]
        public void CollectTreasure_should_increment_found_treasures_counter()
        {
            // Given :
            Adventurer adventurer = new Adventurer(
                "Ismaïl",
                new Position(0, 0),
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
                new Position(0, 0),
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
