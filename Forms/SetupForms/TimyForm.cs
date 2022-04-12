using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BC_Futbal.Databaza;
using BC_Futbal.Model;

namespace BC_Futbal.Forms
{
    public partial class TimyForm : Form
    {
        public event TimyVybraneHandler OnTimyVybrane;

        private bool aktivovatStlaceny = false;
        private DBTimy dbTimy = null;
        private DBHraci dbHraci = null;
        private List<FutbalovyTim> timy = null;
        private FutbalovyTim domaci = null;
        private FutbalovyTim hostia = null;

        public TimyForm(FutbalovyTim domaci, FutbalovyTim hostia, DBTimy dbt, DBHraci dbh)
        {
            InitializeComponent();

            dbTimy = dbt;
            dbHraci = dbh;
            this.domaci = domaci;
            this.hostia = hostia;
        }

        private async void TimyForm_Load(object sender, EventArgs e)
        {
            timy = await dbTimy.GetTimyAsync();
            timy.Sort((x, y) => x.NazovTimu.CompareTo(y.NazovTimu));

            if (timy.Count == 0)
                AktivovatBtn.Enabled = false;
            else
            {
                foreach (FutbalovyTim t in timy)
                {
                    domaciLB.Items.Add(t.NazovTimu);
                    hostiaLB.Items.Add(t.NazovTimu);
                }
                domaciLB.SelectedIndex = 0;
                hostiaLB.SelectedIndex = 0;
            }           
        }

        private void AktivovatBtn_Click(object sender, EventArgs e)
        {
            aktivovatStlaceny = true;          
            Close();
        }

        private void OdznacenieVsetkeho(object sender, EventArgs e)
        {
            domaciLB.ClearSelected();
            hostiaLB.ClearSelected();
        }

        private async void TimyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (aktivovatStlaceny)
            {
                if (domaciLB.SelectedIndex == -1)
                {
                    domaci = null;
                }
                else
                {
                    domaci = timy[domaciLB.SelectedIndex];
                    domaci.ZoznamHracov = await dbHraci.GetHraciVTime(timy[domaciLB.SelectedIndex].IdFutbalovyTim);
                }
                if (hostiaLB.SelectedIndex == -1)
                {
                    hostia = null;
                }
                else
                {
                    hostia = timy[hostiaLB.SelectedIndex];
                    hostia.ZoznamHracov = await dbHraci.GetHraciVTime(timy[hostiaLB.SelectedIndex].IdFutbalovyTim);
                }
                OnTimyVybrane?.Invoke(domaci, hostia);
            }
        }
    }
}
