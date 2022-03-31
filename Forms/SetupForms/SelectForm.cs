using LGR_Futbal.Properties;
using LGR_Futbal.Setup;
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
        public event TeamsSelectedHandler OnTeamsSelected;

        private DBTimy dbTimy = null;
        private DBHraci dbHraci= null;
        private List<FutbalovyTim> timy = null;
        private FutbalovyTim domaci = null;
        private FutbalovyTim hostia = null;

        public SelectForm(FutbalovyTim domaci, FutbalovyTim hostia, DBTimy dbt, DBHraci dbh)
        {
            InitializeComponent();

            dbTimy = dbt;
            dbHraci = dbh;
            timy = dbTimy.GetTimy();
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

        private void AktivovatButton_Click(object sender, EventArgs e)
        {
            if (domaciLB.SelectedIndex == 0 )
            {
                this.domaci = null;
            }
            else
            {
                this.domaci = timy[domaciLB.SelectedIndex - 1];
                this.domaci.ZoznamHracov = dbHraci.GetHraciVTime(timy[domaciLB.SelectedIndex - 1].IdFutbalovyTim);
            }
            if (hostiaLB.SelectedIndex == 0)
            {
                this.hostia = null;
            }
            else
            {
                this.hostia = timy[hostiaLB.SelectedIndex - 1];
                this.hostia.ZoznamHracov = dbHraci.GetHraciVTime(timy[hostiaLB.SelectedIndex - 1].IdFutbalovyTim);
            }
            OnTeamsSelected?.Invoke(domaci, hostia);
            this.Close();
        }

        private void ZrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
