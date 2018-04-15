using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresionLCD
{
    class Program
    {
        public static int PosF, PosC; // Variables publicas para calcular las posiciones de los números.
        static void Main(string[] args)
        {
            int t = 0; // Tamaño del Objeto
            string Num; // Numero a mostrar
            string xTamNum; // Numero en Texto porque solo es un solo dato para calcular
            do //Ciclo para que repita la instrucción hasta que se digite "0.0"
            {
                string xTexto = "Ingrese el Tamaño y Número: ASI: <3,34233> : ";
                Console.SetCursorPosition((Console.WindowWidth / 2) - (xTexto.Length / 2) - 5, 1); //Centre el Titulo
                Console.Write(xTexto); xTamNum = Console.ReadLine(); //Mostrar y Leer el Número

                int Ancho = Console.WindowWidth; int xTam = xTamNum.Length - 2; //Longitud para Centra en la Pantalla el Número
                try //Evita que muestre algún error en pantalla y se cancele el programa
                {
                    t = Int32.Parse(xTamNum.Substring(0, 1)); // Calcula y almacena en "t" el tamaño del objeto
                    Num = xTamNum.Substring(2, xTam); // Calcula y almacena en "Num" en número a mostrar

                    PosC = (Ancho / 2) - (xTam * t) + 2; PosF = 4; // Define la posición de los números al iniciar.
                    for (int k = 0; k < Num.Length; k++) //Recorre cada número del número principal "Num"
                    {
                        int xNum = Int32.Parse(Num.Substring(k, 1)); //Selecciona Número por Número
                        if (xNum == 7) { PosC = PosC - 1; } // Se elimina una columna si el número es 7
                        switch (xNum) // Ubica el Número y ejecuta las vertices que necesita en su respectiva coordenada
                        {
                            case 1: Ver(t, t, 0); Ver(t, t, t); break;
                            case 2: Ver(t, t, 0); Ver(t, -1, t); Hor(t, -1); Hor(t, t - 1); Hor(t, t * 2 - 1); break;
                            case 3: Ver(t, t, 0); Ver(t, t, t); Hor(t, -1); Hor(t, t - 1); Hor(t, t * 2 - 1); break;
                            case 4: Ver(t, -1, 0); Ver(t, t, 0); Ver(t, t, t); Hor(t, t - 1); break;
                            case 5: Ver(t, -1, 0); Ver(t, t, t); Hor(t, -1); Hor(t, t - 1); Hor(t, t * 2 - 1); break;
                            case 6: Ver(t, -1, 0); Ver(t, -1, t); Ver(t, t, t); Hor(t, -1); Hor(t, t - 1); Hor(t, t * 2 - 1); break;
                            case 7: Ver(t, t, 0); Ver(t, t, t); Hor(t, -1); break;
                            case 8: Ver(t, -1, 0); Ver(t, -1, t); Ver(t, t, 0); Ver(t, t, t); Hor(t, -1); Hor(t, t - 1); Hor(t, t * 2 - 1); break;
                            case 9: Ver(t, -1, 0); Ver(t, t, 0); Ver(t, t, t); Hor(t, -1); Hor(t, t - 1); break;
                            case 0: Ver(t, -1, 0); Ver(t, -1, t); Ver(t, t, 0); Ver(t, t, t); Hor(t, -1); Hor(t, t * 2 - 1); break;
                            default: Console.WriteLine("qLos datos deben ser NÚMEROS asi: <3,548> ó <0.0> = Salir "); break;
                        }
                        int Inc = 0; // Espacios entre cada número
                        if (t == 1) { Inc = 2; } // Si el tamaño es 1 los espacios entre ellos son 2 columnas.
                        PosC = PosC + (t * 2) + Inc; //Establece los espacios entre columnas
                    }
                } // catch = Si hay erroes en Num al ejecutar, muestra el siguiente mensaje... inica t=1 y num=1 y no se sale
                catch { Console.Write("Los datos deben ser completos y Numericos asi: <3,548> ó <0.0> = Salir "); t = 1; Num = "1"; }
                Console.ReadKey(); Console.Clear(); //Hace una pausa y limpia la pantalla
            } while (t != 0 && Num != "0"); //Si el numero es "0.0" se sale del programa
        }

        static void Hor(int t, int Pl) //Procedimiento para los vertices horizontales
        {
            for (int j = 0; j < t; j++) { Console.SetCursorPosition(PosC + j, PosF + Pl); Console.Write("_"); }
        }
        static void Ver(int t, int Pc, int Pu) //Procedimiento para los vertices verticales
        {
            for (int j = 0; j < t; j++) { Console.SetCursorPosition(PosC + Pc, PosF + Pu + j); Console.Write("|"); }
        }
    }
}
