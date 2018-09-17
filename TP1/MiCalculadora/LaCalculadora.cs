using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Elimina los datos (texto/operador) contenidos en cada uno de los controles 
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Limpia el contenido de los controles utilizados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Realiza la operación seleccionada en el combo box operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);
            string operador = cmbOperador.Text;

            double total;

            total = Calculadora.Operar(numero1, numero2, operador);
            lblResultado.Text = total + "";
        }

        /// <summary>
        /// Cierra el programa luego de preguntarnos (SI/NO)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult cerrar;
            cerrar = MessageBox.Show("¿Desea salir de la Calculadora?", "Continuar?", MessageBoxButtons.YesNo);
            if (cerrar == DialogResult.Yes)
                this.Close();
        }

        /// <summary>
        /// Convierte el texto del lebel a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }

        /// <summary>
        /// Convierte el contenido binario del label a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }
        
    }
}
