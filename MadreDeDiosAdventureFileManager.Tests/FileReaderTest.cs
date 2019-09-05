using FluentAssertions;
using System;
using Xunit;

namespace MadreDeDiosAdventureFileManager.Tests
{
    public class FileReaderTest
    {
        [Fact]
        public void Should_read_input_file()
        {
            // Given :
            string inputFileName = "dummyTestFile.txt";
            var fileReader = new FileReader(inputFileName);

            // When :
            string fileContent = fileReader.Read();

            // Then :
            fileContent.Should().NotBeNullOrEmpty();
        }
    }
}
