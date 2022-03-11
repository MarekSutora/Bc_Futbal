using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class UdalostiForm : Form
    {
        private Zapas zapas = null;
        private List<Udalost> udalosti = null;
        public UdalostiForm(Zapas zapas)
        {
            InitializeComponent();
            this.zapas = zapas;
            udalosti = zapas.Udalosti;
            listView1.Items.Clear();
            for (int i = 0; i < udalosti.Count; i++)
            {
                string meno_priezvisko = string.Empty;
                string poznamka = string.Empty;
                string udalost = string.Empty; ;
                int minuta = (udalosti[i].Polcas - 1) * zapas.DlzkaPolcasu + udalosti[i].Minuta + 1;
                if (udalosti[i].GetType() == typeof(Gol))
                {
                    Gol gol = (Gol)udalosti[i];
                    meno_priezvisko = gol.Strielajuci.Meno + gol.Strielajuci.Priezvisko;
                    udalost = "Gól";
                }
                if (udalosti[i].GetType() == typeof(Karta))
                {
                    Karta karta = (Karta)udalosti[i];
                    meno_priezvisko = karta.Hrac.Meno + karta.Hrac.Priezvisko;
                    udalost = karta.IdKarta == 2 ? "Červená" : "Žltá";
                }
                if (udalosti[i].GetType() == typeof(Kop))
                {
                    Kop kop = (Kop)udalosti[i];
                    meno_priezvisko = kop.Hrac.Meno + kop.Hrac.Priezvisko;
                    switch (kop.IdTypKopu)
                    {
                        case 1:
                            udalost = "Priamy kop";
                            break;
                        case 2:
                            udalost = "Nepriamy kop";
                            break;
                        case 3:
                            udalost = "Rohový kop";
                            break;
                        case 4:
                            udalost = "Pokutový kop";
                            break;
                        default:
                            udalost = "CHYBA!";
                            break;
                    }
                }
                if (udalosti[i].GetType() == typeof(Offside))
                {
                    Offside offside = (Offside)udalosti[i];
                    meno_priezvisko = offside.Hrac.Meno + offside.Hrac.Priezvisko;
                    udalost = "Offside";
                }
                if (udalosti[i].GetType() == typeof(Out))
                {
                    Out _out = (Out)udalosti[i];
                    meno_priezvisko = _out.Hrac.Meno + _out.Hrac.Priezvisko;
                    udalost = "Outové vhadzovanie";
                }
                if (udalosti[i].GetType() == typeof(Striedanie))
                {
                    Striedanie striedanie = (Striedanie)udalosti[i];
                    meno_priezvisko = striedanie.Striedany.Meno + striedanie.Striedany.Priezvisko;
                    udalost = "Striedanie";
                }

                var row = new string[]
                {
                    udalosti[i].AktualnyCas.ToLongTimeString(),
                    udalosti[i].Polcas.ToString(),
                    minuta.ToString(),
                    udalosti[i].NadstavenaMinuta.ToString(),
                    meno_priezvisko,
                    poznamka,
                    udalost
                };
                listView1.Items.Add(new ListViewItem(row));
            }
        }
    }
}
