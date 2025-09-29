using AccesoDatosLayer;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace AccesoDatosLayer
{
    public class ArticuloDatos
    {
        public List<Articulo> ListarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();

            using (AccesoDatos datos = new AccesoDatos())
            {
                //Agrupo por nombre asi no se repiten articulos
                datos.SetearConsulta(@"
                    SELECT 
                        MIN(A.Id) AS Id,
                        A.Nombre,
                        MIN(A.Descripcion) AS Descripcion,
                        MIN(M.Descripcion) AS MarcaDescripcion,
                        MIN(C.Descripcion) AS CategoriaDescripcion
                    FROM Articulos A
                    INNER JOIN Marcas M ON A.IdMarca = M.Id
                    INNER JOIN Categorias C ON A.IdCategoria = C.Id
                    GROUP BY A.Nombre
                    ORDER BY A.Nombre
                ");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo
                    {
                        Id = (int)datos.Lector["Id"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Marca = new Marca { Descripcion = (string)datos.Lector["MarcaDescripcion"] },
                        Categoria = new Categoria { Descripcion = (string)datos.Lector["CategoriaDescripcion"] }
                    };

                    
                    art.Imagenes = ListarImagenesPorArticulo(art.Id);

                    lista.Add(art);
                }
            }

            return lista;
        }

        //Trae las imagenes 
        public List<Imagen> ListarImagenesPorArticulo(int idArticulo)
        {
            List<Imagen> listaImagenes = new List<Imagen>();

            using (AccesoDatos datos = new AccesoDatos())
            {
                datos.SetearConsulta(
                "SELECT DISTINCT ImagenUrl FROM Imagenes WHERE IdArticulo = " + idArticulo
                );

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    listaImagenes.Add(new Imagen
                    {
                        ImagenUrl = (string)datos.Lector["ImagenUrl"]
                    });
                }
            }

            return listaImagenes;
        }
    }
}
