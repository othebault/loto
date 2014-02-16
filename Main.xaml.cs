using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Loto
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            raz();
        }

        private void raz()
        {
            Grid grid = (Grid)this.FindName("grille");
            for (int i = 0; grid.Children.Count > i; i++)
            {
                if (grid.Children[i] is Button)
                {
                    Button btn = (Button)grid.Children[i];

                    Thickness thickness = new Thickness();
                    thickness.Bottom = 4;
                    thickness.Top = 4;
                    thickness.Left = 4;
                    thickness.Right = 4;
                    btn.Margin = thickness;
                    btn.Click += ClickNumero;

                    setNormal(btn);
                }
            }
        }

        private int currentValue = 0;

        private void ClickNumero(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            currentValue = Convert.ToInt32(btn.Content);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Nombre fenetre = new Nombre();
            fenetre.setValue(currentValue);
            fenetre.Show();
            Button btn = (Button)this.FindName("btn" + currentValue.ToString());
            selectButton(btn);
        }

        private void efface(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)this.FindName("btn" + currentValue.ToString());
            setNormal(btn);
        }

        private void selectButton(Button btn)
        {
            btn.Background = Brushes.Yellow;
            btn.FontWeight = FontWeights.Bold;
            btn.FontStyle = FontStyles.Normal;
            btn.Foreground = Brushes.Blue;
        }

        private void setNormal(Button btn)
        {
            btn.FontSize = 18;
            btn.Background = Brushes.White;
            btn.FontWeight = FontWeights.Normal;
            btn.FontStyle = FontStyles.Normal;
            btn.Foreground = Brushes.Black;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            raz();
        }

        private void suivante(object sender, RoutedEventArgs e)
        {
            Transition fenetre = new Transition();            
            fenetre.Show();
        }
    }
}

