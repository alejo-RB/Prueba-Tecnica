using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class VehiculoDatos
    {
        public List<VehiculoModel> Listar()
        {
            var oLista = new List<VehiculoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ListarVehiculos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new VehiculoModel()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            codigo = Convert.ToString(dr["codigo"]),
                            chasis = Convert.ToString(dr["chasis"]),
                            marca = Convert.ToString(dr["marca"]),
                            modelo = Convert.ToString(dr["modelo"]),
                            anio_modelo = Convert.ToInt32(dr["anio_modelo"]),
                            color = Convert.ToString(dr["color"]),
                            estado = Convert.ToString(dr["estado"]),
                            fecha_registro = Convert.ToDateTime(dr["fecha_registro"]),
                        });
                    }
                }
            }
            return oLista;
        }

        public VehiculoModel Obtener(int id)
        {
            
            var oVehiculo = new VehiculoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerVehiculo", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oVehiculo.id = Convert.ToInt32(dr["id"]);
                        oVehiculo.codigo = Convert.ToString(dr["codigo"]);
                        oVehiculo.chasis = Convert.ToString(dr["chasis"]);
                        oVehiculo.marca = Convert.ToString(dr["marca"]);
                        oVehiculo.modelo = Convert.ToString(dr["modelo"]);
                        oVehiculo.anio_modelo = Convert.ToInt32(dr["anio_modelo"]);
                        oVehiculo.color = Convert.ToString(dr["color"]);
                        oVehiculo.estado = Convert.ToString(dr["estado"]);
                        oVehiculo.fecha_registro = Convert.ToDateTime(dr["fecha_registro"]);
                    }
                }
            }
            return oVehiculo;
        }

        public bool Guardar(VehiculoModel ovehiculo)
        {
            bool rpta;

            try
            {
                //instancia a la clase de conexion
                var cn = new Conexion();
                //usamos esa cadena para crear la conexión
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    //abro la conexion
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("codigo", ovehiculo.codigo);
                    cmd.Parameters.AddWithValue("chasis", ovehiculo.chasis);
                    cmd.Parameters.AddWithValue("marca", ovehiculo.marca);
                    cmd.Parameters.AddWithValue("modelo", ovehiculo.modelo);
                    cmd.Parameters.AddWithValue("anio_modelo", ovehiculo.anio_modelo);
                    cmd.Parameters.AddWithValue("color", ovehiculo.color);
                    cmd.Parameters.AddWithValue("estado", ovehiculo.estado);
                    cmd.Parameters.AddWithValue("fecha_registro", ovehiculo.fecha_registro);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //ejecutar SP Preocedimiento Almacenado
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex) {
                string error = ex.Message;
                rpta=false;
            }

            return rpta;
        }

        public bool Editar(VehiculoModel ovehiculo)
        {
            bool rpta;

            try
            {
                //instancia a la clase de conexion
                var cn = new Conexion();
                //usamos esa cadena para crear la conexión
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    //abro la conexion
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("ActualizarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("id", ovehiculo.id);
                    cmd.Parameters.AddWithValue("codigo", ovehiculo.codigo);
                    cmd.Parameters.AddWithValue("chasis", ovehiculo.chasis);
                    cmd.Parameters.AddWithValue("marca", ovehiculo.marca);
                    cmd.Parameters.AddWithValue("modelo", ovehiculo.modelo);
                    cmd.Parameters.AddWithValue("anio_modelo", ovehiculo.anio_modelo);
                    cmd.Parameters.AddWithValue("color", ovehiculo.color);
                    cmd.Parameters.AddWithValue("estado", ovehiculo.estado);
                    cmd.Parameters.AddWithValue("fecha_registro", ovehiculo.fecha_registro);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //ejecutar SP Preocedimiento Almacenado
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int id)
        {
            bool rpta;

            try
            {
                //instancia a la clase de conexion
                var cn = new Conexion();
                //usamos esa cadena para crear la conexión
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    //abro la conexion
                    conexion.Open();
                    //definir nombre del procedimiento almacenado
                    SqlCommand cmd = new SqlCommand("EliminarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //ejecutar SP Preocedimiento Almacenado
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
