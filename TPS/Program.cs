using System;


namespace CTEDyA_2023_COM5_Franco_Fernando
{
    class Program
    {
        static void Main(string[] args)
        {
            Tp1 tp1 = new Tp1();
            Tp2 tp2 = new Tp2();
            Tp3 tp3 = new Tp3();
            Console.Clear();
            Console.WriteLine("Trabajos practicos Complejidad Temporal Estructuras de Datos y Algoritmos: \n \n1- Tema 1 (ArbolBinario). \n2- Tema 2 (ArbolesGeneral y Heap). \n3- Tema 3 (Hash). \n4- Tema 4. \n \n0- Salir.");
            Console.WriteLine("Ingrese una opcion:");
            int opcion = ingresarEntero();
            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        tp1.Iniciar();
                        break;
                    case 2:
                        tp2.Iniciar();
                        break;
                    case 3:
                        tp3.Iniciar();
                        break;
                    case 4:
                        Console.WriteLine("Aun sin implementar");
                        break;


                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
                Console.WriteLine("Trabajos practicos Complejidad Temporal Estructuras de Datos y Algoritmos: \n \n1- Tema 1 (ArbolBinario). \n2- Tema 2 (ArbolesGeneral y Heap). \n3- Tema 3 (Hash). \n4- Tema 4. \n \n0- Salir.");
                Console.WriteLine("Ingrese una opcion:");
                opcion = ingresarEntero();
            }

            int ingresarEntero()
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
            Console.ReadKey();
        }
        
    }
}
