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
        private List<Rozhodca> allRozhodcovia = null;

        public RozhodcoviaForm(List<Rozhodca> rozhodcovia)
        {
            InitializeComponent();
            DBRozhodcovia dBRozhodcovia = new DBRozhodcovia();
            this.rozhodcovia = rozhodcovia;
            allRozhodcovia = dBRozhodcovia.GetRozhodcovia();
            foreach (var item in allRozhodcovia)
            {
                rozhodcoviaCheckListBox.Items.Add(item.Meno + " " + item.Priezvisko.ToUpper(), true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rozhodcoviaCheckListBox.Items.Count; i++)
            {
                rozhodcoviaCheckListBox.SetItemChecked(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rozhodcoviaCheckListBox.Items.Count; i++)
            {
                rozhodcoviaCheckListBox.SetItemChecked(i, true);
            }
        }

        private void zrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aktivovatButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < rozhodcoviaCheckListBox.Items.Count; i++)
            {
                if (rozhodcoviaCheckListBox.GetItemChecked(i))
                {
                    rozhodcovia.Add(allRozhodcovia[i]);
                }
            }
        }
    }
}
