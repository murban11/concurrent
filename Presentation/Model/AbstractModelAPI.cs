using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class AbstractModelAPI
    {
        public List<IBallModel> Balls { get; set; }

        public abstract void Start(int numberOfBalls);

        public abstract IBallModel GetBallModel(int id);

        public abstract void Simulate(int numberOfBalls);

        public abstract void Move(object state);

        public static AbstractModelAPI CreateAPI()
        {
            return new ModelAPI(AbstractLogicAPI.CreateLogicAPI());
        }


    }
}
