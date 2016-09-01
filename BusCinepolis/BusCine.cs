using Cinepolis.Cine.Business.Entity;
using Cinepolis.Cine.Data;
using Cinepolis.Cine.Business.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinepolis.Cine.Business
{
    public class BusCine
    {
        public BusCine() { }
        public List<EntCine> ObtenerPelicula()
        {
            DataTable dt = new DatCine().ObtenerPelicula();
            List<EntCine> lista = new List<EntCine>();
            foreach (DataRow dr in dt.Rows)
            {
                EntCine ent = new EntCine();
                ent.id = Convert.ToInt32(dr["PELI_ID"]);
                ent.nombre = dr["PELI_NOMB"].ToString();
                ent.sinopsis = dr["PELI_SINO"].ToString();
                ent.generoId = Convert.ToInt32(dr["PELI_GENE_ID"]);
                ent.clasificacionId = Convert.ToInt32(dr["PELI_CLAS_ID"]);
                ent.fotoMini = dr["PELI_FOTO_MINI"].ToString();
                ent.fotoPort = dr["PELI_FOTO_PORT"].ToString();
                ent.anio = Convert.ToInt32(dr["PELI_ANIO"]);
                ent.fechaAlta = Convert.ToDateTime(dr["PELI_FECH_ALTA"]);
                ent.estatus = Convert.ToBoolean(dr["PELI_ESTA"]);
                ent.video = dr["PELI_VIDE"].ToString();
                ent.productor = dr["PELI_PROD"].ToString();
               //ent.Clas = new EntClasificacion();
                ent.Clas.nombre = dr["CLAS_NOMB"].ToString();
                //ent.Genero = new EntGenero();
                ent.Genero.nombre = dr["GENE_NOMB"].ToString();

                lista.Add(ent);
            }
            return lista;

        }

        public List<EntCine> ObtenerEstrenos()
        {
            DataTable dt = new DatCine().ObtenerEstrenos();
            List<EntCine> lista = new List<EntCine>();
            foreach (DataRow dr in dt.Rows)
            {
                EntCine ent = new EntCine();
                ent.id = Convert.ToInt32(dr["PELI_ID"]);
                ent.nombre = dr["PELI_NOMB"].ToString();
                ent.sinopsis = dr["PELI_SINO"].ToString();
                ent.generoId = Convert.ToInt32(dr["PELI_GENE_ID"]);
                ent.clasificacionId = Convert.ToInt32(dr["PELI_CLAS_ID"]);
                ent.fotoMini = dr["PELI_FOTO_MINI"].ToString();
                ent.fotoPort = dr["PELI_FOTO_PORT"].ToString();
                ent.anio = Convert.ToInt32(dr["PELI_ANIO"]);
                ent.fechaAlta = Convert.ToDateTime(dr["PELI_FECH_ALTA"]);
                ent.estatus = Convert.ToBoolean(dr["PELI_ESTA"]);
                ent.video = dr["PELI_VIDE"].ToString();
                ent.productor = dr["PELI_PROD"].ToString();
                lista.Add(ent);
            }
            return lista;

        }


        public EntCine obtener(int id)
        {
            DataRow dr = new DatCine().Obtener(id);
            EntCine ent = new EntCine();

            ent.id = Convert.ToInt32(dr["PELI_ID"]);
            ent.nombre = dr["PELI_NOMB"].ToString();
            ent.sinopsis = dr["PELI_SINO"].ToString();
            ent.generoId = Convert.ToInt32(dr["PELI_GENE_ID"]);
            ent.clasificacionId = Convert.ToInt32(dr["PELI_CLAS_ID"]);
            ent.fotoMini = dr["PELI_FOTO_MINI"].ToString();
            ent.fotoPort = dr["PELI_FOTO_PORT"].ToString();
            ent.anio = Convert.ToInt32(dr["PELI_ANIO"]);
            ent.fechaAlta = Convert.ToDateTime(dr["PELI_FECH_ALTA"]);
            ent.estatus = Convert.ToBoolean(dr["PELI_ESTA"]);
            ent.video = dr["PELI_VIDE"].ToString();
            ent.productor = dr["PELI_PROD"].ToString();

            return ent;
        }

        public void Actualizar(Entity.EntCine ent)
        {
            int filas = new DatCine().Actualizar(ent.id, ent.nombre, ent.sinopsis, ent.generoId, ent.clasificacionId, ent.fotoMini, ent.fotoPort, ent.anio, ent.fechaAlta.ToString("MM/dd/yyyy"), ent.estatus, ent.video, ent.productor);
            if (filas != 1)
                throw new ApplicationException(string.Format("Error al actualizar {0}", ent.nombre));
        }

        public void Insertar(Entity.EntCine ent)
        {
            int filas = new DatCine().Insertar(ent.nombre, ent.sinopsis, ent.generoId, ent.clasificacionId, ent.fotoMini, ent.fotoPort, ent.anio, ent.fechaAlta.ToString("MM/dd/yyyy"), ent.estatus, ent.video, ent.productor);
            if (filas != 1)          
                 throw new ApplicationException(string.Format("Error al Insertar {0}", ent.nombre));
            
        }

        public void Borrar(Entity.EntCine ent)
        {
            int filas = new DatCine().Borrar(ent.id);
            if (filas != 1)
            {
                throw new ApplicationException("No fue posible eliminar esta pelicula");
            }
        }

        public EntUsuario Validar(string mail, string password)
        {
            DataTable dt = new DatCine().Validar(mail, password);
            if (dt.Rows.Count > 0)
            {
                EntUsuario user = new EntUsuario();
                user.id = Convert.ToInt32(dt.Rows[0]["USER_ID"]);
                user.nombre = dt.Rows[0]["USER_NOMB"].ToString();
                user.password = dt.Rows[0]["USER_PASS"].ToString();
                user.mail = dt.Rows[0]["USER_MAIL"].ToString();
                return user;
            }
            else
            {
                throw new ApplicationException("Mail o Contraseña NO validos");
            }            
        }
    }
}
