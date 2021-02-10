using Business;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckyBooks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : Controller
    {
        LibroBusiness objLibros = new LibroBusiness();
        public IActionResult Index()
        {
            return View();
        }

        //Obtener Todos los libros
        [HttpGet]
        public List<LibroEntity> LIS_Libros()
        {
            List<LibroEntity> lstLibros = new List<LibroEntity>();
            try
            {
                lstLibros = objLibros.LIS_LibroBusiness();

            }
            catch (Exception)
            {
                throw;
            }
            return lstLibros;
        }

        //Obtener uno para editar
        [Route("editar/{id}")]
        [HttpGet]
        public List<LibroEntity> LIS_LibroUnico(int id)
        {
            List<LibroEntity> lstLibros = new List<LibroEntity>();
            try
            {
                lstLibros = objLibros.LIS_LibroUnicoBusiness(id);

            }
            catch (Exception)
            {
                throw;
            }
            return lstLibros;
        }

        //Obtener con filtros
        [Route("filtrar")]
        [HttpPost]
        public List<LibroEntity> LIS_LibrosFiltro(LibroEntity objLibroEnt)
        {
            List<LibroEntity> lstLibros = new List<LibroEntity>();
            try
            {
                lstLibros = objLibros.LIS_LibroFiltroBusiness(objLibroEnt);

            }
            catch (Exception)
            {
                throw;
            }
            return lstLibros;
        }

        //Crear Libros
        [HttpPost]
        public String CREATE_Libro(LibroEntity objLibroEnt)
        {

            //LibroEntity libEnt = new LibroEntity();
            string strLibro = "";

            try
            {
                strLibro = objLibros.CREATE_LibroBusiness(objLibroEnt);
            }
            catch (Exception)
            {
                throw;
            }
            return strLibro;
        }

        //Editar Libro
        [Route("{id}")]
        [HttpPut]
        public String UPDATE_Libro(int id, LibroEntity objLibroEnt)
        {

            //LibroEntity libEnt = new LibroEntity();
            string strGame = "";

            try
            {
                strGame = objLibros.UPDATE_LibroBusiness(id,objLibroEnt);

            }
            catch (Exception)
            {
                throw;
            }
            return strGame;
        }

        //Eliminar Libro
        [Route("{id}")]
        [HttpDelete]
        public bool DELETE_Libro(int id)
        {

           // LibroEntity libEnt = new LibroEntity();
            bool bRes;

            try
            {
                bRes = objLibros.DELETE_LibroBusiness(id);

            }
            catch (Exception)
            {
                throw;
            }
            return bRes;
        }


    }
}
