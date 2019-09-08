using FluentAssertions;
using MadreDeDiosAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MadreDeDiosAdventureSimulator.Tests
{
    public class SimulatorTest
    {
        [Fact]
        public void Should_update_map_according_to_simulation_rules()
        {
            // Given :
            Map initialMap = new Map(
                width: 3,
                height: 4,
                mountains: new List<Mountain>
                {
                    new Mountain(new Position(1, 0)),
                    new Mountain(new Position(2, 1))
                },
                treasures: new List<Treasure>
                {
                    new Treasure(new Position(0, 3), 2),
                    new Treasure(new Position(1, 3), 3)
                },
                adventurers: new List<Adventurer>
                {
                    new Adventurer(
                        name: "Lara",
                        position: new Position(1, 1),
                        orientation: Orientation.South,
                        motionSequence: new List<Motion>
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

            var simulator = new Simulator(initialMap);

            // When :
            simulator.Simulate();

            // Then :
            simulator.Map.Adventurers.First(adventurer => adventurer.Name.Equals("Lara")).Position.Should().Be(new Position(0, 3));
            simulator.Map.Adventurers.First(adventurer => adventurer.Name.Equals("Lara")).Orientation.Should().Be(Orientation.South);
            simulator.Map.Adventurers.First(adventurer => adventurer.Name.Equals("Lara")).FoundTreasuresCount.Should().Be(3);

            simulator.Map.Treasures.Should().HaveCount(1);
            simulator.Map.Treasures.First(treasure => treasure.Position.Equals(new Position(1, 3))).Count.Should().Be(2);
        }
    }
}
