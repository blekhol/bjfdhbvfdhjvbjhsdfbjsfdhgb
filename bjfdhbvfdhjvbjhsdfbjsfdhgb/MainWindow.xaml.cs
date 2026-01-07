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
        private DispatcherTimer dispatcherTimer;

		public MainWindow()
        {
            InitializeComponent();

			dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
			dispatcherTimer.Tick += new EventHandler(Update);
			dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
			dispatcherTimer.Start();

			this.KeyDown += new KeyEventHandler(Ugras);
		}

		private void Update(object sender, EventArgs e)
		{
			madar.SetValue(Canvas.TopProperty, Canvas.GetTop(madar) + 3);
		}

		private void Ugras(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
			{
				madar.SetValue(Canvas.TopProperty, Canvas.GetTop(madar) - 60);
			}
		}
	}
}