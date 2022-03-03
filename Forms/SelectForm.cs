using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using LGR_Futbal.Model;
using System;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public delegate void TeamsSelectedHandler(FutbalovyTim t1, FutbalovyTim t2);

    public partial class SelectForm : Form
    {
        private Databaza databaza;
        public event TeamsSelectedHandler OnTeamsSelected;

        public SelectForm(Databaza zdrojDat)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Výběr týmů z databáze";
                domaciLabel.Text = "DOMÁCÍ";
                hostiaLabel.Text = "HOSTÉ";
                aktivovatButton.Text = aktivovatButton.Text.Replace("Vybrať", "Vybrat");
                zrusitButton.Text = zrusitButton.Text.Replace("Zrušiť", "Zrušit");
            }

            databaza = zdrojDat;
            if (databaza.ZoznamTimov.Count == 0)
                aktivovatButton.Enabled = false;
            else
            {
                foreach(FutbalovyTim t in databaza.ZoznamTimov)
                {
                    domaciLB.Items.Add(t.NazovTimu);
                    hostiaLB.Items.Add(t.NazovTimu);
                }

                domaciLB.SelectedIndex = 0;
                hostiaLB.SelectedIndex = 0;
            }
        }

        private void ZrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AktivovatButton_Click(object sender, EventArgs e)
        {
            if (OnTeamsSelected != null)
                OnTeamsSelected(databaza.ZoznamTimov[domaciLB.SelectedIndex],
                    databaza.ZoznamTimov[hostiaLB.SelectedIndex]);
            this.Close();
        }

        private void SelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
