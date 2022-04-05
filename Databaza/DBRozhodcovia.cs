using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using LGR_Futbal.Model;
using System.Threading.Tasks;

namespace LGR_Futbal.Databaza
{
    public class DBRozhodcovia
    {
        private OracleConnection conn = null;
        private DBHraci dbhraci = null;
        public DBRozhodcovia(Pripojenie pripojenie, DBHraci dbhraci)
        {
            conn = pripojenie.GetConnection();
            this.dbhraci = dbhraci;
        }

        public async Task<List<Rozhodca>> GetRozhodcovia()
        {
            List<Rozhodca> rozhodcovia = new List<Rozhodca>();
            Rozhodca rozhodca;
            string cmdQuery = "SELECT * FROM rozhodca WHERE datum_ukoncenia IS NULL";
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
                            rozhodca = new Rozhodca();
                            if (!reader.IsDBNull(0))
                                rozhodca.IdRozhodca = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                                rozhodca.IdOsoba = reader.GetInt32(1);
                            dbhraci.NastavOsobneUdaje(rozhodca);
                            rozhodcovia.Add(rozhodca);
                        }
                    }
                    conn.Close();
                }).ConfigureAwait(false);
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            return rozhodcovia;
        }

        public void InsertRozhodca(Rozhodca r)
        {
            try
            {
                conn.Open();
                string cmdQuery1 = "INSERT INTO osoba(meno, priezvisko, pohlavie) VALUES(:meno, :priezvisko, :pohlavie)";
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[3];
                param[0] = cmd.Parameters.Add("meno", OracleDbType.Varchar2);
                param[0].Value = r.Meno;
                param[1] = cmd.Parameters.Add("priezvisko", OracleDbType.Varchar2);
                param[1].Value = r.Priezvisko;
                param[2] = cmd.Parameters.Add("pohlavie", OracleDbType.Char);
                if (r.Pohlavie != 'X')
                {

                    param[2].Value = r.Pohlavie;
                }
                else
                {
                    param[2].Value = null;
                }
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();


                string cmdQuery2 = "SELECT MAX(id_osoba) FROM osoba";
                cmd.CommandText = cmdQuery2;
                int ID = int.Parse(cmd.ExecuteScalar().ToString());

                string cmdQuery3 = "INSERT INTO rozhodca(id_osoba) VALUES(:id_osoba)";
                cmd.CommandText = cmdQuery3;
                OracleParameter param1 = new OracleParameter("id_osoba", OracleDbType.Int32);
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

        public void UpdateRozhodca(Rozhodca r)
        {
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            string cmdQuery1 = "UPDATE osoba SET meno = :meno, priezvisko = :priezvisko, datum_narodenia = :datum_narodenia, pohlavie = :pohlavie WHERE id_osoba = :id_osoba";
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[4];

                param[0] = cmd.Parameters.Add("meno", OracleDbType.Varchar2);
                param[0].Value = r.Meno;
                param[1] = cmd.Parameters.Add("priezvisko", OracleDbType.Varchar2);
                param[1].Value = r.Priezvisko;
                param[2] = cmd.Parameters.Add("id_osoba", OracleDbType.Int32);
                param[2].Value = r.IdOsoba;
                param[3] = cmd.Parameters.Add("pohlavie", OracleDbType.Char);
                if (r.Pohlavie != 'X')
                {

                    param[3].Value = r.Pohlavie;
                }
                else
                {
                    param[3].Value = null;
                }

                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            //}
        }

        public void OdstranRozhodcu(Rozhodca rozhodca)
        {
            //using (OracleConnection conn = new OracleConnection(constring))
            //{
            string cmdQuery = "UPDATE rozhodca SET datum_ukoncenia = SYSDATE WHERE id_rozhodca = :id_rozhodca";
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(cmdQuery);
                OracleParameter param = new OracleParameter("id_rozhodca", OracleDbType.Int32);
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
            //}
        }
        public Rozhodca GetRozhodca(int idRozhodca)
        {
            Rozhodca Rozhodca = null;
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
                            Rozhodca.IdRozhodca = reader.GetInt32(0);
                        if (!reader.IsDBNull(1))
                            Rozhodca.IdOsoba = reader.GetInt32(1);
                        dbhraci.NastavOsobneUdaje(Rozhodca);
                    }
                }
                conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            return Rozhodca;
        }
    }
}
