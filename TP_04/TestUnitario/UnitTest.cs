using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ListaInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaqueteRepetido()
        {
            Correo correo = new Correo();

            correo += new Paquete("Av. Santa Fe 1900", "666-666-6666");
            correo += new Paquete("Av. Corrientes 2000", "666-666-6666");
        }
    }
}
