using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace LGR_Futbal.Triedy
{
    

    [Serializable]
    public class Databaza
    {
        private List<FutbalovyTim> zoznamTimov;
        private const string constring = "User Id=sutora_bc;Password=bcproj84Qt;Data Source=obelix.fri.uniza.sk:1521/orcl.fri.uniza.sk";
        public List<FutbalovyTim> ZoznamTimov { get => zoznamTimov; set => zoznamTimov = value; }

        public Databaza()
        {
            
            zoznamTimov = new List<FutbalovyTim>();
        }

        public FutbalovyTim NajstTim(string hladanyNazov)
        {
            foreach(FutbalovyTim t in zoznamTimov)
            {
                if (t.NazovTimu.Equals(hladanyNazov))
                    return t;
            }
            return null;
        }

        public void PostLoad()
        {
            int pocet = zoznamTimov.Count;
            if (pocet > 0)
            {
                string[] pole = new string[pocet];
                for (int i = 0; i < pocet; i++)
                {
                    pole[i] = zoznamTimov[i].NazovTimu;
                }

                Array.Sort(pole);

                FutbalovyTim t;
                List<FutbalovyTim> usporiadanyZoznam = new List<FutbalovyTim>();
                for (int i = 0; i < pocet; i++)
                {
                    t = null;
                    foreach (FutbalovyTim tim in zoznamTimov)
                    {
                        if (tim.NazovTimu.Equals(pole[i]))
                            t = tim;
                    }
                    zoznamTimov.Remove(t);
                    usporiadanyZoznam.Add(t);
                }

                zoznamTimov = usporiadanyZoznam;
                foreach (FutbalovyTim tim in zoznamTimov)
                {
                    tim.PostLoad();
                }
            }
        }

        public void resetKariet()
        {
            foreach (FutbalovyTim t in zoznamTimov)
            {
                t.resetKariet();
            }
        }

        //public void PripojKDatabaze()
        //{
        //    string constring = "User Id=sutora_bc;Password=bcproj84Qt;Data Source=obelix.fri.uniza.sk:1521/orcl.fri.uniza.sk"; ;
        //    conn = new OracleConnection(); 
        //    conn.ConnectionString = constring;
        //    try
        //    {
        //        conn.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //            System.Windows.Forms.MessageBox.Show(ex.ToString());
        //    }
        //}

        //public void OdpojitZDatabazi()
        //{
        //    try
        //    {
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.ToString());
        //    }
        //}

        public List<string> GetNazvyTimov()
        {
            List<string> nazvyTimov = new List<string>();
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "select nazov_timu from futbalovy_tim";
                try 
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nazvyTimov.Add(reader.GetString(0));
                        }
                    }
                    conn.Close();
                    
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }    
            }
            return nazvyTimov;
        }

        public List<string> GetKategorie()
        {
            List<string> kategorie = new List<string>();
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "select nazov_kategoria from futbal_kategoria";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kategorie.Add(reader.GetString(0));
                        }
                    }
                    conn.Close();

                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
            return kategorie;
        }

        public bool CheckNazovTimu(string nazov)
        {
            bool returnVal = false;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "select count(*) from futbalovy_tim where nazov_timu = :nazov";
                try
                {
                    conn.Open();
                    OracleParameter param = new OracleParameter("nazov", nazov);
                    param.OracleDbType = OracleDbType.Varchar2;
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    cmd.Parameters.Add(param);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    int count = int.Parse(cmd.ExecuteScalar().ToString());
                    if (count > 0)
                        returnVal = true;
                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
            return returnVal;
        }

        public void InsertFutbalovyTeam(FutbalovyTim futbalovyTim)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "insert into futbalovy_tim(id_kategoria, id_klub, nazov_timu, logo) values(:id_kategoria, :id_klub, :nazov_timu, :logo)";
                try
                {
                    byte[] blob = null;
                    int ?kategoria = null;
                    if (futbalovyTim.Kategoria != 0)
                        kategoria = futbalovyTim.Kategoria;
                    int ?klub = null;
                    if (futbalovyTim.FutbalovyKlub != null)
                        klub = futbalovyTim.FutbalovyKlub.IdKlub;
                    string nazov = futbalovyTim.NazovTimu;
                    if (futbalovyTim.Logo != null)
                    {
                        FileStream fls;
                        fls = new FileStream(@futbalovyTim.Logo, FileMode.Open, FileAccess.Read);
                        blob = new byte[fls.Length];
                        fls.Read(blob, 0, System.Convert.ToInt32(fls.Length));
                        fls.Close();
                    }
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    OracleParameter[] param = new OracleParameter[4];

                    param[0] = cmd.Parameters.Add("id_kategoria", OracleDbType.Int16);
                    param[0].Value = kategoria;
                    param[1] = cmd.Parameters.Add("id_klub", OracleDbType.Int16);
                    param[1].Value = klub;
                    param[2] = cmd.Parameters.Add("nazov_timu", OracleDbType.Varchar2);
                    param[2].Value = nazov;
                    param[3] = cmd.Parameters.Add("logo", OracleDbType.Blob);
                    param[3].Value = blob;
                     
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
        }

        public FutbalovyTim GetTim(string nazovTimu)
        {
            FutbalovyTim ft = new FutbalovyTim();
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "select * from futbalovy_tim where nazov_timu = :nazov";
                try
                {
                    //byte[] pom;
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    cmd.Parameters.Add(new OracleParameter("nazov", OracleDbType.Varchar2, nazovTimu, ParameterDirection.Input));
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                                ft.IdFutbalovyTim = reader.GetInt16(0);
                            if (!reader.IsDBNull(1))
                                ft.Kategoria = reader.GetInt16(1);
                            if (!reader.IsDBNull(2))
                                ft.FutbalovyKlub.IdKlub = reader.GetInt16(2);
                            if (!reader.IsDBNull(3))
                                ft.NazovTimu = reader.GetString(3);
                            if (!reader.IsDBNull(4))
                                ft.LogoBlob = reader.GetOracleBlob(4).Value;
                            ft.LogoImage = ft.byteArrayToImage(ft.LogoBlob);
                            //if (!reader.IsDBNull(4))
                            //    ft.BlobSize = (int)reader.GetOracleBlob(4).Length;
                        }
                    }
                    conn.Close();

                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
            return ft;
        }

        public void UpdateTim(FutbalovyTim ft)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "update futbalovy_tim set id_kategoria = :id_kategoria, id_klub = :id_klub, nazov_timu = :nazov_timu, logo = :logo where id_futbalovy_tim = :id_futbalovy_tim";
                try
                {

                    byte[] blob = null;
                    int? kategoria = null;
                    if (ft.Kategoria != 0)
                        kategoria = ft.Kategoria;
                    int? idklub = null;
                    if (ft.FutbalovyKlub != null && ft.FutbalovyKlub.IdKlub != 0)
                        idklub = ft.FutbalovyKlub.IdKlub;
                    int? klub = null;
                    if (ft.FutbalovyKlub != null)
                        klub = ft.FutbalovyKlub.IdKlub;
                    string nazov = ft.NazovTimu;
                    if (ft.Logo != null)
                    {
                        FileStream fls;
                        fls = new FileStream(ft.Logo, FileMode.Open, FileAccess.Read);
                        blob = new byte[fls.Length];
                        fls.Read(blob, 0, System.Convert.ToInt32(fls.Length));
                        fls.Close();
                    }
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    OracleParameter[] param = new OracleParameter[5];
                    param[0] = cmd.Parameters.Add("id_kategoria", OracleDbType.Int16);
                    param[0].Value = kategoria;
                    param[1] = cmd.Parameters.Add("id_klub", OracleDbType.Int16);
                    param[1].Value = klub;
                    param[2] = cmd.Parameters.Add("nazov_timu", OracleDbType.Varchar2);
                    param[2].Value = nazov;
                    param[3] = cmd.Parameters.Add("logo", OracleDbType.Blob);
                    param[3].Value = blob;
                    param[4] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Varchar2);
                    param[4].Value = ft.IdFutbalovyTim;

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
        }

    }
}
