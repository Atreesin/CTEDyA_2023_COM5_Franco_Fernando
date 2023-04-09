using System;
using System.Collections.Generic;
using System.Text;

namespace CTEDyA_2023_COM5_Franco_Fernando
{
    class ArbolBinarioBusqueda
    {

		private IComparable dato;
		private ArbolBinarioBusqueda hijoIzquierdo;
		private ArbolBinarioBusqueda hijoDerecho;


		public ArbolBinarioBusqueda(IComparable dato)
		{
			this.dato = dato;
		}


		public IComparable getDatoRaiz()
		{
			return this.dato;
		}

		public ArbolBinarioBusqueda getHijoIzquierdo()
		{
			return this.hijoIzquierdo;
		}

		public ArbolBinarioBusqueda getHijoDerecho()
		{
			return this.hijoDerecho;
		}

		public void agregarHijoIzquierdo(ArbolBinarioBusqueda hijo)
		{
			this.hijoIzquierdo = hijo;
		}

		public void agregarHijoDerecho(ArbolBinarioBusqueda hijo)
		{
			this.hijoDerecho = hijo;
		}

		public void eliminarHijoIzquierdo()
		{
			this.hijoIzquierdo = null;
		}

		public void eliminarHijoDerecho()
		{
			this.hijoDerecho = null;
		}

		public void agregar(IComparable elem)
		{
			// si elem es mayor que el dato almacenado en la raiz...
			if (elem.CompareTo(this.dato) > 0)
			{
				// si el subarbol derecho esta vacio, inserto elem 
				if (this.hijoDerecho == null)
					this.agregarHijoDerecho(new ArbolBinarioBusqueda(elem));
				// si el arbol derecho no esta vacio, hago llamada recursiva a agregar()
				else
					this.hijoDerecho.agregar(elem);
			}
			// si elem es menor o igual...
			else
			{
				// si el subarbol iquierdo esta vacio, inserto elem 
				if (this.hijoIzquierdo == null)
					this.agregarHijoIzquierdo(new ArbolBinarioBusqueda(elem));
				// si el arbol izquierdo no esta vacio, hago llamada recursiva a agregar()
				else
					this.hijoIzquierdo.agregar(elem);
			}
		}


		public bool incluye(IComparable elem)
		{
			bool contiene = false;
			

            if (this.getDatoRaiz().CompareTo(elem) == 0)
            {
				return contiene = true;
            }
            else if (this.getDatoRaiz().CompareTo(elem) < 0 && this.getHijoDerecho() != null)
            {
				return this.getHijoDerecho().incluye(elem);
            }
			else if(this.getDatoRaiz().CompareTo(elem) > 0 && this.getHijoIzquierdo() != null)
            {
				return this.getHijoIzquierdo().incluye(elem);
			}
            else
            {
				return contiene;
            }
            			
		}


		public void inorden()
		{
			// hijo izquierdo (recursivamente)
			if (this.hijoIzquierdo != null)
				this.hijoIzquierdo.inorden();

			// raiz
			Console.Write(this.getDatoRaiz() + " ");

			// hijo derecho (recursivamente)
			if (this.hijoDerecho != null)
				this.hijoDerecho.inorden();
		}

		public void preorden()
		{
			// primero raiz
			Console.Write(this.getDatoRaiz() + " ");

			// hijo izquierdo (recursivamente)
			if (this.hijoIzquierdo != null)
				this.hijoIzquierdo.preorden();

			// hijo derecho (recursivamente)
			if (this.hijoDerecho != null)
				this.hijoDerecho.preorden();
		}

		public void postorden()
		{
			// hijo izquierdo (recursivamente)
			if (this.hijoIzquierdo != null)
				this.hijoIzquierdo.postorden();

			// hijo derecho (recursivamente)
			if (this.hijoDerecho != null)
				this.hijoDerecho.postorden();

			// raiz
			Console.Write(this.getDatoRaiz() + " ");
		}


		public void recorridoPorNiveles()
		{
			Cola<ArbolBinarioBusqueda> c = new Cola<ArbolBinarioBusqueda>();
			ArbolBinarioBusqueda arbolAux;

			c.encolar(this);

			while (!c.esVacia())
			{
				arbolAux = c.desencolar();

				Console.Write(arbolAux.getDatoRaiz() + " ");

				if (arbolAux.hijoIzquierdo != null)
					c.encolar(arbolAux.hijoIzquierdo);

				if (arbolAux.hijoDerecho != null)
					c.encolar(arbolAux.hijoDerecho);
			}
		}
	}
}
