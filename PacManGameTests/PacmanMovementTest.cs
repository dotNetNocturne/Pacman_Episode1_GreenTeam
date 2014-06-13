using System;
using FluentAssertions;
using NUnit.Framework;
using PacManGame;

namespace PacManGameTests
{
    [TestFixture]
    public class PacmanMovementTest
    {
        [TestCase(Orientation.Up, 1, 1)]
        [TestCase(Orientation.Down, 1, 3)]
        [TestCase(Orientation.Left, 0, 2)]
        [TestCase(Orientation.Right, 2, 2)]
        public void GivenABoard3x4WithPacmanAt1x2_WhenPlayerSendsTurnAndTickHappens_ThenPacmanIsAtProperPosition(Orientation orientation, int col, int row)
        {
            //Arrange
            var b = new Board(3, 4);

            //Act
            b.PacMan.Turn(orientation);
            b.Tick();

            //Assert
            b.PacMan.Position.Should().Be(new Position(col, row));
        }

        [Test]
        public void GivenABoard3x4WithPacmanAt1x2_WhenATickHappens_ThenPacmanIsAt1x1()
        {
            //Arrange
            var b = new Board(3, 4);

            //Act
            b.Tick();

            //Assert
            b.PacMan.Position.Should().Be(new Position(1, 1));
        }

      //  [TestCase(new Position(1,0), Orientation.Up, new Position(1,3)]
        private object[] WrapAroundData = new[]
        {
            new Object[] {new Position(1, 0), Orientation.Up, new Position(1, 3)}  ,
            new Object[] {new Position(1, 3), Orientation.Down, new Position(1, 0)}  ,
            new Object[] {new Position(0, 2), Orientation.Left, new Position(2, 2)}  ,
            new Object[] {new Position(2, 2), Orientation.Right, new Position(0, 2)}  ,
        };

        [TestCaseSource("WrapAroundData")]
        public void GivenABoard3x4WithPacmanLookingUpAt1x0_WhenATickHappens_ThenPacmanIsAt1x3(
            Position position,Orientation orientation, Position expectedPosition)
        {
            //Arrange
            var b = new Board(3, 4);
            b.PacMan.Position = position;
            b.PacMan.Turn(orientation);

            //Act
            b.Tick();

            //Assert
            b.PacMan.Position.Should().Be(expectedPosition);  
        } 
    }
}