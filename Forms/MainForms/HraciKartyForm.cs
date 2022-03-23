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
    public partial class HraciKartyForm : Form
    {
        private List<Hrac> hraci = null;
        private List<Hrac> nahradnici = null;
        private List<Hrac> hrajuci = null;
        
        public HraciKartyForm(FutbalovyTim ft)
        {
            InitializeComponent();
            this.Text = "Nastavenie kariet hráčov";
            this.hraci = ft.ZoznamHracov;
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "";
            hrajuListView.Columns.Add(header);
            hrajuListView.HeaderStyle = ColumnHeaderStyle.None;
            hrajuListView.Columns[0].Width = 350;

            ColumnHeader header2 = new ColumnHeader();
            header.Text = "";
            header.Name = "";
            nahradniciListView.Columns.Add(header2);
            nahradniciListView.HeaderStyle = ColumnHeaderStyle.None;
            nahradniciListView.Columns[0].Width = 350;

            nahradnici = new List<Hrac>();
            hrajuci = new List<Hrac>();

            for (int i = 0; i < hraci.Count; i++)
            {
                Hrac h = hraci[i];
                if (h.HraAktualnyZapas)
                {
                    hrajuci.Add(h);
                    if (!h.CisloDresu.Equals(string.Empty))
                    {                       
                        hrajuListView.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                    }
                    else
                    {
                        hrajuListView.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                    }
                    if (h.ZltaKarta)
                    {
                        hrajuListView.Items[hrajuci.Count - 1].BackColor = Color.Yellow;
                    }
                    else if (h.CervenaKarta)
                    {
                        hrajuListView.Items[hrajuci.Count - 1].BackColor = Color.Red;
                    }
                }
                else if (h.Nahradnik)
                {
                    nahradnici.Add(h);
                    if (!h.CisloDresu.Equals(string.Empty))
                    {
                        nahradniciListView.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                    }
                    else
                    {
                        nahradniciListView.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                    }
                    if (h.ZltaKarta)
                    {
                        nahradniciListView.Items[nahradnici.Count - 1].BackColor = Color.Yellow;
                    }
                    else if (h.CervenaKarta)
                    {
                        nahradniciListView.Items[nahradnici.Count - 1].BackColor = Color.Red;
                    }
                }
            }
        }

        private void hrajuListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hrajuListView.SelectedItems.Count > 0)
            {
                if (hrajuListView.Items[hrajuListView.SelectedIndices[0]].BackColor == Color.White)
                {
                    hrajuListView.Items[hrajuListView.SelectedIndices[0]].BackColor = Color.Yellow;
                }
                else if (hrajuListView.Items[hrajuListView.SelectedIndices[0]].BackColor == Color.Yellow)
                {
                    hrajuListView.Items[hrajuListView.SelectedIndices[0]].BackColor = Color.Red;
                }
                else if (hrajuListView.Items[hrajuListView.SelectedIndices[0]].BackColor == Color.Red)
                {
                    hrajuListView.Items[hrajuListView.SelectedIndices[0]].BackColor = Color.White;
                }
                hrajuListView.SelectedItems.Clear();
            }
        }
        private void nahradniciListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nahradniciListView.SelectedItems.Count > 0)
            {
                if (nahradniciListView.Items[nahradniciListView.SelectedIndices[0]].BackColor == Color.White)
                {
                    nahradniciListView.Items[nahradniciListView.SelectedIndices[0]].BackColor = Color.Yellow;
                }
                else if (nahradniciListView.Items[nahradniciListView.SelectedIndices[0]].BackColor == Color.Yellow)
                {
                    nahradniciListView.Items[nahradniciListView.SelectedIndices[0]].BackColor = Color.Red;
                }
                else if (nahradniciListView.Items[nahradniciListView.SelectedIndices[0]].BackColor == Color.Red)
                {
                    nahradniciListView.Items[nahradniciListView.SelectedIndices[0]].BackColor = Color.White;
                }
                nahradniciListView.SelectedItems.Clear();
            }
        }

        private void zrusitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aktivovatButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nahradnici.Count; i++)
            {
                if(nahradniciListView.Items[i].BackColor == Color.Yellow)
                {
                    nahradnici[i].ZltaKarta = true;
                } 
                else if (nahradniciListView.Items[i].BackColor == Color.Red)
                {
                    nahradnici[i].CervenaKarta = true;
                } 
                else if (nahradniciListView.Items[i].BackColor == Color.White)
                {
                    nahradnici[i].CervenaKarta = false;
                    nahradnici[i].ZltaKarta = false;
                }
            }
            for (int i = 0; i < hrajuci.Count; i++)
            {
                if (hrajuListView.Items[i].BackColor == Color.Yellow)
                {
                    hrajuci[i].ZltaKarta = true;
                }
                else if (hrajuListView.Items[i].BackColor == Color.Red)
                {
                    hrajuci[i].CervenaKarta = true;
                }
                else if (hrajuListView.Items[i].BackColor == Color.White)
                {
                    hrajuci[i].CervenaKarta = false;
                    hrajuci[i].ZltaKarta = false;
                }
            }
            for (int i = 0; i < hraci.Count; i++)
            {
                for (int j = 0; j < nahradnici.Count; j++)
                {
                    if(hraci[i].IdHrac == nahradnici[j].IdHrac)
                    {
                        hraci[i].ZltaKarta = nahradnici[j].ZltaKarta;
                        hraci[i].CervenaKarta = nahradnici[j].CervenaKarta;
                    }
                }
                for (int j = 0; j < hrajuci.Count; j++)
                {
                    if(hraci[i].IdHrac == hrajuci[j].IdHrac)
                    {
                        hraci[i].ZltaKarta = hrajuci[j].ZltaKarta;
                        hraci[i].CervenaKarta = hrajuci[j].CervenaKarta;
                    }      
                }
            }
            this.Close();
        }

        
    }
}
