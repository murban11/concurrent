using Data;
using Logic;
using NPOI.POIFS.Crypt.Dsig;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Model
{

    internal class ModelAPI : AbstractModelAPI
    {
        private AbstractLogicAPI logicAPI;
        public List<Task> tasks { get; set; } = new List<Task>();
        private readonly int TimeInterval = 10; // (in ms)


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
                addTask(i);
            }
            Simulate(numberOfBalls);
        }

        public override IBallModel GetBallModel(int id)
        {
            return Balls[id];
        }

        public override void Simulate(int numberOfBalls)
        {
            foreach (Task task in tasks)
            {
                task.Start();
            }
        }

        private void addTask(int index)
        {
            tasks.Add(new Task(() =>
            {
                while (true)
                {
                    Balls[index].Move(logicAPI.GetBallCoordinates(index).X, logicAPI.GetBallCoordinates(index).Y);
                    Thread.Sleep(TimeInterval);
                }
            }));
        }

    }
}

