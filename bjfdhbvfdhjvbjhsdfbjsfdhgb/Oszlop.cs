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
		private System.Windows.Shapes.Rectangle felsoRect;
		private System.Windows.Shapes.Rectangle alsoRect;

        public Oszlop()
		{
			felsoRect = new System.Windows.Shapes.Rectangle();
			alsoRect = new System.Windows.Shapes.Rectangle();
		}

		public System.Windows.Shapes.Rectangle FelsoRect { get => felsoRect; set => felsoRect = value; }
		public System.Windows.Shapes.Rectangle AlsoRect { get => alsoRect; set => alsoRect = value; }

        public bool Passed { get; set; } = false;


        public void OszlopLetrehozas()
        {
			felsoRect.Width = 75;
            felsoRect.Height = 30;
            felsoRect.Stroke = Brushes.Black;
            felsoRect.Fill = Brushes.Green;

			alsoRect.Width = 60;
			alsoRect.Height = 280;
			alsoRect.Stroke = Brushes.Black;
			alsoRect.Fill = Brushes.Green;
		}
	}
}
