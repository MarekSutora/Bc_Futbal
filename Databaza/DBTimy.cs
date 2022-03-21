using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using LGR_Futbal.Model;
using LGR_Futbal.Databaza;
using System.Threading.Tasks;


namespace LGR_Futbal.Databaza
{
    public class DBTimy
    {
        private const string constring = "User Id=sutora_bc;Password=bcproj84Qt;Data Source=obelix.fri.uniza.sk:1521/orcl.fri.uniza.sk";
        private DBHraci dbhraci = null;

        public DBTimy()
        {
            dbhraci = new DBHraci();
        }
        public List<FutbalovyTim> GetTimy()
        {
            List<FutbalovyTim> timy = new List<FutbalovyTim>();
            FutbalovyTim ft;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "SELECT * FROM futbalovy_tim WHERE datum_zrusenia IS NULL";
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
                            ft = new FutbalovyTim();
                            if (!reader.IsDBNull(0))
                                ft.IdFutbalovyTim = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                                ft.Kategoria = reader.GetInt32(1);
                            if (!reader.IsDBNull(2))
                                ft.NazovTimu = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                            {
                                ft.LogoBlob = reader.GetOracleBlob(3).Value;
                                ft.LogoImage = dbhraci.byteArrayToImage(ft.LogoBlob);
                            }
                            timy.Add(ft);
                        }
                    }
                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
            return timy;
        }

        public List<Hrac> GetNezaradeniHraci()
        {
            List<Hrac> hraci = new List<Hrac>();
            Hrac hrac = null;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "SELECT * FROM hrac WHERE datum_ukoncenia IS NULL AND id_futbalovy_tim IS NULL";
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
                            hrac = new Hrac();
                            if (!reader.IsDBNull(0))
                                hrac.IdHrac = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                                hrac.IdOsoba = reader.GetInt32(1);
                            if (!reader.IsDBNull(2))
                                hrac.IdFutbalovyTim = reader.GetInt32(3);
                            if (!reader.IsDBNull(3))
                                hrac.Poznamka = reader.GetString(3);
                            if (!reader.IsDBNull(4))
                                hrac.CisloDresu = reader.GetString(4);
                            if (!reader.IsDBNull(6))
                            {
                                hrac.FotkaBlob = reader.GetOracleBlob(6).Value;
                                hrac.FotkaImage = dbhraci.byteArrayToImage(hrac.FotkaBlob);
                            }
                            if (!reader.IsDBNull(7))
                                hrac.Pozicia = reader.GetString(7);
                            dbhraci.NastavOsudaje(hrac);
                            hraci.Add(hrac);
                        }
                    }
                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
            return hraci;
        }

        public List<string> GetKategorie()
        {
            List<string> kategorie = new List<string>();
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "SELECT nazov_kategoria FROM futbal_kategoria";
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
                string cmdQuery = "SELECT COUNT(*) FROM futbalovy_tim WHERE nazov_timu = :nazov AND datum_zrusenia IS NULL";
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
                string cmdQuery = "INSERT INTO futbalovy_tim(id_kategoria, nazov_timu, logo) VALUES(:id_kategoria, :nazov_timu, :logo)";
                try
                {
                    byte[] blob = null;
                    int? kategoria = null;
                    if (futbalovyTim.Kategoria != 0 && futbalovyTim.Kategoria != -1)
                        kategoria = futbalovyTim.Kategoria;
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
                    OracleParameter[] param = new OracleParameter[3];

                    param[0] = cmd.Parameters.Add("id_kategoria", OracleDbType.Int32);
                    param[0].Value = kategoria;
                    param[1] = cmd.Parameters.Add("nazov_timu", OracleDbType.Varchar2);
                    param[1].Value = nazov;
                    param[2] = cmd.Parameters.Add("logo", OracleDbType.Blob);
                    param[2].Value = blob;

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

        public void UpdateTim(FutbalovyTim ft)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "UPDATE futbalovy_tim SET id_kategoria = :id_kategoria, nazov_timu = :nazov_timu, logo = :logo WHERE id_futbalovy_tim = :id_futbalovy_tim";
                try
                {

                    byte[] blob = null;
                    int? kategoria = null;
                    if (ft.Kategoria != 0 && ft.Kategoria != -1)
                        kategoria = ft.Kategoria;
                    string nazov = ft.NazovTimu;
                    if (ft.Logo != null)
                    {
                        if (ft.LogoBlob != null)
                        {
                            blob = ft.LogoBlob;
                        }
                        else
                        {
                            FileStream fls;
                            fls = new FileStream(ft.Logo, FileMode.Open, FileAccess.Read);
                            blob = new byte[fls.Length];
                            fls.Read(blob, 0, System.Convert.ToInt32(fls.Length));
                            fls.Close();
                        }
                    }
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    OracleParameter[] param = new OracleParameter[4];
                    param[0] = cmd.Parameters.Add("id_kategoria", OracleDbType.Int32);
                    param[0].Value = kategoria;
                    param[1] = cmd.Parameters.Add("nazov_timu", OracleDbType.Varchar2);
                    param[1].Value = nazov;
                    param[2] = cmd.Parameters.Add("logo", OracleDbType.Blob);
                    param[2].Value = blob;
                    param[3] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int32);
                    param[3].Value = ft.IdFutbalovyTim;

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

        public void VymazTim(FutbalovyTim ft)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "UPDATE futbalovy_tim SET datum_zrusenia = SYSDATE, logo = NULL WHERE id_futbalovy_tim = :id_futbalovy_tim";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    OracleParameter param = new OracleParameter();
                    param = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int32);
                    param.Value = ft.IdFutbalovyTim;

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

        public void pridajHracovDoTimu(int idTimu, List<Hrac> hraci)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {

                string cmdQuery = "UPDATE hrac SET id_futbalovy_tim = :id_timu WHERE id_hrac = :id_hrac";
                OracleCommand cmd = new OracleCommand(cmdQuery);


                for (int i = 0; i < hraci.Count; i++)
                {
                    try
                    {
                        OracleParameter[] param = new OracleParameter[2];
                        cmd.Parameters.Clear();
                        param[0] = cmd.Parameters.Add("id_timu", OracleDbType.Int32);
                        param[0].Value = idTimu;
                        param[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int32);
                        param[1].Value = hraci[i].IdHrac;
                        conn.Open();

                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
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
}
