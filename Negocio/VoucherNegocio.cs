using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;


namespace Negocio
{

    public enum EstadoVoucher
    {
        Valido,
        YaUsado,
        Inexistente
    }


    public class VoucherNegocio
    {
        public EstadoVoucher ValidarVoucher(string codigo)
        {
            using (Datos datos = new Datos())
            {
                try
                {
                    datos.SetearConsulta("SELECT FechaCanje FROM Vouchers WHERE CodigoVoucher = @codigo");
                    datos.SetearParametro("@codigo", codigo);
                    datos.EjecutarLectura();

                    if (datos.Lector.Read())
                    {
                        object fechaCanje = datos.Lector["FechaCanje"];
                        if (fechaCanje == DBNull.Value)
                            return EstadoVoucher.Valido;    // --> El voucher es válido y no fue usado
                        else
                            return EstadoVoucher.YaUsado;  // --> El voucher existe, pero ya fue usado
                    }
                    else
                    {
                        return EstadoVoucher.Inexistente; // --> El voucher no existe
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al validar voucher: " + ex.Message, ex);
                }
            }
        }


        public void ActualizarVoucher(Voucher voucher, int idCliente, int idArticulo)
        {
            Datos datos = new Datos();

            try
            {
                datos.SetearConsulta("UPDATE VOUCHERS SET IDCLIENTE = @IdCliente, IDARTICULO = @IdArticulo, FechaCanje = GETDATE() WHERE CodigoVoucher = @CodigoVoucher ");
                datos.SetearParametro("@CodigoVoucher", voucher.Codigo);
                datos.SetearParametro("@IdCliente", idCliente);
                datos.SetearParametro("@IdArticulo", idArticulo);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar voucher: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }




    }


}