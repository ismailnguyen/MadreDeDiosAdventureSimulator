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
            var fileConverter = new FileConverter(fileReader);

            // When :
            Map map = fileConverter.Convert();

            // Then :
            fileReader.Received().Read();
        }

        [Fact]
        public void Should_convert_file_content_to_MadreDeDios_map()
        {
            // Given :
            var fileReader = Substitute.For<IFileReader>();
            var fileConverter = new FileConverter(fileReader);

            // When :
            Map map = fileConverter.Convert();

            // Then :
            map.Should().NotBeNull();
        }
    }
}
