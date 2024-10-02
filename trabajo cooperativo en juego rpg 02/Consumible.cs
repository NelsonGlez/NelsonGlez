using System;
using System.Collections.Generic;

    // Clase para representar un objeto consumible
    public class Consumible : Objeto
    {
        public int ValorCurativo { get; set; }
        public int ValorMágico { get; set; }

        public Consumible(string nombre, int valorCurativo, int valorMágico)
            : base(nombre, TipoObjeto.Consumible)
        {
            ValorCurativo = valorCurativo;
            ValorMágico = valorMágico;
        }
    }