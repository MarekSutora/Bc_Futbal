using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class UdalostiForm : Form
    {
        private Zapas zapas = null;
        private List<Udalost> udalosti = null;
        private string filePath;
        public UdalostiForm(Zapas zapas, string cd)
        {
            InitializeComponent();
            this.zapas = zapas;
            this.filePath = cd + "\\CSV\\" + zapas.NazovDomaci + "_" + zapas.DomaciSkore + "_" + zapas.HostiaSkore 
                + "_" + zapas.NazovHostia + zapas.DatumZapasu.Day + "_" + zapas.DatumZapasu.Month + "_" + zapas.DatumZapasu.Year + "_" + zapas.DatumZapasu.Hour 
                + zapas.DatumZapasu.Minute + "_" + zapas.DatumZapasu.Second + ".csv";

            skoreLabel.Text = zapas.NazovDomaci + " " + zapas.DomaciSkore + ":" + zapas.HostiaSkore + " " + zapas.NazovHostia;
            udalosti = zapas.Udalosti;
            for (int i = 0; i < udalosti.Count; i++)
            {
                string meno_priezvisko = string.Empty;
                string poznamka = string.Empty;
                string udalost = string.Empty; ;
                int minuta = (udalosti[i].Polcas - 1) * zapas.DlzkaPolcasu + udalosti[i].Minuta + 1;
                if (udalosti[i].GetType() == typeof(Gol))
                {
                    Gol gol = (Gol)udalosti[i];
                    meno_priezvisko = !gol.Strielajuci.Meno.Equals(string.Empty) ? gol.Strielajuci.CisloDresu + ". " + gol.Strielajuci.Meno + gol.Strielajuci.Priezvisko : "";
                    if (!gol.Asistujuci.Meno.Equals(string.Empty))
                        poznamka = "Asist: " + gol.Asistujuci.CisloDresu + ". " + gol.Asistujuci.Priezvisko;

                    udalost = "Gól";
                }
                if (udalosti[i].GetType() == typeof(Karta))
                {
                    Karta karta = (Karta)udalosti[i];
                    meno_priezvisko = karta.Hrac.CisloDresu + ". " + karta.Hrac.Meno + karta.Hrac.Priezvisko;
                    udalost = karta.IdKarta == 2 ? "Červená" : "Žltá";
                }
                if (udalosti[i].GetType() == typeof(Kop))
                {
                    Kop kop = (Kop)udalosti[i];

                    meno_priezvisko = !kop.Hrac.Meno.Equals(string.Empty) ? kop.Hrac.CisloDresu + ". " + kop.Hrac.Meno + kop.Hrac.Priezvisko : "";
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
                    meno_priezvisko = !offside.Hrac.Meno.Equals(string.Empty) ? offside.Hrac.CisloDresu + ". " + offside.Hrac.Meno + offside.Hrac.Priezvisko : "";
                    udalost = "Offside";
                }
                if (udalosti[i].GetType() == typeof(Out))
                {
                    Out _out = (Out)udalosti[i];
                    meno_priezvisko = !_out.Hrac.Meno.Equals(string.Empty) ? _out.Hrac.CisloDresu + ". " + _out.Hrac.Meno + _out.Hrac.Priezvisko : "";
                    udalost = "Outové vhadzovanie";
                }
                if (udalosti[i].GetType() == typeof(Striedanie))
                {
                    Striedanie striedanie = (Striedanie)udalosti[i];
                    //meno_priezvisko = striedanie.Striedany.Meno + striedanie.Striedany.Priezvisko;
                    poznamka = !striedanie.Striedany.Meno.Equals(string.Empty) ? "↓ " + striedanie.Striedany.CisloDresu + ". " + striedanie.Striedany.Priezvisko + " - " +
                        striedanie.Striedajuci.CisloDresu + striedanie.Striedajuci.Priezvisko + " ↑" : "";
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
                dataGridView1.Rows.Add(row);
            }
        }
        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        private void csvGenButton_Click(object sender, EventArgs e)
        {
            //before your loop
            

            using (var sw = new StreamWriter(File.Open(filePath, FileMode.OpenOrCreate), Encoding.UTF8))
            {
                //var csv = new StringBuilder();
                string line = string.Format("{0};{1}", "Tím 1: ", zapas.NazovDomaci);
                //csv.AppendLine(line);
                sw.WriteLine(line);
                line = string.Format("{0};{1}", "Tím 2:", zapas.NazovHostia);
                sw.WriteLine(line);
                //csv.AppendLine(line);
                line = string.Format("{0};{1}", "Dátum:", zapas.DatumZapasu.ToShortDateString());
                sw.WriteLine(line);
                //csv.AppendLine(line);
                line = string.Format("{0};{1}", "Skóre:", zapas.DomaciSkore + " : " + zapas.HostiaSkore);
                sw.WriteLine(line);
                //csv.AppendLine(line);
                line = string.Format("{0};{1}", "Dĺžka polčasu:", zapas.DlzkaPolcasu);
                sw.WriteLine(line);

                //csv.AppendLine(line);
                //csv.AppendLine("");
                //csv.AppendLine("");
                //csv.AppendLine("");
                line = string.Format("{0};{1};{2};{3};{4};{5};{6}", "ČAS", "POLČAS", "MINÚTA", "NADSTAVENÁ MINÚTA", "HRÁČ", "POZNÁMKA", "UDALOSŤ");
                //csv.AppendLine(line);
                sw.WriteLine(line);
                string cas = string.Empty;
                string polcas = string.Empty;
                string minuta = string.Empty;
                string nadst_min = string.Empty;
                string hrac = string.Empty;
                string poznamka = string.Empty;
                string udalost = string.Empty;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    cas = (string)dataGridView1.Rows[i].Cells[0].Value;
                    polcas = (string)dataGridView1.Rows[i].Cells[1].Value;
                    minuta = (string)dataGridView1.Rows[i].Cells[2].Value;
                    nadst_min = (string)dataGridView1.Rows[i].Cells[3].Value;
                    hrac = (string)dataGridView1.Rows[i].Cells[4].Value;
                    poznamka = (string)dataGridView1.Rows[i].Cells[5].Value;
                    udalost = (string)dataGridView1.Rows[i].Cells[6].Value;


                    var newLine = string.Format("{0};{1};{2};{3};{4};{5};{6}", cas, polcas, minuta, nadst_min, hrac, poznamka, udalost);
                    //csv.AppendLine(newLine);
                    sw.WriteLine(newLine);
                }
            }

            
            //File.WriteAllText(filePath, csv.ToString(), Encoding.Unicode);
           
        }
    }
}
