using Cinepolis.Cine.Business.Entity;
using Cinepolis.Cine.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinepolis.Cine.Business
{
     public class BusCatalogos
    {
         public BusCatalogos() { }
         public List<EntClasificacion> ObtenerClas() 
         {
             DataTable dt = new DatCatalogos().obtenerClas();
             List<EntClasificacion> lista = new List<EntClasificacion>();
             foreach (DataRow dr in dt.Rows)
             {
                 EntClasificacion ent = new EntClasificacion();
                 ent.id = Convert.ToInt32(dr["CLAS_ID"]);
                 ent.nombre = dr["CLAS_NOMB"].ToString();
                 ent.descripcion = dr["CLAS_DESC"].ToString();
                 lista.Add(ent);                                 
             }
             return lista; 
         }

         public List<EntGenero> ObtenerGenero() 
         {
             DataTable dt = new DatCatalogos().ObtenerGenero();
             List<EntGenero> lista = new List<EntGenero>();
             foreach (DataRow dr in dt.Rows)
	          {
		        EntGenero ent = new EntGenero();
                 ent.id = Convert.ToInt32(dr["GENE_ID"]);
                 ent.nombre = dr["GENE_NOMB"].ToString();
                 ent.descripcion = dr["GENE_DESC"].ToString();
                 lista.Add(ent);
	          }

             return lista;
         }
    }
}
