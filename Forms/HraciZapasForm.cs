using LGR_Futbal.Properties;
using LGR_Futbal.Triedy;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LGR_Futbal.Model;
using System.Linq;

namespace LGR_Futbal.Forms
{
    public partial class HraciZapasForm : Form
    {
        #region Atributy

        private FutbalovyTim aktualnyTim = null;
        private List<Hrac> hraci;
        private Databaza databaza = null;

        #endregion

        #region Konstruktor a metody

        public HraciZapasForm(FutbalovyTim t, Databaza databaza)
        {
            InitializeComponent();

            if (Settings.Default.Jazyk == 1)
            {
                this.Text = "Výběr hráčů na zápas";
                label1.Text = "Základní jedenáctka:";
                aktivovatButton.Text = aktivovatButton.Text.Replace("Uložiť", "Uložit");
                aktivovatButton.Text = aktivovatButton.Text.Replace("zmeny", "změny");
                zrusitButton.Text = zrusitButton.Text.Replace("Zrušiť", "Zrušit");

                oznacitVsetkoButton.Text = oznacitVsetkoButton.Text.Replace("Označiť", "Označit");
                oznacitVsetkoButton.Text = oznacitVsetkoButton.Text.Replace("všetko", "vše  ");
                button1.Text = button1.Text.Replace("Označiť", "Označit");
                button1.Text = button1.Text.Replace("všetko", "vše  ");

                zrusOznaceniaButton.Text = zrusOznaceniaButton.Text.Replace("Zrušiť", "Zrušit");
                zrusOznaceniaButton.Text = zrusOznaceniaButton.Text.Replace("všetko", "vše  ");
                button2.Text = button2.Text.Replace("Zrušiť", "Zrušit");
                button2.Text = button2.Text.Replace("všetko", "vše  ");
            }
            this.databaza = databaza;
            aktualnyTim = t;
            hraci = t.ZoznamHracov;
            hraci = hraci.OrderBy(o => o.Priezvisko).ToList();
            this.Text = this.Text + Translate(1) + aktualnyTim.NazovTimu;

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
            // Kontrola spravnosti nastavenia udajov
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
                }
                this.Close();
            }
            else
                MessageBox.Show(Translate(2), "LGR Futbal", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ZrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OznacitVsetkoButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zoznamCheckListBox.Items.Count; i++)
            {
                zoznamCheckListBox.SetItemChecked(i, true);
            }
        }

        private void ZrusOznaceniaButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zoznamCheckListBox.Items.Count; i++)
            {
                zoznamCheckListBox.SetItemChecked(i, false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zoznamCheckListBox.Items.Count; i++)
            {
                nahradniciCheckListBox.SetItemChecked(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < zoznamCheckListBox.Items.Count; i++)
            {
                nahradniciCheckListBox.SetItemChecked(i, false);
            }
        }

        private void HraciZapasForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private string Translate(int cisloVety)
        {
            if (Settings.Default.Jazyk == 0)
            {
                switch(cisloVety)
                {
                    case 1: return " - tím ";
                    case 2: return "Jeden alebo viac hráčov nemá korektne nastavené atribúty!\nNemôže byť súčasne na ihrisku aj náhradník!";
                }
            }
            else if (Settings.Default.Jazyk == 1)
            {
                switch (cisloVety)
                {
                    case 1: return " - tým ";
                    case 2: return "Jeden nebo více hráčů nemá korektně nastaveny atributy!\nNemôže být současně na hřišti i náhradník!";
                }
            }

            return string.Empty;
        }

        #endregion
    }
}
