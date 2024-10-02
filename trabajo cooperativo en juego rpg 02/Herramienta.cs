using System;
using System.Collections.Generic;

    // Clase para representar un objeto de herramienta
    public class Herramienta : Objeto
    {
        public int ValorUtilizador { get; set; }

        public Herramienta(string nombre, int valorUtilizador)
            : base(nombre, TipoObjeto.Herramienta)
        {
            ValorUtilizador = valorUtilizador;
        }
    }