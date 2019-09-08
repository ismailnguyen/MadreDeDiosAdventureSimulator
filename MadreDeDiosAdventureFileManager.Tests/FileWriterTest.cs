using FluentAssertions;
using MadreDeDiosAdventure;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MadreDeDiosAdventureFileManager.Tests
{
    public class FileWriterTest
    {
        [Fact]
        public void Should_not_write_null_map()
        {
            // Given :
            Map inputMap = null;

            string outputFileName = "dummyOutputFile.txt";
            FileWriter fileWriter = new FileWriter(outputFileName);

            // When :
            fileWriter.Write(inputMap);

            // Then :
            bool isFileExist = File.Exists(outputFileName);

            isFileExist.Should().BeFalse();
        }

        [Fact]
        public void Should_write_map_into_output_file()
        {
            // Given :
            Map inputMap = new Map
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

            string outputFileName = "dummyOutputFile.txt";
            FileWriter fileWriter = new FileWriter(outputFileName);

            // When :
            fileWriter.Write(inputMap);

            // Then :
            bool isFileExist = File.Exists(outputFileName);

            isFileExist.Should().BeTrue();

            Map outputMap = ReadMapFrom(outputFileName);

            inputMap.Should().Be(outputMap);
        }

        private Map ReadMapFrom(string outputFileName)
        {
            FileReader fileReader = new FileReader(outputFileName);

            string fileContent = fileReader.Read();

            StringParser stringToMapParser = new StringParser();

            return stringToMapParser.Parse(fileContent);
        }
    }
}
