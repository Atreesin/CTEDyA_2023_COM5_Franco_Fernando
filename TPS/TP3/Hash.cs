using System;
using System.Collections.Generic;
using System.Text;


namespace CTEDyA_2023_COM5_Franco_Fernando
{
    class Hash
    {
        private ABBEmpleados<Empleado>[] empleados;

        public Hash()
        {
            empleados = new ABBEmpleados<Empleado>[23];
        }

        public ABBEmpleados<Empleado>[] getEmpleados()
        {
            return this.empleados;
        }

        public ulong getHashEntry(int dni)
        {
            
            ulong hash = 5381;
            foreach (char c in dni.ToString())
                hash = (hash * 7) + (ulong)c;
            

            return hash % 23;
        }

        //guardarClave(usuario, passwd) Calcula la entrada en la tabla de hash y almacena en la misma el nombre del usuario
        //verificarClave(usuario, passwd) :boolean Retorna verdadero si se verifica que el usuario tiene esa clave.Retorna falso en caso contrario.
        //
        //Los empleados de una cierta compañía se representan
        //en la base de datos de la compañía por su nombre,número de empleado y DNI.
        //Implemente todos los objentos necesarios que permita tener una tablas de
        //hash con estrategia de resolución de colisiones de dispersión abierta que
        //permita guardar y acceder a los registros de los empleado por DNI.
        public void guardarEmpleado(string nombre, string apellido, int numEmpleado, int dni)
        {
            Empleado e = new Empleado(nombre, apellido, numEmpleado, dni);
            if(empleados[getHashEntry(dni)] != null)
            {
                empleados[getHashEntry(dni)].agregar(e);
            }
            else
            {
                empleados[getHashEntry(dni)] = new ABBEmpleados<Empleado>(e);
            }
            

        }

        public Empleado verificarDni(int dni)
        {
            Empleado aux = new Empleado(dni);

           if (empleados[getHashEntry(dni)] != null)
           {
                if (empleados[getHashEntry(dni)].incluye(aux))
                {
                    return empleados[getHashEntry(dni)].buscarEmple(aux);
                }
                else
                {
                    throw (new Exception("El empleado con ese DNI no existe"));
                }
           }
           else
           {
                throw (new Exception("no existen empleados con ese hash"));
           }
             
        }

    }
}
