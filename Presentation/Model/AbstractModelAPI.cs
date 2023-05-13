using Logic;

namespace Model
{
    public abstract class AbstractModelAPI
    {
        public List<IBallModel> Balls { get; set; }

        public abstract void Start(int numberOfBalls);

        public abstract IBallModel GetBallModel(int id);

        public abstract void Simulate(int numberOfBalls);


        public static AbstractModelAPI CreateAPI()
        {
            return new ModelAPI(AbstractLogicAPI.CreateLogicAPI(null));
        }


    }
}
