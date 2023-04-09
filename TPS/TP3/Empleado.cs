using System;
using System.Collections.Generic;
using System.Text;

namespace CTEDyA_2023_COM5_Franco_Fernando
{
    class Empleado: IComparable
    {
        //Los empleados de una cierta compañía se representan
        //en la base de datos de la compañía
        //por su nombre,número de empleado y DNI.
        //Implemente todos los objentos necesarios
        //que permita tener una tablas de hash con
        //estrategia de resolución de colisiones de dispersión
        //abierta que permita guardar y acceder
        //a los registros de los empleado por DNI.
        private string nombre;
        private string apellido;
        private int numEmpleado;
        private int dni;

        public Empleado(string nombre, string apellido, int numEmpleado, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.numEmpleado = numEmpleado;
            this.dni = dni;
        }

        public Empleado(int dni)
        {
            this.nombre = "aux";
            this.apellido = "aux";
            this.numEmpleado = 0;
            this.dni = dni;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public string getApellido()
        {
            return this.apellido;
        }

        public int getNumEmpleado()
        {
            return this.numEmpleado;
        }

        public int getDni()
        {
            return this.dni;
        }

        public int CompareTo(Object obj)
        {
            var e = obj as Empleado;
            int resultado = 0;

            if (e != null)
            {
                if (this.getDni() < e.getDni())
                {
                    resultado = -1;
                }
                else if (this.getDni() == e.getDni())
                {
                    resultado = 0;
                }
                else if (this.getDni() > e.getDni())
                {
                    resultado = 1;
                }

            }
            else
            {
                throw (new Exception("no se puede comparar el valor null")); 
            }

            return resultado;
        }

        public override string ToString()
        {
            return $"[{this.getNombre()},{this.getApellido()}] DNI: {this.getDni()}, N#Empleado: {this.getNumEmpleado()}";
        }

    }
}
