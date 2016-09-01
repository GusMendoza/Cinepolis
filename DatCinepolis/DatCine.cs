using Cinepolis.Cine.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinepolis.Cine.Data
{
    public class DatCine : DatAbstracta
    {
        public DatCine() { }


        public DataTable ObtenerPelicula()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT PELI_ID, PELI_NOMB, PELI_SINO, PELI_GENE_ID, PELI_CLAS_ID, PELI_FOTO_MINI, PELI_FOTO_PORT, PELI_ANIO, PELI_FECH_ALTA, PELI_ESTA, PELI_VIDE, PELI_PROD, GENE_ID, GENE_NOMB, GENE_DESC, CLAS_ID, CLAS_NOMB, CLAS_DESC FROM Pelicula INNER JOIN Clasificacion on Clasificacion.CLAS_ID=Pelicula.PELI_CLAS_ID INNER JOIN Genero ON Genero.GENE_ID=Pelicula.PELI_GENE_ID WHERE PELI_ESTA = 'TRUE'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ObtenerEstrenos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 3 PELI_ID, PELI_NOMB, PELI_SINO, PELI_GENE_ID, PELI_CLAS_ID, PELI_FOTO_MINI, PELI_FOTO_PORT, PELI_ANIO, PELI_FECH_ALTA, PELI_ESTA, PELI_VIDE, PELI_PROD FROM Pelicula INNER JOIN Clasificacion on Clasificacion.CLAS_ID=Pelicula.PELI_CLAS_ID INNER JOIN Genero ON Genero.GENE_ID=Pelicula.PELI_GENE_ID WHERE PELI_ESTA= 'TRUE' ORDER BY PELI_FECH_ALTA DESC", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataRow Obtener(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT PELI_ID, PELI_NOMB, PELI_SINO, PELI_GENE_ID, PELI_CLAS_ID, PELI_FOTO_MINI, PELI_FOTO_PORT, PELI_ANIO, PELI_FECH_ALTA, PELI_ESTA, PELI_VIDE, PELI_PROD FROM Pelicula INNER JOIN Clasificacion on Clasificacion.CLAS_ID=Pelicula.PELI_CLAS_ID INNER JOIN Genero ON Genero.GENE_ID=Pelicula.PELI_GENE_ID WHERE PELI_ID=" + id, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];
        }

        public int Actualizar(int id, string nombre, string sinopsis, int generoId, int clasificacionId, string fotoMini, string fotoPort, int anio, string fechaAlta, bool estatus, string video, string productor)
        {
            SqlCommand com = new SqlCommand(string.Format("UPDATE dbo.Pelicula SET PELI_NOMB = '{0}', PELI_SINO = '{1}', PELI_GENE_ID = {2}, PELI_CLAS_ID = {3}, PELI_FOTO_MINI = '{4}', PELI_FOTO_PORT = '{5}', PELI_ANIO = {6}, PELI_FECH_ALTA ='{7}', PELI_ESTA ='{8}', PELI_VIDE  = '{9}', PELI_PROD = '{10}' WHERE PELI_ID = {11}", nombre, sinopsis, generoId, clasificacionId, fotoMini, fotoPort, anio, fechaAlta, estatus, video, productor, id), con);
            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error en capa de datos, " + ex.Message);
            }

        }

        public int Insertar(string nombre, string sinopsis, int generoId, int clasificacionId, string fotoMini, string fotoPort, int anio, string fechaAlta, bool estatus, string video, string productor)
        {
            SqlCommand com = new SqlCommand(string.Format("INSERT INTO Pelicula (PELI_ID, PELI_NOMB, PELI_SINO, PELI_GENE_ID, PELI_CLAS_ID, PELI_FOTO_MINI, PELI_FOTO_PORT, PELI_ANIO, PELI_FECH_ALTA, PELI_ESTA, PELI_VIDE, PELI_PROD) VALUES ((SELECT  ISNULL(MAX(PELI_ID) + 1, 1) FROM Pelicula),'{0}', '{1}', {2}, {3}, '{4}', '{5}', {6}, '{7}', '{8}', '{9}', '{10}')", nombre, sinopsis, generoId, clasificacionId, fotoMini, fotoPort, anio, fechaAlta, estatus, video, productor), con);
            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error en la capa de datos, " + ex.Message);
            }
        }

        public int Borrar(int id)
        {
            SqlCommand com = new SqlCommand(string.Format("UPDATE dbo.Pelicula SET PELI_ESTA ='false' WHERE PELI_ID = {0}", id), con);
            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error en la capa de datos, " + ex.Message);
            }
        }

        public DataTable Validar(string mail, string password)
        {
            SqlCommand com = new SqlCommand("spValidarUsuario", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = mail, ParameterName = @"Mail", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = password, ParameterName = @"Password"});

            SqlDataAdapter da = new SqlDataAdapter(com); 
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
