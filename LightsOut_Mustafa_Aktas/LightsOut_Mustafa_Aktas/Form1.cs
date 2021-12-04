using LightsOut_Mustafa_Aktas.DTO;
using LightsOut_Mustafa_Aktas.Properties;
using LightsOut_Mustafa_Aktas.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LightsOut_Mustafa_Aktas
{
    public partial class Form1 : Form
    {
        private int rowCount = 5;
        private int colCount = 3;
        private int moveCount = 0;
        private List<decimal> onLights;
        private IGameService _gameService;

        public Form1()
        {
            var address = System.Configuration.ConfigurationManager.AppSettings["serverAddress"];

            this._gameService = RestService.For<IGameService>(address);

            InitializeComponent();
            resetBoardAsync();
        }

        private void resetBoardAsync()
        {
            var boardInf = new BoardDTO
            {
                ColCount = 3,
                RowCount = 3,
                DefaultTiles = new List<int> { 1, 2 }
            };
            try
            {
                boardInf = _gameService.GetBoardSize().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch board info from server : {ex.Message} Continuing with defaults.");
            }
            rowCount = boardInf.RowCount;
            colCount = boardInf.ColCount;

            if (tlpTiles.Controls.Count != 0)
                tlpTiles.Controls.Clear();
            {
                moveCount = 0;
                onLights = new List<decimal>();
                tlpTiles.RowCount = rowCount;
                tlpTiles.ColumnCount = colCount;
                foreach (ColumnStyle style in tlpTiles.ColumnStyles)
                    style.SizeType = SizeType.AutoSize;
                foreach (RowStyle style in tlpTiles.RowStyles)
                    style.SizeType = SizeType.AutoSize;

                for (int i = 1; i <= rowCount * colCount; i++)
                    tlpTiles.Controls.Add(generateTile(i));
            }

            if (boardInf.DefaultTiles != null)
            {
                foreach (var tileId in boardInf.DefaultTiles)
                    handleNeighborSwitchOn(tileId);
            }
        }

        private PictureBox generateTile(int id)
        {
            var c = new PictureBox
            {
                Image = (Image)Resources.ResourceManager.GetObject("off"),
                Name = id.ToString()
            };
            c.Click += new System.EventHandler(this.handleTileClick);
            c.Size = new Size(100, 100);
            c.Dock = DockStyle.Fill;
            c.Enabled = true;
            return c;
        }

        private void handleTileClick(object sender, EventArgs e)
        {
            var senderTile = (PictureBox)sender;
            decimal tileId = Convert.ToDecimal(senderTile.Name);
            if (onLights.Exists(x => x == tileId))
            {
                senderTile.Image = (Image)Resources.ResourceManager.GetObject("off");
                onLights = onLights.Where(x => x != tileId).ToList();
            }
            else
            {
                senderTile.Image = (Image)Resources.ResourceManager.GetObject("on");
                onLights.Add(tileId);
            }

            int xAdr = (int)(tileId % colCount == 0 ? colCount : tileId % colCount);
            int yAdr = (int)Math.Ceiling(tileId / colCount);

            if (yAdr - 1 != 0)
            {
                handleNeighborSwitchOn((int)(tileId - colCount));
            }

            if (yAdr != rowCount)
            {
                handleNeighborSwitchOn((int)(tileId + colCount));
            }

            if (xAdr - 1 != 0)
            {
                handleNeighborSwitchOn((int)(tileId - 1));
            }

            if (xAdr != colCount)
            {
                handleNeighborSwitchOn((int)(tileId + 1));
            }

            moveCount++;
            if (onLights.Count == rowCount * colCount)
            {
                MessageBox.Show($"You won with {moveCount} moves!");
                resetBoardAsync();
            }
        }

        private void handleNeighborSwitchOn(int tileId)
        {
            PictureBox neighbor = (PictureBox)tlpTiles.Controls.Find(tileId.ToString(), true).First();

            if (!onLights.Exists(x => x == tileId))
            {
                neighbor.Image = (Image)Resources.ResourceManager.GetObject("on");
                onLights.Add(tileId);
            }
            else
            {
                neighbor.Image = (Image)Resources.ResourceManager.GetObject("off");
                onLights = onLights.Where(x => x != tileId).ToList();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetBoardAsync();
        }
    }
}