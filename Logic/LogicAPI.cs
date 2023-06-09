﻿using Data;
using Org.BouncyCastle.Asn1.X509;
using System.Numerics;

namespace Logic
{
    internal class LogicAPI : AbstractLogicAPI
    {
        private readonly AbstractDataAPI dataAPI;
        private BallLogic logic;
        private List<IBall> balls;
        private IObserver<int> observer = null;
        private readonly object _gate = new object();


        public LogicAPI(AbstractDataAPI dataAPI)
        {
            this.dataAPI = dataAPI;
        }

        public override void Start(int ballsNumber)
        {
            bool loop;
            balls = new List<IBall>();
            logic = new BallLogic();
            for (int i = 0; i < ballsNumber; i++)
            {
                IBall ball;
                do
                {
                    loop = false;
                    Random rand = new();
                    Vector2 initialPosition = new((float)(rand.NextDouble() * (dataAPI.GetBoardWidth() - 2 * 10) + 10.1F),
                        (float)(rand.NextDouble() * (dataAPI.GetBoardWidth() - 2 * 10) + 10.1F));
                    Vector2 initialDirection = new((float)(rand.NextDouble() * 2), (float)(rand.NextDouble() * 2));
                    ball = IBall.CreateBall(i, initialPosition, 10, 2, initialDirection);
                    for (int j = 0; j < i; j++)
                    {
                        if (logic.checkBallCollision(ball, balls[j]))
                        {
                            loop = true;
                            break;
                        }
                    }
                } while (loop == true);
                ball.Subscribe(this);
                balls.Add(ball);
            }
        }
        public override void Exit()
        {
            for (int i = 0; i < balls.Count(); i++)
            {
                balls[i].IsRunning = false;
            }
            dataAPI.Exit();
        }
        public override Vector2 GetBallCoordinates(int id)
        {
            return balls[id].Coordinates;
        }
        public override Vector2 GetBallDirectionVector(int id)
        {
            return balls[id].DirectionVector;
        }
        public override int GetBoxWidth()
        {
            return dataAPI.GetBoardWidth();
        }

        public override int GetBoxHeight()
        {
            return dataAPI.GetBoardHeight();
        }

        public override double GetBallRadius(int id)
        {
            return balls[id].Radius;
        }

        public override int GetBallNumber()
        {
            return balls.Count();
        }

        public override List<IBall> GetBalls()
        {
            return balls;
        }

        public override void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public override void OnNext(IBall ball)
        {
            lock(_gate)
            {
                dataAPI.appendToLoggingQueue(ball);
                int ballCount = balls.Count();
                int index = -1;

                for (int i = 0; i < ballCount; i++)
                {
                    IBall other = balls[i];

                    if (ball == other)
                    {
                        index = i;
                        continue;
                    }
                    if (logic.checkBallCollision(ball, other))
                    {
                        Vector2 tmp = ball.DirectionVector;
                        ball.changeDirectionVector(other.DirectionVector);
                        other.changeDirectionVector(tmp);
                        observer.OnNext(i);
                    }
                    logic.checkCollisions(ball, dataAPI.GetBoard());
                }
                observer.OnNext(index);
            }   
        }

        public override IDisposable Subscribe(IObserver<int> observer)
        {
            this.observer = observer;
            return new Unsubscriber(this.observer);
        }

        private class Unsubscriber : IDisposable
        {
            private IObserver<int> _observer;

            public Unsubscriber(IObserver<int> observer)
            {
                _observer = observer;
            }

            public void Dispose()
            {
                _observer = null;
            }
        }
    }
}
