using BC_Futbal.Setup;
using System;
using System.Windows.Forms;

namespace BC_Futbal.Forms
{
    public partial class FarbyPrezentacieForm : Form
    {
        private FarbyPrezentacie domaciFarby = null;
        private FarbyPrezentacie hostiaFarby = null;

        public FarbyPrezentacieForm(FarbyPrezentacie dom, FarbyPrezentacie hos)
        {
            InitializeComponent();

            domaciFarby = dom;
            hostiaFarby = hos;

            nadpisDomaciLabel.ForeColor = domaciFarby.GetNadpisFarba(); 
            nadpisHostiaLabel.ForeColor = hostiaFarby.GetNadpisFarba();

            podnadpisDomaciLabel.ForeColor = domaciFarby.GetZakladFarba();
            podnadpisHostiaLabel.ForeColor = hostiaFarby.GetZakladFarba();

            udajeDomaciLabel.ForeColor = domaciFarby.GetUdajeFarba();
            udajeHostiaLabel.ForeColor = hostiaFarby.GetUdajeFarba();

            cisloDomaciLabel.ForeColor = domaciFarby.GetCisloFarba();
            cisloHostiaLabel.ForeColor = hostiaFarby.GetCisloFarba();

            menoDomaciLabel.ForeColor = domaciFarby.GetMenoFarba();
            menoHostiaLabel.ForeColor = hostiaFarby.GetMenoFarba();
        }

        private void UlozitFarbyBtn_Click(object sender, EventArgs e)
        {
            domaciFarby.SetNadpisFarba(nadpisDomaciLabel.ForeColor);
            domaciFarby.SetZakladFarba(podnadpisDomaciLabel.ForeColor);
            domaciFarby.SetUdajeFarba(udajeDomaciLabel.ForeColor);
            domaciFarby.SetCisloFarba(cisloDomaciLabel.ForeColor);
            domaciFarby.SetMenoFarba(menoDomaciLabel.ForeColor);

            hostiaFarby.SetNadpisFarba(nadpisHostiaLabel.ForeColor);
            hostiaFarby.SetZakladFarba(podnadpisHostiaLabel.ForeColor);
            hostiaFarby.SetUdajeFarba(udajeHostiaLabel.ForeColor);
            hostiaFarby.SetCisloFarba(cisloHostiaLabel.ForeColor);
            hostiaFarby.SetMenoFarba(menoHostiaLabel.ForeColor);

            Close();
        }

        private void ZmenitDomaciNadpisBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                nadpisDomaciLabel.ForeColor = cd.Color;
        }
        private void ZmenitDomaciPodnadpisBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                podnadpisDomaciLabel.ForeColor = cd.Color;
        }
        private void ZmenitDomaciUdajeBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                udajeDomaciLabel.ForeColor = cd.Color;
        }
        private void ZmenitDomaciCisloBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                cisloDomaciLabel.ForeColor = cd.Color;
        }
        private void ZmenitDomaciMenoBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                menoDomaciLabel.ForeColor = cd.Color;
        }
        private void ZmenitHostiaNadpisBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                nadpisHostiaLabel.ForeColor = cd.Color;
        }
        private void ZmenitHostiaPodnadpisBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                podnadpisHostiaLabel.ForeColor = cd.Color;
        }
        private void ZmenitHostiaUdajeBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                udajeHostiaLabel.ForeColor = cd.Color;
        }
        private void ZmenitHostiaCisloBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                cisloHostiaLabel.ForeColor = cd.Color;
        }
        private void ZmenitHostiaMenoBtn_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                menoHostiaLabel.ForeColor = cd.Color;
        }        
    }
}
