using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Data
{
    public class AsignaturaData
    {
        private string conf;

        //Construir la conexión
        public string ConfConexion()
        {

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

        //Obtener Todas las asignaturas
        public List<AsignaturaEntity> LIS_AsignaturaData()
        {

            List<AsignaturaEntity> lstAsignatura = new List<AsignaturaEntity>();

            try
            {
                string cOpcion = "02";
                ConfConexion();

                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Asignaturas", conn);
                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                _Command.Parameters.Add(new SqlParameter("@bEstado", null));
                SqlDataReader reader = _Command.ExecuteReader();

                while (reader.Read())
                {
                    AsignaturaEntity asigEnt = new AsignaturaEntity();

                    asigEnt.id_asig = Convert.ToInt32(reader["id_asig"]);
                    asigEnt.descripcion = reader["descripcion"].ToString();
                    asigEnt.estado = Convert.ToBoolean(reader["estado"]);

                    lstAsignatura.Add(asigEnt);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstAsignatura;
        }

        //Obtener una asignatura por id
        public List<AsignaturaEntity> LIS_AsignaturaUnicaData(int id_asignatura)
        {

            List<AsignaturaEntity> lstAsignatura = new List<AsignaturaEntity>();

            try
            {
                string cOpcion = "06";
                ConfConexion();

                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Asignaturas", conn);
                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                _Command.Parameters.Add(new SqlParameter("@bEstado", null));
                _Command.Parameters.Add(new SqlParameter("@nId_asig", id_asignatura));
                SqlDataReader reader = _Command.ExecuteReader();

                while (reader.Read())
                {
                    AsignaturaEntity asigEnt = new AsignaturaEntity();

                    asigEnt.id_asig = Convert.ToInt32(reader["id_asig"]);
                    asigEnt.descripcion = reader["descripcion"].ToString();
                    asigEnt.estado = Convert.ToBoolean(reader["estado"]);

                    lstAsignatura.Add(asigEnt);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstAsignatura;
        }

        //Obtener asignatura por filtros
        public List<AsignaturaEntity> LIS_AsignaturaFiltroData(AsignaturaEntity objAsignaturaEnt)
        {

            List<AsignaturaEntity> lstAsignatura = new List<AsignaturaEntity>();

            try
            {
                string cOpcion = "03";
                ConfConexion();

                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Asignaturas", conn);
                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                _Command.Parameters.Add(new SqlParameter("@nId_asig", objAsignaturaEnt.id_asig));
                _Command.Parameters.Add(new SqlParameter("@cDescripcion", objAsignaturaEnt.descripcion));
                _Command.Parameters.Add(new SqlParameter("@bEstado", objAsignaturaEnt.estado));
                
                //_Command.Parameters.Clear();

                SqlDataReader reader = _Command.ExecuteReader();

                while (reader.Read())
                {
                    AsignaturaEntity asigEnt = new AsignaturaEntity();

                    asigEnt.id_asig = Convert.ToInt32(reader["id_asig"]);
                    asigEnt.descripcion = reader["descripcion"].ToString();
                    asigEnt.estado = Convert.ToBoolean(reader["estado"]);

                    lstAsignatura.Add(asigEnt);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return lstAsignatura;
        }

        //Crear asignatura
        public String CREATE_AsignaturaData(AsignaturaEntity objAsignaturaEnt)
        {
            String strResultado = "";
            string cOpcion = "01";
            try
            {
                ConfConexion();

                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Asignaturas", conn);

                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                _Command.Parameters.Add(new SqlParameter("@nId_asig", objAsignaturaEnt.id_asig));
                _Command.Parameters.Add(new SqlParameter("@cDescripcion", objAsignaturaEnt.descripcion));
                _Command.Parameters.Add(new SqlParameter("@bEstado", objAsignaturaEnt.estado));

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

        //Actualizar asignatura
        public String UPDATE_AsignaturaData(int id_asig, AsignaturaEntity objAsignaturaEnt)
        {
            String strResultado = "";
            string cOpcion = "04";
            try
            {
                ConfConexion();
                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Asignaturas", conn);

                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                _Command.Parameters.Add(new SqlParameter("@nId_asig", id_asig));
                _Command.Parameters.Add(new SqlParameter("@cDescripcion", objAsignaturaEnt.descripcion));
                _Command.Parameters.Add(new SqlParameter("@bEstado", objAsignaturaEnt.estado));

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

        //Eliminar asignatura
        public bool DELETE_AsignaturaData(int id_asig)
        {
            string cOpcion = "05";
            bool res;
            try
            {
                ConfConexion();
                var conn = new SqlConnection(conf);
                conn.Open();

                SqlCommand _Command = new SqlCommand("USP_MNT_Asignaturas", conn);

                _Command.CommandType = CommandType.StoredProcedure;
                _Command.Parameters.Add(new SqlParameter("@cOpcion", cOpcion));
                _Command.Parameters.Add(new SqlParameter("@nId_asig", id_asig));
               

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
