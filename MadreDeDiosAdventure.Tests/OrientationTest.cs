using Xunit;
using FluentAssertions;

namespace MadreDeDiosAdventure.Tests
{
    public class OrientationTest
    {
        #region Right
        [Fact]
        public void Right_of_North_should_be_Est()
        {
            // Given :
            Orientation north = Orientation.North;

            // When :
            Orientation est = north.Right();

            est.Should().Be(Orientation.Est);
        }

        [Fact]
        public void Right_of_Est_should_be_South()
        {
            // Given :
            Orientation est = Orientation.Est;

            // When :
            Orientation south = est.Right();

            south.Should().Be(Orientation.South);
        }

        [Fact]
        public void Right_of_South_should_be_West()
        {
            // Given :
            Orientation south = Orientation.South;

            // When :
            Orientation west = south.Right();

            west.Should().Be(Orientation.West);
        }

        [Fact]
        public void Right_of_West_should_be_North()
        {
            // Given :
            Orientation west = Orientation.West;

            // When :
            Orientation north = west.Right();

            north.Should().Be(Orientation.North);
        }
        #endregion

        #region Left
        [Fact]
        public void Left_of_North_should_be_West()
        {
            // Given :
            Orientation north = Orientation.North;

            // When :
            Orientation west = north.Left();

            west.Should().Be(Orientation.West);
        }

        [Fact]
        public void Left_of_West_should_be_South()
        {
            // Given :
            Orientation west = Orientation.West;

            // When :
            Orientation south = west.Left();

            south.Should().Be(Orientation.South);
        }

        [Fact]
        public void Left_of_South_should_be_Est()
        {
            // Given :
            Orientation south = Orientation.South;

            // When :
            Orientation est = south.Left();

            est.Should().Be(Orientation.Est);
        }

        [Fact]
        public void Left_of_Est_should_be_North()
        {
            // Given :
            Orientation Est = Orientation.Est;

            // When :
            Orientation north = Est.Left();

            north.Should().Be(Orientation.North);
        }
        #endregion
    }
}
