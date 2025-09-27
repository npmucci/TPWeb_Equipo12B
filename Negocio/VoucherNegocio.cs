using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;


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


        public void MarcarComoUsado(string codigo)
        {
            using (Datos datos = new Datos())
            {
                datos.SetearConsulta("UPDATE Vouchers SET FechaCanje = @fecha WHERE Codigo = @codigo");
                datos.SetearParametro("@fecha", DateTime.Now);
                datos.SetearParametro("@codigo", codigo);
                datos.EjecutarAccion();
            }
        }



    }


}