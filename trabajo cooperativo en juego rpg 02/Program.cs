using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear equipos
        List<Personaje> equipo1 = CrearEquipo(1);
        List<Personaje> equipo2 = CrearEquipo(2);

        // Iniciar el combate
        Combate combate = new Combate(equipo1, equipo2);
        combate.IniciarCombate();
    }

    static List<Personaje> CrearEquipo(int numeroEquipo)
    {
        List<Personaje> equipo = new List<Personaje>();

        Console.WriteLine($"Introduce el número de jugadores para el Equipo {numeroEquipo} (máximo 4):");
        int numJugadores = int.Parse(Console.ReadLine());

        for (int i = 0; i < numJugadores; i++)
        {
            Console.WriteLine($"Jugador {i + 1} del Equipo {numeroEquipo}, introduce tu nombre:");
            string nombreJugador = Console.ReadLine();
            Personaje jugador = CrearPersonaje(nombreJugador);
            equipo.Add(jugador);
        }

        return equipo;
    }

    static Personaje CrearPersonaje(string nombreJugador)
    {
        // Seleccionar la clase del personaje
        Console.WriteLine($"{nombreJugador}, selecciona tu clase:");
        Console.WriteLine("1. Guerrero");
        Console.WriteLine("2. Mago");
        Console.WriteLine("3. Clérigo");
        Console.WriteLine("4. Ladrón");
        Console.WriteLine("5. Caballero");
        int opcionClase = int.Parse(Console.ReadLine());

        Clase claseSeleccionada = (Clase)(opcionClase - 1);

        // Crear el personaje
        Personaje personaje = new Personaje(1, nombreJugador, claseSeleccionada);
        personaje.AsignarAtributosIniciales(claseSeleccionada);

        // Mostrar atributos del personaje
        MostrarAtributos(personaje);

        // Seleccionar el arma
        EquiparArma(personaje);

        return personaje;
    }

    static void MostrarAtributos(Personaje personaje)
    {
        Console.WriteLine("\n--- Atributos del Personaje ---");
        Console.WriteLine($"Nombre: {personaje.Nombre}");
        Console.WriteLine($"Clase: {personaje.ClasePersonaje}");
        Console.WriteLine($"Nivel: {personaje.Nivel}");
        Console.WriteLine($"Experiencia: {personaje.Experiencia}");
        Console.WriteLine($"Vida: {personaje.Vida}");
        Console.WriteLine($"Mana: {personaje.Mana}");
        Console.WriteLine($"Stamina: {personaje.Stamina}");
        Console.WriteLine($"Fuerza: {personaje.Fuerza}");
        Console.WriteLine($"Destreza: {personaje.Destreza}");
        Console.WriteLine($"Inteligencia: {personaje.Inteligencia}");
        Console.WriteLine($"Poder Mágico: {personaje.PoderMagico}");
        Console.WriteLine($"Resistencia: {personaje.Resistencia}");
        Console.WriteLine($"Precisión: {personaje.Precision}");
        Console.WriteLine($"Evasión: {personaje.Evasion}");
        Console.WriteLine($"Probabilidad de Crítico: {personaje.ProbabilidadCritico}");
        Console.WriteLine($"Puntos de Atributo Disponibles: {personaje.PuntosAtributoDisponibles}");
        if (personaje.ArmaEquipada != null)
        {
            Console.WriteLine($"Arma Equipada: {personaje.ArmaEquipada.Nombre}");
            Console.WriteLine($"Daño de la Primera Habilidad: {personaje.ArmaEquipada.CalcularDano(personaje, personaje.ArmaEquipada.Habilidades[0])}");
        }
        Console.WriteLine("-------------------------------\n");
    }

    static void EquiparArma(Personaje personaje)
    {
        Console.WriteLine("Selecciona tu arma:");
        for (int i = 0; i < Armas.ListaDeArmas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Armas.ListaDeArmas[i].Nombre}");
        }
        int opcionArma = int.Parse(Console.ReadLine());
        Arma armaSeleccionada = Armas.ListaDeArmas[opcionArma - 1];
        personaje.EquiparArma(armaSeleccionada);
    }
}
