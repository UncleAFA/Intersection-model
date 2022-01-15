using System;
using static Intersection_model.bibl;

namespace Intersection_model
{
    public class ACar : Car
    {
        public Random rnd = new Random();
        private readonly Direction direction;

        public ACar()
        {
            int r = rnd.Next(1, 10); //в 1 из 10 случаев машина развернется, в двух повернет налево, остальные поровну делятся между прямо и направо
            if (r == 1)
            {
                direction = Direction.BACK;
            }
            else if (r < 3)
            {
                direction = Direction.LEFT;
            }
            else if (r < 8)
            {
                direction = Direction.STRAIGHT;
            }
            else
            {
                direction = Direction.RIGHT;
            }
        }
        public ACar(ref ACar car)
        {
            direction = car.direction;
        }
        public override Direction getDirection()
        {
            return direction;
        }

        public override CarType getType()
        {
            return CarType.ACar;
        }
    }
}
