using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam3.Models
{
    public class Games
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
    }
}