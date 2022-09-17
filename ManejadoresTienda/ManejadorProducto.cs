using System.Drawing;
using System.Windows.Forms;
using AccesoDatosTienda;
using CRUD;
using EntidadesTienda;
namespace ManejadoresTienda
{
    public class ManejadorProducto
    {
        AccesoDatosProductos accesoDatosProductos = new AccesoDatosProductos();
        Grafico g = new Grafico();

        public void Guardar(Producto producto)
        {
            accesoDatosProductos.Guardar(producto);
            g.Mensaje("Producto guardado con éxito", "Aviso", MessageBoxIcon.Information);
        }
        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.RowTemplate.Height = 30;
            tabla.DataSource = accesoDatosProductos.Mostrar(filtro).Tables["productos"];
            tabla.Columns.Insert(4, g.Boton("Editar", Color.Blue, Color.White));
            tabla.Columns.Insert(5, g.Boton("Borrar", Color.Red, Color.White));
            tabla.Columns[0].Visible = false;
            tabla.AutoResizeColumns();
        }
    }
}
