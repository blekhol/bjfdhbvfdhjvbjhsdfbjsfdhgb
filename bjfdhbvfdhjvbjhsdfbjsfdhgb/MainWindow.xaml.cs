using System.Diagnostics;
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
using System.Windows.Threading;

namespace bjfdhbvfdhjvbjhsdfbjsfdhgb
{
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;

		Random rnd = new Random();

		List<Oszlop> oszlopok = [];

		public MainWindow()
        {
            InitializeComponent();

			dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
			dispatcherTimer.Tick += new EventHandler(Update);
			dispatcherTimer.Interval = TimeSpan.FromMilliseconds(8);
			dispatcherTimer.Start();

			this.KeyUp += new KeyEventHandler(Ugras);

			for (int i = 0; i < 9; i += 2)
			{
				UjOszlop();
				oszlopok[i].OszlopBox.SetValue(Canvas.LeftProperty, Canvas.GetLeft(oszlopok[0].OszlopBox) + 100 * i);
				oszlopok[i+1].OszlopBox.SetValue(Canvas.LeftProperty, Canvas.GetLeft(oszlopok[0].OszlopBox) + 100 * i);
			}
		}

		private void Update(object sender, EventArgs e)
		{
			madar.SetValue(Canvas.TopProperty, Canvas.GetTop(madar) + 1.5);

			foreach (var oszlop in oszlopok)
			{
				oszlop.OszlopBox.SetValue(Canvas.LeftProperty, Canvas.GetLeft(oszlop.OszlopBox) - 1.5);
			}
		}

		private void Ugras(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
			{
				madar.SetValue(Canvas.TopProperty, Canvas.GetTop(madar) - 40);
			}
		}

		private void UjOszlop()
		{
			int felsoOszlopTop = rnd.Next(-240, -64);
			int alsoOszlopTop = felsoOszlopTop + 440;

			Oszlop felsoOszlop = new Oszlop();
			Oszlop alsoOszlop = new Oszlop();

			felsoOszlop.OszlopLetrehozas(false);
			alsoOszlop.OszlopLetrehozas(true);

			felsoOszlop.OszlopBox.SetValue(Canvas.LeftProperty, (double)700);
			alsoOszlop.OszlopBox.SetValue(Canvas.LeftProperty, (double)700);

			felsoOszlop.OszlopBox.SetValue(Canvas.TopProperty, (double)felsoOszlopTop);
			alsoOszlop.OszlopBox.SetValue(Canvas.TopProperty, (double)alsoOszlopTop);

			canvas.Children.Add(felsoOszlop.OszlopBox);
			canvas.Children.Add(alsoOszlop.OszlopBox);

			oszlopok.Add(felsoOszlop);
			oszlopok.Add(alsoOszlop);
		}
	}
}