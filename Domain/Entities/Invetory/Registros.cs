using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Invetory
{
    public class Registros
    {
        public DateTime FechaRegistro { get; set; }
        public int Existencia { get; set; }
        public decimal ValorUnidad { get; set; }
        public decimal ValorTotal { get; set; }
        public EspecieCuenta Especie { get; set; }

        /* protected Registros(DateTime fechaRegistro, int existencia)
        {
            //, decimal valorU, decimal valorT
            FechaRegistro = fechaRegistro;
            Existencia = existencia;
            //ValorUnidad = valorU;
            //ValorTotal = valorT;
        } */
    }
}
