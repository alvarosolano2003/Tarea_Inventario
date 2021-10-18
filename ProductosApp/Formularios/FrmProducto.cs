using AppCore.Interfaces;
using Domain.Entities;
using Domain.Entities.Invetory;
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
    public partial class FrmProducto : Form
    {
        public InventarioModel inv = new PEPS();
        public FrmProducto()
        {
            this.CenterToScreen();
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Registros p = new Registros()
            {
                FechaRegistro = dtpRegistro.Value,
                Existencia = (int)nudExist.Value,
                ValorUnidad = nudValorU.Value,
                ValorTotal = (int)nudExist.Value * nudValorU.Value,
                Especie = (EspecieCuenta)cmbEspecie.SelectedIndex
            };

            inv.Create(p);

            Dispose();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmProducto_Load_1(object sender, EventArgs e)
        {
            nudValorU.Visible = false;
            lblValorU.Visible = false;
        }

        private void cmbEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspecie.SelectedIndex == 0)
            {
                nudValorU.Visible = true;
                lblValorU.Visible = true;
            }
            else
            {
                nudValorU.Visible = false;
                lblValorU.Visible = false;
            }
        }
    }
}
