using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidades
{
    public interface IBarra
    {
        void Nuevo();
        void Buscar();
        bool Grabar();
        bool Editar();
        void Eliminar();
        void Cancelar();
        void Imprimir();
        void Ayuda();
        void Salir();
    }
}
