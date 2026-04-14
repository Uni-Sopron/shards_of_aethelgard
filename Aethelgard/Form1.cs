using System;
using System.Windows.Forms;
using Aethelgard.Controllers;
using Aethelgard.Models; // Ezt is be kell húzni a Kasztok (ClassType) miatt!

namespace Aethelgard
{
    public partial class Form1 : Form
    {
        // 1. ITT HOZZUK LÉTRE A MENEDZSERT!
        private GameManager _gameManager = new GameManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Opcionális: Alapból letilthatjuk a támadás gombot, amíg nem indult el a játék
            btnAttack.Enabled = false;
        }

        // 2. AZ ÚJ JÁTÉK INDÍTÁSA GOMB ESEMÉNYE
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            // A 2. mérföldkőhöz egyelőre fixen bedrótozzuk az adatokat (később majd TextBox-ból olvassuk ki)
            string playerName = "Teszt Hős";
            ClassType selectedClass = ClassType.NumberMage;

            // Szólunk a menedzsernek, hogy indítsa el a játékot
            _gameManager.StartNewGame(playerName, selectedClass);

            // Frissítjük a felületet
            rtbLog.Text = "A játék elkezdődött! Egy Bináris Farkas állja utad.\r\n";
            btnAttack.Enabled = true; // Bekapcsoljuk a támadás gombot
            UpdateStatus(); // Kiírjuk a kezdő életerőket
        }

        // 3. A TÁMADÁS GOMB ESEMÉNYE (Ez a te kódod, kicsit finomítva)
        private void btnAttack_Click(object sender, EventArgs e)
        {
            // Lefuttatjuk a kört a logikában
            string roundResult = _gameManager.PlayCombatRound();

            // Frissítjük a szöveges naplót
            rtbLog.Text = roundResult + "\r\n" + rtbLog.Text;

            // Vizuálisan frissítjük az életerőket
            UpdateStatus();

            // Ellenőrizzük, vége-e a játéknak, hogy letiltsuk a gombot
            if (_gameManager.CurrentPlayer.IsDead() || _gameManager.TestEnemy.IsDead())
            {
                btnAttack.Enabled = false;
            }
        }

        // 4. ÁLLAPOTFRISSÍTŐ METÓDUS
        private void UpdateStatus()
        {
            // Kiírjuk az aktuális számokat a felületre
            lblPlayerHp.Text = $"Te HP-d: {_gameManager.CurrentPlayer.Health}";
            lblEnemyHp.Text = $"{_gameManager.TestEnemy.Name} HP-ja: {_gameManager.TestEnemy.Health}";
        }

        private void lblEnemyHp_Click(object sender, EventArgs e)
        {

        }
    }
}