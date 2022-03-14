using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using LGR_Futbal.Model;

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
            foreach (FutbalovyTim t in zoznamTimov)
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

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                using (var ms = new MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {

            }
            return null;
        }

        public void resetKariet()
        {
            foreach (FutbalovyTim t in zoznamTimov)
            {
                t.resetKariet();
            }
        }

        #region Timy

        public List<string> GetNazvyTimov()
        {
            List<string> nazvyTimov = new List<string>();
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "SELECT nazov_timu FROM futbalovy_tim";
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

        public List<FutbalovyTim> GetTimy()
        {
            List<FutbalovyTim> timy = new List<FutbalovyTim>();
            FutbalovyTim ft = null;
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
                                ft.IdFutbalovyTim = reader.GetInt16(0);
                            if (!reader.IsDBNull(1))
                                ft.Kategoria = reader.GetInt16(1);
                            if (!reader.IsDBNull(2))
                                ft.NazovTimu = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                                ft.DatumVytvorenia = reader.GetDateTime(3);
                            if (!reader.IsDBNull(4))
                            {
                                ft.LogoBlob = reader.GetOracleBlob(4).Value;
                                ft.LogoImage = byteArrayToImage(ft.LogoBlob);
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
                string cmdQuery = "INSERT INTO futbalovy_tim(id_kategoria, id_klub, nazov_timu, logo, datum_vytvorenia) VALUES(:id_kategoria, :id_klub, :nazov_timu, :logo, SYSDATE)";
                try
                {
                    byte[] blob = null;
                    int? kategoria = null;
                    if (futbalovyTim.Kategoria != 0 && futbalovyTim.Kategoria != -1)
                        kategoria = futbalovyTim.Kategoria;
                    int? klub = null;
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

        public void UpdateTim(FutbalovyTim ft)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "UPDATE futbalovy_tim SET id_kategoria = :id_kategoria, id_klub = :id_klub, nazov_timu = :nazov_timu, logo = :logo WHERE id_futbalovy_tim = :id_futbalovy_tim";
                try
                {

                    byte[] blob = null;
                    int? kategoria = null;
                    if (ft.Kategoria != 0 && ft.Kategoria != -1)
                        kategoria = ft.Kategoria;
                    int? idklub = null;
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
                    OracleParameter[] param = new OracleParameter[5];
                    param[0] = cmd.Parameters.Add("id_kategoria", OracleDbType.Int16);
                    param[0].Value = kategoria;
                    param[1] = cmd.Parameters.Add("id_klub", OracleDbType.Int16);
                    param[1].Value = idklub;
                    param[2] = cmd.Parameters.Add("nazov_timu", OracleDbType.Varchar2);
                    param[2].Value = nazov;
                    param[3] = cmd.Parameters.Add("logo", OracleDbType.Blob);
                    param[3].Value = blob;
                    param[4] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int16);
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
                    param = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int16);
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
        #endregion Timy

        #region Hraci
        public void InsertHrac(Hrac h)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                try
                {
                    conn.Open();
                    string cmdQuery1 = "INSERT INTO osoba(meno, priezvisko, datum_narodenia, pohlavie) VALUES(:meno, :priezvisko, :datum_narodenia, :pohlavie)";
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[4];
                    param[0] = cmd.Parameters.Add("meno", OracleDbType.Varchar2);
                    param[0].Value = h.Meno;
                    param[1] = cmd.Parameters.Add("priezvisko", OracleDbType.Varchar2);
                    param[1].Value = h.Priezvisko;
                    param[2] = cmd.Parameters.Add("datum_narodenia", OracleDbType.Date);
                    param[2].Value = h.DatumNarodenia;
                    param[3] = cmd.Parameters.Add("pohlavie", OracleDbType.Int16);
                    param[3].Value = h.Pohlavie;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();


                    string cmdQuery2 = "SELECT MAX(id_osoba) FROM osoba";
                    cmd.CommandText = cmdQuery2;
                    int ID = int.Parse(cmd.ExecuteScalar().ToString());

                    byte[] blob = null;


                    if (h.Fotka != null)
                    {
                        FileStream fls;
                        fls = new FileStream(h.Fotka, FileMode.Open, FileAccess.Read);
                        blob = new byte[fls.Length];
                        fls.Read(blob, 0, System.Convert.ToInt32(fls.Length));
                        fls.Close();
                    }


                    OracleParameter[] param1 = new OracleParameter[6];

                    int? idTimu = null;
                    if (h.IdFutbalovyTim != 0)
                        idTimu = h.IdFutbalovyTim;
                    string pozicia = null;
                    if (!h.Pozicia.Equals(string.Empty))
                        pozicia = h.Pozicia;
                    string poznamka = null;
                    if (!h.Poznamka.Equals(string.Empty))
                        poznamka = h.Poznamka;
                    int? cislo_dresu = null;
                    if (!h.CisloDresu.Equals(string.Empty))
                        cislo_dresu = Convert.ToInt32(h.CisloDresu);

                    string cmdQuery3 = "INSERT INTO hrac(id_futbalovy_tim, id_osoba, poznamka, cislo_dresu, fotka, post) VALUES(:id_futbalovy_tim, :id_osoba, :poznamka, :cislo_dresu, :fotka, :post)";
                    cmd.CommandText = cmdQuery3;
                    param1[0] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int16);
                    param1[0].Value = idTimu;
                    param1[1] = cmd.Parameters.Add("id_osoba", OracleDbType.Int16);
                    param1[1].Value = ID;
                    param1[2] = cmd.Parameters.Add("poznamka", OracleDbType.Varchar2);
                    param1[2].Value = poznamka;
                    param1[3] = cmd.Parameters.Add("cislo_dresu", OracleDbType.Int16);
                    param1[3].Value = cislo_dresu;
                    param1[4] = cmd.Parameters.Add("fotka", OracleDbType.Blob);
                    param1[4].Value = blob;
                    param1[5] = cmd.Parameters.Add("post", OracleDbType.Varchar2);
                    param1[5].Value = pozicia;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
        }

        public List<Hrac> GetVsetciHraci()
        {
            List<Hrac> hraci = new List<Hrac>();
            Hrac hrac = null;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "SELECT * FROM hrac WHERE datum_ukoncenia IS NULL";
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
                                hrac.IdHrac = reader.GetInt16(0);
                            if (!reader.IsDBNull(1))
                                hrac.IdOsoba = reader.GetInt16(1);
                            if (!reader.IsDBNull(2))
                                hrac.IdFutbalovyTim = reader.GetInt16(2);
                            if (!reader.IsDBNull(3))
                                hrac.Poznamka = reader.GetString(3);
                            if (!reader.IsDBNull(4))
                                hrac.CisloDresu = reader.GetString(4);
                            if (!reader.IsDBNull(6))
                            {
                                hrac.FotkaBlob = reader.GetOracleBlob(6).Value;
                                hrac.FotkaImage = byteArrayToImage(hrac.FotkaBlob);
                            }
                            if (!reader.IsDBNull(7))
                                hrac.Pozicia = reader.GetString(7);
                            NastavOsudaje(hrac);
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
                                hrac.IdHrac = reader.GetInt16(0);
                            if (!reader.IsDBNull(1))
                                hrac.IdOsoba = reader.GetInt16(1);
                            if (!reader.IsDBNull(2))
                                hrac.IdFutbalovyTim = reader.GetInt16(3);
                            if (!reader.IsDBNull(3))
                                hrac.Poznamka = reader.GetString(3);
                            if (!reader.IsDBNull(4))
                                hrac.CisloDresu = reader.GetString(4);
                            if (!reader.IsDBNull(6))
                            {
                                hrac.FotkaBlob = reader.GetOracleBlob(6).Value;
                                hrac.FotkaImage = byteArrayToImage(hrac.FotkaBlob);
                            }
                            if (!reader.IsDBNull(7))
                                hrac.Pozicia = reader.GetString(7);
                            NastavOsudaje(hrac);
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

        public List<Hrac> GetHraciVTime(int idTimu)
        {
            List<Hrac> hraci = new List<Hrac>();
            Hrac hrac = null;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "SELECT * FROM hrac WHERE datum_ukoncenia IS NULL AND id_futbalovy_tim = :id_timu";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    OracleParameter param = new OracleParameter("id_timu", OracleDbType.Int16);
                    param.Value = idTimu;
                    cmd.Parameters.Add(param);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hrac = new Hrac();
                            if (!reader.IsDBNull(0))
                                hrac.IdHrac = reader.GetInt16(0);
                            if (!reader.IsDBNull(1))
                                hrac.IdOsoba = reader.GetInt16(1);
                            if (!reader.IsDBNull(2))
                                hrac.IdFutbalovyTim = reader.GetInt16(2);
                            if (!reader.IsDBNull(3))
                                hrac.Poznamka = reader.GetString(3);
                            if (!reader.IsDBNull(4))
                                hrac.CisloDresu = reader.GetString(4);
                            if (!reader.IsDBNull(6))
                            {
                                hrac.FotkaBlob = reader.GetOracleBlob(6).Value;
                                hrac.FotkaImage = byteArrayToImage(hrac.FotkaBlob);
                            }
                            if (!reader.IsDBNull(7))
                                hrac.Pozicia = reader.GetString(7);
                            NastavOsudaje(hrac);
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

        private void NastavOsudaje(Osoba osoba)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                conn.Open();
                string cmdQuery = "SELECT * FROM osoba WHERE id_osoba = :id_osoba";
                OracleParameter param = new OracleParameter("id_osoba", OracleDbType.Varchar2);
                OracleCommand cmd = new OracleCommand(cmdQuery);
                param.Value = osoba.IdOsoba;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(param);

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(1))
                            osoba.Meno = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                            osoba.Priezvisko = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                            osoba.DatumNarodenia = reader.GetDateTime(3);
                        if (!reader.IsDBNull(4))
                            osoba.Pohlavie = reader.GetInt16(4);
                    }
                }
                conn.Close();
            }
        }

        public Hrac getHrac(int idHrac)
        {
            Hrac hrac = null;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "SELECT * FROM hrac WHERE id_hrac = :id_hrac";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    OracleParameter param = new OracleParameter("id_hrac", OracleDbType.Varchar2);
                    param.Value = idHrac;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(param);

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hrac = new Hrac();
                            if (!reader.IsDBNull(0))
                                hrac.IdHrac = reader.GetInt16(0);
                            if (!reader.IsDBNull(1))
                                hrac.IdOsoba = reader.GetInt16(1);
                            if (!reader.IsDBNull(2))
                                hrac.IdFutbalovyTim = reader.GetInt16(2);
                            if (!reader.IsDBNull(3))
                                hrac.Poznamka = reader.GetString(3);
                            if (!reader.IsDBNull(4))
                                hrac.CisloDresu = reader.GetString(4);
                            if (!reader.IsDBNull(6))
                            {
                                hrac.FotkaBlob = reader.GetOracleBlob(6).Value;
                                hrac.FotkaImage = byteArrayToImage(hrac.FotkaBlob);
                            }
                            if (!reader.IsDBNull(7))
                                hrac.Pozicia = reader.GetString(7);
                            NastavOsudaje(hrac);
                        }


                    }
                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
            return hrac;
        }

        public void UpdateHrac(Hrac h)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery1 = "UPDATE osoba SET meno = :meno, priezvisko = :priezvisko, datum_narodenia = :datum_narodenia, pohlavie = :pohlavie WHERE id_osoba = :id_osoba";
                string cmdQuery2 = "UPDATE hrac SET id_futbalovy_tim = :id_futbalovy_tim, poznamka = :poznamka, cislo_dresu = :cislo_dresu, fotka = :fotka, post = :post WHERE id_hrac = :id_hrac";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[5];

                    param[0] = cmd.Parameters.Add("meno", OracleDbType.Varchar2);
                    param[0].Value = h.Meno;
                    param[1] = cmd.Parameters.Add("priezvisko", OracleDbType.Varchar2);
                    param[1].Value = h.Priezvisko;
                    param[2] = cmd.Parameters.Add("datum_narodenia", OracleDbType.Date);
                    param[2].Value = h.DatumNarodenia;
                    param[3] = cmd.Parameters.Add("pohlavie", OracleDbType.Int16);
                    param[3].Value = h.Pohlavie;
                    param[4] = cmd.Parameters.Add("id_osoba", OracleDbType.Int16);
                    param[4].Value = h.IdOsoba;
                    

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    byte[] blob = null;

                    if (h.Fotka != null)
                    {
                        if (h.FotkaBlob != null)
                        {
                            blob = h.FotkaBlob; 
                        }
                        else
                        {
                            FileStream fls;
                            fls = new FileStream(h.Fotka, FileMode.Open, FileAccess.Read);
                            blob = new byte[fls.Length];
                            fls.Read(blob, 0, System.Convert.ToInt32(fls.Length));
                            fls.Close();
                        }    
                    }

                    int? idTimu = null;
                    if (h.IdFutbalovyTim != 0)
                        idTimu = h.IdFutbalovyTim;
                    string pozicia = null;
                    if (!h.Pozicia.Equals(string.Empty))
                        pozicia = h.Pozicia;
                    string poznamka = null;
                    if (!h.Poznamka.Equals(string.Empty))
                        poznamka = h.Poznamka;
                    int? cislo_dresu = null;
                    if (!h.CisloDresu.Equals(string.Empty))
                        cislo_dresu = Convert.ToInt32(h.CisloDresu);

                    OracleCommand cmd2 = new OracleCommand(cmdQuery2);
                    OracleParameter[] param2 = new OracleParameter[6];

                    param2[0] = cmd2.Parameters.Add("id_futbalovy_tim", OracleDbType.Int16);
                    param2[0].Value = idTimu;
                    param2[1] = cmd2.Parameters.Add("poznamka", OracleDbType.Varchar2);
                    param2[1].Value = poznamka;
                    param2[2] = cmd2.Parameters.Add("cislo_dresu", OracleDbType.Int16);
                    param2[2].Value = cislo_dresu;
                    param2[3] = cmd2.Parameters.Add("fotka", OracleDbType.Blob);
                    param2[3].Value = blob;
                    param2[4] = cmd2.Parameters.Add("post", OracleDbType.Varchar2);
                    param2[4].Value = pozicia;
                    param2[5] = cmd2.Parameters.Add("id_hrac", OracleDbType.Int16);
                    param2[5].Value = h.IdHrac;

                    cmd2.Connection = conn;
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
        }

        public void VymazHraca(Hrac h)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "UPDATE hrac SET datum_ukoncenia = SYSDATE WHERE id_hrac = :id_hrac";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    OracleParameter param = new OracleParameter("id_hrac", OracleDbType.Int16);
                    param.Value = h.IdHrac;
                    cmd.Parameters.Add(param);
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
                        param[0] = cmd.Parameters.Add("id_timu", OracleDbType.Int16);
                        param[0].Value = idTimu;
                        param[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int16);
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

        #endregion hraci

        #region ROZHODCOVIA

        public List<Rozhodca> GetRozhodcovia()
        {
            List<Rozhodca> rozhodcovia = new List<Rozhodca>();

            Rozhodca rozhodca = null;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "SELECT * FROM rozhodca WHERE datum_ukoncenia IS NULL";
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
                            rozhodca = new Rozhodca();
                            if (!reader.IsDBNull(0))
                                rozhodca.IdRozhodca = reader.GetInt16(0);
                            if (!reader.IsDBNull(1))
                                rozhodca.IdOsoba = reader.GetInt16(1);
                            NastavOsudaje(rozhodca);
                            rozhodcovia.Add(rozhodca);
                        }
                    }
                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
            return rozhodcovia;
        }

        public void InsertRozhodca(Rozhodca rozhodca)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                try
                {
                    conn.Open();
                    string cmdQuery1 = "INSERT INTO osoba(meno, priezvisko, pohlavie) VALUES(:meno, :priezvisko, :pohlavie)";
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[3];
                    param[0] = cmd.Parameters.Add("meno", OracleDbType.Varchar2);
                    param[0].Value = rozhodca.Meno;
                    param[1] = cmd.Parameters.Add("priezvisko", OracleDbType.Varchar2);
                    param[1].Value = rozhodca.Priezvisko;
                    param[2] = cmd.Parameters.Add("pohlavie", OracleDbType.Int16);
                    param[2].Value = rozhodca.Pohlavie;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();


                    string cmdQuery2 = "SELECT MAX(id_osoba) FROM osoba";
                    cmd.CommandText = cmdQuery2;
                    int ID = int.Parse(cmd.ExecuteScalar().ToString());

                    string cmdQuery3 = "INSERT INTO rozhodca(id_osoba) VALUES(:id_osoba)";
                    cmd.CommandText = cmdQuery3;
                    OracleParameter param1 = new OracleParameter("id_osoba", OracleDbType.Int16);
                    param1.Value = ID;
                    cmd.Parameters.Add(param1);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
        }

        public void UpdateRozhodca(Rozhodca rozhodca)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery1 = "UPDATE osoba SET meno = :meno, priezvisko = :priezvisko, datum_narodenia = :datum_narodenia WHERE id_osoba = :id_osoba";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[3];

                    param[0] = cmd.Parameters.Add("meno", OracleDbType.Varchar2);
                    param[0].Value = rozhodca.Meno;
                    param[1] = cmd.Parameters.Add("priezvisko", OracleDbType.Varchar2);
                    param[1].Value = rozhodca.Priezvisko;
                    param[2] = cmd.Parameters.Add("id_osoba", OracleDbType.Int16);
                    param[2].Value = rozhodca.IdOsoba;

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

        public void VymazRozhodca(Rozhodca rozhodca)
        {
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "UPDATE rozhodca SET datum_ukoncenia = SYSDATE WHERE id_rozhodca = :id_rozhodca";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    OracleParameter param = new OracleParameter("id_rozhodca", OracleDbType.Int16);
                    param.Value = rozhodca.IdRozhodca;
                    cmd.Parameters.Add(param);
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
        #endregion ROZHODCOVIA

        public Rozhodca GetRozhodca(int idRozhodca)
        {
            Rozhodca Rozhodca = null;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                string cmdQuery = "SELECT * FROM rozhodca WHERE id_rozhodca = :id_rozhodca";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    OracleParameter param = new OracleParameter("id_hrac", OracleDbType.Varchar2);
                    param.Value = idRozhodca;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(param);

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rozhodca = new Rozhodca();
                            if (!reader.IsDBNull(0))
                                Rozhodca.IdRozhodca = reader.GetInt16(0);
                            if (!reader.IsDBNull(1))
                                Rozhodca.IdOsoba = reader.GetInt16(1);
                            NastavOsudaje(Rozhodca);
                        }


                    }
                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
            return Rozhodca;
        }


        #region ZAPASY

        public void PridajZapas(Zapas Zapas)
        {
            List<Udalost> udalosti = null;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                try
                {
                    conn.Open();
                    string cmdQuery1 = "INSERT INTO zapas(id_futbalovy_tim_domaci, id_futbalovy_tim_hostia, datum_zapasu, domaci_skore, hostia_skore, dlzka_polcasu, nadstaveny_cas1, nadstaveny_cas2) " +
                        "VALUES(:id_futbalovy_tim_domaci, :id_futbalovy_tim_hostia, :datum_zapasu, :domaci_skore, :hostia_skore, :dlzka_polcasu, :nadstaveny_cas1, :nadstaveny_cas2)";
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[8];
                    param[0] = cmd.Parameters.Add("id_futbalovy_tim_domaci", OracleDbType.Int16);
                    param[0].Value = Zapas.Domaci.IdFutbalovyTim;
                    param[1] = cmd.Parameters.Add("id_futbalovy_tim_hostia", OracleDbType.Int16);
                    param[1].Value = Zapas.Hostia.IdFutbalovyTim;
                    param[2] = cmd.Parameters.Add("datum_zapasu", OracleDbType.Date);
                    param[2].Value = Zapas.DatumZapasu;
                    param[3] = cmd.Parameters.Add("domaci_skore", OracleDbType.Int16);
                    param[3].Value = Zapas.DomaciSkore;
                    param[4] = cmd.Parameters.Add("hostia_skore", OracleDbType.Int16);
                    param[4].Value = Zapas.HostiaSkore;
                    param[5] = cmd.Parameters.Add("dlzka_polcasu", OracleDbType.Int16);
                    param[5].Value = Zapas.DlzkaPolcasu;
                    param[6] = cmd.Parameters.Add("nadstaveny_cas1", OracleDbType.Int16);
                    param[6].Value = Zapas.NadstavenyCas1;
                    param[7] = cmd.Parameters.Add("nadstaveny_cas1", OracleDbType.Int16);
                    param[7].Value = Zapas.NadstavenyCas2;

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    udalosti = Zapas.Udalosti;

                    cmd.Parameters.Clear();
                    string cmdQuery2 = "SELECT MAX(id_zapas) FROM zapas";
                    cmd.CommandText = cmdQuery2;
                    int IdZapas = int.Parse(cmd.ExecuteScalar().ToString());

                    string cmdQuery3 = "INSERT INTO zapas_hraci(id_zapas, id_hrac, id_futbalovy_tim, typ_hraca) " +
                        "VALUES(:id_zapas, :id_hrac, :id_futbalovy_tim, :typ_hraca)";

                    OracleParameter[] param2 = new OracleParameter[4];
                    cmd.CommandText = cmdQuery3;


                    for (int i = 0; i < Zapas.Domaci.ZoznamHracov.Count; i++)
                    {

                        param2[0] = cmd.Parameters.Add("id_zapas", OracleDbType.Int16);
                        param2[0].Value = IdZapas;
                        param2[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int16);
                        param2[1].Value = Zapas.Domaci.ZoznamHracov[i].IdHrac;
                        param2[2] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int16);
                        param2[2].Value = Zapas.Domaci.ZoznamHracov[i].IdFutbalovyTim;
                        param2[3] = cmd.Parameters.Add("typ_hraca", OracleDbType.Int16);
                        param2[3].Value = Zapas.Domaci.ZoznamHracov[i].Hrajuci ? 1 : 2;

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    for (int i = 0; i < Zapas.Hostia.ZoznamHracov.Count; i++)
                    {
                        param2[0] = cmd.Parameters.Add("id_zapas", OracleDbType.Int16);
                        param2[0].Value = IdZapas;
                        param2[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int16);
                        param2[1].Value = Zapas.Hostia.ZoznamHracov[i].IdHrac;
                        param2[2] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int16);
                        param2[2].Value = Zapas.Hostia.ZoznamHracov[i].IdFutbalovyTim;
                        param2[3] = cmd.Parameters.Add("typ_hraca", OracleDbType.Int16);
                        param2[3].Value = Zapas.Hostia.ZoznamHracov[i].Hrajuci ? 1 : 2;

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    string cmdQuery4 = "INSERT INTO udalost(id_zapas, udalost_popis, minuta, polcas, nadstavena_minuta, typ_udalosti) " +
                        "VALUES(:id_zapas, :udalost_popis, :minuta, :polcas, :nadstavena_minuta, :typ_udalosti)";
                    OracleParameter[] param3 = new OracleParameter[6];

                    for (int i = 0; i < udalosti.Count; i++)
                    {
                        if(i == udalosti.Count - 2)
                        {
                            int x = 5;
                        }
                        param3[0] = cmd.Parameters.Add("id_zapas", OracleDbType.Int16);
                        param3[0].Value = IdZapas;
                        param3[1] = cmd.Parameters.Add("udalost_popis", OracleDbType.Varchar2);
                        param3[1].Value = udalosti[i].UdalostPopis;
                        param3[2] = cmd.Parameters.Add("minuta", OracleDbType.Int16);
                        param3[2].Value = udalosti[i].Minuta;
                        param3[3] = cmd.Parameters.Add("polcas", OracleDbType.Int16);
                        param3[3].Value = udalosti[i].Polcas;
                        param3[4] = cmd.Parameters.Add("nadstavena_minuta", OracleDbType.Int16);
                        param3[4].Value = udalosti[i].NadstavenaMinuta;
                        param3[5] = cmd.Parameters.Add("typ_udalosti", OracleDbType.Int16);
                        param3[5].Value = udalosti[i].Typ;

                        cmd.CommandText = cmdQuery4;
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                        string cmdQuery5 = "SELECT MAX(id_udalost) FROM udalost";
                        cmd.CommandText = cmdQuery5;
                        int IdUdalost = int.Parse(cmd.ExecuteScalar().ToString());

                        udalosti[i].IdUdalosti = IdUdalost;

                        switch (udalosti[i].Typ)
                        {
                            case 1:
                                InsertGol(udalosti[i]);
                                break;
                            case 2:
                                InsertKarta(udalosti[i]);
                                break;
                            case 3:
                                InsertKop(udalosti[i]);
                                break;
                            case 4:
                                InsertOffside(udalosti[i]);
                                break;
                            case 5:
                                InsertOut(udalosti[i]);
                                break;
                            case 6:
                                InsertStriedanie(udalosti[i]);
                                break;
                        }
                    }
                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri praci s Databazou");
                }
            }
        }

        private void InsertStriedanie(Udalost udalost)
        {
            Striedanie striedanie = (Striedanie)udalost;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                try
                {
                    conn.Open();
                    string cmdQuery1 = "INSERT INTO striedanie(id_udalost, id_hraca_striedajuci, id_hraca_striedany) VALUES(:id_udalost, :id_hrac, :id_hraca_striedajuci, :id_hraca_striedany)";
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[3];
                    param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int16);
                    param[0].Value = striedanie.IdUdalosti;
                    param[1] = cmd.Parameters.Add("id_hraca_striedany", OracleDbType.Int16);
                    if (striedanie.Striedany.Meno.Equals(string.Empty))
                    {
                        param[1].Value = null;
                    }
                    else
                    {
                        param[1].Value = striedanie.Striedany.IdHrac;
                    }
                    param[2] = cmd.Parameters.Add("id_hraca_striedajuci", OracleDbType.Int16);
                    if (striedanie.Striedajuci.Meno.Equals(string.Empty))
                    {
                        param[2].Value = null;
                    }
                    else
                    {
                        param[2].Value = striedanie.Striedajuci.IdHrac;
                    }

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri pridavani striedania!");
                }
            }
        }

        private void InsertOut(Udalost udalost)
        {
            Out _out = (Out)udalost;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                try
                {
                    conn.Open();
                    string cmdQuery1 = "INSERT INTO out(id_udalost, id_vhadzujuci_hrac) VALUES(:id_udalost, :id_hrac)";
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[2];
                    param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int16);
                    param[0].Value = _out.IdUdalosti;
                    param[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int16);
                    if (_out.Hrac.Meno.Equals(string.Empty))
                    {
                        param[1].Value = null;
                    }
                    else
                    {
                        param[1].Value = _out.Hrac.IdHrac;
                    }

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri pridavani outu!");
                }
            }
        }

        private void InsertOffside(Udalost udalost)
        {
            Offside offside = (Offside)udalost;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                try
                {
                    conn.Open();
                    string cmdQuery1 = "INSERT INTO offside(id_udalost, id_hrac) VALUES(:id_udalost, :id_hrac)";
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[2];
                    param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int16);
                    param[0].Value = offside.IdUdalosti;
                    param[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int16);
                    if (offside.Hrac.Meno.Equals(string.Empty))
                    {
                        param[1].Value = null;
                    }
                    else
                    {
                        param[1].Value = offside.Hrac.IdHrac;
                    }

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri pridavania offsidu!");
                }
            }
        }

        private void InsertKarta(Udalost udalost)
        {
            Karta karta = (Karta)udalost;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                try
                {
                    conn.Open();
                    string cmdQuery1 = "INSERT INTO karta(id_udalost, id_hrac, id_rozhodca, karta) VALUES(:id_udalost, :id_hrac, :id_rozhodca, :karta)";
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[4];
                    param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int16);
                    param[0].Value = karta.IdUdalosti;
                    param[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int16);
                    if (karta.Hrac.Meno.Equals(string.Empty))
                    {
                        param[1].Value = null;
                    }
                    else
                    {
                        param[1].Value = karta.Hrac.IdHrac;
                    }
                    param[2] = cmd.Parameters.Add("id_rozhodca", OracleDbType.Int16);
                    if (karta.Rozhodca.Meno.Equals(string.Empty))
                    {
                        param[2].Value = null;
                    }
                    else
                    {
                        param[2].Value = karta.Rozhodca.IdRozhodca;
                    }
                    param[3] = cmd.Parameters.Add("karta", OracleDbType.Int16);
                    param[3].Value = karta.IdKarta;

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri pridavani karty!");
                }
            }
        }

        private void InsertKop(Udalost udalost)
        {
            Kop kop = (Kop)udalost;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                try
                {
                    conn.Open();
                    string cmdQuery1 = "INSERT INTO kop(id_udalost, id_hrac, id_typ_kopu) VALUES(:id_udalost, :id_hrac, :id_typ_kopu)";
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[3];
                    param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int16);
                    param[0].Value = kop.IdUdalosti;
                    param[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int16);
                    if (kop.Hrac.Meno.Equals(string.Empty))
                    {
                        param[1].Value = null;
                    }
                    else
                    {
                        param[1].Value = kop.Hrac.IdHrac;
                    }
                    param[2] = cmd.Parameters.Add("id_typ_kopu", OracleDbType.Int16);
                    param[2].Value = kop.IdTypKopu;

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri pridavani kopu!");
                }
            }
        }

        private void InsertGol(Udalost udalost)
        {
            Gol gol = (Gol)udalost;
            using (OracleConnection conn = new OracleConnection(constring))
            {
                try
                {
                    conn.Open();
                    string cmdQuery1 = "INSERT INTO gol(id_udalost, id_hraca_strelec, id_typ_golu, id_hraca_asistujuci) VALUES(:id_udalost, :id_hraca_strelec, :id_typ_golu, :id_hraca_asistujuci)";
                    OracleCommand cmd = new OracleCommand(cmdQuery1);
                    OracleParameter[] param = new OracleParameter[4];
                    param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int16);
                    param[0].Value = gol.IdUdalosti;
                    param[1] = cmd.Parameters.Add("id_hraca_strelec", OracleDbType.Int16);
                    if (gol.Strielajuci.Meno.Equals(string.Empty))
                    {
                        param[1].Value = null;
                    }
                    else
                    {
                        param[1].Value = gol.Strielajuci.IdHrac;
                    }
                    param[2] = cmd.Parameters.Add("id_typ_golu", OracleDbType.Int16);
                    param[2].Value = gol.TypGolu;
                    param[3] = cmd.Parameters.Add("id_hraca_asistujuci", OracleDbType.Int16);
                    if (gol.Asistujuci.Meno.Equals(string.Empty))
                    {
                        param[3].Value = null;
                    }
                    else
                    {
                        param[3].Value = gol.Asistujuci.IdHrac;
                    }
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    conn.Close();
                }
                catch
                {
                    throw new Exception("Chyba pri pridavani golu!");
                }
            }
        }

        #endregion ZAPASY

    }

}
