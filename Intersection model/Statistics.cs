namespace Intersection_model
{
    public class Statistics
    {
        private int NumberOfCars;
        private int CarsLeftCrossRoad;
        private int RedPhases;
		private int GreenPhases;
		private int YellowPhases;
		private int ACar;
		private int Truck;

		public Statistics()
		{
			NumberOfCars = 0;
			CarsLeftCrossRoad = 0;
			RedPhases = 0;
			GreenPhases = 0;
			YellowPhases = 0;
			ACar = 0;
			Truck = 0;
		}
		public void PlusNumberOfCars()
		{
			NumberOfCars++;
		}
		public void PlusCarsLeftCrossRoad()
		{
			CarsLeftCrossRoad++;
		}
		public void PlusRed()
		{
			RedPhases++;
		}
		public void PlusGreen()
		{
			GreenPhases++;
		}
		public void PlusYellow()
		{
			YellowPhases++;
		}
		public void PlusACar()
		{
			ACar++;
		}
		public void PlusTruck()
		{
			Truck++;
		}
		public int getNumberOfCars()
		{
			return NumberOfCars;
		}
		public int getCarsLeftCrossRoad()
		{
			return CarsLeftCrossRoad;
		}
		public int getRedPhases()
		{
			return RedPhases;
		}
		public int getGreenPhases()
		{
			return GreenPhases;
		}
		public int getYellowPhases()
		{
			return YellowPhases;
		}
		public int getACar()
		{
			return ACar;
		}
		public int getTruck()
		{
			return Truck;
		}
		public void sClear()
		{
			NumberOfCars = 0;
			CarsLeftCrossRoad = 0;
			RedPhases = 0;
			GreenPhases = 0;
			YellowPhases = 0;
			ACar = 0;
			Truck = 0;
		}
	}
}
