using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class HraciZapasForm : Form
    {
        private FutbalovyTim futbalovyTim = null;
        private List<Hrac> hraci = null;
        public HraciZapasForm(FutbalovyTim ft)
        {
            InitializeComponent();

            futbalovyTim = ft;
            hraci = ft.ZoznamHracov;
            hraci = hraci.OrderBy(o => o.Priezvisko).ToList();
            this.Text = this.Text + " - tím " + futbalovyTim.NazovTimu;

            int pocet = 0;
            foreach (Hrac h in hraci)
            {
                pocet++;
                if (!h.CisloDresu.Equals(string.Empty))
                {
                    zakladCheckListBox.Items.Add(h.CisloDresu + ". "
                        + h.Meno + " " + h.Priezvisko.ToUpper(), h.HraAktualnyZapas);
                    nahradniciCheckListBox.Items.Add(h.CisloDresu + ". "
                        + h.Meno + " " + h.Priezvisko.ToUpper(), h.HraAktualnyZapas);
                }
                else
                {
                    zakladCheckListBox.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper(), h.HraAktualnyZapas);
                    nahradniciCheckListBox.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper(), h.HraAktualnyZapas);
                }
            }

            for (int i = 0; i < pocet; i++)
            {
                zakladCheckListBox.SetItemChecked(i, hraci[i].HraAktualnyZapas);
                nahradniciCheckListBox.SetItemChecked(i, hraci[i].Nahradnik);
            }
        }

        private void AktivovatBtn_Click(object sender, EventArgs e)
        {
            bool vsetkoVporiadku = true;
            for (int i = 0; i < hraci.Count; i++)
            {
                if ((zakladCheckListBox.GetItemChecked(i)) && (nahradniciCheckListBox.GetItemChecked(i)))
                {
                    vsetkoVporiadku = false;
                    break;
                }
            }
            if (vsetkoVporiadku)
            {
                for (int i = 0; i < hraci.Count; i++)
                {
                    hraci[i].HraAktualnyZapas = zakladCheckListBox.GetItemChecked(i);
                    hraci[i].Nahradnik = nahradniciCheckListBox.GetItemChecked(i);
                    if (zakladCheckListBox.GetItemChecked(i))
                    {
                        hraci[i].TypHraca = 'Z';
                    } 
                    else if (nahradniciCheckListBox.GetItemChecked(i))
                    {
                        hraci[i].TypHraca = 'N';
                    }
                }
                Close();
            }
            else
                MessageBox.Show("Jeden alebo viac hráčov nemá korektne nastavené atribúty!\nNemôže byť súčasne na ihrisku aj náhradník!", "FutbalApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void OznacitZakladBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zakladCheckListBox.Items.Count; i++)
            {
                zakladCheckListBox.SetItemChecked(i, true);
            }
        }

        private void ZrusitZakladBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zakladCheckListBox.Items.Count; i++)
            {
                zakladCheckListBox.SetItemChecked(i, false);
            }
        }

        private void OznacitNahradniciBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zakladCheckListBox.Items.Count; i++)
            {
                nahradniciCheckListBox.SetItemChecked(i, true);
            }
        }

        private void ZrusitNahradniciBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zakladCheckListBox.Items.Count; i++)
            {
                nahradniciCheckListBox.SetItemChecked(i, false);
            }
        }
    }
}
