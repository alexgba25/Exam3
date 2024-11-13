using Exam3.Data.DbProductsv1TableAdapters;
using Exam3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Exam3.Controllers
{
    public class ProductsController
    {
        private productosTableAdapter productosAdapter = new productosTableAdapter(); // TableAdapter para la tabla "productos"

        public DataTable GetAllProducts()
        {
            return productosAdapter.GetData();
        }

        public void AddProduct(Product product)
        {
            productosAdapter.Insert(product.Nombre, product.Cantidad, product.Costo, product.Imagen);
        }


    }
}