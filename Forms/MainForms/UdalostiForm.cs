using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using BC_Futbal.Model;
using BC_Futbal.Databaza;

namespace BC_Futbal.Forms
{
    public partial class UdalostiForm : Form
    {
        private Zapas zapas = null;
        private List<Udalost> udalosti = null;
        private string adresar;
        private DBZapasy dbzapasy = null;
        public UdalostiForm(Zapas zapas, bool zDatabazi, DBZapasy dBZapasy)
        {
            InitializeComponent();
            this.zapas = zapas;
            polcas1CB.Checked = true;
            polcas2CB.Checked = true;
            timCB.Checked = true;
            tim2CB.Checked = true;
            priamyKopCB.Checked = true;
            nepriamyKopCB.Checked = true;
            rohovyKopCB.Checked = true;
            pokutovyKopCB.Checked = true;
            golCB.Checked = true;
            offsideCB.Checked = true;
            outCB.Checked = true;
            striedanieCB.Checked = true;
            zltaKartaCB.Checked = true;
            cervenaKartaCB.Checked = true;

            dbzapasy = dBZapasy;

            if (zapas.Domaci == null || zapas.Hostia == null || zDatabazi)
            {
                PridatDoDatabazyBtn.Enabled = false;
                PridatDoDatabazyBtn.Visible = false;
            }
            if (zDatabazi)
            {
                timCB.Text = zapas.NazovDomaci;
                tim2CB.Text = zapas.NazovHostia;
            }
            else
            {
                if (zapas.Domaci != null)
                {
                    zapas.NazovDomaci = zapas.Domaci.NazovTimu;
                    timCB.Text = zapas.NazovDomaci;
                }
                if (zapas.Hostia != null)
                {
                    zapas.NazovHostia = zapas.Hostia.NazovTimu;
                    tim2CB.Text = zapas.NazovHostia;
                }
            }

            

            skoreLabel.Text = zapas.NazovDomaci + " " + zapas.DomaciSkore + ":" + zapas.HostiaSkore + " " + zapas.NazovHostia;
            udalosti = zapas.Udalosti;

        }
        private void GenerovatCsvBtn_Click(object sender, EventArgs e)
        {
            adresar = Directory.GetCurrentDirectory() + "\\Files\\CSV\\" + zapas.NazovDomaci + "_" + zapas.DomaciSkore + "_" + zapas.HostiaSkore
                + "_" + zapas.NazovHostia + zapas.DatumZapasu.Day + "_" + zapas.DatumZapasu.Month + "_" + zapas.DatumZapasu.Year + "_" + zapas.DatumZapasu.Hour
                + zapas.DatumZapasu.Minute + "_" + zapas.DatumZapasu.Second + ".csv";

            bool uspech = false;
            try
            {
                using (var sw = new StreamWriter(File.Open(adresar, FileMode.Create), Encoding.UTF8))
                {
                    string line = string.Format("{0};{1}", "Tím 1: ", zapas.NazovDomaci);
                    sw.WriteLine(line);
                    line = string.Format("{0};{1}", "Tím 2: ", zapas.NazovHostia);
                    sw.WriteLine(line);
                    line = string.Format("{0};{1}", "Dátum: ", zapas.DatumZapasu.ToShortDateString());
                    sw.WriteLine(line);
                    line = string.Format("{0};{1}", "Skóre: ", zapas.DomaciSkore + " - " + zapas.HostiaSkore);
                    sw.WriteLine(line);

                    line = string.Format("{0};{1}", "Dĺžka polčasu:", zapas.DlzkaPolcasu);
                    sw.WriteLine(line);
                    sw.WriteLine("");
                    sw.WriteLine("");
                    line = string.Format("{0}", "Hráči Tím 1:");
                    sw.WriteLine(line);
                    for (int i = 0; i < zapas.Domaci.ZoznamHracov.Count; i++)
                    {
                        string meno_priezvisko = string.Empty;
                        string priradenost = string.Empty;
                        if (zapas.Domaci.ZoznamHracov[i].TypHraca == 'Z')
                        {
                            meno_priezvisko = zapas.Domaci.ZoznamHracov[i].CisloDresu + ". " + zapas.Domaci.ZoznamHracov[i].Meno + " " + zapas.Domaci.ZoznamHracov[i].Priezvisko;
                            priradenost = "Hrajúci";
                            line = string.Format("{0}, {1}", meno_priezvisko, priradenost);
                            sw.WriteLine(line);
                        }
                        else if (zapas.Domaci.ZoznamHracov[i].TypHraca == 'N')
                        {
                            meno_priezvisko = zapas.Domaci.ZoznamHracov[i].CisloDresu + ". " + zapas.Domaci.ZoznamHracov[i].Meno + " " + zapas.Domaci.ZoznamHracov[i].Priezvisko;
                            priradenost = "Nahradník";
                            line = string.Format("{0}, {1}", meno_priezvisko, priradenost);
                            sw.WriteLine(line);
                        }

                    }
                    line = string.Format("{0}", "Hráči Tím 2:");
                    sw.WriteLine(line);
                    for (int i = 0; i < zapas.Hostia.ZoznamHracov.Count; i++)
                    {
                        string meno_priezvisko = string.Empty;
                        string priradenost = string.Empty;
                        if (zapas.Hostia.ZoznamHracov[i].TypHraca == 'Z')
                        {
                            meno_priezvisko = zapas.Hostia.ZoznamHracov[i].CisloDresu + ". " + zapas.Hostia.ZoznamHracov[i].Meno + zapas.Hostia.ZoznamHracov[i].Priezvisko;
                            priradenost = "Hrajúci";
                            line = string.Format("{0}, {1}", meno_priezvisko, priradenost);
                            sw.WriteLine(line);
                        }
                        else if (zapas.Hostia.ZoznamHracov[i].TypHraca == 'N')
                        {
                            meno_priezvisko = zapas.Hostia.ZoznamHracov[i].CisloDresu + ". " + zapas.Hostia.ZoznamHracov[i].Meno + zapas.Hostia.ZoznamHracov[i].Priezvisko;
                            priradenost = "Nahradník";
                            line = string.Format("{0}, {1}", meno_priezvisko, priradenost);
                            sw.WriteLine(line);
                        }
                    }
                    line = string.Format("{0}", "Rozhodcovia:");
                    sw.WriteLine(line);
                    for (int i = 0; i < zapas.Rozhodcovia.Count; i++)
                    {
                        line = string.Format("{0}", zapas.Rozhodcovia[i].Meno + zapas.Rozhodcovia[i].Priezvisko);

                        sw.WriteLine(line);
                    }

                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("");
                    line = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", "ČAS", "POLČAS", "MINÚTA", "NADSTAVENÁ MINÚTA", "HRÁČ", "POZNÁMKA", "UDALOSŤ", "TÍM");

                    sw.WriteLine(line);
                    string cas = string.Empty;
                    string polcas = string.Empty;
                    string minuta = string.Empty;
                    string nadst_min = string.Empty;
                    string hrac = string.Empty;
                    string poznamka = string.Empty;
                    string udalost = string.Empty;
                    string tim = string.Empty;

                    for (int i = 0; i < ZapasUdalostiDataGrid.Rows.Count; i++)
                    {
                        cas = (string)ZapasUdalostiDataGrid.Rows[i].Cells[0].Value;
                        polcas = (string)ZapasUdalostiDataGrid.Rows[i].Cells[1].Value;
                        minuta = (string)ZapasUdalostiDataGrid.Rows[i].Cells[2].Value;
                        nadst_min = (string)ZapasUdalostiDataGrid.Rows[i].Cells[3].Value;
                        hrac = (string)ZapasUdalostiDataGrid.Rows[i].Cells[4].Value;
                        poznamka = (string)ZapasUdalostiDataGrid.Rows[i].Cells[5].Value;
                        udalost = (string)ZapasUdalostiDataGrid.Rows[i].Cells[6].Value;
                        tim = (string)ZapasUdalostiDataGrid.Rows[i].Cells[7].Value;

                        var newLine = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", cas, polcas, minuta, nadst_min, hrac, poznamka, udalost, tim);
                        sw.WriteLine(newLine);
                    }
                    uspech = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Súbor sa nepodarilo vygenerovať", "LGR_Futbal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (uspech)
                    MessageBox.Show("Súbor úspešne vygenerovaný", "LGR_Futbal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void UdalostiForm_Shown(object sender, EventArgs e)
        {
            Filtruj();
        }

        private void AktivovatFilterBtn_Click(object sender, EventArgs e)
        {
            Filtruj();
        }

        private void Filtruj()
        {
            string aktualnyCas, polcas, nadstMin, meno_priezvisko, poznamka, udalost, minuta, nazovTimu;

            ZapasUdalostiDataGrid.Rows.Clear();
            ZapasUdalostiDataGrid.Refresh();

            for (int i = 0; i < udalosti.Count; i++)
            {
                bool pridat = false;
                if (udalosti[i].SplnaFilter(polcas1CB.Checked, polcas2CB.Checked, timCB.Checked, tim2CB.Checked, zapas.NazovDomaci, zapas.NazovHostia))
                {
                    meno_priezvisko = poznamka = udalost = string.Empty;
                    aktualnyCas = udalosti[i].AktualnyCas.ToLongTimeString();
                    polcas = udalosti[i].Polcas.ToString();
                    nadstMin = udalosti[i].NadstavenaMinuta.ToString();
                    minuta = ((udalosti[i].Polcas - 1) * zapas.DlzkaPolcasu + udalosti[i].Minuta + 1).ToString();
                    nazovTimu = udalosti[i].NazovTimu;

                    if (udalosti[i].Typ == 1 && golCB.Checked)
                    {
                        pridat = true;
                        Gol gol = (Gol)udalosti[i];
                        meno_priezvisko = !gol.Strielajuci.Meno.Equals(string.Empty) ? gol.Strielajuci.CisloDresu + ". " + gol.Strielajuci.Meno + gol.Strielajuci.Priezvisko : "";
                        if (!gol.Asistujuci.Meno.Equals(string.Empty))
                            poznamka = "Asist: " + gol.Asistujuci.CisloDresu + ". " + gol.Asistujuci.Priezvisko;

                        udalost = "Gól";
                        poznamka = gol.TypGolu == 2 ? "Z pokutového kopu" : poznamka;
                    }

                    if (udalosti[i].Typ == 2)
                    {
                        Karta karta = (Karta)udalosti[i];
                        meno_priezvisko = karta.Hrac.CisloDresu + ". " + karta.Hrac.Meno + " " + karta.Hrac.Priezvisko;
                        if (karta.TypKarty == 'C')
                        {
                            if (cervenaKartaCB.Checked)
                            {
                                udalost = "Červená karta";
                                pridat = true;
                            }
                        }
                        else
                        {
                            if (zltaKartaCB.Checked)
                            {
                                udalost = "Žltá karta";
                                pridat = true;
                            }

                        }
                    }
                    if (udalosti[i].Typ == 3)
                    {
                        Kop kop = (Kop)udalosti[i];

                        meno_priezvisko = !kop.Hrac.Meno.Equals(string.Empty) ? kop.Hrac.CisloDresu + ". " + kop.Hrac.Meno + " " + kop.Hrac.Priezvisko : "";
                        switch (kop.IdTypKopu)
                        {
                            case 1:
                                if (priamyKopCB.Checked)
                                {
                                    udalost = "Priamy kop";
                                    pridat = true;
                                }
                                break;
                            case 2:
                                if (nepriamyKopCB.Checked)
                                {
                                    udalost = "Nepriamy kop";
                                    pridat = true;
                                }
                                break;
                            case 3:
                                if (rohovyKopCB.Checked)
                                {
                                    udalost = "Rohový kop";
                                    pridat = true;
                                }
                                break;
                            case 4:
                                if (pokutovyKopCB.Checked)
                                {
                                    udalost = "Pokutový kop";
                                    pridat = true;
                                }
                                break;
                            default:
                                udalost = "CHYBA!";
                                break;
                        }
                    }
                    if (udalosti[i].Typ == 4 && offsideCB.Checked)
                    {
                        Offside offside = (Offside)udalosti[i];
                        meno_priezvisko = !offside.Hrac.Meno.Equals(string.Empty) ? offside.Hrac.CisloDresu + ". " + offside.Hrac.Meno + " " + offside.Hrac.Priezvisko : "";
                        pridat = true;
                        udalost = "Offside";
                    }
                    if (udalosti[i].Typ == 5 && outCB.Checked)
                    {
                        Out _out = (Out)udalosti[i];
                        pridat = true;
                        meno_priezvisko = !_out.Hrac.Meno.Equals(string.Empty) ? _out.Hrac.CisloDresu + ". " + _out.Hrac.Meno + " " + _out.Hrac.Priezvisko : "";
                        udalost = "Outové vhadzovanie";
                    }
                    if (udalosti[i].Typ == 6 && striedanieCB.Checked)
                    {
                        Striedanie striedanie = (Striedanie)udalosti[i];
                        pridat = true;
                        poznamka = !striedanie.Striedany.Meno.Equals(string.Empty) ? "↓ " + striedanie.Striedany.CisloDresu + ". " + striedanie.Striedany.Priezvisko + " - " +
                            striedanie.Striedajuci.CisloDresu + ". " + striedanie.Striedajuci.Priezvisko + " ↑" : "";
                        udalost = "Striedanie";
                    }

                    var row = new string[]
                    {
                    aktualnyCas,
                    polcas,
                    minuta,
                    nadstMin,
                    meno_priezvisko,
                    poznamka,
                    udalost,
                    nazovTimu
                    };

                    if (pridat)
                        ZapasUdalostiDataGrid.Rows.Add(row);
                }
            }
            ZapasUdalostiDataGrid.Focus();
        }

        private async void PridatDoDatabazyBtn_Click(object sender, EventArgs e)
        {
            bool uspech = false;
            try
            {
                await Task.Run(() =>
                {
                    dbzapasy.InsertZapas(zapas);
                    uspech = true;
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "LGR_Futbal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (uspech)
                    MessageBox.Show("Zápas úšpesne pridaný do databázy", "LGR_Futbal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
