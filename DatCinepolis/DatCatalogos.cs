using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinepolis.Cine.Data
{
    public class DatCatalogos : DatAbstracta
    {
        public DatCatalogos() { }

        public DataTable obtenerClas() 
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT CLAS_ID, CLAS_NOMB, CLAS_DESC FROM Clasificacion", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerGenero() 
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT GENE_ID, GENE_NOMB, GENE_DESC FROM Genero", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
