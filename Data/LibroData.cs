using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Data
{
    public class LibroData
    {
        private string conf;
        public string ConfConexion()
        {
            
            //Construir la conexión
            try
            {
                var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfiguration configuration = builder.Build();
                conf = configuration["ConnectionStrings:connectionString"];
            }
            catch (Exception)
            {

                throw;
            }
            return conf;
        }

        //Obtener Todos los libros
        public List<LibroEntity> LIS_LibroData()
        {

            List<LibroEntity> lstLibros = new List<LibroEntity>();

            try
            {
                string cOpcion = "02";
                ConfConexion();

                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Libros", conn);
                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                //_Command.Parameters.Clear();

                SqlDataReader reader = _Command.ExecuteReader();

                while (reader.Read())
                {
                    LibroEntity libEnt = new LibroEntity();

                    libEnt.Id_libro = Convert.ToInt32(reader["Id_libro"]);                    
                    libEnt.descripcion = reader["descripcion"].ToString();
                    libEnt.asignatura = reader["asignatura"].ToString();                 
                    libEnt.stock = Convert.ToInt32(reader["stock"]);
           

                    lstLibros.Add(libEnt);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstLibros;
        }

        //Obtener un libro por id
        public List<LibroEntity> LIS_LibroUnicoData(int id_libro)
        {

            List<LibroEntity> lstLibros = new List<LibroEntity>();

            try
            {
                string cOpcion = "06";
                ConfConexion();

                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Libros", conn);
                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                _Command.Parameters.Add(new SqlParameter("@nId_libro", id_libro));
                //_Command.Parameters.Clear();

                SqlDataReader reader = _Command.ExecuteReader();

                while (reader.Read())
                {
                    LibroEntity libEnt = new LibroEntity();

                    libEnt.Id_libro = Convert.ToInt32(reader["Id_libro"]);
                    libEnt.descripcion = reader["descripcion"].ToString();
                    libEnt.asignatura = reader["asignatura"].ToString();
                    libEnt.stock = Convert.ToInt32(reader["stock"]);


                    lstLibros.Add(libEnt);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstLibros;
        }

        //Obtener libro por filtros
        public List<LibroEntity> LIS_LibroFiltroData(LibroEntity objLibroEnt)
        {

            List<LibroEntity> lstLibros = new List<LibroEntity>();

            try
            {
                string cOpcion = "03";
                ConfConexion();

                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Libros", conn);
                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                //_Command.Parameters.Add(new SqlParameter("@nId_asig", objLibroEnt.nId_asig));
                _Command.Parameters.Add(new SqlParameter("@cDescripcion", objLibroEnt.cDescripcion));
                _Command.Parameters.Add(new SqlParameter("@cAsignatura", objLibroEnt.cAsignatura));
                _Command.Parameters.Add(new SqlParameter("@bStock", objLibroEnt.bStock));
                //_Command.Parameters.Clear();

                SqlDataReader reader = _Command.ExecuteReader();

                while (reader.Read())
                {
                    LibroEntity libEnt = new LibroEntity();

                    libEnt.Id_libro = Convert.ToInt32(reader["Id_libro"]);
                    libEnt.descripcion = reader["descripcion"].ToString();
                    libEnt.asignatura = reader["asignatura"].ToString();
                    libEnt.stock = Convert.ToInt32(reader["stock"]);


                    lstLibros.Add(libEnt);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstLibros;
        }

        //Crear libro
        public String CREATE_LibroData(LibroEntity objLibroEnt)
        {
            String strResultado = "";
            string cOpcion = "01";
            try
            {
                ConfConexion();

                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Libros", conn);
                
                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                _Command.Parameters.Add(new SqlParameter("@nId_asig", objLibroEnt.nId_asig));
                _Command.Parameters.Add(new SqlParameter("@cDescripcion", objLibroEnt.cDescripcion));
                _Command.Parameters.Add(new SqlParameter("@nStock", objLibroEnt.nStock));

                if (_Command.ExecuteNonQuery() != 0)
                {
                    strResultado = "OK";
                    //return strResultado;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                strResultado = "";
                throw new Exception(ex.Message, ex);
            }

            return strResultado;
        }

        //Actualizar libro
        public String UPDATE_LibroData(int id_libro,LibroEntity objLibroEnt)
        {
            String strResultado = "";
            string cOpcion = "04";
            try
            {
                ConfConexion();
                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Libros", conn);

                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                _Command.Parameters.Add(new SqlParameter("@nId_libro", id_libro));
                _Command.Parameters.Add(new SqlParameter("@nId_asig", objLibroEnt.nId_asig));
                _Command.Parameters.Add(new SqlParameter("@cDescripcion", objLibroEnt.cDescripcion));
                _Command.Parameters.Add(new SqlParameter("@nStock", objLibroEnt.nStock));

                if (_Command.ExecuteNonQuery() != 0)
                {
                    strResultado = "OK";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                strResultado = "";
                throw new Exception(ex.Message, ex);
            }

            return strResultado;
        }

        //Eliminar libro
        public bool DELETE_LibroData(int id_libro)
        {
            string cOpcion = "05";
            bool res;
            try
            {
                ConfConexion();
                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Libros", conn);

                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                _Command.Parameters.Add(new SqlParameter("@nId_libro", id_libro));

                if (_Command.ExecuteNonQuery() != 0)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                res = false;
                throw new Exception(ex.Message, ex);
            }

            return res;
        }

    }
}
