using System.Data;
using ConectarBd;
using EntidadesTienda;
namespace AccesoDatosTienda
{
    public class AccesoDatosProductos
    {
        Base b = new Base("localhost", "root", "", "tienda2");
        public void Borrar(Producto producto)
        {
            b.Comando(string.Format("call p_deleteProducto({0})", producto.Id));
        }

        public void Guardar(Producto producto)
        {
            b.Comando(string.Format("call p_insertOrUpdateProducto('{0}', '{1}', {2}, {3})",producto.Nombre,
                producto.Descripcion, producto.Precio, producto.Id));
        }
        public DataSet Mostrar(string filtro)
        {
            return b.Obtener(string.Format("call p_showProductos('%{0}%')", filtro), "productos");
        }
    }
}
