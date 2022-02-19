using System;
using System.Text;
using System.Windows.Forms;

namespace LGR_Futbal.Forms
{
    public partial class TestovaciForm : Form
    {
        #region Atributy

        private TabulaForm formular;
        private Random generator;

        #endregion

        #region Konstruktor a metody

        public TestovaciForm(TabulaForm testovaci)
        {
            InitializeComponent();
            formular = testovaci;
            generator = new Random();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int minuta = generator.Next(0, 99);
            int sekunda = generator.Next(0, 60);
            StringBuilder sb = new StringBuilder();
            if (minuta < 10)
                sb.Append("0" + minuta.ToString() + ":");
            else
                sb.Append(minuta.ToString() + ":");
            if (sekunda < 10)
                sb.Append("0" + sekunda.ToString());
            else
                sb.Append(sekunda.ToString());

            if (minuta < 90)
                formular.SetCas(sb.ToString(), true);
            else
                formular.SetCas(sb.ToString(), false);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            formular.SetSkoreDomaci(generator.Next(0, 99));
            formular.SetSkoreHostia(generator.Next(0, 99));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            formular.SetPolcas(1, 0);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            formular.SetPolcas(2, 0);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            formular.SetPolcas(3, generator.Next(1, 5));
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            formular.SetPolcas(4, 0);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            formular.SetPolcas(0, 0);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            formular.Reset();
        }

        #endregion
    }
}
