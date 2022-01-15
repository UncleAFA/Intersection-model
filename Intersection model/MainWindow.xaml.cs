using System;
using System.Collections.Generic;
using System.Windows;
using static Intersection_model.bibl;

namespace Intersection_model
{
    public class PrintResult
    {
        public int PrintNumberColom { get; set; }
        public int PrintNumberOfCars { get; set; }
        public int PrintCarsLeftCrossRoad { get; set; }
        public int PrintRedPhases { get; set; }
        public int PrintGreenPhases { get; set; }
        public int PrintYellowPhases { get; set; }
        public int PrintACar { get; set; }
        public int PrintTruck { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<PrintResult> ResultList = new List<PrintResult>();
        public static int NumberLine = 1;
        public MainWindow()
        {
            InitializeComponent();
        }
        private Load ReternLoadChoos(string choos)
        {
            Load val;
            if (choos == "Низкая")
            {
                val = Load.LOW;
            }
            else if (choos == "Средняя")
            {
                val = Load.MEDIUM;
            }
            else
            {
                val = Load.HIGH;
            }
            return val;
        }
        private bibl.Color ReternColorChoos(string choos)
        {
            bibl.Color val;
            if (choos == "Зеленый")
            {
                val = bibl.Color.GREEN;
            }
            else if (choos == "Красный")
            {
                val = bibl.Color.RED;
            }
            else
            {
                val = bibl.Color.YELLOW;
            }
            return val;
        }
        private void StartProgram(string up, string lower, string right, string left, string color , string upperLowerText, string rightLeftText, string Time, string Green, string Red)
        {
            bibl.Color cColor = ReternColorChoos(color);
            Load upperLoad = ReternLoadChoos(up);
            Load lowerLoad = ReternLoadChoos(lower);
            Load rightLoad = ReternLoadChoos(right);
            Load leftLoad = ReternLoadChoos(left);
            int upperLowerBandwidth = Convert.ToInt32(upperLowerText);
            int rightLeftBandwidth = Convert.ToInt32(rightLeftText);
            int cTime = Convert.ToInt32(Time);
            int cRed = Convert.ToInt32(Red);
            int cGreen = Convert.ToInt32(Green);
            Statistics result;
            TrafficLight trafficLight = new TrafficLight(cColor, cGreen, cRed);
            CrossRoad crossRoad = new CrossRoad(trafficLight, upperLoad, upperLoad, upperLoad, upperLoad, cTime, upperLowerBandwidth, rightLeftBandwidth);
            crossRoad.clearS();
            trafficLight.setColor(cColor);
            trafficLight.setGreenTime(cGreen);
            trafficLight.setRedTime(cRed);

            crossRoad.setBandwidth(upperLowerBandwidth, 0);
            crossRoad.setBandwidth(upperLowerBandwidth, 1);
            crossRoad.setBandwidth(rightLeftBandwidth, 2);
            crossRoad.setBandwidth(rightLeftBandwidth, 3);

            crossRoad.setLoad(upperLoad, 0);
            crossRoad.setLoad(lowerLoad, 1);
            crossRoad.setLoad(rightLoad, 2);
            crossRoad.setLoad(leftLoad, 3);

            crossRoad.setTL(trafficLight);
            crossRoad.setTime(cTime);
            result = crossRoad.revive();

            //TextBox txtBox = new TextBox();
            //txtBox.Text = $"{NumberLine}) Количество машин: {result.getNumberOfCars()} Количество машин проехавших через перекресток: {result.getCarsLeftCrossRoad()}{NumberLine}) Количество машин: {result.getNumberOfCars()} Количество машин проехавших через перекресток: {result.getCarsLeftCrossRoad()}";
            //MainScrollViewer.Children.Add(txtBox);//все остальные элементы добавляются по аналогии.Cheldren.Add(txtBox);//все остальные элементы добавляются по аналогии
            //NumberLine++;
            ResultList.Add(new PrintResult() { PrintNumberColom = NumberLine , PrintNumberOfCars = result.getNumberOfCars(), PrintCarsLeftCrossRoad = result.getCarsLeftCrossRoad(), PrintGreenPhases = result.getGreenPhases(), PrintRedPhases = result.getRedPhases(), PrintYellowPhases = result.getYellowPhases(), PrintACar = result.getACar(), PrintTruck = result.getTruck()});
            gridProducts.ItemsSource = null;
            gridProducts.ItemsSource = ResultList;
            NumberLine++;
        }
        private bool ChecCorect(string input)
        {
            try
            {
                int t = Convert.ToInt32(input);

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        
        }
        private void ErrorCorectFirstLine(string up, string lower, string right, string left, string color)
        {
            if (up == "")
            {
                MessageBox.Show("Выберите нагрузку на верхней дороге");
            }
            else if (lower == "")
            {
                MessageBox.Show("Выберите нагрузку на нижней дороге");
            }
            else if (left == "")
            {
                MessageBox.Show("Выберите нагрузку на левой дороге");
            }
            else if (right == "")
            {
                MessageBox.Show("Выберите нагрузку на правой дороге");
            }
            else if(color == "")
            {
                MessageBox.Show("Выберите цвет старта для верхней/нижней дороги");
            }
        }
        private void ErrorCorectSecondLine(string upperLowerText, string rightLeftText, string Time, string Green, string Red)
        {
            if (!ChecCorect(upperLowerText) )
            {
                MessageBox.Show("Пропускная способность врхней/нижней дороги должна быть заполнена целым числом больше нуля");
            }
            else if (Convert.ToInt32(upperLowerText) <= 0)
            {
                MessageBox.Show("Пропускная способность врхней/нижней дороги должна быть заполнена целым числом больше нуля");
            }
            else if (!ChecCorect(rightLeftText))
            {
                MessageBox.Show("Пропускная способность правой/левой дороги должна быть заполнена целым числом больше нуля");
            }
            else if (Convert.ToInt32(rightLeftText) <= 0)
            {
                MessageBox.Show("Пропускная способность правой/левой дороги должна быть заполнена целым числом больше нуля");
            }
            else if (!ChecCorect(Time))
            {
                MessageBox.Show("Время моделирования должно быть заполнена целым числом больше нуля");
            }
            else if (Convert.ToInt32(Time) <= 0)
            {
                MessageBox.Show("Время моделирования должно быть заполнена целым числом больше нуля");
            }
            else if (!ChecCorect(Green))
            {
                MessageBox.Show("Длина зеленой фазы должно быть заполнена целым числом больше нуля");
            }
            else if (Convert.ToInt32(Green) <= 0)
            {
                MessageBox.Show("Длина зеленой фазы должно быть заполнена целым числом больше нуля");
            }
            else if (Convert.ToInt32(Time) <= Convert.ToInt32(Green))
            {
                MessageBox.Show("Длина зеленой фазы должно быть меньше времени моделирования");
            }
            else if (!ChecCorect(Red))
            {
                MessageBox.Show("Длина красной фазы должно быть заполнена целым числом больше нуля");
            }
            else if (Convert.ToInt32(Red) <= 0)
            {
                MessageBox.Show("Длина красной фазы должно быть заполнена целым числом больше нуля");
            }
            else if(Convert.ToInt32(Time) < Convert.ToInt32(Red))
            {
                MessageBox.Show("Длина красной фазы должно быть меньше времени моделирования");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string up = upperLoadChoos.Text.ToString();
            string lower = lowerLoadChoos.Text.ToString();
            string right = rightLoadChoos.Text.ToString();
            string left = leftLoadChoos.Text.ToString();
            string color = cColorChoos.Text.ToString();

            string upperLowerText = upperLowerBandwidthChoos.Text.ToString();
            string rightLeftText = rightLeftBandwidthChoos.Text.ToString();
            string Time = cTimeChoos.Text.ToString();
            string Green = cGreenChoos.Text.ToString();
            string Red = cRedChoos.Text.ToString();
            if ((up == "") | (lower == "") | (right == "") | (left == "") | (color == ""))
            {
                ErrorCorectFirstLine(up, lower, right, left, color);
            }
            else if (!ChecCorect(upperLowerText) | !ChecCorect(rightLeftText) | !ChecCorect(Time) | !ChecCorect(Green) | !ChecCorect(Red) )
            {

                ErrorCorectSecondLine(upperLowerText, rightLeftText, Time, Green, Red);
            }else if ((Convert.ToInt32(upperLowerText) <= 0) | (Convert.ToInt32(rightLeftText) <= 0) | (Convert.ToInt32(Time) <= 0) | (Convert.ToInt32(Green) <= 0) | (Convert.ToInt32(Red) <= 0))
            {
                ErrorCorectSecondLine(upperLowerText, rightLeftText, Time, Green, Red);
            }
            else
            {
                StartProgram(up, lower, right, left, color, upperLowerText, rightLeftText, Time, Green, Red);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Обозначения в таблице:\nКол.М - Общее количество машин, которые были на перекрестке\n"+
                            "Кол.М.П - Количество машин, которые проехали перекресток\nКол.З.Ф - Количество зеленых фаз\nКол.К.Ф - Количество красных фаз\n"+
                            "Кол.Ж.Ф. - Количество желтых фаз\nКол.Л - Количество легковых автомобилей\nКол.Г - Количество грузовых автомобилей","Помощь");
        }
    }
}
