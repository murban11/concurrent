using Logic;

namespace Model
{
    internal class ModelAPI : AbstractModelAPI
    {
        private AbstractLogicAPI logicAPI;
        private Timer timer;


        public ModelAPI(AbstractLogicAPI logicAPI)
        {
            this.logicAPI = logicAPI;
            Balls = new List<IBallModel> ();
        }


        public override void Start(int numberOfBalls)
        {
            logicAPI.Start(numberOfBalls);
            for (int i = 0; i < numberOfBalls; i++)
            {
                Balls.Add(new BallModel(logicAPI.GetBallCoordinates(i).X, logicAPI.GetBallCoordinates(i).Y, logicAPI.GetBallRadius(i)));
            }
            Simulate();
        }

        public override IBallModel GetBallModel(int id)
        {
            return Balls[id];
        }

        public override void Simulate()
        {
            timer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(10));
        }

        public override void Move(object state)
        {

            logicAPI.Move();
            for (int i = 0; i < Balls.Count; i++)
            {
                Balls[i].Move(logicAPI.GetBallCoordinates(i).X, logicAPI.GetBallCoordinates(i).Y);
            }
        }

    }
}

