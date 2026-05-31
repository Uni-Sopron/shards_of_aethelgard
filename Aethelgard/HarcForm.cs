using Aethelgard;
using Aethelgard.Controllers;
using System;
using System.Windows.Forms;

namespace Aethelgard
{
    public partial class HarcForm : Form
    {
        private GameManager _gameManager;

        public HarcForm(GameManager gameManager)
        {
            InitializeComponent();
            _gameManager = gameManager;

            UpdateStatus();
        }

        // ÁLLAPOTFRISSÍTŐ METÓDUS
        private void UpdateStatus()
        {
            if (_gameManager.CurrentPlayer != null)
            {
                lblPlayerHp.Text = $"HP: {_gameManager.CurrentPlayer.Health}/{_gameManager.CurrentPlayer.MaxHealth} " +
                    $"| Mana: {_gameManager.CurrentPlayer.Mana}/{_gameManager.CurrentPlayer.MaxMana}";
            }
            else
            {
                lblPlayerHp.Text = "Te HP-d: -";
            }

            if (_gameManager.TestEnemy != null)
            {
                lblEnemyHp.Visible = true;
                lblEnemyHp.Text = $"{_gameManager.TestEnemy.Name} HP-ja: {_gameManager.TestEnemy.Health}";
            }
            else
            {
                lblEnemyHp.Visible = false;
            }
        }

        private void HarcForm_Load(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        // TÁMADÁS
        private void btnAttack_Click(object sender, EventArgs e)
        {
            string roundResult = _gameManager.PlayCombatRound();
            rtbLog.Text = roundResult + "\r\n" + rtbLog.Text;

            UpdateStatus();

            if (_gameManager.TestEnemy != null && _gameManager.TestEnemy.IsDead())
            {
                btnAttack.Enabled = false;
                btnSpecialAttack.Enabled = false;
                btnNext.Enabled = true;
            }
            else if (_gameManager.CurrentPlayer.IsDead())
            {
                UpdateStatus();

                MessageBox.Show("Sajnos elestél a harcban...\n\nA Zéró Entitás győzedelmeskedett, és a kódex elveszett. Próbáld újra!",
                                "Game Over",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSpecialAttack_Click(object sender, EventArgs e)
        {
            string roundResult = _gameManager.PlaySpecialRound();
            rtbLog.Text = roundResult + "\r\n" + rtbLog.Text;

            UpdateStatus();

            if (_gameManager.TestEnemy != null && _gameManager.TestEnemy.IsDead())
            {
                btnAttack.Enabled = false;
                btnSpecialAttack.Enabled = false;
                btnNext.Enabled = true;
            }
            else if (_gameManager.CurrentPlayer.IsDead())
            {
                UpdateStatus();

                MessageBox.Show("Sajnos elestél a harcban...\n\nA Zéró Entitás győzedelmeskedett, és a kódex elveszett. Próbáld újra!",
                                "Game Over",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _gameManager.SaveGame();
            rtbLog.Text = "Játék sikeresen mentve az adatbázisba!\r\n" + rtbLog.Text;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int choice = rnd.Next(0, 10);

            if (choice <= 7)
            {
                _gameManager.SpawnNextEnemy();

                rtbLog.Text = $"\r\n--- ÚJ KÜZDELEM ---\r\nEgy {_gameManager.TestEnemy.Name} jelenik meg!\r\n" + rtbLog.Text;

                UpdateStatus();

                btnAttack.Enabled = true;
                btnSpecialAttack.Enabled = true;
                btnNext.Enabled = false;
            }
            else
            {
                _gameManager.GeneratePuzzle();

                UpdateStatus();

                PuzzleForm puzzleWindow = new PuzzleForm(_gameManager);
                this.Hide();
                puzzleWindow.ShowDialog();
                this.Show();

                if (!string.IsNullOrEmpty(puzzleWindow.PuzzleResultLog))
                {
                    rtbLog.Text = puzzleWindow.PuzzleResultLog + rtbLog.Text;
                }

                UpdateStatus();

                btnAttack.Enabled = false;
                btnSpecialAttack.Enabled = false;
                btnNext.Enabled = true;
            }
        }
    }
}