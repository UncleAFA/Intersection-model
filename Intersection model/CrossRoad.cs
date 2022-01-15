using System;
using System.Collections.Generic;

namespace Intersection_model
{
    public class CrossRoad
    {
        public Random rnd = new Random();
        private Statistics stat = new Statistics();
        private int Time;
        private TrafficLight TraficLight;
        private List<Road> crossRoad = new List<Road>();

        public CrossRoad(TrafficLight nTrafficLight, bibl.Load firstLd, bibl.Load secondLd, bibl.Load thirdLd, bibl.Load fourthLd, int time, int UpperLowerBandwidth, int RightLeftBandwidth)
        {
            TraficLight = nTrafficLight;
            Time = time;
            crossRoad.Add(new Road(firstLd, UpperLowerBandwidth));
            crossRoad.Add(new Road(secondLd, UpperLowerBandwidth));
            crossRoad.Add(new Road(thirdLd, RightLeftBandwidth));
            crossRoad.Add(new Road(fourthLd, RightLeftBandwidth));


        }
        public Statistics revive()//запуск программы
        {
            int time = Time;
            int green = TraficLight.getGreenTime();
            int red = TraficLight.getRedTime();

            if (TraficLight.GetROG())
            {
                while (time > 0)
                {
                    time -= green;
                    for (int i = 0; i < green; i++)
                    {
                        greenAction();
                    }
                    stat.PlusGreen();
                    if (time <= 0)
                        return stat;
                    TraficLight.changeColor();

                    time -= 1;
                    yellowAction();
                    stat.PlusYellow();
                    if (time <= 0)
                        return stat;
                    TraficLight.changeColor();

                    time -= red;
                    for (int i = 0; i < green; i++)
                    {
                        redAction();
                    }
                    stat.PlusRed();
                    if (time <= 0)
                        return stat;
                    TraficLight.changeColor();

                    time -= 1;
                    yellowAction();
                    stat.PlusYellow();
                    if (time <= 0)
                        return stat;
                    TraficLight.changeColor();
                }
            }
            else
            {
                while (time > 0)
                {
                    time -= red;
                    for (int i = 0; i < green; i++)
                    {
                        redAction();
                    }
                    stat.PlusRed();
                    if (time <= 0)
                        return stat;
                    TraficLight.changeColor();

                    time -= 1;
                    yellowAction();
                    stat.PlusYellow();
                    if (time <= 0)
                        return stat;
                    TraficLight.changeColor();

                    time -= green;
                    for (int i = 0; i < green; i++)
                    {
                        greenAction();
                    }
                    stat.PlusGreen();
                    if (time <= 0)
                        return stat;
                    TraficLight.changeColor();

                    time -= 1;
                    yellowAction();
                    stat.PlusYellow();
                    if (time <= 0)
                        return stat;
                    TraficLight.changeColor();
                }
            }

            return stat;
        }
        //Действия для разных фаз цветов 
        public void greenAction()
        {
            for (int i = 0; i < 4; i++)
            {
                bibl.Load tmp = crossRoad[i].getLoad();
                if (tmp == bibl.Load.LOW)
                {
                    if (rnd.Next(3, 10) > 3)
                    {
                        crossRoad[i].addCar(stat);
                    }
                }
                else if (tmp == bibl.Load.HIGH)
                {
                    if (rnd.Next(1, 10) > 1)
                    {
                        crossRoad[i].addCar(stat);
                    }
                }
                else
                {
                    if (rnd.Next(1, 10) > 2)
                    {
                        crossRoad[i].addCar(stat);
                    }
                }
            }

            for (int i = 0; i < crossRoad[0].getBandwidth(); i++)
            {
                bool flag = true;
                if (crossRoad[0].isLeftOrBack())
                {
                    for (int j = 0; j < crossRoad[0].count(); j++)
                    {
                        if (flag)
                        {
                            if (crossRoad[1].isEmpty())
                            {
                                crossRoad[0].deleteCar(stat, j);
                                flag = !flag;
                            }
                            else if (crossRoad[1].isLeftOrBack())
                            {
                                crossRoad[0].deleteCar(stat, j);
                                flag = !flag;
                            }
                        }
                    }
                }
                else
                {
                    crossRoad[0].deleteCar(stat, 0);
                }

                flag = true;
                if (crossRoad[1].isLeftOrBack())
                {
                    for (int j = 0; j < crossRoad[1].count(); j++)
                    {
                        if (flag)
                        {
                            if (crossRoad[0].isEmpty())
                            {
                                crossRoad[1].deleteCar(stat, j);
                                flag = !flag;
                            }
                            else if (crossRoad[0].isLeftOrBack())
                            {
                                crossRoad[1].deleteCar(stat, j);
                                flag = !flag;
                            }
                        }
                    }
                }
                else
                {
                    crossRoad[1].deleteCar(stat, 0);
                }
            }
        }
        public void redAction()
        {

            for (int i = 0; i < 4; i++)
            {
                bibl.Load tmp = crossRoad[i].getLoad();
                if (tmp == bibl.Load.LOW)
                {
                    if (rnd.Next(1, 10) > 3)
                    {
                        crossRoad[i].addCar(stat);
                    }
                }
                else if (tmp == bibl.Load.HIGH)
                {
                    if (rnd.Next(1, 10) > 1)
                    {
                        crossRoad[i].addCar(stat);
                    }
                }
                else
                {
                    if (rnd.Next(1, 10) > 2)
                    {
                        crossRoad[i].addCar(stat);
                    }
                }
            }

            for (int i = 0; i < crossRoad[2].getBandwidth(); i++)
            {
                bool flag = true;
                if (crossRoad[2].isLeftOrBack())
                {
                    for (int j = 0; j < crossRoad[2].count(); j++)
                    {
                        if (flag)
                        {
                            if (crossRoad[3].isEmpty())
                            {
                                crossRoad[2].deleteCar(stat, j);
                                flag = !flag;
                            }
                            else if (crossRoad[3].isLeftOrBack())
                            {
                                crossRoad[2].deleteCar(stat, j);
                                flag = !flag;
                            }
                        }
                    }
                }
                else
                {
                    crossRoad[2].deleteCar(stat, 0);
                }

                flag = true;
                if (crossRoad[3].isLeftOrBack())
                {
                    for (int j = 0; j < crossRoad[3].count(); j++)
                    {
                        if (flag)
                        {
                            if (crossRoad[2].isEmpty())
                            {
                                crossRoad[3].deleteCar(stat, j);
                                flag = !flag;
                            }
                            else if (crossRoad[2].isLeftOrBack())
                            {
                                crossRoad[3].deleteCar(stat, j);
                                flag = !flag;
                            }
                        }
                    }
                }
                else
                {
                    crossRoad[3].deleteCar(stat, 0);
                }
            }
        }
        public void yellowAction()
        {
            for (int i = 0; i < 4; i++)
            {
                bibl.Load tmp = crossRoad[i].getLoad();
                if (tmp == bibl.Load.LOW)
                {
                    if (rnd.Next(1, 10) > 3)
                    {
                        crossRoad[i].addCar(stat);
                    }
                }
                else if (tmp == bibl.Load.HIGH)
                {
                    if (rnd.Next(1, 10) > 1)
                    {
                        crossRoad[i].addCar(stat);
                    }
                }
                else
                {
                    if (rnd.Next(1, 10) > 2)
                    {
                        crossRoad[i].addCar(stat);
                    }
                }
            }
        }
        public int getTime()
        {
            return Time;
        }
        public void setTime(int time)
        {
            Time = time;
        }
        public string getLoad(int r)
        {
            if (crossRoad[r].getLoad() == bibl.Load.HIGH)
            {
                return "HIGH";
            }
            else if (crossRoad[r].getLoad() == bibl.Load.LOW)
            {
                return "LOW";
            }
            return "MEDIUM";
        }
        public void setLoad(bibl.Load nLoad, int r)
        {
            crossRoad[r].setLoad(nLoad);
        }
        public void setTL(TrafficLight tl)
        {
            TraficLight = tl;
        }
        public int getRed()
        {
            return TraficLight.getRedTime();
        }
        public int getGreen()
        {
            return TraficLight.getGreenTime();
        }
        public string getColor()
        {
            if (TraficLight.getColor() == bibl.Color.GREEN)
            {
                return "Green";
            }
            else if (TraficLight.getColor() == bibl.Color.RED)
            {
                return "Red";
            }
            return "Yellow";
        }
        public void clearS()
        {
            stat.sClear();
        }
        public void setBandwidth(int bw, int index)
        {
            crossRoad[index].setBandwidth(bw);
        }

    }
}
