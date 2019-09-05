using FluentAssertions;
using MadreDeDiosAdventure;
using NSubstitute;
using Xunit;

namespace MadreDeDiosAdventureFileManager.Tests
{
    public class StringMapperTest
    {
        [Fact]
        public void Should_convert_string_to_MadreDeDios_map()
        {
            // Given :
            string content = "";
            var stringMapper = new StringMapper(content);

            // When :
            Map map = stringMapper.Map();

            // Then :
            map.Should().NotBeNull();
        }

        //[Fact]
        //public void Should_convert_file_content_to_MadreDeDios_map()
        //{
        //    // Given :
        //    var fileReader = Substitute.For<IFileReader>();
        //    var fileConverter = new FileConverter(fileReader);

        //    // When :
        //    Map map = fileConverter.Convert();

        //    // Then :
        //    map.Should().NotBeNull();
        //}
    }
}
