using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CTEDyA_2023_COM5_Franco_Fernando
{
    public class Tp1
    {
        private List<ArbolBinario<int>> arbolesEnteros = new List<ArbolBinario<int>>();
        private List<ArbolBinario<string>> arbolesStrings = new List<ArbolBinario<string>>();
        private List<ArbolBinario<object>> arbolesObjetos = new List<ArbolBinario<object>>();

        public void Iniciar()
        {
            
            Console.Clear();
            Console.WriteLine("Menu ArbolesBinarios: \n \n1- crear un arbol. \n2- recorridos. \n3- buscar elemento en un arbol. \n4- eliminar arbol. \n \n0- Salir.");
            Console.WriteLine("Ingrese una opcion:");
            int opcion = int.Parse(Console.ReadLine());
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
                        buscarElementoEntero();
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
                Console.WriteLine("Menu ArbolesBinarios: \n \n1- crear un arbol. \n2- recorridos. \n3- buscar elemento en un arbol. \n4- eliminar arbol. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = int.Parse(Console.ReadLine());
            }

        }

        private void crearArbol()
        {
            Console.Clear();
            Console.WriteLine("Menu Crear Arbol: \n  \n1- crear un arbol de enteros. \n2- crear un arbol de strings. \n \n0- Salir.");
            Console.WriteLine("Ingrese una opcion:");
            int opcion = int.Parse(Console.ReadLine());
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
                Console.WriteLine("Menu Crear Arbol: \n \n1- crear un arbol de enteros. \n2- crear un arbol de strings. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = int.Parse(Console.ReadLine());
            }
        }

        private ArbolBinario<int> crearArbolEnteros()
        {
            
            Console.WriteLine("Ingrese dato (entero):");
            int dato = int.Parse(Console.ReadLine());
            ArbolBinario<int> arbolEnteros = new ArbolBinario<int>(dato);
            Console.Clear();
            Console.WriteLine($"Desea agregarle un hijo izquierdo al {dato}? \n1- Si. \n2- No.");
            int Opc = int.Parse(Console.ReadLine());
            if (Opc == 1)
            {
                Console.Clear();
                Console.WriteLine($"Hijo izquierdo de: {dato}");
                arbolEnteros.agregarHijoIzquierdo(crearArbolEnteros());
            }
            Console.Clear();
            Console.WriteLine($"Desea agregarle un hijo derecho al {dato}? \n1- Si. \n2- No.");
            int Opc2 = int.Parse(Console.ReadLine());
            if (Opc2 == 1)
            {
                Console.Clear();
                Console.WriteLine($"Hijo derecho de: {dato}");
                arbolEnteros.agregarHijoDerecho(crearArbolEnteros());
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
            int Opc = int.Parse(Console.ReadLine());
            if (Opc == 1)
            {
                Console.Clear();
                Console.WriteLine($"Hijo izquierdo de: {dato}");
                arbolStrings.agregarHijoIzquierdo(crearArbolStrings());
            }
            Console.Clear();
            Console.WriteLine($"Desea agregarle un hijo derecho a {dato}? \n1- Si. \n2- No.");
            int Opc2 = int.Parse(Console.ReadLine());
            if (Opc2 == 1)
            {
                Console.Clear();
                Console.WriteLine($"Hijo derecho de: {dato}");
                arbolStrings.agregarHijoDerecho(crearArbolStrings());
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
            Console.WriteLine("Menu Recorridos: \n \n1- Recorridos de arbol de enteros. \n2- Recorridos de arbol de strings. \n \n0- Salir.");
            Console.WriteLine("Ingrese una opcion:");
            int opcion = int.Parse(Console.ReadLine());
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
                Console.WriteLine("Menu Recorridos: \n \n1- Recorridos de arbol de enteros. \n2- Recorridos de arbol de strings. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = int.Parse(Console.ReadLine());
            }
        }

        private void recorridoEnteros()
        {
            Console.Clear();
            Console.WriteLine("Menu Recorrido de arbol de enteros:");
            for (int i = 0; i < arbolesEnteros.Count; i++)
            {
                Console.WriteLine(i+1 +" - " + arbolesEnteros[i].getDatoRaiz());
            }
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Elija un arbol:");
            int opcion = int.Parse(Console.ReadLine());
            while (opcion != 0)
            {
                if(opcion-1 < arbolesEnteros.Count)
                {
                    recorrerEntero(arbolesEnteros[opcion - 1]);
                }
                
                Console.Clear();
                Console.WriteLine("Menu Recorrido de arbol de enteros:");
                for (int i = 0; i < arbolesEnteros.Count; i++)
                {
                    Console.WriteLine(i + 1 + " - " + arbolesEnteros[i].getDatoRaiz());
                }
                Console.WriteLine("0 - Salir");
                Console.WriteLine("Elija un arbol:");
                opcion = int.Parse(Console.ReadLine());
            }
        }
        private void recorridoStrings()
        {
            Console.Clear();
            Console.WriteLine("Menu Recorrido de arbol de strings:");
            for (int i = 0; i < arbolesStrings.Count; i++)
            {
                Console.WriteLine(i + 1 + " - " + arbolesStrings[i].getDatoRaiz());
            }
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Elija un arbol:");
            int opcion = int.Parse(Console.ReadLine());
            while (opcion != 0)
            {
                if (opcion - 1 < arbolesStrings.Count)
                {
                    recorrerString(arbolesStrings[opcion - 1]);
                }

                Console.Clear();
                Console.WriteLine("Menu Recorrido de arbol de enteros:");
                for (int i = 0; i < arbolesStrings.Count; i++)
                {
                    Console.WriteLine(i + 1 + " - " + arbolesStrings[i].getDatoRaiz());
                }
                Console.WriteLine("0 - Salir");
                Console.WriteLine("Elija un arbol:");
                opcion = int.Parse(Console.ReadLine());
            }
        }

        private void recorrerEntero(ArbolBinario<int> arbol)
        {
            Console.Clear();
            Console.WriteLine("Menu Recorridos: \n \n \n1- InOrden. \n2- PreOrden. \n3- PostOrden \n4- PorNiveles. \n5- EntreNiveles. \n \n0- Salir.");
            Console.Write("\n Ingrese una opcion:");
            int opcion = int.Parse(Console.ReadLine());
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Recorrido InOrden:");
                        arbol.inorden();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Recorrido PreOrden:");
                        arbol.preorden();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Recorrido PostOrden:");
                        arbol.postorden();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Recorrido PorNiveles:");
                        arbol.recorridoPorNiveles();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Recorrido entre nivel (ingrese nivel):");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine("y el nivel (ingrese segundo nivel):");
                        int m = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine($"Recorrido entre niveles {n} y {m}:");
                        arbol.recorridoEntreNiveles(n, m);
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Menu Recorridos: \n \n1- InOrden. \n2- PreOrden. \n3- PostOrden \n4- PorNiveles. \n5- EntreNiveles. \n \n0- Salir.");
                Console.Write("\n Ingrese una opcion:");
                opcion = int.Parse(Console.ReadLine());
            }
        }

        private void recorrerString(ArbolBinario<string> arbol)
        {
            Console.Clear();
            Console.WriteLine("Menu Recorridos: \n \n \n1- InOrden. \n2- PreOrden. \n3- PostOrden \n4- PorNiveles. \n5- EntreNiveles. \n \n0- Salir.");
            Console.Write("\n Ingrese una opcion:");
            int opcion = int.Parse(Console.ReadLine());
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Recorrido InOrden:");
                        arbol.inorden();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Recorrido PreOrden:");
                        arbol.preorden();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Recorrido PostOrden:");
                        arbol.postorden();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Recorrido PorNiveles:");
                        arbol.recorridoPorNiveles();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Recorrido entre nivel (ingrese nivel):");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine("y el nivel (ingrese segundo nivel):");
                        int m = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine($"Recorrido entre niveles {n} y {m}:");
                        arbol.recorridoEntreNiveles(n, m);
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Menu Recorridos: \n \n1- InOrden. \n2- PreOrden. \n3- PostOrden \n4- PorNiveles. \n5- EntreNiveles. \n \n0- Salir.");
                Console.Write("\n Ingrese una opcion:");
                opcion = int.Parse(Console.ReadLine());
            }
        }


        //************************//
        //*** buscar Elementos ***//
        //************************//
        private void buscarElementoEntero()
        {
            Console.Clear();
            Console.WriteLine("Menu Buscar un elemento en un arbol de enteros:");
            for (int i = 0; i < arbolesEnteros.Count; i++)
            {
                Console.WriteLine(i + 1 + " - " + arbolesEnteros[i].getDatoRaiz());
            }
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Elija un arbol:");
            int opcion = int.Parse(Console.ReadLine());
            while (opcion != 0)
            {
                if (opcion - 1 < arbolesEnteros.Count)
                {
                    buscarEntero(arbolesEnteros[opcion - 1]);
                }

                Console.Clear();
                Console.WriteLine("Menu Recorrido de arbol de enteros:");
                for (int i = 0; i < arbolesEnteros.Count; i++)
                {
                    Console.WriteLine(i + 1 + " - " + arbolesEnteros[i].getDatoRaiz());
                }
                Console.WriteLine("0 - Salir");
                Console.WriteLine("Elija un arbol:");
                opcion = int.Parse(Console.ReadLine());
            }
        }

        private void buscarEntero(ArbolBinario<int> arbol)
        {
            Console.Clear();
            Console.WriteLine($"Inserte el elemento que desea buscar en el arbol {arbol}");
            int elemento = int.Parse(Console.ReadLine());
            if (arbol.incluye(elemento))
            {
                Console.WriteLine($"El elemento {elemento} SI existe en el arbol {arbol}");
            }
            else
            {
                Console.WriteLine($"El elemento {elemento} NO existe en el arbol {arbol}");
            }
        }
        private void buscarString(ArbolBinario<string> arbol)
        {
            Console.Clear();
            Console.WriteLine($"Inserte el elemento que desea buscar en el arbol {arbol}");
            string elemento = Console.ReadLine();
            if (arbol.incluye(elemento))
            {
                Console.WriteLine($"El elemento {elemento} SI existe en el arbol {arbol}");
            }
            else
            {
                Console.WriteLine($"El elemento {elemento} NO existe en el arbol {arbol}");
            }
        }

        //**************************//
        //*** eliminar Elementos ***//
        //**************************//
        private void eliminarArbol()
        {

        }
    }
}
