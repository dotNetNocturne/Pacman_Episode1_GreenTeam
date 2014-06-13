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
            FakeTimer timer = new FakeTimer();
            GameController gameController = new GameController(boardMock, timer);

            //Act
            timer.OnElapsed();

            //Assert
            Mock.Get(boardMock).Verify(b => b.Tick(), Times.Once);
        }

    }


    public class FakeTimer : ITimer
    {
        public event EventHandler Elapsed;

        public void OnElapsed()
        {
            if (Elapsed != null)
            {
                Elapsed(this, new EventArgs());
            }
        }
    }
}