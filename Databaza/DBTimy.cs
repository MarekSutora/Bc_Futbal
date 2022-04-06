using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using LGR_Futbal.Model;
using System.Threading.Tasks;


namespace LGR_Futbal.Databaza
{
    public class DBTimy
    {

        private DBHraci dbhraci = null;
        private OracleConnection conn = null;

        public DBTimy(Pripojenie pripojenie, DBHraci dbhraci)
        {
            conn = pripojenie.GetConnection();
            this.dbhraci = dbhraci;
        }
        public async Task<List<FutbalovyTim>> GetTimyAsync()
        {
            List<FutbalovyTim> timy = new List<FutbalovyTim>();
            FutbalovyTim ft;
            string cmdQuery = "SELECT * FROM futbalovy_tim WHERE datum_zrusenia IS NULL";
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
                            ft = new FutbalovyTim();
                            ft.IdFutbalovyTim = reader.GetInt32(0);
                            ft.Kategoria = reader.GetInt32(1);
                            ft.NazovTimu = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                            {
                                ft.LogoBlob = reader.GetOracleBlob(3).Value;
                                ft.LogoImage = dbhraci.BytesToImage(ft.LogoBlob);
                            }
                            timy.Add(ft);
                        }
                    }
                    conn.Close();
                }).ConfigureAwait(false);
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            return timy;
        }

        public async Task<List<string>> GetKategorieAsync()
        {
            List<string> kategorie = new List<string>();

            string cmdQuery = "SELECT nazov_kategoria FROM futbal_kategoria";
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
                            kategorie.Add(reader.GetString(0));
                        }
                    }
                    conn.Close();
                }).ConfigureAwait(false);

            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }
            return kategorie;
        }

        public bool CheckNazovTimu(string nazov)
        {
            bool returnVal = false;
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
            return returnVal;
        }

        public void InsertFutbalovyTeam(FutbalovyTim ft)
        {
            string cmdQuery = "INSERT INTO futbalovy_tim(id_kategoria, nazov_timu, logo) VALUES(:id_kategoria, :nazov_timu, :logo)";
            try
            {
                byte[] blob = null;
                int? kategoria = null;
                if (ft.Kategoria != 0 && ft.Kategoria != -1)
                    kategoria = ft.Kategoria;
                string nazov = ft.NazovTimu;
                if (ft.Logo != null)
                {
                    FileStream fls;
                    fls = new FileStream(@ft.Logo, FileMode.Open, FileAccess.Read);
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

        public void UpdateTim(FutbalovyTim ft)
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
                        fls.Read(blob, 0, Convert.ToInt32(fls.Length));
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

        public void OdstranTim(FutbalovyTim ft)
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
        public string GetNazovTimu(int id)
        {
            string nazov;
            string cmdQuery = "SELECT nazov_timu FROM futbalovy_tim WHERE id_futbalovy_tim = :id_futbalovy_tim";
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OracleCommand cmd = new OracleCommand(cmdQuery);
                OracleParameter param = new OracleParameter("id_futbalovy_tim", OracleDbType.Int32);
                param.Value = id;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(param);

                nazov = cmd.ExecuteScalar().ToString();

                conn.Close();
            }
            catch
            {
                throw new Exception("Chyba pri praci s Databazou");
            }

            return nazov;
        }
    }
}
