using Cinepolis.Cine.Business.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinepolis.Cine.Business.Entity
{
    public class EntCine
    {
        public EntCine() { }

        public int id { get; set; }
        public string nombre { get; set; }
        public string sinopsis { get; set; }
        public int generoId { get; set; }

        private EntGenero genero;
        public EntGenero Genero
        {
            get
            {
                if (genero == null)
                    genero = new EntGenero();
                return genero;
            }
            set
            {
                if (genero == null)
                    genero = new EntGenero();

                genero = value;
            }
        }
        public int clasificacionId { get; set; }

        private EntClasificacion clas;

        public EntClasificacion Clas
        {
            get
            {
                if (clas == null)
                    clas = new EntClasificacion();
                return clas;
            }
            set
            {
                if (clas == null)
                    clas = new EntClasificacion();
                clas = value;
            }
        }
        public string fotoMini { get; set; }
        public string fotoPort { get; set; }
        public int anio { get; set; }
        public DateTime fechaAlta { get; set; }
        public Boolean estatus { get; set; }
        public string video { get; set; }
        public string productor { get; set; }


    }
}
