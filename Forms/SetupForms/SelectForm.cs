using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using LGR_Futbal.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LGR_Futbal.Databaza;

namespace LGR_Futbal.Forms
{
    public delegate void TeamsSelectedHandler(FutbalovyTim t1, FutbalovyTim t2);

    public partial class SelectForm : Form
    {
        private DBTimy dBTimy = null;
        private DBHraci dBHraci= null;
        private List<FutbalovyTim> timy = null;
        private FutbalovyTim domaci = null;
        private FutbalovyTim hostia = null;

        public event TeamsSelectedHandler OnTeamsSelected;

        public SelectForm(FutbalovyTim domaci, FutbalovyTim hostia)
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
            dBTimy = new DBTimy();
            dBHraci = new DBHraci();
            timy = dBTimy.GetTimy();
            if (timy.Count == 0)
                aktivovatButton.Enabled = false;
            else
            {
                domaciLB.Items.Add("    ");
                hostiaLB.Items.Add("    ");
                foreach (FutbalovyTim t in timy)
                {
                    domaciLB.Items.Add(t.NazovTimu);
                    hostiaLB.Items.Add(t.NazovTimu);
                }

                domaciLB.SelectedIndex = 0;
                hostiaLB.SelectedIndex = 0;
            }
            this.domaci = domaci;
            this.hostia = hostia;
        }

        private void ZrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AktivovatButton_Click(object sender, EventArgs e)
        {
            if (domaciLB.SelectedIndex == 0 )
            {
                this.domaci = null;
            }
            else
            {
                this.domaci = timy[domaciLB.SelectedIndex - 1];
                this.domaci.ZoznamHracov = dBHraci.GetHraciVTime(timy[domaciLB.SelectedIndex - 1].IdFutbalovyTim);
            }
            if (hostiaLB.SelectedIndex == 0)
            {
                this.hostia = null;
            }
            else
            {
                this.hostia = timy[hostiaLB.SelectedIndex - 1];
                this.hostia.ZoznamHracov = dBHraci.GetHraciVTime(timy[hostiaLB.SelectedIndex - 1].IdFutbalovyTim);
            }
            if (OnTeamsSelected != null)
                OnTeamsSelected(domaci, hostia);
            this.Close();
        }

        private void SelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
