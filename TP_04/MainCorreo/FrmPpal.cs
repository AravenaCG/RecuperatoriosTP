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
using System.IO;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        /// <summary>
        /// Constructor que inicializa el formulario y el atributo correo.
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        /// <summary>
        /// Evento que agrega un paquete al correo.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDireccion.Text != "" && mtxtTrackingID.Text != "")
            {
                Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                nuevoPaquete.InformaEstado += paq_InformaEstado;
                try
                {
                    correo += nuevoPaquete;
                    ActualizarEstados();              
                }
                catch (TrackingIdRepetidoException ex)
                {
                    MessageBox.Show(String.Format("El tracking ID {0} ya figura en la lista de envios",
                        nuevoPaquete.TrackingID), ex.Message);
                } 
            }
        }

        /// <summary>
        /// Evento que muestra la lista de paquetes.
        /// </summary>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Evento que muestra un menu al hacer click con boton derecho.
        /// </summary>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Evento que cierra el formulario
        /// </summary>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }


        #region Metodos
        /// <summary>
        /// Metodo que actualiza estados.
        /// </summary>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke( d, new object[] {sender, e} );
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Metodo que muestra informacion.
        /// </summary>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                if (elemento is Correo)
                    rbtMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);
                else if (elemento is Paquete)
                    rbtMostrar.Text = ((Paquete)elemento).ToString();
                
                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string ruta = Path.Combine(escritorio, "salida.txt");
                rbtMostrar.Text.Guardar(ruta);
            }
        }

        /// <summary>
        /// Metodo que actualiza estados.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete aux in correo.Paquetes)
            {               
                switch (aux.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(aux);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(aux);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(aux);
                        break;
                }
            }
        }



        #endregion

        private void rbtMostrar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
