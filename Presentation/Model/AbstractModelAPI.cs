using Logic;

namespace Model
{
    public abstract class AbstractModelAPI : IObserver<int>, IObservable<IBallModel>
    {
        public List<IBallModel> Balls { get; set; }

        public abstract void Start(int numberOfBalls);

        public abstract IBallModel GetBallModel(int id);

        public static AbstractModelAPI CreateAPI()
        {
            return new ModelAPI(AbstractLogicAPI.CreateLogicAPI(null));
        }

        public abstract void OnCompleted();
        public abstract void OnError(Exception error);
        public abstract void OnNext(int value);
        public abstract IDisposable Subscribe(IObserver<IBallModel> observer);
    }
}
