using System;
using System.Threading;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PacManGame;

namespace PacManGameTests
{
    [TestFixture]
    public class GameTimerTest
    {

        [Test]
        public void GivenABoard3x4WithPacmanLookingUpAt1x2_When500msPass_ThenPacmanIsAt1x1()
        {
            //Arrange
            Board b = new Board(3, 4);
            ITimer gameTimer = new GameTimer(500);
            GameController gameController = new GameController(b, gameTimer);
            gameTimer.Start();

            //Act
            Thread.Sleep(TimeSpan.FromMilliseconds(600));

            // Assert
            b.PacMan.Position.Should().Be(new Position(1, 1));
        }


        [Test]
        public void GivenABoardTickableAndAGameController_WhenTimerElapsed_ThenATickIsCalled()
        {
            //Arrange
            ITickable boardMock = Mock.Of<ITickable>();
            ITimer timerMock = Mock.Of<ITimer>();
            GameController gameController = new GameController(boardMock, timerMock);

            //Act
            Mock.Get(timerMock).Raise(t => t.Elapsed += null, new EventArgs());

            //Assert
            Mock.Get(boardMock).Verify(b => b.Tick(), Times.Once);
        }
    }
}