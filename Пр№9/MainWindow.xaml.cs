using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Пр_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        double[,] table = new double[5, 3];
        Baggage[] baggage=new Baggage[5];
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberOrder.Text, out int i) && i > 0 && i <= 5)
            {
                baggage[i - 1].QuantityThings = Convert.ToInt32(Quantity.Text);
                baggage[i - 1].TotalWeight = Convert.ToInt32(Weigth.Text);

                table[i - 1, 0] = i;
                table[i - 1, 1] = baggage[i - 1].QuantityThings;
                table[i - 1, 2] = baggage[i - 1].TotalWeight/1000;

                DataGrid.ItemsSource = VisualArray.ToDataTable(table).DefaultView;
                DataGrid.Columns[0].Header = "№";
                DataGrid.Columns[1].Header = "Количество вещей, шт";
                DataGrid.Columns[2].Header = "Общий вес, кг";
            }  
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double[] mas = new double[table.GetLength(1)];
            double sumThings = 0, sumWeigth = 0, averageWeigth;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (j == 1) sumThings += table[i, j];
                    if (j == 2) sumWeigth += table[i, j];
                    if (j == 2) sumWeigth += table[i, j];
                }
            }
            averageWeigth = sumWeigth / sumThings;
            for (int i = table.GetLength(0); i >=0; i--)
            {
                for (int j = table.GetLength(1); j < table.GetLength(1); j++)
                {
                    mas[i] = table[i, table.GetLength(1)] / table[i, table.GetLength(1) - 1];
                }
            }
            for (int i = 0; i < mas.Length; i++) if (averageWeigth - mas[i] <= 0.3) { result.Text = (i+1).ToString(); break; }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < table.GetLength(0); i++) for (int j = 0; j < table.GetLength(1); j++) { table[i, j] = 0; DataGrid.ItemsSource = VisualArray.ToDataTable(table).DefaultView; }
            result.Clear();
            Weigth.Clear();
            Quantity.Clear();
            NumberOrder.Clear();

        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практичсекая работа №9\nВыполнила: студентка группы ИСП-31 Кочеткова В.\nЗадание:Багаж пассажира характеризуется количеством вещей и общим весом вещей. Сведения о багаже каждого пассажира представляют собой структуру с двумя полями: одно поле целого типа(количество вещей) и одно - действительное(вес в килограммах).Вывести результат на экран.Найти багаж, средний вес одной вещи в котором отличается не более, чем на 0.3 кг от общего среднего веса одной вещи. ","Доп.Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
