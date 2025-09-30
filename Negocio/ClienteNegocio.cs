using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;
using System.Security.Cryptography.X509Certificates;

namespace Negocio
{
    public class ClienteNegocio
    {
        Datos datos = new Datos();
        public Cliente BuscarCliente(string dni)
        {   
            

            try
                {
                    datos.SetearConsulta("SELECT Id, Email, Nombre, Apellido, Documento, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @dni");
                    datos.SetearParametro("@dni", dni);
                    datos.EjecutarLectura();
                    if (datos.Lector.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            Id = (int)datos.Lector["Id"],
                            Email = (string)datos.Lector["Email"],
                            Nombre = (string)datos.Lector["Nombre"],
                            Apellido = (string)datos.Lector["Apellido"],
                            Documento = (string)datos.Lector["Documento"],
                            Direccion = (string)datos.Lector["Direccion"],
                            Ciudad = (string)datos.Lector["Ciudad"],
                            CP = (int)datos.Lector["CP"]
                        };
                        return cliente;
                    }
                    else
                    {
                        return null; // No se encontró el cliente
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar cliente: " + ex.Message, ex);
                }
                finally
                {
                    datos.CerrarConexion();
            }
            
        }

        public void AgregarCliente(Cliente nuevoCliente)
        {

            try
            {
                datos.SetearConsulta("INSERT INTO Clientes (Email, Nombre, Apellido, Documento, Direccion, Ciudad, CP) VALUES (@Email, @Nombre, @Apellido, @Dni, @Direccion, @Ciudad, @CodPostal)");
                datos.SetearParametro("@Email", nuevoCliente.Email);
                datos.SetearParametro("@Nombre", nuevoCliente.Nombre);
                datos.SetearParametro("@Apellido", nuevoCliente.Apellido);
                datos.SetearParametro("@Dni", nuevoCliente.Documento);
                datos.SetearParametro("@Direccion", nuevoCliente.Direccion);
                datos.SetearParametro("@Ciudad", nuevoCliente.Ciudad);
                datos.SetearParametro("@CodPostal", nuevoCliente.CP);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar cliente: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

         }
    }
}
