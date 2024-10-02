using System;
using System.Collections.Generic;
    
    // Clase para representar un objeto general
    public class ObjetoGeneral : Objeto
    {
        public int ValorUtilizador { get; set; }

        public ObjetoGeneral(string nombre, int valorUtilizador)
            : base(nombre, TipoObjeto.Objeto)
        {
            ValorUtilizador = valorUtilizador;
        }
    }