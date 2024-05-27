namespace SudokuSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.namegame = new System.Windows.Forms.Label();
            this.newGame = new System.Windows.Forms.Button();
            this.easygame = new System.Windows.Forms.Button();
            this.middlegame = new System.Windows.Forms.Button();
            this.hardgame = new System.Windows.Forms.Button();
            this.difselect = new System.Windows.Forms.Label();
            this.stepall = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.undo = new System.Windows.Forms.Button();
            this.onestep = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.goback = new System.Windows.Forms.Button();
            this.verify = new System.Windows.Forms.Button();
            this.backmethod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // namegame
            // 
            this.namegame.AutoSize = true;
            this.namegame.BackColor = System.Drawing.Color.MistyRose;
            this.namegame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.namegame.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.namegame.Location = new System.Drawing.Point(880, 89);
            this.namegame.Name = "namegame";
            this.namegame.Size = new System.Drawing.Size(260, 71);
            this.namegame.TabIndex = 0;
            this.namegame.Text = "Судоку";
            // 
            // newGame
            // 
            this.newGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newGame.BackColor = System.Drawing.Color.OldLace;
            this.newGame.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newGame.Location = new System.Drawing.Point(841, 776);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(339, 80);
            this.newGame.TabIndex = 1;
            this.newGame.Text = "Нова гра";
            this.newGame.UseVisualStyleBackColor = false;
            // 
            // easygame
            // 
            this.easygame.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.easygame.Location = new System.Drawing.Point(683, 795);
            this.easygame.Name = "easygame";
            this.easygame.Size = new System.Drawing.Size(152, 47);
            this.easygame.TabIndex = 2;
            this.easygame.Text = "легка";
            this.easygame.UseVisualStyleBackColor = true;
            this.easygame.Click += new System.EventHandler(this.easygame_Click);
            // 
            // middlegame
            // 
            this.middlegame.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.middlegame.Location = new System.Drawing.Point(936, 795);
            this.middlegame.Name = "middlegame";
            this.middlegame.Size = new System.Drawing.Size(152, 47);
            this.middlegame.TabIndex = 3;
            this.middlegame.Text = "середня";
            this.middlegame.UseVisualStyleBackColor = true;
            this.middlegame.Click += new System.EventHandler(this.middlegame_Click);
            // 
            // hardgame
            // 
            this.hardgame.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hardgame.Location = new System.Drawing.Point(1186, 795);
            this.hardgame.Name = "hardgame";
            this.hardgame.Size = new System.Drawing.Size(152, 47);
            this.hardgame.TabIndex = 4;
            this.hardgame.Text = "складна";
            this.hardgame.UseVisualStyleBackColor = true;
            this.hardgame.Click += new System.EventHandler(this.hardgame_Click);
            // 
            // difselect
            // 
            this.difselect.AutoSize = true;
            this.difselect.BackColor = System.Drawing.Color.Transparent;
            this.difselect.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.difselect.Location = new System.Drawing.Point(868, 753);
            this.difselect.Name = "difselect";
            this.difselect.Size = new System.Drawing.Size(301, 30);
            this.difselect.TabIndex = 5;
            this.difselect.Text = "Оберіть складність";
            // 
            // stepall
            // 
            this.stepall.BackColor = System.Drawing.Color.OldLace;
            this.stepall.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepall.Location = new System.Drawing.Point(641, 776);
            this.stepall.Name = "stepall";
            this.stepall.Size = new System.Drawing.Size(225, 80);
            this.stepall.TabIndex = 6;
            this.stepall.Text = "Покровкове вирішення";
            this.stepall.UseVisualStyleBackColor = false;
            this.stepall.Click += new System.EventHandler(this.stepall_Click);
            // 
            // solveButton
            // 
            this.solveButton.BackColor = System.Drawing.Color.OldLace;
            this.solveButton.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.solveButton.Location = new System.Drawing.Point(892, 776);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(235, 80);
            this.solveButton.TabIndex = 7;
            this.solveButton.Text = "Автоматичне вирішення";
            this.solveButton.UseVisualStyleBackColor = false;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.OldLace;
            this.help.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.help.Location = new System.Drawing.Point(1157, 777);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(235, 80);
            this.help.TabIndex = 8;
            this.help.Text = "Підказка";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // undo
            // 
            this.undo.BackColor = System.Drawing.Color.OldLace;
            this.undo.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.undo.Location = new System.Drawing.Point(629, 789);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(246, 55);
            this.undo.TabIndex = 9;
            this.undo.Text = "Скасувати";
            this.undo.UseVisualStyleBackColor = false;
            // 
            // onestep
            // 
            this.onestep.BackColor = System.Drawing.Color.OldLace;
            this.onestep.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.onestep.Location = new System.Drawing.Point(1146, 787);
            this.onestep.Name = "onestep";
            this.onestep.Size = new System.Drawing.Size(258, 55);
            this.onestep.TabIndex = 10;
            this.onestep.Text = "Крок";
            this.onestep.UseVisualStyleBackColor = false;
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.OldLace;
            this.reset.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reset.Location = new System.Drawing.Point(887, 787);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(246, 55);
            this.reset.TabIndex = 11;
            this.reset.Text = "Скинути";
            this.reset.UseVisualStyleBackColor = false;
            // 
            // goback
            // 
            this.goback.BackColor = System.Drawing.Color.MistyRose;
            this.goback.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goback.Location = new System.Drawing.Point(104, 73);
            this.goback.Name = "goback";
            this.goback.Size = new System.Drawing.Size(90, 65);
            this.goback.TabIndex = 12;
            this.goback.Text = "<";
            this.goback.UseVisualStyleBackColor = false;
            this.goback.Click += new System.EventHandler(this.goback_Click);
            // 
            // verify
            // 
            this.verify.BackColor = System.Drawing.Color.OldLace;
            this.verify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.verify.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.verify.Location = new System.Drawing.Point(641, 879);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(751, 65);
            this.verify.TabIndex = 13;
            this.verify.Text = "Перевірити";
            this.verify.UseVisualStyleBackColor = false;
            this.verify.Click += new System.EventHandler(this.verify_Click);
            // 
            // backmethod
            // 
            this.backmethod.BackColor = System.Drawing.Color.MistyRose;
            this.backmethod.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backmethod.Location = new System.Drawing.Point(55, 144);
            this.backmethod.Name = "backmethod";
            this.backmethod.Size = new System.Drawing.Size(187, 83);
            this.backmethod.TabIndex = 14;
            this.backmethod.Text = "До інших методів";
            this.backmethod.UseVisualStyleBackColor = false;
            this.backmethod.Click += new System.EventHandler(this.backmethod_Click);
            // 
            // MainForm
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::GameSudoku.Properties.Resources.Untitled_design__5_;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.backmethod);
            this.Controls.Add(this.verify);
            this.Controls.Add(this.goback);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.onestep);
            this.Controls.Add(this.undo);
            this.Controls.Add(this.help);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.stepall);
            this.Controls.Add(this.difselect);
            this.Controls.Add(this.hardgame);
            this.Controls.Add(this.middlegame);
            this.Controls.Add(this.easygame);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.namegame);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Судоку";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label namegame;
        private System.Windows.Forms.Button newGame;
        private System.Windows.Forms.Button easygame;
        private System.Windows.Forms.Button middlegame;
        private System.Windows.Forms.Button hardgame;
        private System.Windows.Forms.Label difselect;
        private System.Windows.Forms.Button stepall;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.Button onestep;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button goback;
        private System.Windows.Forms.Button verify;
        private System.Windows.Forms.Button backmethod;
    }
}
