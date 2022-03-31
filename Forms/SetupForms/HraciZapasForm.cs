using LGR_Futbal.Properties;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class HraciZapasForm : Form
    {

        private FutbalovyTim aktualnyTim = null;
        private List<Hrac> hraci = null;

        public HraciZapasForm(FutbalovyTim ft)
        {
            InitializeComponent();

            aktualnyTim = ft;
            hraci = ft.ZoznamHracov;
            hraci = hraci.OrderBy(o => o.Priezvisko).ToList();
            this.Text = this.Text + " - tím " + aktualnyTim.NazovTimu;

            int pocet = 0;
            foreach (Hrac h in hraci)
            {
                pocet++;
                if (!h.CisloDresu.Equals(string.Empty))
                {
                    zoznamCheckListBox.Items.Add(h.CisloDresu + ". "
                        + h.Meno + " " + h.Priezvisko.ToUpper(), h.HraAktualnyZapas);
                    nahradniciCheckListBox.Items.Add(h.CisloDresu + ". "
                        + h.Meno + " " + h.Priezvisko.ToUpper(), h.HraAktualnyZapas);
                }
                else
                {
                    zoznamCheckListBox.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper(), h.HraAktualnyZapas);
                    nahradniciCheckListBox.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper(), h.HraAktualnyZapas);
                }
            }

            for (int i = 0; i < pocet; i++)
            {
                zoznamCheckListBox.SetItemChecked(i, hraci[i].HraAktualnyZapas);
                nahradniciCheckListBox.SetItemChecked(i, hraci[i].Nahradnik);
            }
        }

        private void AktivovatButton_Click(object sender, EventArgs e)
        {
            bool vsetkoVporiadku = true;
            for (int i = 0; i < hraci.Count; i++)
            {
                if ((zoznamCheckListBox.GetItemChecked(i)) && (nahradniciCheckListBox.GetItemChecked(i)))
                {
                    vsetkoVporiadku = false;
                    break;
                }
            }
            if (vsetkoVporiadku)
            {
                for (int i = 0; i < hraci.Count; i++)
                {
                    hraci[i].HraAktualnyZapas = zoznamCheckListBox.GetItemChecked(i);
                    hraci[i].Nahradnik = nahradniciCheckListBox.GetItemChecked(i);
                    if (zoznamCheckListBox.GetItemChecked(i))
                    {
                        hraci[i].Priradeny = 'Z';
                    } 
                    else if (nahradniciCheckListBox.GetItemChecked(i))
                    {
                        hraci[i].Priradeny = 'N';
                    }
                }
                this.Close();
            }
            else
                MessageBox.Show("Jeden alebo viac hráčov nemá korektne nastavené atribúty!\nNemôže byť súčasne na ihrisku aj náhradník!", "LGR Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void OznacitZakladniBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zoznamCheckListBox.Items.Count; i++)
            {
                zoznamCheckListBox.SetItemChecked(i, true);
            }
        }

        private void ZrusitZakladniBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zoznamCheckListBox.Items.Count; i++)
            {
                zoznamCheckListBox.SetItemChecked(i, false);
            }
        }

        private void OznacitNahradniciBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zoznamCheckListBox.Items.Count; i++)
            {
                nahradniciCheckListBox.SetItemChecked(i, true);
            }
        }

        private void ZrusitNahradniciBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zoznamCheckListBox.Items.Count; i++)
            {
                nahradniciCheckListBox.SetItemChecked(i, false);
            }
        }
    }
}
