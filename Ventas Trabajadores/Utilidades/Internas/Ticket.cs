using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplicacion;

namespace Utilidades
{
    internal class Ticket
    {
        private int intLongTexto, intCorte;
        //intTotalCaracateres: Total de Caracteres Máximos que acepta la impresora Horizontalmente

        public string LineasGuion(int intTotalCaracateres)
        {
            switch (intTotalCaracateres)
            {
                case Constantes.CaracteresEpsonTMU:
                    return @"______________________________________";
                default: //Por Defecto esta configurado para 40
                    return @"----------------------------------------";
            }
        }

        public string LineasAsterisco(int intTotalCaracateres)
        {
            switch (intTotalCaracateres)
            {
                case Constantes.CaracteresEpsonTMU:
                    return @"**************************************";
                default: //Por Defecto esta configurado para 40
                    return @"****************************************";
            }
        }

        public string LineasIgual(int intTotalCaracateres)
        {
            switch (intTotalCaracateres)
            {
                case Constantes.CaracteresEpsonTMU:
                    return @"======================================"; ;
                default: //Por Defecto esta configurado para 40
                    return @"========================================"; ;
            }
        }


        public string TextoIzquierda(string strTexto, int intTotalCaracateres)
        {
            string strTextoImp = "";
            intLongTexto = strTexto.Length;
            if (intLongTexto > intTotalCaracateres)
            {
                intCorte = intLongTexto - intTotalCaracateres;
                strTextoImp = strTexto.Remove(intTotalCaracateres, intCorte);// si es mayor que Tope Caracteres, lo corta
            }
            else strTextoImp = strTexto;
            return strTextoImp;
        }

        public string TextoDerecha(string strTexto, int intTotalCaracateres)
        {
            string strTextoImp = "";
            intLongTexto = strTexto.Length;
            if (intLongTexto > intTotalCaracateres)
            {
                intCorte = intLongTexto - intTotalCaracateres;
                strTextoImp = strTexto.Remove(intTotalCaracateres, intCorte);// si es mayor que Tope Caracteres, lo corta
            }
            else strTextoImp = strTexto;
            intLongTexto = intTotalCaracateres - strTextoImp.Length;  // obtiene la cantidad de espacios para llegar al Tope Caracteres
            strTextoImp = EspacioBlanco(intLongTexto) + strTextoImp;
            return strTextoImp;
        }

        public string TextoCentro(string strTexto, int intTotalCaracateres)
        {
            string strTextoImp = "";

            intLongTexto = strTexto.Length;
            if (intLongTexto > intTotalCaracateres)
            {
                intCorte = intLongTexto - intTotalCaracateres;
                strTextoImp = strTexto.Remove(intTotalCaracateres, intCorte); // si es mayor que Tope Caracteres, lo corta
            }
            else strTextoImp = strTexto;
            intLongTexto = (int)(intTotalCaracateres - strTextoImp.Length) / 2;// saca la cantidad de espacios libres y divide entre dos
            strTextoImp = EspacioBlanco(intLongTexto) + strTextoImp + EspacioBlanco(intLongTexto);
            return strTextoImp;
        }

        public string TextoDistribuido(string[] strEncabezado, int intCantCol, int intTotalCaracateres)
        {
            string strTextoImp = "";
            int intLong = 0;
            int intCantEspacio = 0;

            for (int i = 0; i < intCantCol; i++)
                intLong += strEncabezado[i].Trim().Length;

            intCantEspacio = Convert.ToInt32(Math.Truncate(Convert.ToDouble(((intTotalCaracateres - intLong) / (intCantCol - 1)))));
            if (intCantEspacio >= 1)
            {
                for (int i = 0; i < intCantCol; i++)
                {
                    if (i == 0)
                        strTextoImp += strEncabezado[i];
                    else
                        strTextoImp += EspacioBlanco(intCantEspacio) + strEncabezado[i];
                }
            }
            else strTextoImp = ""; //No Existe Espacio adecuado para dejar entre cada Columna
            return strTextoImp;
        }

        private string EspacioBlanco(int intCantEspacio)
        {
            string strTexto = "";
            for (int i = 0; i <= intCantEspacio; i++)
                strTexto = strTexto + " ";
            return strTexto;
        }
    }
}
