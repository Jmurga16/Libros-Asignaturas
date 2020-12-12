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
    public class AsignaturasController : Controller
    {
        AsignaturaBusiness objAsignaturas = new AsignaturaBusiness();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<AsignaturaEntity> LIS_Libros()
        {
            List<AsignaturaEntity> lstAsignaturas = new List<AsignaturaEntity>();
            try
            {
                lstAsignaturas = objAsignaturas.LIS_AsignaturaBusiness();

            }
            catch (Exception)
            {
                throw;
            }
            return lstAsignaturas;
        }

        [Route("id")]
        [HttpGet]
        public List<AsignaturaEntity> LIS_Libros(AsignaturaEntity objLibroEnt)
        {
            List<AsignaturaEntity> lstAsignaturas = new List<AsignaturaEntity>();
            try
            {
                lstAsignaturas = objAsignaturas.LIS_AsignaturaBusiness();

            }
            catch (Exception)
            {
                throw;
            }
            return lstAsignaturas;
        }

        [HttpPost]
        public String CREATE_Game(AsignaturaEntity objLibroEnt)
        {

            AsignaturaEntity libEnt = new AsignaturaEntity();
            string strGame = "";

            try
            {
                strGame = objAsignaturas.CREATE_AsignaturaBusiness(objLibroEnt);
            }
            catch (Exception)
            {
                throw;
            }
            return strGame;
        }

        [Route("id")]
        [HttpPut]
        public String UPDATE_Game(AsignaturaEntity objLibroEnt)
        {

            AsignaturaEntity libEnt = new AsignaturaEntity();
            string strGame = "";

            try
            {
                strGame = objAsignaturas.UPDATE_AsignaturaBusiness(objLibroEnt);

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

            AsignaturaEntity libEnt = new AsignaturaEntity();
            bool bRes;

            try
            {
                bRes = objAsignaturas.DELETE_AsignaturaBusiness(id);

            }
            catch (Exception)
            {
                throw;
            }
            return bRes;
        }


    
    }
}
