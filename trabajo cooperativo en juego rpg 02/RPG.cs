using System;
using System.Collections.Generic;

    // Enumeración para representar las diferentes clases de personajes
    public enum Clase
    {
        Guerrero,
        Mago,
        Clerigo,
        Ladron,
        Caballero
    }

    // Enumeración para representar los diferentes tipos de objetos
    public enum TipoObjeto
    {
        Arma,
        Armadura,
        Consumible,
        Herramienta,
        Objeto
    }

    // Enumeración para representar los niveles de las armas
    public enum NivelArma
    {
        T1, T2, T3, T4, T5
    }

    // Enumeración para representar los encantamientos de las armas
    public enum Encantamiento
    {
        Normal,
        Raro,
        Epico,
        Legendario
    }

    // Clase para representar un objeto en el inventario
    public abstract class Objeto
    {
        public string Nombre { get; set; }
        public TipoObjeto Tipo { get; set; }

        protected Objeto(string nombre, TipoObjeto tipo)
        {
            Nombre = nombre;
            Tipo = tipo;
        }
    }

    // Clase para representar el inventario
    public class Inventario
    {
        public List<Objeto> Objetos { get; } = new List<Objeto>();

        public void AgregarObjeto(Objeto objeto)
        {
            Objetos.Add(objeto);
        }
    }