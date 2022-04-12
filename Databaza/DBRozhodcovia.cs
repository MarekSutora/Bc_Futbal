using System;
using System.Data;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;
using LGR_Futbal.Model;

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

        public async Task<List<Rozhodca>> GetRozhodcoviaAsync()
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
                            rozhodca.IdRozhodca = reader.GetInt32(0);
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
                throw new Exception("Chyba pri práci s Databázou");
            }
            return rozhodcovia;
        }

        public int InsertRozhodca(Rozhodca r)
        {
            int id = 0;
            try
            {
                if (conn.State != ConnectionState.Open)
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

                string cmdQuery4 = "SELECT MAX(id_rozhodca) FROM rozhodca";
                cmd.CommandText = cmdQuery4;
                id = int.Parse(cmd.ExecuteScalar().ToString());

                conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
            return id;
        }

        public void UpdateRozhodca(Rozhodca r)
        {
            string cmdQuery1 = "UPDATE osoba SET meno = :meno, priezvisko = :priezvisko, pohlavie = :pohlavie WHERE id_osoba = :id_osoba";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OracleCommand cmd = new OracleCommand(cmdQuery1);
                OracleParameter[] param = new OracleParameter[4];

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
                param[3] = cmd.Parameters.Add("id_osoba", OracleDbType.Int32);
                param[3].Value = r.IdOsoba;


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

        public void OdstranRozhodca(Rozhodca rozhodca)
        {
            string cmdQuery = "UPDATE rozhodca SET datum_ukoncenia = SYSDATE WHERE id_rozhodca = :id_rozhodca";
            try
            {
                if (conn.State != ConnectionState.Open)
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
                throw new Exception("Chyba pri práci s Databázou");
            }
        }
        public Rozhodca GetRozhodca(int idRozhodca)
        {
            Rozhodca Rozhodca = null;
            string cmdQuery = "SELECT * FROM rozhodca WHERE id_rozhodca = :id_rozhodca";
            try
            {
                if (conn.State != ConnectionState.Open)
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
                        Rozhodca.IdRozhodca = reader.GetInt32(0);
                        Rozhodca.IdOsoba = reader.GetInt32(1);
                        dbhraci.NastavOsobneUdaje(Rozhodca);
                    }
                }
                conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri práci s Databázou");
            }
            return Rozhodca;
        }
    }
}
