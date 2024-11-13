using Exam3.Controllers;
using Exam3.Data.DbGamesTableAdapters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exam3.Views
{
    public partial class Games : System.Web.UI.Page
    {
        private GamesController controller = new GamesController();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindGamesGrid();
            }
        }

        private void BindGamesGrid()
        {
            gvJuegos.DataSource = controller.GetAllGames();
            gvJuegos.DataBind();
        }

        protected void btnAgregarJuego_Click(object sender, EventArgs e)
        {
            
            string nombre = txtNombre.Text;
            string cantidadStr = txtCantidad.Text;
            string precioStr = txtPrecio.Text;
            string imagenNombre = null; 

            // Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(nombre))
            {
                MostrarAlerta("El nombre del juego es obligatorio.");
                return;
            }

            if (string.IsNullOrEmpty(cantidadStr) || !int.TryParse(cantidadStr, out int cantidad) || cantidad <= 0)
            {
                MostrarAlerta("La cantidad debe ser un número positivo.");
                return;
            }

            // Validar el precio
            if (string.IsNullOrEmpty(precioStr) || !decimal.TryParse(precioStr, out decimal precio) || precio <= 0)
            {
                MostrarAlerta("El precio debe ser un número decimal positivo.");
                return;
            }

            // Validar imagen
            if (fileImagen.HasFile)
            {
                string fileExtension = Path.GetExtension(fileImagen.FileName).ToLower();
                if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
                {
                    MostrarAlerta("La imagen debe tener formato JPG, JPEG o PNG.");
                    return;
                }


                string nombreArchivo = Path.GetFileName(fileImagen.FileName); 
                string rutaFisica = "~/Images/" + nombreArchivo;
                imagenNombre = rutaFisica;

            }
            else
            {
                MostrarAlerta("Debe subir una imagen para el juego.");
                return;
            }

            
            try
            {
                videojuegosTableAdapter gamesAdapter = new videojuegosTableAdapter();
                gamesAdapter.Insert(nombre, cantidad, precio, imagenNombre); 
                MostrarAlerta("Juego agregado correctamente.");
                BindGamesGrid(); 
            }
            catch (Exception ex)
            {
                MostrarAlerta("Ocurrió un error al agregar el juego: " + ex.Message);
            }
        }

        // Método para mostrar una alerta de JavaScript
        private void MostrarAlerta(string mensaje)
        {
            string script = $"alert('{mensaje}');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }
    }
}