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
            Text = "Nastavenie kariet hráčov";
            hraci = ft.ZoznamHracov;
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "";
            HrajuciListView.Columns.Add(header);
            HrajuciListView.HeaderStyle = ColumnHeaderStyle.None;
            HrajuciListView.Columns[0].Width = 350;

            ColumnHeader header2 = new ColumnHeader();
            header.Text = "";
            header.Name = "";
            NahradniciListView.Columns.Add(header2);
            NahradniciListView.HeaderStyle = ColumnHeaderStyle.None;
            NahradniciListView.Columns[0].Width = 350;

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
                        HrajuciListView.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                    }
                    else
                    {
                        HrajuciListView.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                    }
                    if (h.ZltaKarta)
                    {
                        HrajuciListView.Items[hrajuci.Count - 1].BackColor = Color.Yellow;
                    }
                    else if (h.CervenaKarta)
                    {
                        HrajuciListView.Items[hrajuci.Count - 1].BackColor = Color.Red;
                    }
                }
                else if (h.Nahradnik)
                {
                    nahradnici.Add(h);
                    if (!h.CisloDresu.Equals(string.Empty))
                    {
                        NahradniciListView.Items.Add(h.CisloDresu + ". " + h.Meno + " " + h.Priezvisko.ToUpper());
                    }
                    else
                    {
                        NahradniciListView.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper());
                    }
                    if (h.ZltaKarta)
                    {
                        NahradniciListView.Items[nahradnici.Count - 1].BackColor = Color.Yellow;
                    }
                    else if (h.CervenaKarta)
                    {
                        NahradniciListView.Items[nahradnici.Count - 1].BackColor = Color.Red;
                    }
                }
            }
        }

        private void HrajuciListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HrajuciListView.SelectedItems.Count > 0)
            {
                if (HrajuciListView.Items[HrajuciListView.SelectedIndices[0]].BackColor == Color.White)
                {
                    HrajuciListView.Items[HrajuciListView.SelectedIndices[0]].BackColor = Color.Yellow;
                }
                else if (HrajuciListView.Items[HrajuciListView.SelectedIndices[0]].BackColor == Color.Yellow)
                {
                    HrajuciListView.Items[HrajuciListView.SelectedIndices[0]].BackColor = Color.Red;
                }
                else if (HrajuciListView.Items[HrajuciListView.SelectedIndices[0]].BackColor == Color.Red)
                {
                    HrajuciListView.Items[HrajuciListView.SelectedIndices[0]].BackColor = Color.White;
                }
                HrajuciListView.SelectedItems.Clear();
            }
        }
        private void NahradniciListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NahradniciListView.SelectedItems.Count > 0)
            {
                if (NahradniciListView.Items[NahradniciListView.SelectedIndices[0]].BackColor == Color.White)
                {
                    NahradniciListView.Items[NahradniciListView.SelectedIndices[0]].BackColor = Color.Yellow;
                }
                else if (NahradniciListView.Items[NahradniciListView.SelectedIndices[0]].BackColor == Color.Yellow)
                {
                    NahradniciListView.Items[NahradniciListView.SelectedIndices[0]].BackColor = Color.Red;
                }
                else if (NahradniciListView.Items[NahradniciListView.SelectedIndices[0]].BackColor == Color.Red)
                {
                    NahradniciListView.Items[NahradniciListView.SelectedIndices[0]].BackColor = Color.White;
                }
                NahradniciListView.SelectedItems.Clear();
            }
        }

        private void UlozitBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nahradnici.Count; i++)
            {
                if(NahradniciListView.Items[i].BackColor == Color.Yellow)
                {
                    nahradnici[i].ZltaKarta = true;
                } 
                else if (NahradniciListView.Items[i].BackColor == Color.Red)
                {
                    nahradnici[i].CervenaKarta = true;
                } 
                else if (NahradniciListView.Items[i].BackColor == Color.White)
                {
                    nahradnici[i].CervenaKarta = false;
                    nahradnici[i].ZltaKarta = false;
                }
            }
            for (int i = 0; i < hrajuci.Count; i++)
            {
                if (HrajuciListView.Items[i].BackColor == Color.Yellow)
                {
                    hrajuci[i].ZltaKarta = true;
                }
                else if (HrajuciListView.Items[i].BackColor == Color.Red)
                {
                    hrajuci[i].CervenaKarta = true;
                }
                else if (HrajuciListView.Items[i].BackColor == Color.White)
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
