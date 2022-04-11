using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LGR_Futbal.Databaza;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class RozhodcoviaForm : Form
    {
        private List<Rozhodca> rozhodcovia = null;
        private List<Rozhodca> vsetciRozhodcovia = null;
        private DBRozhodcovia dbRozhodcovia = null;

        public RozhodcoviaForm(List<Rozhodca> rozhodcovia, DBRozhodcovia dbr)
        {
            InitializeComponent();
            this.rozhodcovia = rozhodcovia;
            dbRozhodcovia = dbr;

        }

        private async void RozhodcoviaForm_Load(object sender, EventArgs e)
        {
            vsetciRozhodcovia = await dbRozhodcovia.GetRozhodcoviaAsync();
            foreach (var rozhodca in vsetciRozhodcovia)
            {
                rozhodcoviaCheckListBox.Items.Add(rozhodca.Meno + " " + rozhodca.Priezvisko.ToUpper(), false);
            }
        }

        private void AktivovatBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rozhodcoviaCheckListBox.Items.Count; i++)
            {
                if (rozhodcoviaCheckListBox.GetItemChecked(i))
                {
                    rozhodcovia.Add(vsetciRozhodcovia[i]);
                }
            }
            Close();
        }
        private void OznacitVsetkoBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rozhodcoviaCheckListBox.Items.Count; i++)
            {
                rozhodcoviaCheckListBox.SetItemChecked(i, true);
            }
        }
        private void ZrusitVsetkoBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rozhodcoviaCheckListBox.Items.Count; i++)
            {
                rozhodcoviaCheckListBox.SetItemChecked(i, false);
            }
        }
    }
}
