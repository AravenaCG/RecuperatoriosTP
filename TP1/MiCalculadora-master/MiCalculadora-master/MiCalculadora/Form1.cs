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
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }
        /// <summary>
        /// Realiza la Operacion seleccinada entre los 2 numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="x"></param>
        private void btnOperar_Click(object sender, EventArgs x)
        {
            try { 
            Calculadora calculator = new Calculadora();
            Numero num1 = new Numero();
            Numero num2 = new Numero();
            num1.SetNumero = txtNumero1.Text;
            num2.SetNumero = txtNumero2.Text;
            if ((cmbOperador.Text == "/") && ( txtNumero2.Text == "0") )
                {
                    throw new DivideByZeroException("no se puede dividir por Zero!");
                }
           
            lblResultado.Text = calculator.Operar(num1, num2, cmbOperador.Text).ToString();
        }
            catch(DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        /// <summary>
        /// Cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Convierte a Decimal el contenido del lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numAConvertir = new Numero();
            lblResultado.Text = numAConvertir.DecimalBinario(lblResultado.Text);
        }
        /// <summary>
        /// Cheque si el contenido del lblResultado contiene 0 y 1 solamente y eso lo convierte a Decimal de cer asi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero NumBinarioAConvertir = new Numero();
            lblResultado.Text = NumBinarioAConvertir.BinarioDecimal(lblResultado.Text);
        }
        /// <summary>
        /// Limpia los txt , cmb y lbl del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = " Resultado: ";
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.Text = " ";

        }
    }
}
