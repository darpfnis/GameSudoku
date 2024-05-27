using GameSudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class MainForm : Form
    {
        private Button[,] buttons = new Button[9, 9];
        private int[,] puzzle = new int[9, 9];
        private int[,] initialPuzzle = new int[9, 9];
        private Stack<(int, int, int)> steps = new Stack<(int, int, int)>();
        private List<(int, int)> emptyCells = new List<(int, int)>();
        private Dictionary<(int, int), List<int>> candidates = new Dictionary<(int, int), List<int>>();
        private int currentIndex = 0;
        private SudokuSolverLogic solver;
        private SudokuHelper helper;

        public MainForm()
        {
            InitializeComponent();
            InitializeSudokuGrid();
            solver = new SudokuSolverLogic( puzzle, buttons, steps, emptyCells, candidates, initialPuzzle, currentIndex);
            helper = new SudokuHelper(buttons);
            solver.LoadPuzzle();
            easygame.Visible = false;
            middlegame.Visible = false;
            hardgame.Visible = false;
            difselect.Visible = false;
            stepall.Visible = false;
            onestep.Visible = false;
            undo.Visible = false;
            reset.Visible = false;
            solveButton.Visible = false;
            help.Visible = false;
            goback.Visible = false;
            verify.Visible = false;
            backmethod.Visible = false;
        }

        private void InitializeSudokuGrid()
        {
            int buttonSize = 60;
            int spacing = 10;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Button btn = new Button
                    {

                        Width = buttonSize,
                        Height = buttonSize,
                        Left = col * buttonSize + (col / 3) * spacing + 740,
                        Top = row * buttonSize + (row / 3) * spacing + 180,
                        Enabled = false
                    };
                    btn.Click += new EventHandler(ButtonClick);
                    this.Controls.Add(btn);
                    buttons[row, col] = btn;
                    buttons[row, col].ForeColor = System.Drawing.Color.Black;
                }
            }
            newGame.Click += new EventHandler(newGame_Click);
            onestep.Click += new EventHandler(onestep_Click);
            undo.Click += new EventHandler(undo_Click);
            reset.Click += new EventHandler(reset_Click);
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            solver.SolveSudokuAutomatically();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            solver.ClickButtons(sender);
        }

        private void onestep_Click(object sender, EventArgs e)
        {
            solver.SolveNextStep();
            solver.DisplayPuzzle();
        }

        private void undo_Click(object sender, EventArgs e)
        {
            solver.UndoAction();
            solver.DisplayPuzzle();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            solver.ResetPuzzle();
            solver.DisplayPuzzle();
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            easygame.Visible = true;
            middlegame.Visible = true;
            hardgame.Visible = true;
            difselect.Visible = true;
            newGame.Visible = false;
            namegame.Visible = false;
        }
        private void easygame_Click(object sender, EventArgs e)
        {
            solver.GenerateRandomPuzzle(20);
            buttonshide();
        }

        private void middlegame_Click(object sender, EventArgs e)
        {
            solver.GenerateRandomPuzzle(30);
            buttonshide();
        }

        private void hardgame_Click(object sender, EventArgs e)
        {
            solver.GenerateRandomPuzzle(45);
            buttonshide();
        }

        private void stepall_Click(object sender, EventArgs e)
        {
            onestep.Visible = true;
            undo.Visible = true;
            reset.Visible = true;
            stepall.Visible = false;
            verify.Visible = false;
            solveButton.Visible = false;
            backmethod.Visible = true;
            help.Visible = false;
        }

        private void help_Click(object sender, EventArgs e)
        {
            solver.GiveHint();
        }
        private void buttonshide()
        {
            easygame.Visible = false;
            middlegame.Visible = false;
            hardgame.Visible = false;
            difselect.Visible = false;
            stepall.Visible = true;
            solveButton.Visible = true;
            help.Visible = true;
            goback.Visible = true;
            verify.Visible = true;
        }

        private void goback_Click(object sender, EventArgs e)
        {
            easygame.Visible = false;
            middlegame.Visible = false;
            hardgame.Visible = false;
            difselect.Visible = false;
            stepall.Visible = false;
            solveButton.Visible = false;
            help.Visible = false;
            newGame.Visible = true;
            onestep.Visible = false;
            undo.Visible = false;
            reset.Visible = false;
            helper.DisplayInitialPuzzleAndLock();
            goback.Visible = false;
            verify.Visible = false;
            namegame.Visible = true;
            backmethod.Visible = false;
        }

        private void verify_Click(object sender, EventArgs e)
        {
            int[,] userSolution = new int[9, 9];
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (int.TryParse(buttons[row, col].Text, out int value))
                    {
                        userSolution[row, col] = value;
                    }
                    else
                    {
                        userSolution[row, col] = 0;
                    }
                }
            }
            if (helper.IsSolutionCorrect(userSolution))
            {
                MessageBox.Show("Ви правильно вирішили головоломку!", "Перевірка рішення");
            }
            else
            {
                MessageBox.Show("Рішення неправильне. Спробуйте ще раз.", "Перевірка рішення");
            }
        }

        private void backmethod_Click(object sender, EventArgs e)
        {
            stepall.Visible = true;
            solveButton.Visible = true;
            help.Visible = true;
            onestep.Visible = false;
            reset.Visible = false;
            backmethod.Visible = false;
            undo.Visible = false;
            verify.Visible = true;
        }
    }
}