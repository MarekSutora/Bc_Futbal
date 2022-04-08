using System;
using Oracle.ManagedDataAccess.Client;

namespace LGR_Futbal.Databaza
{
    public class Pripojenie
    {
        private const string constring = "User Id=sutora_bc;Password=bcproj84Qt;Data Source=obelix.fri.uniza.sk:1521/orcl.fri.uniza.sk;Connection Lifetime=120";

        public Pripojenie()
        {

        }

        public OracleConnection GetConnection()
        {
            OracleConnection conn;
            try
            {
                conn = new OracleConnection(constring);
            }
            catch
            {
                throw new Exception("Nepodarilo sa pripojiť k databáze");
            }
            return conn;
        }
    }
}
