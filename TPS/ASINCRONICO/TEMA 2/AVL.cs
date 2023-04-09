using System;
using System.Collections.Generic;
using System.Text;

namespace CTEDyA_2023_COM5_Franco_Fernando
{
	public class AVL
	{

		private IComparable dato;
		private AVL hijoIzquierdo;
		private AVL hijoDerecho;
		private int altura;

		public AVL(IComparable dato)
		{
			this.dato = dato;
			altura = 0;
		}

		public IComparable getDatoRaiz()
		{
			return this.dato;
		}

		public int getAltura()
		{
			return this.altura;
		}

		public AVL getHijoIzquierdo()
		{
			return this.hijoIzquierdo;
		}

		public AVL getHijoDerecho()
		{
			return this.hijoDerecho;
		}

		public void agregarHijoIzquierdo(AVL hijo)
		{
			this.hijoIzquierdo = hijo;
		}

		public void agregarHijoDerecho(AVL hijo)
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

		public AVL agregar(IComparable elem)
		{
			// inserta dato como en ABB:
			// si elem es mayor que el dato almacenado en la raiz...
			if (elem.CompareTo(this.dato) > 0)
			{
				// si el subarbol derecho esta vacio, inserto elem 
				if (this.hijoDerecho == null)
					this.agregarHijoDerecho(new AVL(elem));
				// si el arbol derecho no esta vacio, hago llamada recursiva a agregar()
				else
					this.hijoDerecho = this.hijoDerecho.agregar(elem);
			}
			// si elem es menor o igual...
			else
			{
				// si el subarbol iquierdo esta vacio, inserto elem 
				if (this.hijoIzquierdo == null)
					this.agregarHijoIzquierdo(new AVL(elem));
				// si el arbol izquierdo no esta vacio, hago llamada recursiva a agregar()
				else
					this.hijoIzquierdo = this.hijoIzquierdo.agregar(elem);
			}

			// actualizo altura 
			this.actualizarAltura();

			// chequeamos balance
			int balance = this.calcularDesbalance();
			AVL nuevaRaiz = this;

			if (balance >= 2)
			{ // entonces el lado derecho es mas alto -> rotacion con derecho
			  // si elem > dato hijo derecho, entonces aplico rotacion simple
				if (elem.CompareTo(this.hijoDerecho.dato) > 0)
					nuevaRaiz = this.rotacionSimpleDerecha();
				else
					nuevaRaiz = this.rotacionDobleDerecha();
			}

			if (balance <= -2)
			{// entonces el lado izquierdo es mas alto -> rotacion con izquierdo
			 // si elem < dato hijo izquierdo, entonces aplico rotacion simple
				if (elem.CompareTo(this.hijoIzquierdo.dato) <= 0)
					nuevaRaiz = this.rotacionSimpleIzquierda();
				else
					nuevaRaiz = this.rotacionDobleIzquierda();
			}

			return nuevaRaiz;
		}

		// rotacion simple CON derecho
		public AVL rotacionSimpleDerecha()
		{
			// referencia a nueva a raiz
			AVL nuevaRaiz = this.getHijoDerecho();

			// cambio hijo derecho de raiz actual (this)
			//this.agregarHijoDerecho(nuevaRaiz.hijoIzquierdo);
			this.hijoDerecho = nuevaRaiz.hijoIzquierdo;

			// cambio hijo izquierdo de nueva raiz
			nuevaRaiz.agregarHijoIzquierdo(this);

			// actualizamos altura de antigua raiz (this)
			this.actualizarAltura();

			// actualizamos altura de nueva raiz 
			nuevaRaiz.actualizarAltura();

			// retorno nueva raiz
			return nuevaRaiz;
		}

		// rotacion simple CON izquierdo
		public AVL rotacionSimpleIzquierda()
		{
			// referencia a nueva a raiz
			AVL nuevaRaiz = this.getHijoIzquierdo();

			// cambio hijo izquierdo de raiz actual (this)
			this.agregarHijoIzquierdo(nuevaRaiz.hijoDerecho);

			// cambio hijo derecho de nueva raiz
			nuevaRaiz.agregarHijoDerecho(this);

			// actualizamos altura de antigua raiz (this)
			this.actualizarAltura();

			// actualizamos altura de nueva raiz 
			nuevaRaiz.actualizarAltura();

			// retorno nueva raiz
			return nuevaRaiz;
		}

		// rotacion doble CON derecho
		public AVL rotacionDobleDerecha()
		{
			// 1ero: rotacion simple con izquierdo en hijo derecho
			this.hijoDerecho = this.hijoDerecho.rotacionSimpleIzquierda();

			// 2do: rotacion simple con derecho en raiz (this)
			return this.rotacionSimpleDerecha();
		}

		// rotacion doble CON izquierdo		
		public AVL rotacionDobleIzquierda()
		{
			// 1ero: rotacion simple con derecho en hijo izquierdo
			this.hijoIzquierdo = this.hijoIzquierdo.rotacionSimpleDerecha();

			// 2do: rotacion simple con izquierdo en raiz (this)
			return this.rotacionSimpleIzquierda();
		}

		private void actualizarAltura()
		{
			int alturaIzq = -1;
			int alturaDer = -1;

			if (this.hijoIzquierdo != null)
				alturaIzq = this.hijoIzquierdo.altura;

			if (this.hijoDerecho != null)
				alturaDer = this.hijoDerecho.altura;

			if (alturaDer > alturaIzq)
				this.altura = alturaDer + 1;
			else
				this.altura = alturaIzq + 1;
		}

		private int calcularDesbalance()
		{
			int alturaIzq = -1;
			int alturaDer = -1;

			if (this.hijoIzquierdo != null)
				alturaIzq = this.hijoIzquierdo.altura;

			if (this.hijoDerecho != null)
				alturaDer = this.hijoDerecho.altura;

			return (alturaDer - alturaIzq);
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
			Cola<AVL> c = new Cola<AVL>();
			AVL arbolAux;

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
