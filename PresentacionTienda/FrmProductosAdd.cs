using System;
using System.Windows.Forms;
using ManejadoresTienda;
using EntidadesTienda;
namespace PresentacionTienda
{
    public partial class FrmProductosAdd : Form
    {
        ManejadorProducto manejadorProducto;
        public FrmProductosAdd()
        {
            InitializeComponent();
            manejadorProducto = new ManejadorProducto();
            if (FrmProductos.producto.Id > 0)
            {
                txtNombre.Text = FrmProductos.producto.Nombre;
                txtDescripcion.Text = FrmProductos.producto.Descripcion;
                txtPrecio.Text = FrmProductos.producto.Precio.ToString();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtPrecio.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de valor en precio", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            manejadorProducto.Guardar(new Producto
                (FrmProductos.producto.Id, txtNombre.Text, txtDescripcion.Text, double.Parse(txtPrecio.Text)));
            Close();
        }
    }
}
