namespace Intersection_model
{
    public class TrafficLight
    {
        private bibl.Color color;
        private int GreenTime;
        private int RedTime;
        private bool ROG; //Для правильной смены фазы после желтого, если true, то зеленый, иначе - красный

        public TrafficLight()
        {
            color = bibl.Color.GREEN;
            GreenTime = 0;
            RedTime = 0;
            ROG = true;
        }
        public TrafficLight(bibl.Color Color, int GT, int RT)
        {
            color = Color;
            GreenTime = GT;
            RedTime = RT;

            if (Color == bibl.Color.GREEN)
            {
                ROG = true;
            }
            else if (Color == bibl.Color.YELLOW)
            {
                Color = bibl.Color.GREEN;
                ROG = true;
            }
            else
            {
                ROG = false;
            }
        }
        public TrafficLight(ref TrafficLight TrafficLight)
        {
            color = TrafficLight.color;
            GreenTime = TrafficLight.GreenTime;
            RedTime = TrafficLight.RedTime;
            ROG = TrafficLight.ROG;
        }
        public bibl.Color getColor()
        {
            return color;
        }
        public int getGreenTime()
        {
            return GreenTime;
        }
        public int getRedTime()
        {
            return RedTime;
        }
        public bool GetROG()
        {
            return ROG;
        }
        public void changeColor()
        {
            if (color == bibl.Color.GREEN)
            {
                color = bibl.Color.YELLOW;
            }
            else if (color == bibl.Color.YELLOW)
            {
                if (ROG)
                {
                    ROG = !ROG;
                    color = bibl.Color.RED;
                }
                else
                {
                    ROG = !ROG;
                    color = bibl.Color.GREEN;
                }
            }
            else
            {
                color = bibl.Color.YELLOW;
            }
        }
        public void setColor(bibl.Color clr)
        {
            color = clr;
        }
        public void setGreenTime(int gt)
        {
            GreenTime = gt;
        }
        public void setRedTime(int rt)
        {
            RedTime = rt;
        }
    }
}
