using System;

public class Habilidad
{
    public string Nombre { get; set; }
    public int Dano { get; set; }
    public int CostoMana { get; set; }
    public int CostoStamina { get; set; }
    public int Velocidad { get; set; }
    public double MultiplicadorCritico { get; set; }
    public string EfectoPasivo { get; set; }
    public bool CausesDamage { get; set; } = true;

    public Habilidad(string nombre, int dano, int costoMana, int costoStamina, int velocidad, double multiplicadorCritico, string efectoPasivo = "")
    {
        Nombre = nombre;
        Dano = dano;
        CostoMana = costoMana;
        CostoStamina = costoStamina;
        Velocidad = velocidad;
        MultiplicadorCritico = multiplicadorCritico;
        EfectoPasivo = efectoPasivo;
        CausesDamage = dano > 0;
    }
    // Métodos para variar multiplicador de crítico
public void ModificarMultiplicadorCritico(double cantidad)
{
    MultiplicadorCritico += cantidad;
}

// Métodos para variar velocidad
public void ModificarVelocidad(int cantidad)
{
    Velocidad += cantidad;
}

}
