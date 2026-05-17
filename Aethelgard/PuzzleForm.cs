using System;
using System.Windows.Forms;
using Aethelgard.Controllers;

namespace Aethelgard
{
    public partial class PuzzleForm : Form
    {
        private GameManager _gameManager;

        public string PuzzleResultLog { get; private set; }

        public PuzzleForm(GameManager gameManager)
        {
            InitializeComponent();
            _gameManager = gameManager;

            UpdatePuzzleUI();
        }

        private void UpdatePuzzleUI()
        {
            if (_gameManager.CurrentPuzzle != null)
            {
                rtbQuestion.Text = _gameManager.CurrentPuzzle.Question;
            }
            else
            {
                rtbQuestion.Text = "Nincs aktív rejtvény.";
            }

            lblPuzzleError.Text = "";
            lblPuzzleError.Visible = false;

            txtPuzzleAnswer.Text = "";
        }

        private void PuzzleForm_Load(object sender, EventArgs e)
        {
            UpdatePuzzleUI();
        }

        private void btnSubmitPuzzle_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtPuzzleAnswer.Text, out double playerGuess))
            {
                lblPuzzleError.Visible = false;

                PuzzleResultLog = _gameManager.SolvePuzzle(playerGuess);

                this.Close();
            }
            else
            {
                lblPuzzleError.Text = "Nem megfelelő formátum! Csak számokat adhatsz meg!";
                lblPuzzleError.Visible = true;
            }
        }
    }
}