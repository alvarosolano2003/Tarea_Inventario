using AppCore.Interfaces;
using Domain.Enums;
using Infraestructure.Inventario;
using Infraestructure.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosApp.Formularios
{
    public partial class FrmProductos : Form
    {
        public InventarioModel inv;
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            InventarioModel obj = SeleccionarObjeto();

            rtbView.Text = $@"Saldo Final: {obj.CalcularSaldo()}
                              Existencias sobrantes: {inv.CalcularExistencias()}";
        }

        public InventarioModel SeleccionarObjeto()
        {
            InventarioModel aux;

            if (cmbFinderType.SelectedIndex == 0)
            {
                aux = new PromedioSimple();
                return aux;
            }
            else if (cmbFinderType.SelectedIndex == 1)
            {
                aux = new PEPS();
                return aux;
            }
            else if (cmbFinderType.SelectedIndex == 2)
            {
                aux = new UEPS();
                return aux;
            }
            else 
            {
                aux = new PromedioPonderado();
                return aux;
            }
        }
    }
}
