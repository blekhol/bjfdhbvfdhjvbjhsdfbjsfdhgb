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
        private GroupBox oszlopBox;

        public Oszlop()
        {
            this.oszlopBox = new GroupBox();
		}

		public void OszlopLetrehozas()
        {
            StackPanel stackPanel = new StackPanel();

            System.Windows.Shapes.Rectangle felsoRect = new System.Windows.Shapes.Rectangle();
			felsoRect.Width = 75;
            felsoRect.Height = 30;
            felsoRect.Stroke = Brushes.Black;
		}
	}
}
