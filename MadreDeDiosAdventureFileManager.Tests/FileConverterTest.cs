using FluentAssertions;
using MadreDeDiosAdventure;
using NSubstitute;
using Xunit;

namespace MadreDeDiosAdventureFileManager.Tests
{
    public class FileConverterTest
    {
        [Fact]
        public void Should_call_file_reader()
        {
            // Given :
            var fileReader = Substitute.For<IFileReader>();
            var contentParser = Substitute.For<IContentParser>();
            var fileConverter = new FileConverter(fileReader, contentParser);

            // When :
            Map map = fileConverter.Convert();

            // Then :
            fileReader.Received().Read();
        }

        [Fact]
        public void Should_call_content_parser()
        {
            // Given :
            string dummyFileContent = "test string";
            var fileReader = Substitute.For<IFileReader>();
            fileReader.Read().Returns(dummyFileContent);
            var contentParser = Substitute.For<IContentParser>();
            var fileConverter = new FileConverter(fileReader, contentParser);

            // When :
            Map map = fileConverter.Convert();

            // Then :
            contentParser.Received().Parse(dummyFileContent);
        }
    }
}
