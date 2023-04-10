using System;
using System.Collections.Generic;
using System.Text;

namespace CTEDyA_2023_COM5_Franco_Fernando
{
    public class Tp2
    {
        private List<ArbolGeneral<int>> arbolesEnteros = new List<ArbolGeneral<int>>();
        private List<ArbolGeneral<string>> arbolesStrings = new List<ArbolGeneral<string>>();
        private List<ArbolGeneral<object>> arbolesObjetos = new List<ArbolGeneral<object>>();
        private int opcion;
        public void Iniciar()
        {

            Console.Clear();
            Console.WriteLine("Menu ArbolesGenerales: \n \n1- crear un ArbolGeneral. \n2- recorridos de ArbolesGenerales. \n3- buscar elemento en un ArbolGeneral. \n4- eliminar ArbolGeneral. \n \n0- Salir.");
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
                    case 5:
                        eliminarArbol();
                        break;


                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
                Console.WriteLine("Menu ArbolesGenerales: \n \n1- crear un ArbolGeneral. \n2- recorridos de ArbolesGenerales. \n3- buscar elemento en un ArbolGeneral. \n4- eliminar ArbolGeneral. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = ingresarEntero();
            }

        }

        private void crearArbol()
        {
            Console.Clear();
            Console.WriteLine("Menu Crear ArbolGeneral: \n  \n1- crear un ArbolGeneral de enteros. \n2- crear un ArbolGeneral de strings. \n \n0- Salir.");
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
                Console.WriteLine("Menu Crear ArbolGeneral: \n \n1- crear un ArbolGeneral de enteros. \n2- crear un ArbolGeneral de strings. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = ingresarEntero();
            }
        }

        private ArbolGeneral<int> crearArbolEnteros()
        {

            Console.WriteLine("Ingrese dato (entero):");
            int dato = ingresarEntero();
            ArbolGeneral<int> arbolEnteros = new ArbolGeneral<int>(dato);
            Console.Clear();
            Console.WriteLine($"Desea agregarle un hijo al {arbolEnteros.getDatoRaiz()}? \n1- Si. \n2- No.");
            opcion = ingresarEntero();
            while(opcion != 2)
            {
                if(opcion == 1)
                {
                    arbolEnteros.agregarHijo(crearArbolEnteros());
                    Console.WriteLine($"Desea agregarle otro hijo al {arbolEnteros.getDatoRaiz()}? \n1- Si. \n2- No.");
                }
                else
                {
                    Console.WriteLine($"La opcion {opcion} no es valida por vavor intente de nuevo:");
                }
                opcion = ingresarEntero();
            }
            

            return arbolEnteros;
        }
        private ArbolGeneral<string> crearArbolStrings()
        {

            Console.WriteLine("Ingrese dato (string):");
            string dato = Console.ReadLine();
            ArbolGeneral<string> arbolStrings = new ArbolGeneral<string>(dato);
            Console.Clear();
            Console.WriteLine($"Desea agregarle un hijo al {arbolStrings.getDatoRaiz()}? \n1- Si. \n2- No.");
            opcion = ingresarEntero();
            while (opcion != 2)
            {
                if(opcion == 1)
                {
                    arbolStrings.agregarHijo(crearArbolStrings());
                    Console.WriteLine($"Desea agregarle otro hijo al {arbolStrings.getDatoRaiz()}? \n1- Si. \n2- No.");
                }
                else
                {
                    
                }
                opcion = ingresarEntero();
            }


            return arbolStrings;
        }


        // para cualquier objeto
        

        //******************//
        //*** recorridos ***//
        //******************//

        private void recorridos()
        {
            Console.Clear();
            Console.WriteLine("Menu Recorridos de ArbolGeneral: \n \n1- Recorridos de ArbolGeneral de enteros. \n2- Recorridos de ArbolGeneral de strings. \n \n0- Salir.");
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
                Console.WriteLine("Menu Recorridos de ArbolGeneral: \n \n1- Recorridos de ArbolGeneral de enteros. \n2- Recorridos de ArbolGeneral de strings. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = ingresarEntero();
            }
        }

        private void recorridoEnteros()
        {
            Console.Clear();
            Console.WriteLine("Menu Recorrido de ArbolGeneral de enteros:");
            for (int i = 0; i < arbolesEnteros.Count; i++)
            {
                Console.WriteLine($"{i+1}- ({arbolesEnteros[i].getDatoRaiz()})  -  Ancho: {arbolesEnteros[i].ancho()}  -  Alto: {arbolesEnteros[i].altura()}");
            }
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Elija un arbol:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                if (opcion - 1 < arbolesEnteros.Count)
                {
                    recorrerEntero(arbolesEnteros[opcion - 1]);
                }

                Console.Clear();
                Console.WriteLine("Menu Recorrido de ArbolGeneral de enteros:");
                for (int i = 0; i < arbolesEnteros.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- ({arbolesEnteros[i].getDatoRaiz()})  -  Ancho: {arbolesEnteros[i].ancho()}  -  Alto: {arbolesEnteros[i].altura()}");
                }
                Console.WriteLine("\n0 - Salir\n");
                Console.WriteLine("Elija un arbol:");
                opcion = ingresarEntero();
            }
        }
        private void recorridoStrings()
        {
            Console.Clear();
            Console.WriteLine("Menu Recorrido de arbol de strings:");
            for (int i = 0; i < arbolesStrings.Count; i++)
            {
                Console.WriteLine($"{i + 1}- ({arbolesStrings[i].getDatoRaiz()})  -  Ancho: {arbolesStrings[i].ancho()}  -  Alto: {arbolesStrings[i].altura()}");
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
                Console.WriteLine("Menu Recorrido de arbol de strings:");
                for (int i = 0; i < arbolesStrings.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- ({arbolesStrings[i].getDatoRaiz()})  -  Ancho: {arbolesStrings[i].ancho()}  -  Alto: {arbolesStrings[i].altura()}");
                }
                Console.WriteLine("0 - Salir");
                Console.WriteLine("Elija un arbol:");
                opcion = ingresarEntero();
            }
        }

        private void recorrerEntero(ArbolGeneral<int> arbol)
        {
            Console.Clear();
            Console.WriteLine("Menu Recorridos - ArbolGeneral de enteros: \n \n \n1- In orden. \n2- Pre orden. \n3- Post orden \n4- Por niveles. \n5- Por niveles con separacion. \n \n0- Salir.");
            Console.Write("\n Ingrese una opcion:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Recorrido InOrden del ArbolGeneral ({arbol.getDatoRaiz()}):");
                        arbol.inorden();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PreOrden del ArbolGeneral ({arbol.getDatoRaiz()}):");
                        arbol.preorden();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PostOrden del ArbolGeneral ({arbol.getDatoRaiz()}):");
                        arbol.postorden();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PorNiveles del ArbolGeneral ({arbol.getDatoRaiz()}):");
                        arbol.porNiveles();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine($"Recorrido por niveles con separacion del ArbolGeneral ({arbol.getDatoRaiz()}):");
                        arbol.porNivelesConSeparacion();
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Menu Recorridos - ArbolGeneral de enteros: \n \n \n1- In orden. \n2- Pre orden. \n3- Post orden \n4- Por niveles. \n5- Por niveles con separacion. \n \n0- Salir.");
                Console.Write("\n Ingrese una opcion:");
                opcion = ingresarEntero();
            }
        }

        private void recorrerString(ArbolGeneral<string> arbol)
        {
            Console.Clear();
            Console.WriteLine("Menu Recorridos - ArbolGeneral de strings: \n \n \n1- In orden. \n2- Pre orden. \n3- Post orden \n4- Por niveles. \n5- Por niveles con separacion. \n \n0- Salir.");
            Console.Write("\n Ingrese una opcion:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Recorrido InOrden del ArbolGeneral ({arbol.getDatoRaiz()}):");
                        arbol.inorden();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PreOrden del ArbolGeneral ({arbol.getDatoRaiz()}):");
                        arbol.preorden();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PostOrden del ArbolGeneral ({arbol.getDatoRaiz()}):");
                        arbol.postorden();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Recorrido PorNiveles del ArbolGeneral ({arbol.getDatoRaiz()}):");
                        arbol.porNiveles();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine($"Recorrido por niveles con separacion del ArbolGeneral ({arbol.getDatoRaiz()}):");
                        arbol.porNivelesConSeparacion();
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Menu Recorridos - ArbolGeneral de strings: \n \n \n1- In orden. \n2- Pre orden. \n3- Post orden \n4- Por niveles. \n5- Por niveles con separacion. \n \n0- Salir.");
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
            Console.WriteLine("Menu Recorridos de ArbolGeneral: \n \n1- Buscar Elementos en un ArbolGeneral de enteros. \n2- Buscar Elementos en un ArbolGeneral de strings. \n \n0- Salir.");
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
                Console.WriteLine("Menu Recorridos de ArbolGeneral: \n \n1- Buscar Elementos en un ArbolGeneral de enteros. \n2- Buscar Elementos en un ArbolGeneral de strings. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = ingresarEntero();
            }
        }
        private void buscarElementoEntero()
        {
            Console.Clear();
            Console.WriteLine("Menu Buscar un elemento en un ArbolGeneral de enteros:");
            for (int i = 0; i < arbolesEnteros.Count; i++)
            {
                Console.WriteLine(i + 1 + " - " + arbolesEnteros[i].getDatoRaiz());
            }
            Console.WriteLine("\n0 - Salir\n");
            Console.WriteLine("Elija un arbol:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                if (opcion - 1 < arbolesEnteros.Count)
                {
                    buscarEntero(arbolesEnteros[opcion - 1]);
                }

                Console.Clear();
                Console.WriteLine("Menu Recorrido de ArbolGeneral de enteros:");
                for (int i = 0; i < arbolesEnteros.Count; i++)
                {
                    Console.WriteLine(i + 1 + " - " + arbolesEnteros[i].getDatoRaiz());
                }
                Console.WriteLine("\n0 - Salir\n");
                Console.WriteLine("Elija un arbol:");
                opcion = ingresarEntero();
            }
        }

        private void buscarEntero(ArbolGeneral<int> arbol)
        {
            Console.Clear();
            Console.WriteLine($"Inserte el elemento que desea buscar en el arbol {arbol.getDatoRaiz()}");
            int elemento = ingresarEntero();
            if (arbol.nivel(elemento) != -1)
            {
                Console.WriteLine($"El elemento {elemento} se ecuentra en el nivel {arbol.nivel(elemento)} del ArbolGeneral ({arbol.getDatoRaiz()})");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"El elemento {elemento} NO existe en el ArbolGeneral ({arbol.getDatoRaiz()})");
                Console.ReadKey();
            }
        }

        private void buscarElementoString()
        {
            Console.Clear();
            Console.WriteLine("Menu Buscar un elemento en un ArbolGeneral de strings:");
            for (int i = 0; i < arbolesStrings.Count; i++)
            {
                Console.WriteLine(i + 1 + " - " + arbolesStrings[i].getDatoRaiz());
            }
            Console.WriteLine("\n0 - Salir\n");
            Console.WriteLine("Elija un arbol:");
            opcion = ingresarEntero();
            while (opcion != 0)
            {
                if (opcion - 1 < arbolesStrings.Count)
                {
                    buscarString(arbolesStrings[opcion - 1]);
                }

                Console.Clear();
                Console.WriteLine("Menu Recorrido de ArbolGeneral de enteros:");
                for (int i = 0; i < arbolesStrings.Count; i++)
                {
                    Console.WriteLine(i + 1 + " - " + arbolesStrings[i].getDatoRaiz());
                }
                Console.WriteLine("\n0 - Salir\n");
                Console.WriteLine("Elija un arbol:");
                opcion = ingresarEntero();
            }
        }
        private void buscarString(ArbolGeneral<string> arbol)
        {
            Console.Clear();
            Console.WriteLine($"Inserte el elemento que desea buscar en el ArbolGeneral {arbol}");
            string elemento = Console.ReadLine();
            if (arbol.nivel(elemento) != -1)
            {
                Console.WriteLine($"El elemento {elemento} se ecuentra en el nivel {arbol.nivel(elemento)} del ArbolGeneral ({arbol.getDatoRaiz()})");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"El elemento {elemento} NO existe en el ArbolGeneral ({arbol.getDatoRaiz()})");
                Console.ReadKey();
            }
        }

        //**************************//
        //*** eliminar Elementos ***//
        //**************************//
        private void eliminarArbol()
        {

        }

        //********************//
        //**   Auxiliares   **//
        //********************//

        

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
