using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum PerfilTipoPermisoBE
    {
        PermisoA, // ABM Usuarios
        PermisoB, // Gestión de Perfiles de Acceso
        PermisoC, // Asignar Perfiles a Usuarios
        PermisoD, // Puede Emitir Presupuestos
        PermisoE, // Puede realizar Aprobacion Técnica de Presupuesto
        PermisoF, // Puede Realizar Aprobación Comercial de Presupuesto
        PermisoG, // Visualizar Presupuestos
        PermisoH, // Puede Anular Presupuestos
        PermisoJ, // Gestión de Idioma y Traducciones
        Ninguno, // No borrar esto (usado en PerfilComponenteDAL)
    }
}
