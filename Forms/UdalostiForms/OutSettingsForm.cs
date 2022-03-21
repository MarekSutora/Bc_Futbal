using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{

    public partial class OutSettingsForm : Form
    {
        public event UdalostPridanaHandler OnUdalostPridana;
        private Zapas zapas = null;
        private FutbalovyTim futbalovyTim = null;
        private List<Hrac> hrajuci = null;
        private bool nadstavenyCas = false;
        private int nadstavenaMinuta = 0;
        private int lastIndex = -1;
        private int minuta = -1;
        private int polcas = -1;
        private DateTime cas;
        private bool uspech = false;
        private bool domaci = false;

        public OutSettingsForm(FutbalovyTim tim, Zapas zapas, bool nadstavenyCas, int nadstavenaMinuta, int minuta, int polcas, bool domaci)
        {
            InitializeComponent();
            this.zapas = zapas;
            cas = DateTime.Now;
            this.futbalovyTim = tim;
            this.nadstavenaMinuta = nadstavenaMinuta;
            this.nadstavenyCas = nadstavenyCas;
            this.minuta = minuta;
            this.polcas = polcas;
            this.domaci = domaci;
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "";
            hrajuListView.Columns.Add(header);
            hrajuListView.HeaderStyle = ColumnHeaderStyle.None;
            hrajuListView.Columns[0].Width = 350;

            hrajuci = new List<Hrac>();
            if (tim != null)
            {
                for (int i = 0; i < tim.ZoznamHracov.Count; i++)
                {
                    Hrac h = tim.ZoznamHracov[i];
                    if (h.HraAktualnyZapas && !h.CervenaKarta)
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

                    }
                }
            }

            if (futbalovyTim == null)
                potvrditButton.Enabled = true;
            else
            {
                if (hrajuci.Count == 0)
                    potvrditButton.Enabled = false;
                else
                {
                    potvrditButton.Enabled = true;
                }
            }
        }

        private void potvrdit()
        {
            Hrac hrac = new Hrac();
            if (lastIndex != -1)
            {
                hrac = hrajuci[lastIndex];
            }
            Out _out = new Out();
            _out.Hrac = hrac;
            _out.Minuta = minuta;
            _out.NadstavenaMinuta = nadstavenaMinuta;
            _out.Predlzenie = nadstavenyCas ? 1 : 0;
            _out.Polcas = polcas;
            _out.AktualnyCas = cas;
            _out.NazovTimu = domaci ? zapas.NazovDomaci : zapas.NazovHostia;
            _out.IdFutbalovyTim = futbalovyTim != null ? futbalovyTim.IdFutbalovyTim : 0;
            zapas.Udalosti.Add(_out);
            uspech = true;
            this.Close();
        }

        private void potvrditButton_Click(object sender, EventArgs e)
        {
            potvrdit();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hrajuListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hrajuListView.SelectedItems.Count > 0)
            {
                for (int i = 0; i < hrajuListView.Items.Count; i++)
                {
                    hrajuListView.Items[i].BackColor = Color.White;
                }
                hrajuListView.Items[hrajuListView.SelectedIndices[0]].BackColor = Color.Green;
                lastIndex = hrajuListView.SelectedIndices[0];
                hrajuListView.SelectedItems.Clear();

            }
        }
        private void OutSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (uspech && OnUdalostPridana != null)
                OnUdalostPridana("OUT PRIDANÝ DO UDALOSTÍ");
        }

        private void hrajuListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            potvrdit();
        }
    }
}
