using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace LGR_Futbal.Databaza
{
    public class Pripojenie
    {
        private const string constring = "User Id=sutora_bc;Password=bcproj84Qt;Data Source=obelix.fri.uniza.sk:1521/orcl.fri.uniza.sk";
      
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
                throw new Exception("Nepodarilo sa pripojit k databaze");
            }
            return conn;
        }
    }
}
