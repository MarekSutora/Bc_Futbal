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
using LGR_Futbal.Triedy;

namespace LGR_Futbal.Forms
{
    public partial class NezaradeniHraciForm : Form
    {
        private int IdTimu;
        private List<Hrac> hraci = null;
        private List<Hrac> hraciNaPridanie = null;
        private Databaza dbs = null;
        public NezaradeniHraciForm(int id, Databaza databaza)
        {
            Text = "Pridanie nezaradených hráčov do tímu";
            InitializeComponent();
            IdTimu = id;
            dbs = databaza;
            hraci = dbs.GetNezaradeniHraci();
            hraciNaPridanie = new List<Hrac>();
            foreach (Hrac h in hraci)
            {
                if (!h.CisloDresu.Equals(string.Empty))
                {
                    checkedListBox1.Items.Add(h.CisloDresu + ". "
                        + h.Meno + " " + h.Priezvisko.ToUpper(), false);
                }
                else
                {
                    checkedListBox1.Items.Add(h.Meno + " " + h.Priezvisko.ToUpper(), false);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void aktivovatButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    hraciNaPridanie.Add(hraci[i]);
                }
            }
            try
            {
                dbs.pridajHracovDoTimu(IdTimu, hraciNaPridanie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "LGR_futbal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.Close();
            }
            
        }
    }
}
