using System;
using System.Collections.Generic;

// Clase para representar las armas
public class Arma : Objeto
{
    public int Defensa { get; set; }
    public NivelArma Nivel { get; set; }
    public Encantamiento Encantamiento { get; set; }
    public char EscalaFuerza { get; set; }
    public char EscalaDestreza { get; set; }
    public char EscalaInteligencia { get; set; }
    public List<Habilidad> Habilidades { get; set; }

    public Arma(string nombre, int defensa, NivelArma nivel, Encantamiento encantamiento,
                char escalaFuerza, char escalaDestreza, char escalaInteligencia, List<Habilidad> habilidades)
        : base(nombre, TipoObjeto.Arma)
    {
        Nombre = nombre;
        Defensa = defensa;
        Nivel = nivel;
        Encantamiento = encantamiento;
        EscalaFuerza = escalaFuerza;
        EscalaDestreza = escalaDestreza;
        EscalaInteligencia = escalaInteligencia;
        Habilidades = habilidades;
    }

    // Método para calcular el daño basado en los atributos escaladores
    public int CalcularDano(Personaje personaje, Habilidad habilidad)
    {
        double danoReal = habilidad.Dano;
        if (danoReal > 0)
    {
        // Aplicar bonus según el nivel y encantamiento
        danoReal = AplicarBonus(danoReal);

        // Cálculo del daño extra por cada atributo escalador
        double danoExtraFuerza = CalcularEscalamiento(EscalaFuerza) * personaje.Fuerza;
        double danoExtraDestreza = CalcularEscalamiento(EscalaDestreza) * personaje.Destreza;
        double danoExtraInteligencia = CalcularEscalamiento(EscalaInteligencia) * personaje.Inteligencia;

        // Sumar los daños extras al daño base
        danoReal += danoExtraFuerza + danoExtraDestreza + danoExtraInteligencia;

        // Aumentar daño basado en el poder mágico si escala con inteligencia
        if (EscalaInteligencia == 'S' || EscalaInteligencia == 'A' || EscalaInteligencia == 'B')
        {
            danoReal *= 1 + Math.Log(personaje.PoderMagico + 1);
        }
    }
        return (int)Math.Round(danoReal);
    }

    // Método para calcular el daño total de todas las habilidades
    public Dictionary<string, int> CalcularDanioTotal(Personaje personaje)
    {
        var danios = new Dictionary<string, int>();

        foreach (var habilidad in Habilidades)
        {
            danios[habilidad.Nombre] = CalcularDano(personaje, habilidad);
        }

        return danios;
    }

    // Método para calcular el escalamiento basado en la escala
    public double CalcularEscalamiento(char escala)
    {
        return escala switch
        {
            'S' => 1.6,
            'A' => 1.1,
            'B' => 0.7,
            'C' => 0.4,
            'D' => 0.2,
            'E' => 0.0,
            _ => 0.0,
        };
    }

    // Método para aplicar bonus según el nivel y encantamiento
    private double AplicarBonus(double danoReal)
    {
        // Aplicar bonus según el nivel
        danoReal *= Nivel switch
        {
            NivelArma.T1 => 1.0,
            NivelArma.T2 => 1.1,
            NivelArma.T3 => 1.2,
            NivelArma.T4 => 1.3,
            NivelArma.T5 => 1.4,
            _ => 1.0,
        };

        // Aplicar bonus según el encantamiento
        danoReal *= Encantamiento switch
        {
            Encantamiento.Raro => 1.05,
            Encantamiento.Epico => 1.10,
            Encantamiento.Legendario => 1.15,
            _ => 1.0,
        };

        return danoReal;
    }

    // Método para calcular la penalización de evasión basada en la escala de fuerza
    public int CalcularPenalizacionEvasion()
    {
        return EscalaFuerza switch
        {
            'S' => 16,
            'A' => 11,
            'B' => 7,
            'C' => 4,
            'D' => 2,
            'E' => 0,
            _ => 0,
        };
    }
    
    public void ModificarDefensa(int cantidad)
{
    Defensa += cantidad;
    if (Defensa < 0) Defensa = 0; // Asegurarse de que la defensa no sea negativa
    if (Defensa > 100) Defensa = 100; // Asegurarse de que la defensa no pase de 100
}

}
