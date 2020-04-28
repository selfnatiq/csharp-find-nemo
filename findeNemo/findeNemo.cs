using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace findeNemo
{
    public partial class findeNemo : Form
    {
        List<Block> tiles = new List<Block>();
        int cols = 4;
        int rows = 5;
        Color blockGreen = Color.Green;
        Color blockPink = Color.Pink;
        Color blockRed = Color.Red;

        public findeNemo()
        {
            InitializeComponent();
        }

        private void findeNemo_Load(object sender, EventArgs e)
        {
            int blockHeight = pnlBlocks.Height / rows;
            int blockWidth = pnlBlocks.Width / cols;
            var block = new Block(blockWidth, blockHeight, blockGreen);


            for (int zeile = 0; zeile++ < rows;)
            {
                for (int spalte = 0; spalte++ < cols;)
                {
                    int positionX = (spalte - 1) * blockWidth;
                    int positionY = (zeile - 1) * blockHeight;

                    block.setPosition(positionX, positionY);

                    //add blocks to panel
                    block.drawOn(pnlBlocks);
                    tiles.Add(block);
                }
            }
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
