using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace LGR_Futbal.Setup
{
    public static class LayoutSetter
    {


        public static void ZobrazNaDruhejObrazovke(Form form)
        {
            Screen primarnyDisplej = Screen.AllScreens.ElementAtOrDefault(0);
            Screen sekundarnyDisplej = Screen.AllScreens.FirstOrDefault(s => s != primarnyDisplej) ?? primarnyDisplej;
            form.Left = sekundarnyDisplej.WorkingArea.Left;
            form.Top = sekundarnyDisplej.WorkingArea.Top;
        }

        public static void NastavVelkostiElementov(Form form, float pomer)
        {
            Label l;
            Panel p;
            Button b;
            foreach (object item in form.Controls)
            {
                if (item.GetType() == typeof(Label))
                {
                    l = (Label)item;
                    l.Font = new Font(l.Font.Name, (float)Math.Floor(l.Font.Size * pomer));
                }
                else if (item.GetType() == typeof(Panel))
                {
                    p = (Panel)item;
                    foreach (object prvok in p.Controls)
                    {
                        if (prvok.GetType() == typeof(Label))
                        {
                            l = (Label)prvok;
                            l.Font = new Font(l.Font.Name, (float)Math.Floor(l.Font.Size * pomer));
                        }
                    }
                }
                else if (item.GetType() == typeof(Button))
                {
                    b = (Button)item;
                    b.Font = new Font(b.Font.Name, (float)Math.Floor(b.Font.Size * pomer));
                }
            }
        }
    }
}
