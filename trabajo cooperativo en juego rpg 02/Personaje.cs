using System;
using System.Collections.Generic;

public class Personaje
{
    // Propiedades básicas
    public int Id { get; set; }
    public string Nombre { get; set; }
    public Clase ClasePersonaje { get; set; }

    // Propiedades de nivel y experiencia
    public int Nivel { get; private set; }
    public double Experiencia { get; set; }
    public int PuntosAtributoDisponibles { get; set; }

    // Propiedades de atributos
    public int Fuerza { get; set; }
    public int Destreza { get; set; }
    public int Inteligencia { get; set; }
    public int PoderMagico { get; set; }
    public int Resistencia { get; set; }
    public int Precision { get; set; }

    // Propiedades de recursos
    public int Vida { get; private set; }
    public int Mana { get; private set; }
    public int Stamina { get; private set; }
    public int VidaMaxima { get; private set; }
    public int ManaMaximo { get; private set; }
    public int StaminaMaxima { get; private set; }

    // Nuevas propiedades
    public int Evasion { get; set; } = 30;
    public int ProbabilidadCritico { get; set; }

    // Inventario
    public Inventario? Inventario { get; set; }
    public Arma? ArmaEquipada { get; set; }

    // Constructor
    public Personaje(int id, string nombre, Clase clasePersonaje)
    {
        Id = id;
        Nombre = nombre;
        ClasePersonaje = clasePersonaje;
    }

    // Métodos de inicialización
    public void AsignarAtributosIniciales(Clase clasePersonaje)
    {
        switch (clasePersonaje)
        {
            case Clase.Guerrero:
                AsignarAtributos(6, 5, 3, 3, 5, 4); // Total: 26
                break;
            case Clase.Mago:
                AsignarAtributos(4, 5, 6, 6, 3, 2); // Total: 26
                break;
            case Clase.Clerigo:
                AsignarAtributos(4, 4, 5, 5, 4, 4); // Total: 26
                break;
            case Clase.Ladron:
                AsignarAtributos(4, 6, 4, 3, 4, 5); // Total: 26
                break;
            case Clase.Caballero:
                AsignarAtributos(5, 4, 3, 3, 5, 6); // Total: 26
                break;
        }

        VidaMaxima = CalcularVida(Fuerza, Resistencia);
        ManaMaximo = CalcularMana(Inteligencia, PoderMagico);
        StaminaMaxima = CalcularStamina(Destreza, Precision);

        Vida = VidaMaxima;
        Mana = ManaMaximo;
        Stamina = StaminaMaxima;

        ProbabilidadCritico = CalcularProbCritico(Precision);

        Nivel = CalcularNivelInicial();
    }

    public void AsignarAtributos(int fuerza, int destreza, int inteligencia, int poderMagico, int resistencia, int precision)
    {
        Fuerza = fuerza;
        Destreza = destreza;
        Inteligencia = inteligencia;
        PoderMagico = poderMagico;
        Resistencia = resistencia;
        Precision = precision;
    }

    // Métodos de cálculo
    private int CalcularNivelInicial()
    {
        int totalPoints = Fuerza + Destreza + Inteligencia + PoderMagico + Resistencia + Precision;
        return Math.Max((totalPoints - 18), 1);
    }

    private int CalcularVida(int fuerza, int resistencia)
    {
        return (int)(10 * Math.Log(fuerza * 4 + resistencia * 3 + 1));
    }

    private int CalcularMana(int inteligencia, int poderMagico)
    {
        return (int)(5 * Math.Log(inteligencia * 4 + poderMagico * 3 + 1));
    }

    private int CalcularStamina(int destreza, int precision)
    {
        return (int)(7 * Math.Log(destreza * 4 + precision * 3 + 1));
    }

    private int CalcularProbCritico(int precision)
    {
        ProbabilidadCritico = (int)(3 * Math.Log(Precision + 1));
        return ProbabilidadCritico;
    }

    private long CalcularExperienciaNecesaria(int nivel)
    {
        const int baseExperience = 100;
        float experienceMultiplier = (float)Math.Pow(Math.E, nivel * 0.02f);
        return (long)Math.Round(baseExperience * experienceMultiplier);
    }

    // Métodos de nivelación

    // Método que suma la experiencia ganada a la experiencia del jugador
    public void GanarExperiencia(int experienciaGanada)
    {
        Experiencia += experienciaGanada;
        
        // Verificar si se debe subir de nivel
        while (Experiencia >= CalcularExperienciaNecesaria(Nivel + 1))
        {
            SubirNivel();
        }
    }

    // Método que se encarga de subir el nivel del jugador
    public void SubirNivel()
    {
        int nextLevel = Nivel + 1;
        long requiredExperience = CalcularExperienciaNecesaria(nextLevel);

        if (Experiencia >= requiredExperience)
        {
            Nivel++;
            Experiencia -= requiredExperience;
            PuntosAtributoDisponibles++;

            Console.WriteLine($"Has subido al nivel {nextLevel}. Tienes {PuntosAtributoDisponibles} punto(s) de atributo disponible(s).");

            // Recalcular máximos y ajustar valores actuales
            VidaMaxima = CalcularVida(Fuerza, Resistencia);
            ManaMaximo = CalcularMana(Inteligencia, PoderMagico);
            StaminaMaxima = CalcularStamina(Destreza, Precision);

            Vida = Math.Min(Vida, VidaMaxima);
            Mana = Math.Min(Mana, ManaMaximo);
            Stamina = Math.Min(Stamina, StaminaMaxima);
        }
    }

    public void AumentarAtributo(int atributo)
    {
        if (PuntosAtributoDisponibles > 0)
        {
            switch (atributo)
            {
                case 1:
                    Fuerza++; break;
                case 2:
                    Destreza++; break;
                case 3:
                    Inteligencia++; break;
                case 4:
                    PoderMagico++; break;
                case 5:
                    Precision++; break;
                case 6:
                    Resistencia++; break;
            }

            PuntosAtributoDisponibles--;
            Console.WriteLine($"Has aumentado el atributo {GetAttributeName(atributo)}");

            // Actualizar recursos basados en los nuevos valores de atributos
            VidaMaxima = CalcularVida(Fuerza, Resistencia);
            ManaMaximo = CalcularMana(Inteligencia, PoderMagico);
            StaminaMaxima = CalcularStamina(Destreza, Precision);

            Vida = Math.Min(Vida, VidaMaxima);
            Mana = Math.Min(Mana, ManaMaximo);
            Stamina = Math.Min(Stamina, StaminaMaxima);
            ProbabilidadCritico = CalcularProbCritico(Precision);
        }
        else
        {
            Console.WriteLine("No tienes puntos de atributo disponibles.");
        }
    }

    private string GetAttributeName(int atributo)
    {
        switch (atributo)
        {
            case 1: return "Fuerza";
            case 2: return "Destreza";
            case 3: return "Inteligencia";
            case 4: return "Poder Mágico";
            case 5: return "Precisión";
            case 6: return "Resistencia";
            default: return "Desconocido";
        }
    }

    // Métodos para variar evasión
    public void ModificarEvasion(int cantidad)
    {
        Evasion += cantidad;
    }
    //Modificadores (Para usar en los efectos pasivos de las habilidades en combate)
    public static void ModificarVida(Personaje personaje, int cantidad)
    {
        personaje.Vida += cantidad;
        if (personaje.Vida < 0) personaje.Vida = 0; // Asegurarse de que la vida no sea negativa
        if (personaje.Vida > personaje.VidaMaxima) personaje.Vida = personaje.VidaMaxima; // Asegurarse de que la vida no exceda el máximo
    }

    public static void ModificarMana(Personaje personaje, int cantidad)
    {
        personaje.Mana += cantidad;
        if (personaje.Mana < 0) personaje.Mana = 0; // Asegurarse de que el mana no sea negativo
        if (personaje.Mana > personaje.ManaMaximo) personaje.Mana = personaje.ManaMaximo; // Asegurarse de que el mana no exceda el máximo
    }

    public static void ModificarStamina(Personaje personaje, int cntidad)
    {
        personaje.Stamina += cntidad;
        if (personaje.Stamina < 0) personaje.Stamina = 0; // Asegurarse de que la stamina no sea negativo
        if (personaje.Stamina > personaje.StaminaMaxima) personaje.Stamina = personaje.Stamina; // Asegurarse de que Stamina no exceda el máximo
    }

    // Método para equipar un arma y ajustar la evasión
    public void EquiparArma(Arma arma)
    {
        ArmaEquipada = arma;
        int penalizacionEvasion = arma.CalcularPenalizacionEvasion();
        ModificarEvasion(-penalizacionEvasion);
    }

        // Método para desequipar un arma y restaurar la evasión
    public void DesequiparArma()
    {
        if (ArmaEquipada != null)
        {
            int penalizacionEvasion = ArmaEquipada.CalcularPenalizacionEvasion();
            ModificarEvasion(penalizacionEvasion);
            ArmaEquipada = null;
        }
    }

public void ModificarVida(int cantidad)
{
    Vida += cantidad;
    if (Vida < 0) Vida = 0; // Asegurarse de que la vida no sea negativa
    if (Vida > VidaMaxima) Vida = VidaMaxima; // Asegurarse de que la vida no exceda el máximo
}

public void ModificarMana(int cantidad)
{
    Mana += cantidad;
    if (Mana < 0) Mana = 0; // Asegurarse de que el mana no sea negativo
    if (Mana > ManaMaximo) Mana = ManaMaximo; // Asegurarse de que el mana no exceda el máximo
}

public void ModificarStamina(int cantidad)
{
    Stamina += cantidad;
    if (Stamina < 0) Stamina = 0; // Asegurarse de que la stamina no sea negativa
    if (Stamina > StaminaMaxima) Stamina = StaminaMaxima; // Asegurarse de que la stamina no exceda el máximo
}

// Métodos para variar probabilidad de ataque crítico
public void ModificarProbabilidadCritico(int cantidad)
{
    ProbabilidadCritico += cantidad;
    if (ProbabilidadCritico > 100) ProbabilidadCritico = 100;
}
}
