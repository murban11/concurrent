using Data;
using Logic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public List<BallModel> Balls { get; set; }

        public abstract void Start(int numberOfBalls);

        public abstract BallModel GetBallModel(int id);

        public abstract void Simulate();

        public static ModelAbstractAPI CreateAPI()
        { 
            return new ModelAPI(AbstractLogicAPI.CreateLogicAPI()); 
        }

        public abstract void Move(object state);
        
    }
    internal class ModelAPI : ModelAbstractAPI
    {
        private AbstractLogicAPI logicAPI;
        private Timer timer;


        public ModelAPI(AbstractLogicAPI logicAPI)
        {
            this.logicAPI = logicAPI;
            Balls = new List<BallModel> ();
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

        public override BallModel GetBallModel(int id)
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

