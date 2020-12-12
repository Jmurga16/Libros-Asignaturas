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

        public String CREATE_AsignaturaBusiness(AsignaturaEntity objAsignaturasEnt)
        {
            return asigData.CREATE_AsignaturaData(objAsignaturasEnt);
        }

        public String UPDATE_AsignaturaBusiness(AsignaturaEntity objAsignaturasEnt)
        {
            return asigData.UPDATE_AsignaturaData(objAsignaturasEnt);
        }

        public bool DELETE_AsignaturaBusiness(int id_asig)
        {
            return asigData.DELETE_AsignaturaData(id_asig);
        }

    }
}
