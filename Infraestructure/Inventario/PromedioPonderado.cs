using Domain.Entities.Invetory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Inventario
{
    public class PromedioPonderado : InventarioModel
    {
        public override void CalcularValores()
        {
            OrdenarPorFecha(inventario, inventario.Length);

            Registros[] entradas, salidas;
            (entradas, salidas) = GetEntradasSalidas();
            decimal promedio = 0;

            for (int i = 0; i < entradas.Length; i++)
            {
                promedio += entradas[i].ValorUnidad;
            }

            promedio = promedio / entradas.Length;

            for (int i = 0; i < salidas.Length; i++)
            {
                salidas[i].ValorUnidad = promedio;
                salidas[i].ValorTotal = salidas[i].ValorUnidad * salidas[i].Existencia;

                for (int j = 0; i < inventario.Length; i++)
                {
                    if (inventario[j] == salidas[i])
                    {
                        inventario[j] = salidas[i];
                        break;
                    }
                }
            }
        }
    }
}
