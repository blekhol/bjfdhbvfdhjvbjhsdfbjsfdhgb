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

        double utolsoOszlopX = 700;
        const double OSZLOP_TAVOLSAG = 100;

        DispatcherTimer spawnTimer;

        int score = 0;
        double madarX;


        public MainWindow()
        {
            InitializeComponent();
		}

        private void RegularButton_Click(object sender, RoutedEventArgs e)
        {
            startMenu.Visibility = Visibility.Hidden;
            Start("");
        }

        private void RainButton_Click(object sender, RoutedEventArgs e)
        {
            startMenu.Visibility = Visibility.Hidden;
            Start("eső");
        }

        private void FogButton_Click(object sender, RoutedEventArgs e)
        {
            startMenu.Visibility = Visibility.Hidden;
            Start("köd");
        }


        private void Start(string palya)
		{
            madarX = Canvas.GetLeft(madar);


            if (palya == "köd")
			{
				kod.Visibility = Visibility.Visible;
			}
			else if (palya == "eső")
			{
				eso.Visibility = Visibility.Visible;
			}

			dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
			dispatcherTimer.Tick += new EventHandler(Update);
			dispatcherTimer.Interval = TimeSpan.FromMilliseconds(8);
			dispatcherTimer.Start();

			this.KeyUp += new KeyEventHandler(Ugras);

			//oszlop csinálás
            spawnTimer = new DispatcherTimer();
            spawnTimer.Interval = TimeSpan.FromSeconds(1.6);
            spawnTimer.Tick += (s, e) => UjOszlop();
            spawnTimer.Start();
        }

        private void Update(object sender, EventArgs e)
		{
			madar.SetValue(Canvas.TopProperty, Canvas.GetTop(madar) + 1.5);

			foreach (var oszlop in oszlopok.ToList())
			{
				oszlop.FelsoRect.SetValue(Canvas.LeftProperty, Canvas.GetLeft(oszlop.FelsoRect) - 1.5);
				oszlop.AlsoRect.SetValue(Canvas.LeftProperty, Canvas.GetLeft(oszlop.AlsoRect) - 1.5);

                if (Canvas.GetLeft(oszlop.FelsoRect) < -100)
                {
                    canvas.Children.Remove(oszlop.FelsoRect);
                    canvas.Children.Remove(oszlop.AlsoRect);
                    oszlopok.Remove(oszlop);
                }

                if (!oszlop.Passed && Canvas.GetLeft(oszlop.FelsoRect) + oszlop.FelsoRect.Width < madarX && oszlopok.IndexOf(oszlop) % 2 == 0)
                {
                    oszlop.Passed = true;
                    score++;
                    Title = "Score: " + score;
                }
            }

			Collision();
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

            double spawnX = utolsoOszlopX + OSZLOP_TAVOLSAG;

            Oszlop felsoOszlop = new Oszlop();
            Oszlop alsoOszlop = new Oszlop();

            felsoOszlop.OszlopLetrehozas();
            felsoOszlop.AlsoRect.SetValue(Canvas.LeftProperty, spawnX);
            felsoOszlop.AlsoRect.SetValue(Canvas.TopProperty, (double)felsoOszlopTop);
            felsoOszlop.FelsoRect.SetValue(Canvas.LeftProperty, spawnX - 7);
            felsoOszlop.FelsoRect.SetValue(Canvas.TopProperty, (double)felsoOszlopTop + 250);

            alsoOszlop.OszlopLetrehozas();
            alsoOszlop.AlsoRect.SetValue(Canvas.LeftProperty, spawnX);
            alsoOszlop.AlsoRect.SetValue(Canvas.TopProperty, (double)alsoOszlopTop);
            alsoOszlop.FelsoRect.SetValue(Canvas.LeftProperty, spawnX - 7);
            alsoOszlop.FelsoRect.SetValue(Canvas.TopProperty, (double)alsoOszlopTop);

            oszlopok.Add(felsoOszlop);
            oszlopok.Add(alsoOszlop);

            canvas.Children.Add(felsoOszlop.AlsoRect);
            canvas.Children.Add(felsoOszlop.FelsoRect);
            canvas.Children.Add(alsoOszlop.AlsoRect);
            canvas.Children.Add(alsoOszlop.FelsoRect);

            utolsoOszlopX = spawnX;
        }


        private void Collision()
		{
			Rect madarRect = new Rect(Canvas.GetLeft(madar), Canvas.GetTop(madar), madar.Width, madar.Height);
			EllipseGeometry madarGeo = new EllipseGeometry(madarRect);

			foreach (var oszlop in oszlopok.ToList())
			{
				Rect felsoRect = new Rect(Canvas.GetLeft(oszlop.FelsoRect), Canvas.GetTop(oszlop.FelsoRect), oszlop.FelsoRect.Width, oszlop.FelsoRect.Height);
				RectangleGeometry felsoRectGeo = new RectangleGeometry(felsoRect);

				Rect alsoRect = new Rect(Canvas.GetLeft(oszlop.AlsoRect), Canvas.GetTop(oszlop.AlsoRect), oszlop.AlsoRect.Width, oszlop.AlsoRect.Height);
				RectangleGeometry alsoRectGeo = new RectangleGeometry(alsoRect);

				if (felsoRectGeo.FillContainsWithDetail(madarGeo) != IntersectionDetail.Empty || alsoRectGeo.FillContainsWithDetail(madarGeo) != IntersectionDetail.Empty)
				{
					MessageBox.Show("meghaltál");
					Application.Current.Shutdown();
				}
			}
		}
	}
}