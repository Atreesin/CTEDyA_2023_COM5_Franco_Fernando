using System;


namespace CTEDyA_2023_COM5_Franco_Fernando
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ArbolBinario<int> arbol = new ArbolBinario<int>(1);
            arbol.agregarHijoIzquierdo(new ArbolBinario<int>(21));
            arbol.agregarHijoDerecho(new ArbolBinario<int>(22));
            arbol.getHijoIzquierdo().agregarHijoIzquierdo(new ArbolBinario<int>(31));
            arbol.getHijoIzquierdo().agregarHijoDerecho(new ArbolBinario<int>(32));
            arbol.getHijoDerecho().agregarHijoIzquierdo(new ArbolBinario<int>(33));
            arbol.getHijoDerecho().agregarHijoDerecho(new ArbolBinario<int>(34));

            Console.WriteLine("incluye 3: ");
            Console.WriteLine(arbol.incluye(3));
            Console.WriteLine("incluye 21: ");
            Console.WriteLine(arbol.incluye(21));
            Console.WriteLine("incluye 34: ");
            Console.WriteLine(arbol.incluye(34));

            Console.WriteLine("InOrden: ");
            arbol.inorden();

            Console.WriteLine();
            Console.WriteLine("preOrden: ");
            arbol.preorden();

            Console.WriteLine();
            Console.WriteLine("postOrden: ");
            arbol.postorden();

            Console.WriteLine();
            Console.WriteLine("ContarHojas: " + arbol.contarHojas());

            try {
                Console.WriteLine();
                Console.WriteLine("recorrido entre niveles n=2, m=4: ");
                arbol.recorridoEntreNiveles(2, 4);
            }

            catch
            {
                Console.WriteLine("Los valores de n y m no son válidos.");
            }


            try
            {
                Console.WriteLine();
                Console.WriteLine("recorrido entre niveles n=2, m=3: ");
                arbol.recorridoEntreNiveles(2, 3);
            }

            catch
            {
                Console.WriteLine("Los valores de n y m no son válidos.");
            }

            try
            {
                Console.WriteLine();
                Console.WriteLine("recorrido entre niveles n=1, m=3: ");
                arbol.recorridoEntreNiveles(1, 3);
            }

            catch
            {
                Console.WriteLine("Los valores de n y m no son válidos.");
            }
            try
            {
                Console.WriteLine();
                Console.WriteLine("recorrido entre niveles n=1, m=2: ");
                arbol.recorridoEntreNiveles(1, 2);
            }

            catch
            {
                Console.WriteLine("Los valores de n y m no son válidos.");
            }

            Tp1 tp1 = new Tp1();
            tp1.Iniciar();

            Console.ReadKey();
        }
    }
}
