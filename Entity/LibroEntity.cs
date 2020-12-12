using System;

namespace Entity
{
    public class LibroEntity
    {
        #region parametros
        public string cOpcion { get; set; }
        public int nId_libro { get; set; }
        public string cDescripcion { get; set; }
        public int nId_asig { get; set; }
        public int nStock { get; set; }
        public int bStock { get; set; }
        public string cAsignatura { get; set; }
        #endregion

        #region columnas
        public int Id_libro { get; set; }
        public string descripcion { get; set; }
        public string asignatura { get; set; }
        public int id_asig { get; set; }
        public int stock { get; set; }
        #endregion
    }
}
