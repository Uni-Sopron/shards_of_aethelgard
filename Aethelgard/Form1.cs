using System;
using System.Windows.Forms;
using Aethelgard.Controllers;
using Aethelgard.Models;

namespace Aethelgard
{
    public partial class Form1 : Form
    {
        private GameManager _gameManager = new GameManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnAttack.Enabled = false;

            cmbClassSelect.Items.Add("Rúnaharcos");
            cmbClassSelect.Items.Add("Számmágus");
            cmbClassSelect.Items.Add("Árnyék-Algoritmus");

            cmbClassSelect.SelectedIndex = 0;

            txtPlayerName.Text = "Ismeretlen Vándor";
        }

        // ÚJ JÁTÉK INDÍTÁSA
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            string playerName = txtPlayerName.Text;

            string selectedText = cmbClassSelect.SelectedItem.ToString();
            ClassType selectedClass = ClassType.RuneWarrior;

            if (selectedText == "Rúnaharcos")
            {
                selectedClass = ClassType.RuneWarrior;
            }
            else if (selectedText == "Számmágus")
            {
                selectedClass = ClassType.NumberMage;
            }
            else if (selectedText == "Árnyék-Algoritmus")
            {
                selectedClass = ClassType.ShadowAlgorithm;
            }

            _gameManager.StartNewGame(playerName, selectedClass);

            rtbLog.Text = $"A játék elkezdődött! Üdvözlünk, {playerName}!\r\nEgy {_gameManager.TestEnemy.Name} állja utad.\r\n";
            btnAttack.Enabled = true;
            UpdateStatus();
        }

        // TÁMADÁS
        private void btnAttack_Click(object sender, EventArgs e)
        {
            string roundResult = _gameManager.PlayCombatRound();

            rtbLog.Text = roundResult + "\r\n" + rtbLog.Text;

            UpdateStatus();

            if (_gameManager.TestEnemy.IsDead())
            {
                btnAttack.Enabled = false;
                btnNextEnemy.Enabled = true;
            }
            else if (_gameManager.CurrentPlayer.IsDead())
            {
                btnAttack.Enabled = false;
                rtbLog.Text = "A játéknak vége. Tölts be egy mentést, vagy indíts új játékot.\r\n" + rtbLog.Text;
            }
        }


        // ÁLLAPOTFRISSÍTŐ METÓDUS
        private void UpdateStatus()
        {
            // 1. Játékos adatainak frissítése (Biztonsági ellenőrzéssel)
            if (_gameManager.CurrentPlayer != null)
            {
                lblPlayerHp.Text = $"Te HP-d: {_gameManager.CurrentPlayer.Health}";
            }
            else
            {
                lblPlayerHp.Text = "Te HP-d: -";
            }

            // 2. Ellenség adatainak frissítése
            if (_gameManager.TestEnemy != null)
            {
                // Ha van aktív ellenség, kiírjuk az adatait
                lblEnemyHp.Text = $"{_gameManager.TestEnemy.Name} HP-ja: {_gameManager.TestEnemy.Health}";
            }
            else
            {
                // Ha pihenő fázisban vagyunk (pl. betöltés után), ezt írjuk ki:
                lblEnemyHp.Text = "Nincs aktív ellenség";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _gameManager.SaveGame();
            rtbLog.Text = "Játék sikeresen mentve az adatbázisba!\r\n" + rtbLog.Text;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (_gameManager.LoadGame())
            {
                rtbLog.Text = $"Adatbázis betöltve! Üdv újra, {_gameManager.CurrentPlayer.Name} (Szint: {_gameManager.CurrentPlayer.Level})!\r\n" + rtbLog.Text;
                UpdateStatus();
                btnAttack.Enabled = false;
                btnNextEnemy.Enabled = true;
            }
            else
            {
                rtbLog.Text = "Nem található mentett játék az adatbázisban.\r\n" + rtbLog.Text;
            }
        }

        private void btnNextEnemy_Click(object sender, EventArgs e)
        {
            _gameManager.SpawnNextEnemy();

            rtbLog.Text = $"\r\n--- ÚJ KÜZDELEM ---\r\nEgy {_gameManager.TestEnemy.Name} jelenik meg!\r\n" + rtbLog.Text;

            UpdateStatus();
            btnAttack.Enabled = true;
            btnNextEnemy.Enabled = false;
        }
    }
}