using System;
using System.Windows.Forms;
using Aethelgard.Controllers;
using Aethelgard.Models;

namespace Aethelgard
{
    public partial class MenuForm : Form
    {
        private GameManager _gameManager = new GameManager();

        public MenuForm()
        {
            InitializeComponent();
        }

        // --- ÚJ JÁTÉK ---
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlayerName.Text))
            {
                MessageBox.Show("Kérlek, adj meg egy nevet a hősödnek!");
                return;
            }
            if (cmbClassSelect.SelectedIndex == -1)
            {
                MessageBox.Show("Kérlek, válassz egy kasztot a legördülő listából!");
                return;
            }

            string playerName = txtPlayerName.Text;

            ClassType selectedClass = (ClassType)cmbClassSelect.SelectedIndex;

            _gameManager.StartNewGame(playerName, selectedClass);

            HarcForm harcWindow = new HarcForm(_gameManager);

            this.Hide();
            harcWindow.ShowDialog();
            this.Show();
        }

        // --- BETÖLTÉS ---
        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            if (_gameManager.LoadGame())
            {
                HarcForm harcWindow = new HarcForm(_gameManager);
                this.Hide();
                harcWindow.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Nem található korábbi mentés az adatbázisban!");
            }
        }

        // --- SZTORI ---
        private void btnStory_Click(object sender, EventArgs e)
        {
            StoryForm storyWindow = new StoryForm();
            storyWindow.ShowDialog();
        }

        // --- KILÉPÉS ---
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}