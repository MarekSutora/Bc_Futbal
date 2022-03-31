using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LGR_Futbal.Databaza;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class RozhodcoviaForm : Form
    {
        private List<Rozhodca> rozhodcovia = null;
        private List<Rozhodca> vsetciRozhodcovia = null;

        public RozhodcoviaForm(List<Rozhodca> rozhodcovia, DBRozhodcovia dbr)
        {
            InitializeComponent();
            this.rozhodcovia = rozhodcovia;
            vsetciRozhodcovia = dbr.GetRozhodcovia();
            foreach (var item in vsetciRozhodcovia)
            {
                rozhodcoviaCheckListBox.Items.Add(item.Meno + " " + item.Priezvisko.ToUpper(), true);
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
                rozhodcoviaCheckListBox.SetItemChecked(i, true);
            }
        }
    }
}
