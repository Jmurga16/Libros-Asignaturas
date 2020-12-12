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

        [Route("editar/{id}")]
        [HttpGet]
        public List<LibroEntity> LIS_One(int id)
        {
            List<LibroEntity> lstLibros = new List<LibroEntity>();
            try
            {
                lstLibros = objLibros.LIS_OneBusiness(id);

            }
            catch (Exception)
            {
                throw;
            }
            return lstLibros;
        }

        [Route("id")]
        [HttpGet]
        public List<LibroEntity> LIS_Libros(LibroEntity objLibroEnt)
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

 
        [HttpPost]
        public String CREATE_Game(LibroEntity objLibroEnt)
        {

            LibroEntity libEnt = new LibroEntity();
            string strGame = "";

            try
            {
                strGame = objLibros.CREATE_LibroBusiness(objLibroEnt);
            }
            catch (Exception)
            {
                throw;
            }
            return strGame;
        }

        [Route("{id}")]
        [HttpPut]
        public String UPDATE_Game(int id, LibroEntity objLibroEnt)
        {

            LibroEntity libEnt = new LibroEntity();
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

        [Route("{id}")]
        [HttpDelete]
        public bool DELETE_Game(int id)
        {

            LibroEntity libEnt = new LibroEntity();
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
