﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CTEDyA_2023_COM5_Franco_Fernando
{
    class Tp4
    {
        //Los empleados de una cierta compañía se representan
        //en la base de datos de la compañía
        //por su nombre,número de empleado y DNI.
        //Implemente todos los objentos necesarios
        //que permita tener una tablas de hash con
        //estrategia de resolución de colisiones de dispersión
        //abierta que permita guardar y acceder
        //a los registros de los empleado por DNI.
        
        public void Iniciar()
        {
            Hash empleados = new Hash();
            Console.Clear();
            Console.WriteLine("Menu Empleados: \n \n1- Agregar un nuevo empleado. \n2- Buscar un Empleado por su DNI. \n \n0- Salir.");
            Console.Write("\n Ingrese una opcion:");
            int opcion = int.Parse(Console.ReadLine());

            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        string nombre;
                        string apellido;
                        int dni;
                        int numEmpleado;

                        Console.Write("ingrese Nombre del empleado:");
                        nombre = Console.ReadLine();
                        Console.Clear();

                        Console.Write("ingrese Apellido del empleado: ");
                        apellido = Console.ReadLine();
                        Console.Clear();

                        Console.Write("ingrese Numero de empleado: ");
                        numEmpleado = int.Parse(Console.ReadLine());
                        Console.Clear();

                        Console.Write("ingrese DNI del empleado: ");
                        dni = int.Parse(Console.ReadLine());
                        Console.Clear();

                        empleados.guardarEmpleado(nombre, apellido, numEmpleado, dni);

                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Ingrese el DNI del empleado: ");
                        try
                        {
                            Console.WriteLine(empleados.verificarDni(int.Parse(Console.ReadLine())));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No se ha encontrado ningun Empleado con ese DNI");
                        }
                        
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine($"{opcion} no es una opcion valida \npresione una telca para volver a intentar.");
                        Console.ReadKey();
                        break;


                }
                Console.Clear();
                Console.WriteLine("Menu Empleados: \n \n1- Agregar un nuevo empleado. \n2- Buscar un Empleado por su DNI. \n \n0- Salir.");
                Console.WriteLine("\n Ingrese una opcion:");
                opcion = int.Parse(Console.ReadLine());

            }
            

        }
    }
}
