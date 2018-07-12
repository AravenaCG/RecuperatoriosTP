using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Entidades;

namespace Entidades
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void Mostrar_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDireccion.Text != "" && mtxtTrackingId.Text != "")
            {
                Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxtTrackingId.Text);
                nuevoPaquete.Event1 += paq_InformaEstado;
                try
                {
                    correo += nuevoPaquete;
                    ActualizarEstados();
                }
                catch (TranckingIdRepetidoException ex)
                {
                    MessageBox.Show(String.Format("El tracking ID {0} ya figura en la lista de envios",
                        nuevoPaquete.TrackingId), ex.Message);
                }
            }
        }


        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoDeEstado d = new Paquete.DelegadoDeEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                if (elemento is Correo)
                    rtbMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);
                else if (elemento is Paquete)
                    rtbMostrar.Text = ((Paquete)elemento).ToString();

                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string ruta = Path.Combine(escritorio, "salida.txt");
                rtbMostrar.Text.Guardar(ruta);
            }
        }

        /// <summary>
        /// Metodo que actualiza estados.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEsstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete aux in correo.Paquetes)
            {
                switch (aux.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEsstadoIngresado.Items.Add(aux);
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo); 
        }
    }


}



    