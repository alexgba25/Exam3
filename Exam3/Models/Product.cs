using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam3.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public byte[] Imagen { get; set; } 

        public Product(int id, string nombre, int cantidad, decimal costo, byte[] imagen)
        {
            ID = id;
            Nombre = nombre;
            Cantidad = cantidad;
            Costo = costo;
            Imagen = imagen;
        }

        public Product() { }
    }
}