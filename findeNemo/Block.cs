using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace findeNemo
{
    class Block
    {
        private Panel block = new Panel();

        public Block(int blockWidth, int blockHeight, Color blockColor)
        {
            block.Width = blockWidth;
            block.Height = blockHeight;
            block.BackColor = blockColor;
        }

        public void drawOn(Panel pnl)
        {
            pnl.Controls.Add(block);
        }

        public void setPosition(int x, int y)
        {
            block.Location = new Point(x, y);
        }
    }
}
