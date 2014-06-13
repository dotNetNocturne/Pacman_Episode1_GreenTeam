using FluentAssertions;
using NUnit.Framework;
using PacManGame;

namespace PacManGameTests
{
    [TestFixture]
    public class PacmanOrientationTest
    {
        [Test]
        public void GivenABoard_WithWidth3AndHeight4_ThenPacmanLooksUp()
        {
            //Arrange
            Board b = new Board(3, 4);

            //Act
            Orientation orientation = b.PacMan.Orientation;

            //Assert
            orientation.Should().Be(Orientation.Up);

        }

        [TestCase(Orientation.Left)]
        [TestCase(Orientation.Right)]
        [TestCase(Orientation.Down)]
        [TestCase(Orientation.Up)]
        public void GivenABoardWithPacmanLookingUp_WhenPlayerChangesDirection_ThenPacmanHasThatDirection(
            Orientation orientation)
        {
            //Arrange
            Board b = new Board(3, 4);

            //Act
            b.PacMan.Turn(orientation);

            //Assert
            b.PacMan.Orientation.Should().Be(orientation);

        }
    }
}