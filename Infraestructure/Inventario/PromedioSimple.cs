using Domain.Entities.Invetory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Inventario
{
    public class PromedioSimple : InventarioModel
    {

        public override void CalcularValores()
        {
            OrdenarPorFecha(inventario, inventario.Length);

            Registros[] entradas, salidas;
            (entradas, salidas) = GetEntradasSalidas();

            for (int i = 0; i < salidas.Length; i++)
            {
                salidas[i].ValorUnidad = CalcularPromedio(entradas, salidas[i].FechaRegistro);
                salidas[i].ValorTotal = salidas[i].ValorUnidad * salidas[i].Existencia;

                for (int j = 0; j < inventario.Length; i++)
                {
                    if (inventario[j] == salidas[i])
                    {
                        inventario[j] = salidas[i];
                        break;
                    }
                }
            }
        }

        public decimal CalcularPromedio(Registros[] arr, DateTime aux)
        {
            decimal promedio = 0;
            int cantidad = 0;

            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j].FechaRegistro > aux)
                {
                    promedio += arr[j].ValorUnidad;
                    cantidad++;
                }
            }

            return promedio / cantidad;
        }
    }
}
