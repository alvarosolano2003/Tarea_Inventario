using Domain.Entities;
using Domain.Entities.Invetory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Inventario
{
    public abstract class InventarioModel
    {
        protected Registros[] inventario;
        
        public void Create(Registros e)
        {
            Add(e, inventario);
        }

        private void Add(Registros e, Registros[] arr)
        {
            if (arr == null)
            {
                arr = new Registros[1];
                arr[0] = e;
                return;
            }

            Registros[] tmp = new Registros[arr.Length + 1];
            Array.Copy(arr, tmp, arr.Length);
            tmp[arr.Length + 1] = e;
            arr = tmp;

        }

        public void OrdenarPorFecha(Registros[] arr, int n)
        {
            DateTime valorC;
            int posicion;

            for (int i = 0; i < n; i++)
            {
                valorC = arr[i].FechaRegistro;
                posicion = i;

                while (posicion > 0 && arr[posicion - 1].FechaRegistro > valorC)
                {
                    arr[posicion] = arr[posicion - 1];
                    posicion = posicion - 1;
                }

                arr[posicion] = arr[i];
            }
        }

        protected (Registros[], Registros[]) GetEntradasSalidas()
        {
            Registros[] entradas = new Registros[0];
            Registros[] salidas = new Registros[0];

            foreach (Registros e in inventario)
            {
                if (e.Especie == Domain.Enums.EspecieCuenta.Entrada)
                {
                    Add(e, entradas);
                }
                else if (e.Especie == Domain.Enums.EspecieCuenta.Salida)
                {
                
                    Add(e, salidas);
                }
            }

            return (entradas, salidas);
        }

        public decimal CalcularSaldo()
        {
            decimal totalEntradas = 0, totalSalidas = 0;
            CalcularValores();
            Registros[] entradas, salidas;
            (entradas, salidas) = GetEntradasSalidas();

            foreach (Registros e in entradas)
            {
                totalEntradas += e.ValorTotal;
            }

            foreach (Registros e in salidas)
            {
                totalSalidas += e.ValorTotal;
            }

            return totalEntradas - totalSalidas;
        }

        public int CalcularExistencias()
        {
            int totalEntradas = 0, totalSalidas = 0;
            Registros[] entradas, salidas;
            (entradas, salidas) = GetEntradasSalidas();

            foreach (Registros e in entradas)
            {
                totalEntradas += e.Existencia;
            }

            foreach (Registros e in salidas)
            {
                totalSalidas += e.Existencia;
            }

            return totalEntradas - totalSalidas;
        }

        public abstract void CalcularValores();
    }
}
