using System;

namespace CTEDyA_2023_COM5_Franco_Fernando
{
	public class ArbolBinario<T>
	{
		private T dato;
		private ArbolBinario<T> hijoIzquierdo;
		private ArbolBinario<T> hijoDerecho;


		public ArbolBinario(T dato)
		{
			this.dato = dato;
		}

		public T getDatoRaiz()
		{
			return this.dato;
		}

		public ArbolBinario<T> getHijoIzquierdo()
		{
			return this.hijoIzquierdo;
		}

		public ArbolBinario<T> getHijoDerecho()
		{
			return this.hijoDerecho;
		}

		public void agregarHijoIzquierdo(ArbolBinario<T> hijo)
		{
			this.hijoIzquierdo = hijo;
		}

		public void agregarHijoDerecho(ArbolBinario<T> hijo)
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

		public bool esHoja()
		{
			return this.hijoIzquierdo == null && this.hijoDerecho == null;
		}


		//************//
		//*recorridos*//
		//************//
		//***************//
		//**Ejercicio 4**//
		//***************//

		public void inorden()
        {
			//HIJO IZQUIERDO
			if (this.hijoIzquierdo != null)
			{
				this.hijoIzquierdo.inorden();
			}

			//RAIZ
			Console.Write(this.dato + " ");

			//HIJO DERECHO
			if (this.hijoDerecho != null)
			{
				this.hijoDerecho.inorden();
			}
		}
		

		public void preorden()
		{
			//RAIZ
			Console.Write(this.dato + " ");

			//HIJOS
			if (this.hijoIzquierdo != null)
			{
				this.hijoIzquierdo.preorden();
			}

			if (this.hijoDerecho != null)
			{
				this.hijoDerecho.preorden();
			}
		}

		public void postorden()
		{
			//HIJOS
			if (this.hijoIzquierdo != null)
			{
				this.hijoIzquierdo.postorden();
			}

			if (this.hijoDerecho != null)
			{
				this.hijoDerecho.postorden();
			}

			//RAIZ
			Console.Write(this.dato + " ");

		}

		public void recorridoPorNiveles()
		{
			Cola<ArbolBinario<T>> cola = new Cola<ArbolBinario<T>>();
			cola.encolar(this);

			while (cola.Count() > 0)
			{
				ArbolBinario<T> actual = cola.desencolar();
				Console.Write(actual.dato + " ");

				if (actual.hijoIzquierdo != null)
				{
					cola.encolar(actual.hijoIzquierdo);
				}

				if (actual.hijoDerecho != null)
				{
					cola.encolar(actual.hijoDerecho);
				}
			}

		}

		public bool incluye(T dato)
		{
			if (this.dato.Equals(dato))
			{
				return true;
			}

			bool encontrado = false;

			if (this.hijoIzquierdo != null)
			{
				encontrado = this.hijoIzquierdo.incluye(dato);
			}

			if (!encontrado && this.hijoDerecho != null)
			{
				encontrado = this.hijoDerecho.incluye(dato);
			}

			return encontrado;
		}


		//***************//
		//**Ejercicio 5**//
		//***************//
		

		public int contarHojas()
		{
			if (this.esHoja())
			{
				return 1;
			}

			int contador = 0;

			if (this.hijoIzquierdo != null)
			{
				contador += this.hijoIzquierdo.contarHojas();
			}

			if (this.hijoDerecho != null)
			{
				contador += this.hijoDerecho.contarHojas();
			}

			return contador;
		}

		public void recorridoEntreNiveles(int n, int m)
		{
			if (n < 0 || m < n || m > this.Altura())
			{
				throw new ArgumentException("Los valores de n y m no son válidos.");
			}

			Cola<ArbolBinario<T>> cola = new Cola<ArbolBinario<T>>();
			cola.encolar(this);

			int nivel = 0;

			while (cola.Count() > 0 && nivel <= m)
			{
				int cantidadNodosNivel = cola.Count();

				if (nivel >= n && nivel <= m)
				{
					for (int i = 0; i < cantidadNodosNivel; i++)
					{
						ArbolBinario<T> actual = cola.desencolar();
						Console.Write(actual.dato + " ");

						if (actual.hijoIzquierdo != null)
						{
							cola.encolar(actual.hijoIzquierdo);
						}

						if (actual.hijoDerecho != null)
						{
							cola.encolar(actual.hijoDerecho);
						}
					}
				}
				else
				{
					for (int i = 0; i < cantidadNodosNivel; i++)
					{
						ArbolBinario<T> actual = cola.desencolar();

						if (actual.hijoIzquierdo != null)
						{
							cola.encolar(actual.hijoIzquierdo);
						}

						if (actual.hijoDerecho != null)
						{
							cola.encolar(actual.hijoDerecho);
						}
					}
				}

				nivel++;
			}

		}

		public int Altura()
		{
			if (this.esHoja())
			{
				return 0;
			}

			int alturaIzquierdo = 0;
			int alturaDerecho = 0;

			if (this.hijoIzquierdo != null)
			{
				alturaIzquierdo = this.hijoIzquierdo.Altura();
			}

			if (this.hijoDerecho != null)
			{
				alturaDerecho = this.hijoDerecho.Altura();
			}

			return 1 + Math.Max(alturaIzquierdo, alturaDerecho);
		}

		






	}


	
}
