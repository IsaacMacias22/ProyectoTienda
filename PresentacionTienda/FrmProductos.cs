using System;
using System.Windows.Forms;
using ManejadoresTienda;
using EntidadesTienda;
namespace PresentacionTienda
{
    public partial class FrmProductos : Form
    {
        ManejadorProducto manejadorProducto;
        public static Producto producto = new Producto(0,"","",0);
        int fila = 0, col = 0;
        public FrmProductos()
        {
            InitializeComponent();
            manejadorProducto = new ManejadorProducto();
        }
        void Actualizar()
        {
            manejadorProducto.Mostrar(dtgProductos, txtBuscar.Text);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            producto.Id = -1;
            FrmProductosAdd productosAdd = new FrmProductosAdd();
            productosAdd.ShowDialog();
            txtBuscar.Clear();
            Actualizar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtgProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
            producto.Id = int.Parse(dtgProductos.Rows[fila].Cells[0].Value.ToString());
            producto.Nombre = dtgProductos.Rows[fila].Cells[1].Value.ToString();
            producto.Descripcion = dtgProductos.Rows[fila].Cells[2].Value.ToString();
            producto.Precio = double.Parse(dtgProductos.Rows[fila].Cells[3].Value.ToString());
        }

        private void dtgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (col)
            {
                case 4:
                    {
                        FrmProductosAdd fpa = new FrmProductosAdd();
                        fpa.ShowDialog();
                        txtBuscar.Text = "-1";
                        txtBuscar.Clear();
                        Actualizar();
                    } break;
                case 5:
                    {
                        manejadorProducto.Borrar(producto);
                        txtBuscar.Text = "";
                        Actualizar();
                    } break;
            }
        }

    }
}
