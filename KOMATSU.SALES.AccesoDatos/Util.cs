using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CapaDatos
{
    public class Util
    {

        public static Database CrearBaseDatos()
        {
            // Create DataBase Instance
            Database db = DatabaseFactory.CreateDatabase("BDkomatsu");

            return db;
        }
    }
}
