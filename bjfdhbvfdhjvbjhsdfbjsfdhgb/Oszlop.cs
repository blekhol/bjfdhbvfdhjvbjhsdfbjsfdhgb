using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace bjfdhbvfdhjvbjhsdfbjsfdhgb
{
    class Oszlop
    {
		private GroupBox oszlopBox = new GroupBox();

		public Oszlop()
		{
		}

		public GroupBox OszlopBox { get => oszlopBox; }

		public void OszlopLetrehozas(bool forditott)
        {
            StackPanel stackPanel = new StackPanel();

            System.Windows.Shapes.Rectangle felsoRect = new System.Windows.Shapes.Rectangle();
			felsoRect.Width = 75;
            felsoRect.Height = 30;
            felsoRect.Stroke = Brushes.Black;
            felsoRect.Fill = Brushes.Green;

			System.Windows.Shapes.Rectangle alsoRect = new System.Windows.Shapes.Rectangle();
			alsoRect.Width = 60;
			alsoRect.Height = 280;
			alsoRect.Stroke = Brushes.Black;
			alsoRect.Fill = Brushes.Green;

			if (forditott)
            {
				stackPanel.Children.Add(felsoRect);
				stackPanel.Children.Add(alsoRect);
			}
			else
			{
				stackPanel.Children.Add(alsoRect);
				stackPanel.Children.Add(felsoRect);
			}

			oszlopBox.Content = stackPanel;
            oszlopBox.BorderThickness = new System.Windows.Thickness(0);
		}
	}
}
