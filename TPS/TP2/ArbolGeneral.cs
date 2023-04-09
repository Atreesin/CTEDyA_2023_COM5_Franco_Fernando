using System;
using System.Collections.Generic;
using System.Text;

namespace CTEDyA_2023_COM5_Franco_Fernando
{
	public class ArbolGeneral<T>
	{

		private T dato;
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

		public ArbolGeneral(T dato)
		{
			this.dato = dato;
		}

		public T getDatoRaiz()
		{
			return this.dato;
		}

		public List<ArbolGeneral<T>> getHijos()
		{
			return hijos;
		}

		public void agregarHijo(ArbolGeneral<T> hijo)
		{
			this.getHijos().Add(hijo);
		}

		public void eliminarHijo(ArbolGeneral<T> hijo)
		{
			this.getHijos().Remove(hijo);
		}

		public bool esHoja()
		{
			return this.getHijos().Count == 0;
		}

		public int altura()
		{
			int alt = 0;
			if (!esHoja())
			{
				foreach (ArbolGeneral<T> hijo in getHijos())
				{
					if (alt < hijo.altura())
					{
						alt = hijo.altura();
					}

				}
				return alt + 1;
			}
			else
			{
				return alt;
			}

		}

		public int nivel(T dato)
		{
			Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> arbolAux;
			int nivel = 0;

			// encolamos raiz
			c.encolar(this);
			// encolamos null
			c.encolar(null);

			// procesamos cola
			while (!c.esVacia())
			{
				arbolAux = c.desencolar();

				if (arbolAux == null)
				{
					if (!c.esVacia())
					{
						c.encolar(null);
						nivel++;
					}
				}
				else
				{
					// procesar el dato
					if (arbolAux.getDatoRaiz().Equals(dato))
						return nivel;

					// encolamos hijos
					foreach (var hijo in arbolAux.getHijos())
						c.encolar(hijo);
				}
			}
			return -1;
		}

		public void preorden()
		{
			// primero se procesa la raiz 
			Console.Write(this.getDatoRaiz() + " ");

			// luego los hijos (recursivamente)
			foreach (var hijo in this.getHijos())
				hijo.preorden();
		}

		public void postorden()
		{
			// primero se procesan los hijos (recursivamente)
			foreach (var hijo in this.getHijos())
				hijo.postorden();

			// por ultimo se procesa la raiz 
			Console.Write(this.getDatoRaiz() + " ");
		}

		public void inorden()
		{
			// Se procesa primero el primer hijo (recursivamente)
			if (!this.esHoja())
				this.getHijos()[0].inorden();

			// Luego la raiz
			Console.Write(this.getDatoRaiz() + " ");

			// por ultimo los restantes hijos (recursivamente)
			for (int i = 1; i < this.getHijos().Count; i++)
				this.getHijos()[i].inorden();
		}

		public void porNiveles()
		{
			Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> arbolAux;

			// encolamos raiz
			c.encolar(this);

			// procesamos cola
			while (!c.esVacia())
			{
				arbolAux = c.desencolar();

				// procesar el dato
				Console.Write(arbolAux.getDatoRaiz() + " ");

				// encolamos hijos
				foreach (var hijo in arbolAux.getHijos())
					c.encolar(hijo);
			}
		}

		public void porNivelesConSeparacion()
		{
			Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> arbolAux;
			int nivel = 0;

			// encolamos raiz
			c.encolar(this);
			// encolamos null
			c.encolar(null);

			Console.Write("Nivel " + nivel + ": ");

			// procesamos cola
			while (!c.esVacia())
			{
				arbolAux = c.desencolar();

				if (arbolAux == null)
				{
					if (!c.esVacia())
					{
						c.encolar(null);

						nivel++;
						Console.WriteLine();
						Console.Write("Nivel " + nivel + ": ");
					}
				}
				else
				{
					// procesar el dato
					Console.Write(arbolAux.getDatoRaiz() + " ");

					// encolamos hijos
					foreach (var hijo in arbolAux.getHijos())
						c.encolar(hijo);
				}
			}
		}

	}

}
