using System;
using System.Windows.Forms;
namespace PresentacionTienda
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new FrmProductos());
        }
    }
}
