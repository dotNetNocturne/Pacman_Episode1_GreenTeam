using System;
using FluentAssertions;
using NUnit.Framework;
using PacManGame;

namespace PacManGameTests
{

    [TestFixture]
    public class BoardInitializationPacmanInMiddleTest
    {
        [Test]
        public void GivenABoard_WithWidth3AndHeight4_ThenPacManIsAt1x2()
        {
            //Arrange
            Board b = new Board(3, 4);

            //Act
            Position p = b.PacMan.Position;

            //assert
            p.Should().Be(new Position(1, 2));
        }


        [Test]
        public void GivenABoard_WithWidth6AndHeight6_ThenPacmanIsAt3x3()
        {
            //Arrange
            Board b = new Board(6, 6);

            //Act
            Position p = b.PacMan.Position;

            //assert
            p.Should().Be(new Position(3, 3));
        }

    }
}
