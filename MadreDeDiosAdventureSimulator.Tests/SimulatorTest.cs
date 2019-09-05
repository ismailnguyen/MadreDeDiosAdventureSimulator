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
                    new Mountain(1, 0),
                    new Mountain(2, 1)
                },
                treasures: new List<Treasure>
                {
                    new Treasure(0, 3, 2),
                    new Treasure(1, 3, 3)
                },
                adventurers: new List<Adventurer>
                {
                    new Adventurer(
                        name: "Lara",
                        horizontalAxis: 1,
                        verticalAxis: 1,
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
            var expectedFinalMap = new Map(
                width: 3,
                height: 4,
                mountains: new List<Mountain>
                {
                    new Mountain(1, 0),
                    new Mountain(2, 1)
                },
                treasures: new List<Treasure>
                {
                    new Treasure(1, 3, 2)
                },
                adventurers: new List<Adventurer>
                {
                    new Adventurer(
                        name: "Lara",
                        horizontalAxis: 0,
                        verticalAxis: 3,
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

            simulator.Map.Should().Be(expectedFinalMap);
            simulator.Map.Adventurers.First(adventurer => adventurer.Name.Equals("Lara")).FoundTreasuresCount.Should().Be(3);
        }
    }
}
