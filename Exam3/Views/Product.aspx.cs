using Exam3.Controllers;
using Exam3.Data.DbProductsv1TableAdapters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exam3.Views
{
    public partial class Product : System.Web.UI.Page
    {
        private ProductsController controller = new ProductsController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductsGrid();
            }
        }

        private void BindProductsGrid()
        {
            gvProductos.DataSource = controller.GetAllProducts();
            gvProductos.DataBind();
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Captura los datos del formulario
            string nombre = txtNombre.Text;
            int cantidad = int.Parse(txtCantidad.Text);
            decimal costo = decimal.Parse(txtCosto.Text);
            byte[] imagenBytes = null;

            // Convierte la imagen en un arreglo de bytes si se sube una
            if (fileImagen.HasFile)
            {
                using (BinaryReader br = new BinaryReader(fileImagen.PostedFile.InputStream))
                {
                    imagenBytes = br.ReadBytes(fileImagen.PostedFile.ContentLength);
                }
            }

            // Crea una instancia del TableAdapter y llama al método Insert
            productosTableAdapter productosAdapter = new productosTableAdapter();
            productosAdapter.Insert(nombre, cantidad, costo, imagenBytes);

            BindProductsGrid();
        }
    }
}