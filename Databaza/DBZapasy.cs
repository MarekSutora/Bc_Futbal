﻿using System;
using System.Data;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;
using BC_Futbal.Model;

namespace BC_Futbal.Databaza
{
    public class DBZapasy
    {
        private OracleConnection conn = null;
        private DBHraci dbhraci = null;
        private DBRozhodcovia dbrozhodcovia = null;
        private DBTimy dbtimy = null;
        public DBZapasy(Pripojenie pripojenie, DBHraci dbhraci, DBRozhodcovia dbrozhodcovia, DBTimy dbtimy)
        {
            conn = pripojenie.GetConnection();
            this.dbhraci = dbhraci;
            this.dbrozhodcovia = dbrozhodcovia;
            this.dbtimy = dbtimy;
        }

        public void OdstranZapas(Zapas z)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string cmdQuery = "DELETE FROM zapas WHERE id_zapas = :id_zapas";
                OracleParameter param = new OracleParameter("id_zapas", z.IdZapasu);
                param.OracleDbType = OracleDbType.Int32;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Parameters.Add(param);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
        }

        public void InsertZapas(Zapas z)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string cmdQuery1 = "INSERT INTO zapas(id_futbalovy_tim_domaci, id_futbalovy_tim_hostia, datum_zapasu, domaci_skore, hostia_skore, dlzka_polcasu, nadstaveny_cas1, nadstaveny_cas2) " +
                    "VALUES(:id_futbalovy_tim_domaci, :id_futbalovy_tim_hostia, :datum_zapasu, :domaci_skore, :hostia_skore, :dlzka_polcasu, :nadstaveny_cas1, :nadstaveny_cas2)";
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[8];
                param[0] = cmd.Parameters.Add("id_futbalovy_tim_domaci", OracleDbType.Int32);
                param[0].Value = z.Domaci.IdFutbalovyTim;
                param[1] = cmd.Parameters.Add("id_futbalovy_tim_hostia", OracleDbType.Int32);
                param[1].Value = z.Hostia.IdFutbalovyTim;
                param[2] = cmd.Parameters.Add("datum_zapasu", OracleDbType.Date);
                param[2].Value = z.DatumZapasu;
                param[3] = cmd.Parameters.Add("domaci_skore", OracleDbType.Int32);
                param[3].Value = z.DomaciSkore;
                param[4] = cmd.Parameters.Add("hostia_skore", OracleDbType.Int32);
                param[4].Value = z.HostiaSkore;
                param[5] = cmd.Parameters.Add("dlzka_polcasu", OracleDbType.Int32);
                param[5].Value = z.DlzkaPolcasu;
                param[6] = cmd.Parameters.Add("nadstaveny_cas1", OracleDbType.Int32);
                param[6].Value = z.NadstavenyCas1;
                param[7] = cmd.Parameters.Add("nadstaveny_cas1", OracleDbType.Int32);
                param[7].Value = z.NadstavenyCas2;

                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                string cmdQuery2 = "SELECT MAX(id_zapas) FROM zapas";
                cmd.CommandText = cmdQuery2;
                int IdZapas = int.Parse(cmd.ExecuteScalar().ToString());

                string cmdQuery3 = "INSERT INTO zapas_hraci(id_zapas, id_hrac, id_futbalovy_tim, typ_hraca) " +
                    "VALUES(:id_zapas, :id_hrac, :id_futbalovy_tim, :typ_hraca)";

                OracleParameter[] param2 = new OracleParameter[4];
                cmd.CommandText = cmdQuery3;


                for (int i = 0; i < z.Domaci.ZoznamHracov.Count; i++)
                {
                    if (z.Domaci.ZoznamHracov[i].TypHraca != 'X')
                    {
                        param2[0] = cmd.Parameters.Add("id_zapas", OracleDbType.Int32);
                        param2[0].Value = IdZapas;
                        param2[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int32);
                        param2[1].Value = z.Domaci.ZoznamHracov[i].IdHrac;
                        param2[2] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int32);
                        param2[2].Value = z.Domaci.ZoznamHracov[i].IdFutbalovyTim;
                        param2[3] = cmd.Parameters.Add("typ_hraca", OracleDbType.Char);
                        param2[3].Value = z.Domaci.ZoznamHracov[i].TypHraca;
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Parameters.Clear();
                }

                for (int i = 0; i < z.Hostia.ZoznamHracov.Count; i++)
                {

                    if (z.Hostia.ZoznamHracov[i].TypHraca != 'X')
                    {
                        param2[0] = cmd.Parameters.Add("id_zapas", OracleDbType.Int32);
                        param2[0].Value = IdZapas;
                        param2[1] = cmd.Parameters.Add("id_hrac", OracleDbType.Int32);
                        param2[1].Value = z.Hostia.ZoznamHracov[i].IdHrac;
                        param2[2] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int32);
                        param2[2].Value = z.Hostia.ZoznamHracov[i].IdFutbalovyTim;
                        param2[3] = cmd.Parameters.Add("typ_hraca", OracleDbType.Char);
                        param2[3].Value = z.Hostia.ZoznamHracov[i].TypHraca;
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Parameters.Clear();
                }

                OracleParameter[] param4 = new OracleParameter[2];
                string cmdQuery6 = "INSERT INTO zapas_rozhodcovia(id_rozhodca, id_zapas) " +
                    "VALUES(:id_rozhodca, :id_zapas)";
                cmd.CommandText = cmdQuery6;

                for (int i = 0; i < z.Rozhodcovia.Count; i++)
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

                for (int i = 0; i < z.Udalosti.Count; i++)
                {
                    cmd.CommandText = cmdQuery4;
                    param3[0] = cmd.Parameters.Add("id_zapas", OracleDbType.Int32);
                    param3[0].Value = IdZapas;
                    param3[1] = cmd.Parameters.Add("id_futbalovy_tim", OracleDbType.Int32);
                    param3[1].Value = z.Udalosti[i].IdFutbalovyTim;
                    param3[2] = cmd.Parameters.Add("aktualny_cas", OracleDbType.Date);
                    param3[2].Value = z.Udalosti[i].AktualnyCas;
                    param3[3] = cmd.Parameters.Add("minuta", OracleDbType.Int32);
                    param3[3].Value = z.Udalosti[i].Minuta;
                    param3[4] = cmd.Parameters.Add("polcas", OracleDbType.Int32);
                    param3[4].Value = z.Udalosti[i].Polcas;
                    param3[5] = cmd.Parameters.Add("nadstavena_minuta", OracleDbType.Int32);
                    param3[5].Value = z.Udalosti[i].NadstavenaMinuta;
                    param3[6] = cmd.Parameters.Add("typ_udalosti", OracleDbType.Int32);
                    param3[6].Value = z.Udalosti[i].Typ;

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    string cmdQuery5 = "SELECT MAX(id_udalost) FROM udalost";
                    cmd.CommandText = cmdQuery5;
                    int IdUdalost = int.Parse(cmd.ExecuteScalar().ToString());

                    z.Udalosti[i].IdUdalosti = IdUdalost;

                    switch (z.Udalosti[i].Typ)
                    {
                        case 1:
                            InsertGol(z.Udalosti[i]);
                            break;
                        case 2:
                            InsertKarta(z.Udalosti[i]);
                            break;
                        case 3:
                            InsertKop(z.Udalosti[i]);
                            break;
                        case 4:
                            InsertOffside(z.Udalosti[i]);
                            break;
                        case 5:
                            InsertOut(z.Udalosti[i]);
                            break;
                        case 6:
                            InsertStriedanie(z.Udalosti[i]);
                            break;
                    }
                }
                conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
        }
        private void InsertStriedanie(Udalost udalost)
        {
            Striedanie striedanie = (Striedanie)udalost;
            try
            {

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

            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
        }

        private void InsertOut(Udalost udalost)
        {
            Out _out = (Out)udalost;
            try
            {
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

            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
        }

        private void InsertOffside(Udalost udalost)
        {
            Offside offside = (Offside)udalost;
            try
            {
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

            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
        }

        private void InsertKarta(Udalost udalost)
        {
            Karta karta = (Karta)udalost;
            try
            {
                string cmdQuery1 = "INSERT INTO karta(id_udalost, id_hrac, karta) VALUES(:id_udalost, :id_hrac, :karta)";
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[3];
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
                param[2] = cmd.Parameters.Add("karta", OracleDbType.Char);
                param[2].Value = karta.TypKarty;

                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
        }

        private void InsertKop(Udalost udalost)
        {
            Kop kop = (Kop)udalost;
            try
            {
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

            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
        }

        private void InsertGol(Udalost udalost)
        {
            Gol gol = (Gol)udalost;
            try
            {
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

            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
        }

        public async Task<List<Zapas>> GetZapasyAsync()
        {
            List<Zapas> zapasy = new List<Zapas>();
            Zapas zapas;
            int pom1, pom2;

            string cmdQuery = "SELECT * from zapas";
            try
            {
                await Task.Run(() =>
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    OracleCommand cmd = new OracleCommand(cmdQuery);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            zapas = new Zapas();
                            zapas.Domaci = new FutbalovyTim();
                            zapas.Hostia = new FutbalovyTim();
                            zapas.IdZapasu = reader.GetInt32(0);
                            pom1 = reader.GetInt32(1);
                            zapas.NazovDomaci = dbtimy.GetNazovTimu(pom1);
                            zapas.Domaci.IdFutbalovyTim = pom1;
                            pom2 = reader.GetInt32(2);
                            zapas.NazovHostia = dbtimy.GetNazovTimu(pom2);
                            zapas.Hostia.IdFutbalovyTim = pom2;
                            zapas.DatumZapasu = reader.GetDateTime(3);
                            zapas.DomaciSkore = reader.GetInt32(4);
                            zapas.HostiaSkore = reader.GetInt32(5);
                            zapas.DlzkaPolcasu = reader.GetInt32(6);

                            if (!reader.IsDBNull(7))
                                zapas.NadstavenyCas1 = reader.GetInt32(7);
                            if (!reader.IsDBNull(8))
                                zapas.NadstavenyCas2 = reader.GetInt32(8);

                            zapasy.Add(zapas);
                        }
                    }
                    conn.Close();
                }).ConfigureAwait(false);
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
            return zapasy;
        }


        public async Task<Zapas> NastavZapasAsync(Zapas z)
        {
            Zapas zapas = z;

            try
            {
                await Task.Run(() =>
                {
                    if (conn.State != ConnectionState.Open)
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
                        Hrac hrac;
                        while (reader.Read())
                        {
                            hrac = dbhraci.GetHrac(reader.GetInt32(2));
                            hrac.TypHraca = reader.GetString(4)[0];   
                            
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
                    string cmdQuery = "SELECT id_udalost, typ_udalosti FROM udalost WHERE id_zapas = :id_zapas";
                    cmd.CommandText = cmdQuery;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PridajUdalost(reader.GetInt32(0), reader.GetInt32(1), z.Udalosti);
                        }
                    }
                    conn.Close();
                }).ConfigureAwait(false);
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
            return zapas;

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
            striedanie.Typ = 6;
            try
            {
                NastavAtributy(striedanie, id);
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
                            striedanie.Striedajuci = dbhraci.GetHrac(reader.GetInt32(2));
                        if (!reader.IsDBNull(3))
                            striedanie.Striedany = dbhraci.GetHrac(reader.GetInt32(3));
                    }
                }
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }

            udalosti.Add(striedanie);
        }

        private void PridajOutDoUdalosti(int id, List<Udalost> udalosti)
        {
            Out _out = new Out();
            _out.Typ = 5;
            try
            {
                NastavAtributy(_out, id);
                string cmdQuery2 = "SELECT id_vhadzujuci_hrac FROM out WHERE id_udalost = :id_udalost";
                OracleCommand cmd = new OracleCommand(cmdQuery2);
                cmd.CommandText = cmdQuery2;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleParameter param = new OracleParameter("id_udalost", id);
                param.OracleDbType = OracleDbType.Int32;
                cmd.Parameters.Add(param);
                if (!cmd.ExecuteScalar().ToString().Equals(string.Empty))
                    _out.Hrac = dbhraci.GetHrac(int.Parse(cmd.ExecuteScalar().ToString()));

            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }

            udalosti.Add(_out);
        }

        private void PridajOffsideDoUdalosti(int id, List<Udalost> udalosti)
        {
            Offside offside = new Offside();
            offside.Typ = 4;
            try
            {
                NastavAtributy(offside, id);
                string cmdQuery2 = "SELECT id_hrac FROM offside WHERE id_udalost = :id_udalost";
                OracleCommand cmd = new OracleCommand(cmdQuery2);
                cmd.CommandText = cmdQuery2;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                OracleParameter param = new OracleParameter("id_udalost", id);
                param.OracleDbType = OracleDbType.Int32;
                cmd.Parameters.Add(param);

                if (!cmd.ExecuteScalar().ToString().Equals(string.Empty))
                    offside.Hrac = dbhraci.GetHrac(int.Parse(cmd.ExecuteScalar().ToString()));
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }

            udalosti.Add(offside);
        }

        private void PridajKopDoUdalosti(int id, List<Udalost> udalosti)
        {
            Kop kop = new Kop();
            kop.Typ = 3;
            try
            {
                NastavAtributy(kop, id);
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
                            kop.Hrac = dbhraci.GetHrac(reader.GetInt32(2));

                        kop.IdTypKopu = reader.GetInt32(3);
                    }
                }
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }

            udalosti.Add(kop);
        }

        private void PridajtKartaDoUdalosti(int id, List<Udalost> udalosti)
        {
            Karta karta = new Karta();
            karta.Typ = 2;
            try
            {
                NastavAtributy(karta, id);
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
                            karta.Hrac = dbhraci.GetHrac(reader.GetInt32(2));

                        karta.TypKarty = reader.GetString(3)[0];
                    }
                }
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
            udalosti.Add(karta);
        }

        private void PridajGolDoUdalosti(int id, List<Udalost> udalosti)
        {
            Gol gol = new Gol();
            gol.Typ = 1;

            try
            {
                NastavAtributy(gol, id);

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
                        gol.TypGolu = reader.GetInt32(2);
                        if (!reader.IsDBNull(3))
                            gol.Strielajuci = dbhraci.GetHrac(reader.GetInt32(3));
                        if (!reader.IsDBNull(4))
                            gol.Asistujuci = dbhraci.GetHrac(reader.GetInt32(4));
                    }
                }
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
            udalosti.Add(gol);
        }

        private void NastavAtributy(Udalost udalost, int id)
        {
            try
            {
                string cmdQuery = "SELECT * FROM udalost WHERE id_udalost = :id_udalost";
                OracleParameter param = new OracleParameter("id_udalost", id);
                param.OracleDbType = OracleDbType.Int32;
                OracleCommand cmd = new OracleCommand(cmdQuery);
                cmd.Parameters.Add(param);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        udalost.NazovTimu = dbtimy.GetNazovTimu(reader.GetInt32(2));
                        udalost.AktualnyCas = reader.GetDateTime(3);
                        udalost.Minuta = reader.GetInt32(4);
                        udalost.Polcas = reader.GetInt32(5);
                        udalost.NadstavenaMinuta = reader.GetInt32(6);
                    }
                }
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
        }
    }
}
