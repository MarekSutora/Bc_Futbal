using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using LGR_Futbal.Model;
using LGR_Futbal.Databaza;


namespace LGR_Futbal.Databaza
{

    public class DBZapasy
    {
        private OracleConnection conn = null;
        private DBHraci dbhraci = null;
        private DBRozhodcovia dbrozhodcovia = null;
        public DBZapasy(Pripojenie pripojenie, DBHraci dbhraci, DBRozhodcovia dbrozhodcovia)
        {
            conn = pripojenie.GetConnection();
            this.dbhraci = dbhraci;
            this.dbrozhodcovia = dbrozhodcovia;
        }

        public void PridajZapas(Zapas Zapas)
        {
            List<Udalost> udalosti;
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            try
            {
                conn.Open();
                string cmdQuery1 = "INSERT INTO zapas(id_futbalovy_tim_domaci, id_futbalovy_tim_hostia, datum_zapasu, domaci_skore, hostia_skore, dlzka_polcasu, nadstaveny_cas1, nadstaveny_cas2) " +
                    "VALUES(:id_futbalovy_tim_domaci, :id_futbalovy_tim_hostia, :datum_zapasu, :domaci_skore, :hostia_skore, :dlzka_polcasu, :nadstaveny_cas1, :nadstaveny_cas2)";
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[8];
                param[0] = cmd.Parameters.Add("id_futbalovy_tim_domaci", OracleDbType.Int32);
                param[0].Value = Zapas.Domaci.IdFutbalovyTim;
                param[1] = cmd.Parameters.Add("id_futbalovy_tim_hostia", OracleDbType.Int32);
                param[1].Value = Zapas.Hostia.IdFutbalovyTim;
                param[2] = cmd.Parameters.Add("datum_zapasu", OracleDbType.Date);
                param[2].Value = Zapas.DatumZapasu;
                param[3] = cmd.Parameters.Add("domaci_skore", OracleDbType.Int32);
                param[3].Value = Zapas.DomaciSkore;
                param[4] = cmd.Parameters.Add("hostia_skore", OracleDbType.Int32);
                param[4].Value = Zapas.HostiaSkore;
                param[5] = cmd.Parameters.Add("dlzka_polcasu", OracleDbType.Int32);
                param[5].Value = Zapas.DlzkaPolcasu;
                param[6] = cmd.Parameters.Add("nadstaveny_cas1", OracleDbType.Int32);
                param[6].Value = Zapas.NadstavenyCas1;
                param[7] = cmd.Parameters.Add("nadstaveny_cas1", OracleDbType.Int32);
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
                    if (Zapas.Domaci.ZoznamHracov[i].Priradeny != 'X')
                    {
                        param2[0] = cmd.Parameters.Add("id_zapas", OracleDbType.Int32);
                        param2[0].Value = IdZapas;
                        param2[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int32);
                        param2[1].Value = Zapas.Domaci.ZoznamHracov[i].IdHrac;
                        param2[2] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int32);
                        param2[2].Value = Zapas.Domaci.ZoznamHracov[i].IdFutbalovyTim;
                        param2[3] = cmd.Parameters.Add("typ_hraca", OracleDbType.Char);
                        param2[3].Value = Zapas.Domaci.ZoznamHracov[i].Priradeny;
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Parameters.Clear();
                }

                for (int i = 0; i < Zapas.Hostia.ZoznamHracov.Count; i++)
                {

                    if (Zapas.Hostia.ZoznamHracov[i].Priradeny != 'X')
                    {
                        param2[0] = cmd.Parameters.Add("id_zapas", OracleDbType.Int32);
                        param2[0].Value = IdZapas;
                        param2[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int32);
                        param2[1].Value = Zapas.Hostia.ZoznamHracov[i].IdHrac;
                        param2[2] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int32);
                        param2[2].Value = Zapas.Hostia.ZoznamHracov[i].IdFutbalovyTim;
                        param2[3] = cmd.Parameters.Add("typ_hraca", OracleDbType.Char);
                        param2[3].Value = Zapas.Hostia.ZoznamHracov[i].Priradeny;
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Parameters.Clear();
                }

                OracleParameter[] param4 = new OracleParameter[2];
                string cmdQuery6 = "INSERT INTO zapas_rozhodcovia(id_rozhodca, id_zapas) " +
                    "VALUES(:id_rozhodca, :id_zapas)";
                cmd.CommandText = cmdQuery6;

                for (int i = 0; i < Zapas.Rozhodcovia.Count; i++)
                {
                    param4[0] = cmd.Parameters.Add("id_rozhodca", OracleDbType.Int32);
                    param4[0].Value = IdZapas;
                    param4[1] = cmd.Parameters.Add("id_zapas", OracleDbType.Int32);
                    param4[1].Value = IdZapas;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }


                string cmdQuery4 = "INSERT INTO udalost(id_zapas, id_futbalovy_tim, aktualny_cas, minuta, polcas, nadstavena_minuta, typ_udalosti) " +
                    "VALUES(:id_zapas, :aktualny_cas, :id_futbalovy_tim, :minuta, :polcas, :nadstavena_minuta, :typ_udalosti)";
                OracleParameter[] param3 = new OracleParameter[7];

                for (int i = 0; i < udalosti.Count; i++)
                {
                    cmd.CommandText = cmdQuery4;
                    param3[0] = cmd.Parameters.Add("id_zapas", OracleDbType.Int32);
                    param3[0].Value = IdZapas;
                    param3[1] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int32);
                    param3[1].Value = udalosti[i].IdFutbalovyTim;
                    param3[2] = cmd.Parameters.Add("aktualny_cas", OracleDbType.Date);
                    param3[2].Value = udalosti[i].AktualnyCas;
                    param3[3] = cmd.Parameters.Add("minuta", OracleDbType.Int32);
                    param3[3].Value = udalosti[i].Minuta;
                    param3[4] = cmd.Parameters.Add("polcas", OracleDbType.Int32);
                    param3[4].Value = udalosti[i].Polcas;
                    param3[5] = cmd.Parameters.Add("nadstavena_minuta", OracleDbType.Int32);
                    param3[5].Value = udalosti[i].NadstavenaMinuta;
                    param3[6] = cmd.Parameters.Add("typ_udalosti", OracleDbType.Int32);
                    param3[6].Value = udalosti[i].Typ;

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
            //}
        }
        private void InsertStriedanie(Udalost udalost)
        {
            Striedanie striedanie = (Striedanie)udalost;
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            try
            {
                conn.Open();
                string cmdQuery1 = "INSERT INTO striedanie(id_udalost, id_hraca_striedajuci, id_hraca_striedany) VALUES(:id_udalost, :id_hraca_striedajuci, :id_hraca_striedany)";
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[3];
                param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int32);
                param[0].Value = striedanie.IdUdalosti;
                param[1] = cmd.Parameters.Add("id_hraca_striedajuci", OracleDbType.Int32);
                if (striedanie.Striedajuci.Meno.Equals(string.Empty))
                {
                    param[1].Value = null;
                }
                else
                {
                    param[1].Value = striedanie.Striedajuci.IdHrac;
                }
                param[2] = cmd.Parameters.Add("id_hraca_striedany", OracleDbType.Int32);
                if (striedanie.Striedany.Meno.Equals(string.Empty))
                {
                    param[2].Value = null;
                }
                else
                {
                    param[2].Value = striedanie.Striedany.IdHrac;
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
            //}
        }

        private void InsertOut(Udalost udalost)
        {
            Out _out = (Out)udalost;
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            try
            {
                conn.Open();
                string cmdQuery1 = "INSERT INTO out(id_udalost, id_vhadzujuci_hrac) VALUES(:id_udalost, :id_hrac)";
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[2];
                param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int32);
                param[0].Value = _out.IdUdalosti;
                param[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int32);
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
            //}
        }

        private void InsertOffside(Udalost udalost)
        {
            Offside offside = (Offside)udalost;
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            try
            {
                conn.Open();
                string cmdQuery1 = "INSERT INTO offside(id_udalost, id_hrac) VALUES(:id_udalost, :id_hrac)";
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[2];
                param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int32);
                param[0].Value = offside.IdUdalosti;
                param[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int32);
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
            //}
        }

        private void InsertKarta(Udalost udalost)
        {
            Karta karta = (Karta)udalost;
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            try
            {
                conn.Open();
                string cmdQuery1 = "INSERT INTO karta(id_udalost, id_hrac, id_rozhodca, karta) VALUES(:id_udalost, :id_hrac, :id_rozhodca, :karta)";
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[4];
                param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int32);
                param[0].Value = karta.IdUdalosti;
                param[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int32);
                if (karta.Hrac.Meno.Equals(string.Empty))
                {
                    param[1].Value = null;
                }
                else
                {
                    param[1].Value = karta.Hrac.IdHrac;
                }
                param[2] = cmd.Parameters.Add("id_rozhodca", OracleDbType.Int32);
                if (karta.Rozhodca.Meno.Equals(string.Empty))
                {
                    param[2].Value = null;
                }
                else
                {
                    param[2].Value = karta.Rozhodca.IdRozhodca;
                }
                param[3] = cmd.Parameters.Add("karta", OracleDbType.Char);
                param[3].Value = karta.TypKarty;

                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri pridavani karty!");
            }
            //}
        }

        private void InsertKop(Udalost udalost)
        {
            Kop kop = (Kop)udalost;
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            try
            {
                conn.Open();
                string cmdQuery1 = "INSERT INTO kop(id_udalost, id_hrac, id_typ_kopu) VALUES(:id_udalost, :id_hrac, :id_typ_kopu)";
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[3];
                param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int32);
                param[0].Value = kop.IdUdalosti;
                param[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int32);
                if (kop.Hrac.Meno.Equals(string.Empty))
                {
                    param[1].Value = null;
                }
                else
                {
                    param[1].Value = kop.Hrac.IdHrac;
                }
                param[2] = cmd.Parameters.Add("id_typ_kopu", OracleDbType.Int32);
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
            //}
        }

        private void InsertGol(Udalost udalost)
        {
            Gol gol = (Gol)udalost;
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            try
            {
                conn.Open();
                string cmdQuery1 = "INSERT INTO gol(id_udalost, id_hraca_strelec, id_typ_golu, id_hraca_asistujuci) VALUES(:id_udalost, :id_hraca_strelec, :id_typ_golu, :id_hraca_asistujuci)";
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[4];
                param[0] = cmd.Parameters.Add("id_udalost", OracleDbType.Int32);
                param[0].Value = gol.IdUdalosti;
                param[1] = cmd.Parameters.Add("id_hraca_strelec", OracleDbType.Int32);
                if (gol.Strielajuci.Meno.Equals(string.Empty))
                {
                    param[1].Value = null;
                }
                else
                {
                    param[1].Value = gol.Strielajuci.IdHrac;
                }
                param[2] = cmd.Parameters.Add("id_typ_golu", OracleDbType.Int32);
                param[2].Value = gol.TypGolu;
                param[3] = cmd.Parameters.Add("id_hraca_asistujuci", OracleDbType.Int32);
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
            //}
        }

        public List<Zapas> GetZapasy()
        {
            List<Zapas> zapasy = new List<Zapas>();
            Zapas zapas = null;
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            string cmdQuery = "SELECT * from zapas";
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
                        zapas = new Zapas();
                        if (!reader.IsDBNull(0))
                            zapas.IdZapasu = reader.GetInt32(0);
                        //if (!reader.IsDBNull(1))
                        //    zapas.NazovDomaci = GetNazovTimu(reader.GetInt32(1));
                        //if (!reader.IsDBNull(2))
                        //    zapas.NazovHostia = GetNazovTimu(reader.GetInt32(2));
                        if (!reader.IsDBNull(3))
                            zapas.DatumZapasu = reader.GetDateTime(3);
                        if (!reader.IsDBNull(4))
                            zapas.DomaciSkore = reader.GetInt32(4);
                        if (!reader.IsDBNull(5))
                            zapas.HostiaSkore = reader.GetInt32(5);
                        if (!reader.IsDBNull(5))
                            zapas.DlzkaPolcasu = reader.GetInt32(6);
                        zapas.NadstavenyCas1 = reader.GetInt32(7);
                        zapas.NadstavenyCas2 = reader.GetInt32(8);

                        FutbalovyTim domaci = new FutbalovyTim();
                        FutbalovyTim hostia = new FutbalovyTim();

                        domaci = GetTim(reader.GetInt32(1));
                        hostia = GetTim(reader.GetInt32(2));

                        zapas.Domaci = domaci;
                        zapas.Hostia = hostia;

                        zapasy.Add(zapas);
                    }
                }
                conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}

            return zapasy;
        }

        private FutbalovyTim GetTim(int id)
        {
            FutbalovyTim ft = new FutbalovyTim();

            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            string cmdQuery = "SELECT * FROM futbalovy_tim WHERE id_futbalovy_tim = :id_futbalovy_tim";
            try
            {
                //conn.Open();
                OracleCommand cmd = new OracleCommand(cmdQuery);
                OracleParameter param = new OracleParameter("id_futbalovy_tim", OracleDbType.Varchar2);
                param.Value = id;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(param);

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(1))
                            ft.Kategoria = reader.GetInt32(1);
                        if (!reader.IsDBNull(2))
                            ft.NazovTimu = reader.GetString(2);

                    }
                }
                //conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}

            return ft;
        }

        public void NastavUdalosti(Zapas zapas)
        {
            List<Udalost> udalosti = new List<Udalost>();
            zapas.Udalosti = udalosti;
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            try
            {
                conn.Open();
                string cmdQuery2 = "SELECT id_rozhodca FROM zapas_rozhodcovia WHERE id_zapas = :id_zapas";
                OracleParameter param = new OracleParameter("id_zapas", zapas.IdZapasu);
                param.OracleDbType = OracleDbType.Int32;
                OracleCommand cmd = new OracleCommand(cmdQuery2);
                cmd.Parameters.Add(param);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rozhodca rozhodca = new Rozhodca();
                        rozhodca = dbrozhodcovia.GetRozhodca(int.Parse(cmd.ExecuteScalar().ToString()));
                        zapas.Rozhodcovia.Add(rozhodca);
                    }
                }

                string cmdQuery3 = "SELECT * FROM zapas_hraci WHERE id_zapas = :id_zapas";
                cmd.CommandText = cmdQuery3;

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    Hrac hrac = new Hrac();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(4))
                            hrac.Priradeny = reader.GetString(4)[0];
                        if (!reader.IsDBNull(3))
                        {
                            if (reader.GetInt32(3) == zapas.Domaci.IdFutbalovyTim)
                            {
                                zapas.Domaci.ZoznamHracov.Add(hrac);
                            }
                            else if (reader.GetInt32(3) == zapas.Hostia.IdFutbalovyTim)
                            {
                                zapas.Hostia.ZoznamHracov.Add(hrac);
                            }
                        }
                    }
                }

                string cmdQuery = "SELECT id_udalost, typ_udalosti FROM udalost WHERE id_zapas = :id_zapas";


                cmd.CommandText = cmdQuery;


                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PridajUdalost(reader.GetInt32(0), reader.GetInt32(1), zapas.Udalosti);
                    }
                }
                conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}

        }
        private void PridajUdalost(int id, int typ, List<Udalost> udalosti)
        {
            switch (typ)
            {
                case 1:
                    PridajGolDoUdalosti(id, udalosti);
                    break;
                case 2:
                    PridajtKartaDoUdalosti(id, udalosti);
                    break;
                case 3:
                    PridajKopDoUdalosti(id, udalosti);
                    break;
                case 4:
                    PridajOffsideDoUdalosti(id, udalosti);
                    break;
                case 5:
                    PridajOutDoUdalosti(id, udalosti);
                    break;
                case 6:
                    PridajStriedanieDoUdalosti(id, udalosti);
                    break;
            }

        }

        private void PridajStriedanieDoUdalosti(int id, List<Udalost> udalosti)
        {
            Striedanie striedanie = new Striedanie();
            //using (OracleConnection conn = new OracleConnection(constring))
            //{

            try
            {
                NastavAtributy(striedanie, id);
                //conn.Open();

                string cmdQuery2 = "SELECT * FROM striedanie WHERE id_udalost = :id_udalost";
                OracleCommand cmd = new OracleCommand(cmdQuery2);
                cmd.CommandText = cmdQuery2;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleParameter param = new OracleParameter("id_udalost", id);
                param.OracleDbType = OracleDbType.Int32;
                cmd.Parameters.Add(param);

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(2))
                            striedanie.Striedajuci = dbhraci.getHrac(reader.GetInt32(2));
                        if (!reader.IsDBNull(3))
                            striedanie.Striedany = dbhraci.getHrac(reader.GetInt32(3));
                    }
                }

                //conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}

            udalosti.Add(striedanie);
        }

        private void PridajOutDoUdalosti(int id, List<Udalost> udalosti)
        {
            Out _out = new Out();
            // using (OracleConnection conn = new OracleConnection(constring))
            //{

            try
            {
                NastavAtributy(_out, id);
                //conn.Open();

                string cmdQuery2 = "SELECT id_vhadzujuci_hrac FROM out WHERE id_udalost = :id_udalost";
                OracleCommand cmd = new OracleCommand(cmdQuery2);
                cmd.CommandText = cmdQuery2;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleParameter param = new OracleParameter("id_udalost", id);
                param.OracleDbType = OracleDbType.Int32;
                cmd.Parameters.Add(param);
                if (!cmd.ExecuteScalar().ToString().Equals(string.Empty))
                    _out.Hrac = dbhraci.getHrac(int.Parse(cmd.ExecuteScalar().ToString()));

                //conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}

            udalosti.Add(_out);
        }

        private void PridajOffsideDoUdalosti(int id, List<Udalost> udalosti)
        {
            Offside offside = new Offside();
            //using (OracleConnection conn = new OracleConnection(constring))
            //{

            try
            {
                NastavAtributy(offside, id);
                //conn.Open();

                string cmdQuery2 = "SELECT id_hrac FROM offside WHERE id_udalost = :id_udalost";
                OracleCommand cmd = new OracleCommand(cmdQuery2);
                cmd.CommandText = cmdQuery2;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleParameter param = new OracleParameter("id_udalost", id);
                param.OracleDbType = OracleDbType.Int32;
                cmd.Parameters.Add(param);

                if (!cmd.ExecuteScalar().ToString().Equals(string.Empty))
                    offside.Hrac = dbhraci.getHrac(int.Parse(cmd.ExecuteScalar().ToString()));

                //conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}

            udalosti.Add(offside);
        }

        private void PridajKopDoUdalosti(int id, List<Udalost> udalosti)
        {
            Kop kop = new Kop();
            //using (OracleConnection conn = new OracleConnection(constring))
            //{

            try
            {
                NastavAtributy(kop, id);
                //conn.Open();

                string cmdQuery2 = "SELECT * FROM kop WHERE id_udalost = :id_udalost";
                OracleCommand cmd = new OracleCommand(cmdQuery2);
                cmd.CommandText = cmdQuery2;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleParameter param = new OracleParameter("id_udalost", id);
                param.OracleDbType = OracleDbType.Int32;
                cmd.Parameters.Add(param);

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(2))
                            kop.Hrac = dbhraci.getHrac(reader.GetInt32(2));
                        if (!reader.IsDBNull(3))
                            kop.IdTypKopu = reader.GetInt32(3);
                    }
                }
                //conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}

            udalosti.Add(kop);
        }

        private void PridajtKartaDoUdalosti(int id, List<Udalost> udalosti)
        {
            Karta karta = new Karta();
            //using (OracleConnection conn = new OracleConnection(constring))
            //{

            try
            {
                NastavAtributy(karta, id);
                //conn.Open();

                string cmdQuery2 = "SELECT * FROM karta WHERE id_udalost = :id_udalost";
                OracleCommand cmd = new OracleCommand(cmdQuery2);
                cmd.CommandText = cmdQuery2;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleParameter param = new OracleParameter("id_udalost", id);
                param.OracleDbType = OracleDbType.Int32;
                cmd.Parameters.Add(param);

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(2))
                            karta.Hrac = dbhraci.getHrac(reader.GetInt32(2));
                        if (!reader.IsDBNull(4))
                            karta.TypKarty = reader.GetString(4)[0];
                    }
                }
                //conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}
            udalosti.Add(karta);
        }

        private void PridajGolDoUdalosti(int id, List<Udalost> udalosti)
        {
            Gol gol = new Gol();
            //using (OracleConnection conn = new OracleConnection(constring))
            //{

            try
            {
                NastavAtributy(gol, id);
                //conn.Open();

                string cmdQuery2 = "SELECT * FROM gol WHERE id_udalost = :id_udalost";
                OracleCommand cmd = new OracleCommand(cmdQuery2);
                cmd.CommandText = cmdQuery2;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleParameter param = new OracleParameter("id_udalost", id);
                param.OracleDbType = OracleDbType.Int32;
                cmd.Parameters.Add(param);

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(2))
                            gol.Strielajuci = dbhraci.getHrac(reader.GetInt32(2));
                        if (!reader.IsDBNull(3))
                            gol.TypGolu = reader.GetInt32(3);
                        if (!reader.IsDBNull(4))
                            gol.Asistujuci = dbhraci.getHrac(reader.GetInt32(4));
                    }
                }
                //conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}
            udalosti.Add(gol);
        }

        private void NastavAtributy(Udalost udalost, int id)
        {
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            try
            {
                //conn.Open();
                string cmdQuery = "SELECT * FROM udalost WHERE id_udalost = :id_udalost";
                OracleParameter param = new OracleParameter("id_udalost", id);
                param.OracleDbType = OracleDbType.Int32;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Parameters.Add(param);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(2))
                            udalost.NazovTimu = GetNazovTimu(reader.GetInt32(2));
                        if (!reader.IsDBNull(3))
                            udalost.AktualnyCas = reader.GetDateTime(3);
                        if (!reader.IsDBNull(4))
                            udalost.Minuta = reader.GetInt32(4);
                        if (!reader.IsDBNull(5))
                            udalost.Polcas = reader.GetInt32(5);
                        if (!reader.IsDBNull(6))
                            udalost.NadstavenaMinuta = reader.GetInt32(6);

                    }
                }
                //conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}
        }

        private string GetNazovTimu(int id)
        {
            string nazov = string.Empty;
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            string cmdQuery = "SELECT nazov_timu FROM futbalovy_tim WHERE id_futbalovy_tim = :id_futbalovy_tim";
            try
            {
                //conn.Open();
                OracleCommand cmd = new OracleCommand(cmdQuery);
                OracleParameter param = new OracleParameter("id_futbalovy_tim", OracleDbType.Int32);
                param.Value = id;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(param);

                nazov = cmd.ExecuteScalar().ToString();

                //conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}
            return nazov;
        }
    }
}
