using Domain.Entities.Invetory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Inventario
{
    public class UEPS : InventarioModel
    {
        public override void CalcularValores()
        {
            OrdenarPorFecha(inventario, inventario.Length);

            Registros[] entradas, salidas;
            (entradas, salidas) = GetEntradasSalidas();

            for (int i = 0; i < salidas.Length; i++)
            {
                salidas[i].ValorUnidad = entradas[i].ValorUnidad;
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
    }
}
