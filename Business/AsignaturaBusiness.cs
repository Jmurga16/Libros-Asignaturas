using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class AsignaturaBusiness
    {
        AsignaturaData asigData = new AsignaturaData();

        public List<AsignaturaEntity> LIS_AsignaturaBusiness()
        {
            return asigData.LIS_AsignaturaData();
        }

        public List<AsignaturaEntity> LIS_AsignaturaFiltroBusiness(AsignaturaEntity objAsignaturasEnt)
        {
            return asigData.LIS_AsignaturaFiltroData(objAsignaturasEnt);
        }

        public List<AsignaturaEntity> LIS_AsignaturaUnicaBusiness(int id_asignatura)
        {
            return asigData.LIS_AsignaturaUnicaData(id_asignatura);
        }

        public String CREATE_AsignaturaBusiness(AsignaturaEntity objAsignaturasEnt)
        {
            return asigData.CREATE_AsignaturaData(objAsignaturasEnt);
        }

        public String UPDATE_AsignaturaBusiness(int id_asig, AsignaturaEntity objAsignaturasEnt)
        {
            return asigData.UPDATE_AsignaturaData(id_asig, objAsignaturasEnt);
        }

        public bool DELETE_AsignaturaBusiness(int id_asig)
        {
            return asigData.DELETE_AsignaturaData(id_asig);
        }

    }
}
