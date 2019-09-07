using FluentAssertions;
using MadreDeDiosAdventure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MadreDeDiosAdventureFileManager.Tests
{
    public class FileWriterTest
    {
        [Fact]
        public void Should_create_output_file_if_not_already_exists()
        {
            // Given :
            Map map = new Map
            (
                3,
                4,
                new List<Mountain>
                {
                    new Mountain(1, 0),
                    new Mountain(2, 1)
                },
                new List<Treasure>
                {
                    new Treasure(0, 3, 2),
                    new Treasure(1, 3, 3)
                },
                new List<Adventurer>
                {
                    new Adventurer(
                        "Lara",
                        1,
                        1,
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

            string outputFileName = "dummyOutputFile.txt";
            FileWriter fileWriter = new FileWriter(outputFileName);

            // When :
            fileWriter.Write();

            // Then :
            bool isFileExist = File.Exists(outputFileName);

            isFileExist.Should().BeTrue();
        }
    }
}
