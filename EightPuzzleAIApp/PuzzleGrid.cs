using System;
using System.Drawing;
using System.Windows.Forms;

namespace EightPuzzleAIApp
{
    public partial class PuzzleGrid : UserControl
    {
        public Label[] Labels;
        public byte[] Data;

        public PuzzleGrid()
        {
            InitializeComponent();
            Labels = new Label[] { c00, c01, c02, c10, c11, c12, c20, c21, c22 };
            Data = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        public void Initialize(byte[] data)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = data[i];

                if (Data[i] > 0)
                {
                    Labels[i].BackColor = Color.White;
                    Labels[i].Text = Data[i].ToString();
                }
                else
                {
                    Labels[i].BackColor = Color.Transparent;
                    Labels[i].ResetText();
                }
            }
        }

        public void ChangeData(int row, int col, int value)
        {
            int i = row * 3 + col;

            if (value != 0)
            {
                Labels[i].BackColor = Color.White;
                Labels[i].Text = value.ToString();
            }
            else
            {
                Labels[i].Text = "";
                Labels[i].BackColor = Color.Gainsboro;
            }
        }

        public void ChangeAllData(byte[] data)
        {
            Data = data;

            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] != 0)
                {
                    Labels[i].BackColor = Color.White;
                    Labels[i].Text = Data[i].ToString();
                }
                else
                {
                    Labels[i].Text = "";
                    Labels[i].BackColor = Color.Gainsboro;
                }
            }
        }

        public int GetData(int row, int col)
        {
            int i = row * 3 + col;
            return int.Parse(Labels[i].Text);
        }

        private void PuzzleGrid_Load(object sender, EventArgs e)
        {
            
        }
    }
}
