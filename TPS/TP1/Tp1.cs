using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace CTEDyA_2023_COM5_Franco_Fernando
{
    public class Tp1
    {
        private int opcion;
        private int n, m;
        private List<ArbolBinario<int>> arbolesEnteros = new List<ArbolBinario<int>>();
        private List<ArbolBinario<string>> arbolesStrings = new List<ArbolBinario<string>>();
        private List<ArbolBinario<object>> arbolesObjetos = new List<ArbolBinario<object>>();

        private ArbolBinario<int> testInt = new ArbolBinario<int>(1);
        private ArbolBinario<string> teststring = new ArbolBinario<string>("pablo");
        public Tp1()
        {
            testInt.agregarHijoIzquierdo(new ArbolBinario<int>(2));
            testInt.agregarHijoDerecho(new ArbolBinario<int>(3));
            testInt.getHijoIzquierdo().agregarHijoIzquierdo(new ArbolBinario<int>(4));
            testInt.getHijoDerecho().agregarHijoIzquierdo(new ArbolBinario<int>(5));
            arbolesEnteros.Add(testInt);
            teststring.agregarHijoIzquierdo(new ArbolBinario<string>("jose"));
            teststring.agregarHijoDerecho(new ArbolBinario<string>("marta"));
            teststring.getHijoIzquierdo().agregarHijoIzquierdo(new ArbolBinario<string>("Alf"));
            teststring.getHijoDerecho().agregarHijoIzquierdo(new ArbolBinario<string>("Hamburguesa"));
            arbolesStrings.Add(teststring);
        }
        public void Iniciar()
        {
            Console.Clear();
            Console.WriteLine("Menu ArbolesBinarios: \n \n1- crear un ArbolBinario. \n2- recorridos de un ArbolBinario. \n3- buscar elemento en un ArbolBinario. \n4- eliminar ArbolBinario. \n \n0- Salir.");
            Console.WriteLine("Ingrese una opcion:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        crearArbol();
                        break;
                    case 2:
                        recorridos();
                        break;
                    case 3:
                        buscarElementos();
                        break;
                    case 4:
                        eliminarArbol();
                        break;


                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
                Console.WriteLine("Menu ArbolesBinarios: \n \n1- crear un ArbolBinario. \n2- recorridos de un ArbolBinario. \n3- buscar elemento en un ArbolBinario.  \n4- eliminar ArbolBinario. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = ingresarEntero();
            }

        }

        private void crearArbol()
        {
            Console.Clear();
            Console.WriteLine("Menu Crear ArbolBinario: \n  \n1- crear un ArbolBinario de enteros. \n2- crear un ArbolBinario de strings. \n \n0- Salir.");
            Console.WriteLine("Ingrese una opcion:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        arbolesEnteros.Add(crearArbolEnteros());
                        break;
                    case 2:
                        Console.Clear();
                        arbolesStrings.Add(crearArbolStrings());
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Menu Crear ArbolBinario: \n \n1- crear un ArbolBinario de enteros. \n2- crear un ArbolBinario de strings. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = ingresarEntero();
            }
        }

        private ArbolBinario<int> crearArbolEnteros()
        {
            Console.WriteLine("Creando un ArbolBinario de enteros");
            Console.WriteLine("Ingrese dato (entero):");
            int dato = ingresarEntero();
            ArbolBinario<int> arbolEnteros = new ArbolBinario<int>(dato);
            Console.Clear();
            Console.WriteLine($"Desea agregarle un hijo izquierdo al ({dato})? \n1- Si. \n2- No.");
            opcion = ingresarEntero();
            while(opcion != 2)
            {
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Hijo izquierdo de ({dato}):");
                    arbolEnteros.agregarHijoIzquierdo(crearArbolEnteros());
                }
                else
                {
                    Console.WriteLine($"La opcion {opcion} no es valida. Por favor intente de nuevo:");
                    opcion = ingresarEntero();
                }
            }
            
            Console.Clear();
            Console.WriteLine($"Desea agregarle un hijo derecho al ({dato})? \n1- Si. \n2- No.");
            opcion = ingresarEntero();
            while(opcion != 2)
            {
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Hijo derecho de ({dato}):");
                    arbolEnteros.agregarHijoDerecho(crearArbolEnteros());
                }
                else
                {
                    Console.WriteLine($"La opcion {opcion} no es valida. Por favor intente de nuevo:");
                    opcion = ingresarEntero();
                }
            }
            


            return arbolEnteros;
        }
        private ArbolBinario<string> crearArbolStrings()
        {
            
            Console.WriteLine("Ingrese dato (string):");
            string dato = Console.ReadLine();
            ArbolBinario<string> arbolStrings = new ArbolBinario<string>(dato);
            Console.Clear();
            Console.WriteLine($"Desea agregarle un hijo izquierdo a {dato}? \n1- Si. \n2- No.");
            opcion = ingresarEntero();
            while (opcion != 2)
            {
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Hijo izquierdo de: {dato}");
                    arbolStrings.agregarHijoIzquierdo(crearArbolStrings());
                }
                else
                {
                    Console.WriteLine($"La opcion {opcion} no es valida. Por favor intente de nuevo:");
                    opcion = ingresarEntero();
                }
            }
            
            Console.Clear();
            Console.WriteLine($"Desea agregarle un hijo derecho a {dato}? \n1- Si. \n2- No.");
            opcion = ingresarEntero();
            while(opcion != 2)
            {
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Hijo derecho de: {dato}");
                    arbolStrings.agregarHijoDerecho(crearArbolStrings());
                }
                else
                {
                    Console.WriteLine($"La opcion {opcion} no es valida. Por favor intente de nuevo:");
                    opcion = ingresarEntero();
                }
                
            }
            

            return arbolStrings;

        }


        // para cualquier objeto
        private ArbolBinario<Object> crearArbolObjetos(Object objeto)
        {
            Object dato = objeto;
            ArbolBinario<Object> arbolObjetos = new ArbolBinario<Object>(dato);
            return arbolObjetos;
        }
        private void agregarHijoIzquierdo(ArbolBinario<Object> arbolObjetos, Object dato)
        {
            arbolObjetos.agregarHijoIzquierdo(crearArbolObjetos(dato));
        }
        private void agregarHijoDerecho(ArbolBinario<Object> arbolObjetos, Object dato)
        {
            arbolObjetos.agregarHijoDerecho(crearArbolObjetos(dato));
        }

        //******************//
        //*** recorridos ***//
        //******************//

        private void recorridos()
        {
            Console.Clear();
            Console.WriteLine("Menu Recorridos - ArbolBinario: \n \n1- Recorridos de arbol de enteros. \n2- Recorridos de arbol de strings. \n \n0- Salir.");
            Console.WriteLine("Ingrese una opcion:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        recorridoEnteros();
                        break;
                    case 2:
                        Console.Clear();
                        recorridoStrings();
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Menu Recorridos - Arbol Binario: \n \n1- Recorridos de arbol de enteros. \n2- Recorridos de arbol de strings. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = ingresarEntero();
            }
        }

        private void recorridoEnteros()
        {
            Console.Clear();
            Console.WriteLine("Menu Recorrido de ArbolBinario de enteros:");
            for (int i = 0; i < arbolesEnteros.Count; i++)
            {
                Console.WriteLine($"{i+1}- ({arbolesEnteros[i].getDatoRaiz()})  -  Altura: {arbolesEnteros[i].Altura()}");
            }
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Elija un arbol:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                if(opcion-1 < arbolesEnteros.Count)
                {
                    recorrerEntero(arbolesEnteros[opcion - 1]);
                }
                
                Console.Clear();
                Console.WriteLine("Menu Recorrido de ArbolBinario de enteros:");
                for (int i = 0; i < arbolesEnteros.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- ({arbolesEnteros[i].getDatoRaiz()})  -  Altura: {arbolesEnteros[i].Altura()}");
                }
                Console.WriteLine("0 - Salir");
                Console.WriteLine("Elija un arbol:");
                opcion = ingresarEntero();
            }
        }
        private void recorridoStrings()
        {
            Console.Clear();
            Console.WriteLine("Menu Recorrido de ArbolBinario de strings:");
            for (int i = 0; i < arbolesStrings.Count; i++)
            {
                Console.WriteLine($"{i + 1}- ({arbolesStrings[i].getDatoRaiz()})  -  Altura: {arbolesStrings[i].Altura()}");
            }
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Elija un arbol:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                if (opcion - 1 < arbolesStrings.Count)
                {
                    recorrerString(arbolesStrings[opcion - 1]);
                }

                Console.Clear();
                Console.WriteLine("Menu Recorrido de ArbolBinario de strings:");
                for (int i = 0; i < arbolesStrings.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- ({arbolesStrings[i].getDatoRaiz()})  -  Altura: {arbolesStrings[i].Altura()}");
                }
                Console.WriteLine("0 - Salir");
                Console.WriteLine("Elija un arbol:");
                opcion = ingresarEntero();
            }
        }

        private void recorrerEntero(ArbolBinario<int> arbol)
        {
            Console.Clear();
            Console.WriteLine("Menu Recorridos - ArbolBinario de enteros: \n \n \n1- InOrden. \n2- PreOrden. \n3- PostOrden \n4- PorNiveles. \n5- EntreNiveles. \n \n0- Salir.");
            Console.Write("\n Ingrese una opcion:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Recorrido InOrden del ArbolBinario de enteros ({arbol.getDatoRaiz()}):");
                        arbol.inorden();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PreOrden del ArbolBinario de enteros ({arbol.getDatoRaiz()}):");
                        arbol.preorden();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PostOrden del ArbolBinario de enteros ({arbol.getDatoRaiz()}):");
                        arbol.postorden();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PorNiveles del ArbolBinario de enteros ({arbol.getDatoRaiz()}):");
                        arbol.recorridoPorNiveles();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Recorrido entre nivel (ingrese nivel):");
                        int n = ingresarEntero();
                        Console.WriteLine("y el nivel (ingrese segundo nivel):");
                        int m = ingresarEntero();
                        Console.Clear();
                        Console.WriteLine($"Recorrido entre niveles {n} y {m} del ArbolBinario de enteros ({arbol.getDatoRaiz()}):");
                        try
                        {
                            arbol.recorridoEntreNiveles(n, m);
                        }
                        catch
                        {
                            Console.WriteLine($"Los niveles {n} y {m} no son validos.");
                        }
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Menu Recorridos - ArbolBinario de enteros: \n \n1- InOrden. \n2- PreOrden. \n3- PostOrden \n4- PorNiveles. \n5- EntreNiveles. \n \n0- Salir.");
                Console.Write("\n Ingrese una opcion:");
                opcion = ingresarEntero();
            }
        }

        private void recorrerString(ArbolBinario<string> arbol)
        {
            Console.Clear();
            Console.WriteLine("Menu Recorridos - ArbolBinario de strings: \n \n \n1- InOrden. \n2- PreOrden. \n3- PostOrden \n4- PorNiveles. \n5- EntreNiveles. \n \n0- Salir.");
            Console.Write("\n Ingrese una opcion:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Recorrido InOrden del ArbolBinario de strings ({arbol.getDatoRaiz()}):");
                        arbol.inorden();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PreOrden del ArbolBinario de strings ({arbol.getDatoRaiz()}):");
                        arbol.preorden();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PostOrden del ArbolBinario de strings ({arbol.getDatoRaiz()}):");
                        arbol.postorden();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PorNiveles del ArbolBinario de strings ({arbol.getDatoRaiz()}):");
                        arbol.recorridoPorNiveles();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Recorrido entre nivel (ingrese nivel):");
                        n = ingresarEntero();
                        Console.WriteLine("y el nivel (ingrese segundo nivel):");
                        m = ingresarEntero();
                        Console.Clear();
                        Console.WriteLine($"Recorrido entre niveles {n} y {m} del ArbolBinario de strings ({arbol.getDatoRaiz()}):");
                        try
                        {
                            arbol.recorridoEntreNiveles(n, m);
                        }
                        catch
                        {
                            Console.WriteLine($"Los niveles {n} y {m} no son validos.");
                        }
                        
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Menu Recorridos - ArbolBinario de strings: \n \n1- InOrden. \n2- PreOrden. \n3- PostOrden \n4- PorNiveles. \n5- EntreNiveles. \n \n0- Salir.");
                Console.Write("\n Ingrese una opcion:");
                opcion = ingresarEntero();
            }
        }


        //************************//
        //*** buscar Elementos ***//
        //************************//
        private void buscarElementos()
        {
            Console.Clear();
            Console.WriteLine("Menu buscar elementos en un ArbolBinario: \n \n1- Buscar Elementos en un ArbolBinario de enteros. \n2- Buscar Elementos en un ArbolBinario de strings. \n \n0- Salir.");
            Console.WriteLine("Ingrese una opcion:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        buscarElementoEntero();
                        break;
                    case 2:
                        Console.Clear();
                        buscarElementoString();
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Menu buscar elementos en un ArbolBinario: \n \n1- Buscar Elementos en un ArbolBinario de enteros. \n2- Buscar Elementos en un ArbolBinario de strings. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = ingresarEntero();
            }
        }
        private void buscarElementoEntero()
        {
            Console.Clear();
            Console.WriteLine("Menu Buscar un elemento en un ArbolBinario de enteros:");
            for (int i = 0; i < arbolesEnteros.Count; i++)
            {
                Console.WriteLine($"{i + 1}- ({arbolesEnteros[i].getDatoRaiz()})  -  Altura: {arbolesEnteros[i].Altura()}");
            }
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Elija un arbol:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                if (opcion - 1 < arbolesEnteros.Count)
                {
                    buscarEntero(arbolesEnteros[opcion - 1]);
                }

                Console.Clear();
                Console.WriteLine("Menu Buscar un elemento en un ArbolBinario de enteros:");
                for (int i = 0; i < arbolesEnteros.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- ({arbolesEnteros[i].getDatoRaiz()})  -  Altura: {arbolesEnteros[i].Altura()}");
                }
                Console.WriteLine("0 - Salir");
                Console.WriteLine("Elija un arbol:");
                opcion = ingresarEntero();
            }
        }

        private void buscarEntero(ArbolBinario<int> arbol)
        {
            Console.Clear();
            Console.WriteLine($"Inserte el elemento que desea buscar en el ArbolBinario ({arbol.getDatoRaiz()})");
            int elemento = ingresarEntero();
            if (arbol.incluye(elemento))
            {
                Console.WriteLine($"El elemento {elemento} SI existe en el ArbolBinario ({arbol.getDatoRaiz()})");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"El elemento {elemento} NO existe en el ArbolBinario ({arbol.getDatoRaiz()})");
                Console.ReadKey();
            }
        }


        private void buscarElementoString()
        {
            Console.Clear();
            Console.WriteLine("Menu Buscar un elemento en un ArbolBinario de strings:");
            for (int i = 0; i < arbolesStrings.Count; i++)
            {
                Console.WriteLine($"{i + 1}- ({arbolesStrings[i].getDatoRaiz()})  -  Altura: {arbolesStrings[i].Altura()}");
            }
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Elija un arbol:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                if (opcion - 1 < arbolesStrings.Count)
                {
                    buscarString(arbolesStrings[opcion - 1]);
                }

                Console.Clear();
                Console.WriteLine("Menu Buscar un elemento en un ArbolBinario de strings:");
                for (int i = 0; i < arbolesStrings.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- ({arbolesStrings[i].getDatoRaiz()})  -  Altura: {arbolesStrings[i].Altura()}");
                }
                Console.WriteLine("0 - Salir");
                Console.WriteLine("Elija un arbol:");
                opcion = ingresarEntero();
            }
        }
        private void buscarString(ArbolBinario<string> arbol)
        {
            Console.Clear();
            Console.WriteLine($"Inserte el elemento que desea buscar en el ArbolBinario ({arbol.getDatoRaiz()})");
            string elemento = Console.ReadLine();
            if (arbol.incluye(elemento))
            {
                Console.WriteLine($"El elemento {elemento} SI existe en el ArbolBinario ({arbol.getDatoRaiz()})");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"El elemento {elemento} NO existe en el ArbolBinario ({arbol.getDatoRaiz()})");
                Console.ReadKey();
            }
        }

        //**************************//
        //***  eliminar Arboles  ***//
        //**************************//
        private void eliminarArbol()
        {
            Console.Clear();
            Console.WriteLine("Menu Eliminar un ArbolBinario: \n \n1- Eliminar un ArbolBinario de enteros. \n2- Eliminar un ArbolBinario de strings. \n \n0- Salir.");
            Console.WriteLine("Ingrese una opcion:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        eliminarArbolEntero();
                        break;
                    case 2:
                        Console.Clear();
                        eliminarArbolString();
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Menu Eliminar un ArbolBinario: \n \n1- Eliminar un ArbolBinario de enteros. \n2- Eliminar un ArbolBinario de strings. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = ingresarEntero();
            }
        }

        public void eliminarArbolEntero()
        {
            Console.Clear();
            Console.WriteLine("Menu eliminar un ArbolBinario de enteros:");
            for (int i = 0; i < arbolesEnteros.Count; i++)
            {
                Console.WriteLine($"{i + 1}- ({arbolesEnteros[i].getDatoRaiz()})  -  Alto: {arbolesEnteros[i].Altura()}");
            }
            Console.WriteLine("\n0 - Salir\n");
            Console.WriteLine("Elija un arbol:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                if (opcion - 1 < arbolesEnteros.Count)
                {
                    arbolesEnteros.RemoveAt(opcion - 1);
                }

                Console.Clear();
                Console.WriteLine("Menu eliminar un ArbolBinario de strings:");
                for (int i = 0; i < arbolesEnteros.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- ({arbolesEnteros[i].getDatoRaiz()})  -  Alto: {arbolesEnteros[i].Altura()}");
                }
                Console.WriteLine("\n0 - Salir\n");
                Console.WriteLine("Elija un arbol:");
                opcion = ingresarEntero();
            }
        }
        public void eliminarArbolString()
        {
            Console.Clear();
            Console.WriteLine("Menu eliminar un ArbolBinario de strings:");
            for (int i = 0; i < arbolesStrings.Count; i++)
            {
                Console.WriteLine($"{i + 1}- ({arbolesStrings[i].getDatoRaiz()})  -  Alto: {arbolesStrings[i].Altura()}");
            }
            Console.WriteLine("\n0 - Salir\n");
            Console.WriteLine("Elija un arbol:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                if (opcion - 1 < arbolesStrings.Count)
                {
                    arbolesStrings.RemoveAt(opcion - 1);
                }

                Console.Clear();
                Console.WriteLine("Menu eliminar elemento en un ArbolBinario de strings:");
                for (int i = 0; i < arbolesStrings.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- ({arbolesStrings[i].getDatoRaiz()})  -  Alto: {arbolesStrings[i].Altura()}");
                }
                Console.WriteLine("\n0 - Salir\n");
                Console.WriteLine("Elija un arbol:");
                opcion = ingresarEntero();
            }
        }


        //********************//
        //**   Auxiliares   **//
        //********************//

        private int[] ingresarNiveles()
        {
            int[] niveles = new int[2];
            Console.WriteLine("Recorrido entre nivel (ingrese nivel):");
            int n = ingresarEntero();
            Console.WriteLine("y el nivel (ingrese segundo nivel):");
            int m = ingresarEntero();
            niveles[0] = n;
            niveles[1] = m;
            
            return niveles;
        }

        private int ingresarEntero()
        {
            int num;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("El valor ingresado es incorrecto. \nPor favor intente de nuevo:");
                num = ingresarEntero();
            }
            

            return num;
        }

    }
}
