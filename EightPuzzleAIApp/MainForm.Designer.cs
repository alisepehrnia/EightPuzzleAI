namespace EightPuzzleAIApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.performanceButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.idsButton = new System.Windows.Forms.Button();
            this.maxDepthNumeric = new System.Windows.Forms.NumericUpDown();
            this.bfsButton = new System.Windows.Forms.Button();
            this.greedyButton = new System.Windows.Forms.Button();
            this.heuristicComboBox = new System.Windows.Forms.ComboBox();
            this.astarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.puzzleGrid1 = new EightPuzzleAIApp.PuzzleGrid();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.puzzleGrid2 = new EightPuzzleAIApp.PuzzleGrid();
            ((System.ComponentModel.ISupportInitialize)(this.maxDepthNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // performanceButton
            // 
            this.performanceButton.Location = new System.Drawing.Point(782, 443);
            this.performanceButton.Name = "performanceButton";
            this.performanceButton.Size = new System.Drawing.Size(212, 28);
            this.performanceButton.TabIndex = 4;
            this.performanceButton.Text = "Node Performance Test";
            this.performanceButton.UseVisualStyleBackColor = true;
            this.performanceButton.Click += new System.EventHandler(this.PerformanceButton_Click);
            // 
            // logBox
            // 
            this.logBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBox.Location = new System.Drawing.Point(13, 70);
            this.logBox.MaxLength = 99999999;
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logBox.Size = new System.Drawing.Size(763, 639);
            this.logBox.TabIndex = 5;
            // 
            // idsButton
            // 
            this.idsButton.Location = new System.Drawing.Point(891, 275);
            this.idsButton.Name = "idsButton";
            this.idsButton.Size = new System.Drawing.Size(100, 28);
            this.idsButton.TabIndex = 6;
            this.idsButton.Text = "IDS";
            this.idsButton.UseVisualStyleBackColor = true;
            this.idsButton.Click += new System.EventHandler(this.IdsButton_Click);
            // 
            // maxDepthNumeric
            // 
            this.maxDepthNumeric.Location = new System.Drawing.Point(782, 279);
            this.maxDepthNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxDepthNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxDepthNumeric.Name = "maxDepthNumeric";
            this.maxDepthNumeric.Size = new System.Drawing.Size(100, 22);
            this.maxDepthNumeric.TabIndex = 7;
            this.maxDepthNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // bfsButton
            // 
            this.bfsButton.Location = new System.Drawing.Point(782, 200);
            this.bfsButton.Name = "bfsButton";
            this.bfsButton.Size = new System.Drawing.Size(209, 28);
            this.bfsButton.TabIndex = 8;
            this.bfsButton.Text = "BFS";
            this.bfsButton.UseVisualStyleBackColor = true;
            this.bfsButton.Click += new System.EventHandler(this.BfsButton_Click);
            // 
            // greedyButton
            // 
            this.greedyButton.Location = new System.Drawing.Point(782, 378);
            this.greedyButton.Name = "greedyButton";
            this.greedyButton.Size = new System.Drawing.Size(103, 28);
            this.greedyButton.TabIndex = 9;
            this.greedyButton.Text = "Greedy";
            this.greedyButton.UseVisualStyleBackColor = true;
            this.greedyButton.Click += new System.EventHandler(this.GreedyButton_Click);
            // 
            // heuristicComboBox
            // 
            this.heuristicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.heuristicComboBox.FormattingEnabled = true;
            this.heuristicComboBox.Items.AddRange(new object[] {
            "Manhattan",
            "IncorrectTiles"});
            this.heuristicComboBox.Location = new System.Drawing.Point(782, 348);
            this.heuristicComboBox.Name = "heuristicComboBox";
            this.heuristicComboBox.Size = new System.Drawing.Size(212, 24);
            this.heuristicComboBox.TabIndex = 10;
            // 
            // astarButton
            // 
            this.astarButton.Location = new System.Drawing.Point(891, 378);
            this.astarButton.Name = "astarButton";
            this.astarButton.Size = new System.Drawing.Size(103, 28);
            this.astarButton.TabIndex = 11;
            this.astarButton.Text = "A*";
            this.astarButton.UseVisualStyleBackColor = true;
            this.astarButton.Click += new System.EventHandler(this.AstarButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(779, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Max Depth:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(779, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Heuristic Function:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(764, 47);
            this.label5.TabIndex = 16;
            this.label5.Text = "8 Puzzle Solver";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // puzzleGrid1
            // 
            this.puzzleGrid1.Location = new System.Drawing.Point(786, 85);
            this.puzzleGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.puzzleGrid1.Name = "puzzleGrid1";
            this.puzzleGrid1.Size = new System.Drawing.Size(90, 90);
            this.puzzleGrid1.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(786, 568);
            this.textBox1.MaxLength = 99999999;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(211, 141);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "Developer: Ali Sepehrnia\r\nAutumn 1399-1400\r\nDamghan University\r\n-----------------" +
    "-----\r\n With Special Thanks\r\n To Ms.Erfani\r\n----------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(789, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Initial State";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(900, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Goal State";
            // 
            // puzzleGrid2
            // 
            this.puzzleGrid2.Location = new System.Drawing.Point(894, 85);
            this.puzzleGrid2.Margin = new System.Windows.Forms.Padding(0);
            this.puzzleGrid2.Name = "puzzleGrid2";
            this.puzzleGrid2.Size = new System.Drawing.Size(90, 90);
            this.puzzleGrid2.TabIndex = 22;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.puzzleGrid2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.puzzleGrid1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.astarButton);
            this.Controls.Add(this.heuristicComboBox);
            this.Controls.Add(this.greedyButton);
            this.Controls.Add(this.bfsButton);
            this.Controls.Add(this.maxDepthNumeric);
            this.Controls.Add(this.idsButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.performanceButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "8 Puzzle Solver";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxDepthNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button performanceButton;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button idsButton;
        private System.Windows.Forms.NumericUpDown maxDepthNumeric;
        private System.Windows.Forms.Button bfsButton;
        private System.Windows.Forms.Button greedyButton;
        private System.Windows.Forms.ComboBox heuristicComboBox;
        private System.Windows.Forms.Button astarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private PuzzleGrid puzzleGrid1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private PuzzleGrid puzzleGrid2;
    }
}

