﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LGR_Futbal.Triedy;
using LGR_Futbal.Model;

namespace LGR_Futbal.Forms
{
    public partial class OutSettingsForm : Form
    {
        private Zapas zapas = null;
        private FutbalovyTim futbalovyTim = null;
        private List<Hrac> hrajuci = null;
        private bool nadstavenyCas = false;
        private int nadstavenaMinuta = 0;
        private int lastIndex = -1;
        private int minuta = -1;
        private int polcas = -1;
        private DateTime cas;
        public OutSettingsForm(FutbalovyTim tim, Zapas zapas, bool nadstavenyCas, int nadstavenaMinuta, int minuta, int polcas)
        {
            InitializeComponent();
            this.zapas = zapas;
            cas = DateTime.Now;
            this.futbalovyTim = tim;
            this.nadstavenaMinuta = nadstavenaMinuta;
            this.nadstavenyCas = nadstavenyCas;
            this.minuta = minuta;
            this.polcas = polcas;
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "";
            hrajuListView.Columns.Add(header);
            hrajuListView.HeaderStyle = ColumnHeaderStyle.None;
            hrajuListView.Columns[0].Width = 350;

            hrajuci = new List<Hrac>();

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

        private void potvrditButton_Click(object sender, EventArgs e)
        {
            Hrac hrac = new Hrac();
            if (lastIndex != -1)
            {
                hrac.IdHrac = hrajuci[lastIndex].IdHrac;
                hrac.Meno = hrajuci[lastIndex].Meno;
                hrac.Priezvisko = hrajuci[lastIndex].Priezvisko;
            }
            Out _out = new Out();
            _out.Hrac = hrac;
            _out.Minuta = minuta;
            _out.NadstavenaMinuta = nadstavenaMinuta;
            _out.Predlzenie = nadstavenyCas ? 1 : 0;
            _out.Polcas = polcas;
            _out.AktualnyCas = cas;
            zapas.Udalosti.Add(_out);

            //var w = new Form() { Size = new Size(0, 0) };
            //Task.Delay(TimeSpan.FromSeconds(1))
            //    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

            //MessageBox.Show(w, "Offside uspesne pridany", "Pridane!");


            this.Close();
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
    }
}
