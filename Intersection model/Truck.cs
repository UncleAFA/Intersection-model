using System;
using static Intersection_model.bibl;

namespace Intersection_model
{
    public class Truck : Car
    {
        public Random rnd = new Random();
        private Direction direction;

        public Truck()
        {
            int r = rnd.Next(1, 10);
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
        public Truck(ref Truck truck)
        {
            direction = truck.direction;
        }
        public override Direction getDirection()
        {
            return direction;
        }

        public override CarType getType()
        {
            return CarType.Truck;
        }
    }
}
