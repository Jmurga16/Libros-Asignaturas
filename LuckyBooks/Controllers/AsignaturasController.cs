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

        //Obtener Todas las asignaturas
        [HttpGet]
        public List<AsignaturaEntity> LIS_Asignaturas()
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

        //Obtener uno para editar
        [Route("editar/{id}")]
        [HttpGet]
        public List<AsignaturaEntity> LIS_AsignaturaUnica(int id)
        {
            List<AsignaturaEntity> lstAsignaturas = new List<AsignaturaEntity>();
            try
            {
                lstAsignaturas = objAsignaturas.LIS_AsignaturaUnicaBusiness(id);
            }
            catch (Exception)
            {
                throw;
            }
            return lstAsignaturas;
        }

        //Obtener con filtros
        [Route("filtrar")]
        [HttpPost]
        public List<AsignaturaEntity> LIS_AsignaturasFiltro(AsignaturaEntity objAsigEnt)
        {
            List<AsignaturaEntity> lstAsignaturas = new List<AsignaturaEntity>();
            try
            {
                lstAsignaturas = objAsignaturas.LIS_AsignaturaFiltroBusiness(objAsigEnt);

            }
            catch (Exception)
            {
                throw;
            }
            return lstAsignaturas;
        }

        //Crear Asignaturas
        [HttpPost]
        public String CREATE_Asignatura(AsignaturaEntity objAsigEnt)
        {

            //AsignaturaEntity asigEnt = new AsignaturaEntity();
            string strGame = "";

            try
            {
                strGame = objAsignaturas.CREATE_AsignaturaBusiness(objAsigEnt);
            }
            catch (Exception)
            {
                throw;
            }
            return strGame;
        }

        //Editar Asignaturas
        [Route("{id}")]
        [HttpPut]
        public String UPDATE_Asignatura(int id, AsignaturaEntity objAsigEnt)
        {

            //AsignaturaEntity asigEnt = new AsignaturaEntity();
            string strGame = "";

            try
            {
                strGame = objAsignaturas.UPDATE_AsignaturaBusiness(id, objAsigEnt);

            }
            catch (Exception)
            {
                throw;
            }
            return strGame;
        }

        //Eliminar Asignaturas
        [Route("{id}")]
        [HttpDelete]
        public bool DELETE_Asignatura(int id)
        {

            AsignaturaEntity asigEnt = new AsignaturaEntity();
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
