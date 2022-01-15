using System;
using System.Collections.Generic;

namespace Intersection_model
{
    public class Road
    {
        public Random rnd = new Random();
        private List<Car> CarQueue = new List<Car>();
        private int Bandwidth;
        private bibl.Load load;

        public Road(bibl.Load load, int bw)
        {
            this.load = load;
            Bandwidth = bw;
        }
        public void addCar(Statistics stat)
        {
            if (rnd.Next(1, 10) > 8)
            {
                CarQueue.Add(new Truck());
                stat.PlusTruck();
            }
            else
            {
                CarQueue.Add(new ACar());
                stat.PlusACar();
            }
            stat.PlusNumberOfCars();
        }
        public void deleteCar(Statistics stat, int index)
        {
            if ((CarQueue.Count > 0))
            {
                if (stat.getCarsLeftCrossRoad() != stat.getNumberOfCars())
                {
                    stat.PlusCarsLeftCrossRoad();
                }
                // TODO Понять что делать с это функцией и понять какой тип использовать (vector или List )
                // CarQueue.RemoveAt(CarQueue.FindIndex(0)+ index);
                CarQueue.RemoveAt(index);//временная заглушка
            }
        }
        public bool isEmpty()
        {
            if (CarQueue.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool isLeftOrBack()
        {
            if ((CarQueue.Count > 0))
            {
                bibl.Direction direction = CarQueue[0].getDirection();
                if (direction == bibl.Direction.LEFT || direction == bibl.Direction.BACK)
                {
                    return true;
                }
            }
            return false;
        }
        public int count()
        {
            return CarQueue.Count;
        }
        public bibl.CarType getCarType()
        {
            return CarQueue[1].getType();
        }
        public bibl.Load getLoad()
        {
            return load;
        }
        public void setLoad(bibl.Load ld)
        {
            load = ld;
        }
        public int getBandwidth()
        {
            return Bandwidth;
        }
        public void setBandwidth(int bw)
        {
            Bandwidth = bw;
        }
    }
}
