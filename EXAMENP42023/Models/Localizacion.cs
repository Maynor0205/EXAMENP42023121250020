using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EXAMENP42023.Models
{
    public class Localizacion
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }

        [MaxLength(200)]
        public string descripcion_larga { get; set; }

        [MaxLength(60)]

        public string descripcion_corta { get; set; }
        
    }
}
