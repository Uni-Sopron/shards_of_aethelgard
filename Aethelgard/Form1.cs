using System;
using System.Windows.Forms;
using Aethelgard.Controllers;
using Aethelgard.Models; // Ezt is be kell húzni a Kasztok (ClassType) miatt!

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
            // A támadás gomb letiltása, amíg nem indítanak játékot
            btnAttack.Enabled = false;

            // 1. Kasztok hozzáadása a ComboBox-hoz
            cmbClassSelect.Items.Add("Rúnaharcos");
            cmbClassSelect.Items.Add("Számmágus");
            cmbClassSelect.Items.Add("Árnyék-Algoritmus");

            // 2. Alapértelmezett kiválasztás, hogy ne legyen üres a mező induláskor
            cmbClassSelect.SelectedIndex = 0;

            // Alapértelmezett név beállítása a TextBox-ban
            txtPlayerName.Text = "Ismeretlen Vándor";
        }

        // 2. AZ ÚJ JÁTÉK INDÍTÁSA GOMB ESEMÉNYE
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            // 1. Név kiolvasása a felületről
            string playerName = txtPlayerName.Text;

            // 2. A kiválasztott kaszt szövegének átalakítása Enum-má
            string selectedText = cmbClassSelect.SelectedItem.ToString();
            ClassType selectedClass = ClassType.RuneWarrior; // Alapérték

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

            // 3. A játék indítása a VALÓDI adatokkal
            _gameManager.StartNewGame(playerName, selectedClass);

            // 4. Felület frissítése
            rtbLog.Text = $"A játék elkezdődött! Üdvözlünk, {playerName}!\r\nEgy Bináris Farkas állja utad.\r\n";
            btnAttack.Enabled = true;
            UpdateStatus();
        }

        // 3. A TÁMADÁS GOMB ESEMÉNYE
        private void btnAttack_Click(object sender, EventArgs e)
        {
            string roundResult = _gameManager.PlayCombatRound();

            rtbLog.Text = roundResult + "\r\n" + rtbLog.Text;

            UpdateStatus();

            if (_gameManager.CurrentPlayer.IsDead() || _gameManager.TestEnemy.IsDead())
            {
                btnAttack.Enabled = false;
            }
        }

        // 4. ÁLLAPOTFRISSÍTŐ METÓDUS
        private void UpdateStatus()
        {
            lblPlayerHp.Text = $"Te HP-d: {_gameManager.CurrentPlayer.Health}";
            lblEnemyHp.Text = $"{_gameManager.TestEnemy.Name} HP-ja: {_gameManager.TestEnemy.Health}";
        }

        private void lblEnemyHp_Click(object sender, EventArgs e)
        {

        }
    }
}