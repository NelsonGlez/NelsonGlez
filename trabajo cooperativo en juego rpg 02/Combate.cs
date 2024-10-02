using System;
using System.Collections.Generic;
using System.Linq;

public class Combate
{
    private List<Personaje> equipo1;
    private List<Personaje> equipo2;
    public List<EfectoTemporal> efectosAplicados = new List<EfectoTemporal>();

    public Combate(List<Personaje> equipo1, List<Personaje> equipo2)
    {
        this.equipo1 = equipo1;
        this.equipo2 = equipo2;
    }

    public void IniciarCombate()
    {
        Console.WriteLine("¡El combate ha comenzado!");

        while (HayJugadoresVivos(equipo1) && HayJugadoresVivos(equipo2))
        {
            List<Accion> acciones = new List<Accion>();

            foreach (var jugador in equipo1)
            {
                if (jugador.Vida > 0)
                {
                    acciones.Add(SeleccionarAccion(jugador, equipo2));
                }
            }

            foreach (var jugador in equipo2)
            {
                if (jugador.Vida > 0)
                {
                    acciones.Add(SeleccionarAccion(jugador, equipo1));
                }
            }

            acciones.Sort((a, b) => b.Habilidad.Velocidad.CompareTo(a.Habilidad.Velocidad));

            foreach (var accion in acciones)
            {
                if (accion.Atacante.Vida > 0 && accion.Defensor.Vida > 0)
                {
                    EjecutarAccion(accion);
                }
            }

            MostrarResultadosTurno(equipo1, equipo2);
        }

        if (HayJugadoresVivos(equipo1))
        {
            Console.WriteLine("¡El equipo 1 ha ganado el combate!");
        }
        else
        {
            Console.WriteLine("¡El equipo 2 ha ganado el combate!");
        }

        RevertirEfectosTemporales();
    }

    private void RevertirEfectosTemporales()
    {
        foreach (var efecto in efectosAplicados)
        {
            efecto.Revertir(efecto.Nombre.Contains("Equipo 1") ? equipo1.First(p => p.Nombre == efecto.Nombre) : equipo2.First(p => p.Nombre == efecto.Nombre));
        }
        efectosAplicados.Clear();
    }

    private bool HayJugadoresVivos(List<Personaje> equipo)
    {
        return equipo.Any(jugador => jugador.Vida > 0);
    }

private Accion SeleccionarAccion(Personaje atacante, List<Personaje> equipoEnemigo)
{
    Habilidad habilidadSeleccionada = null;
    bool habilidadValida = false;
    Personaje objetivoSeleccionado = null;

    while (!habilidadValida)
    {
        Console.WriteLine($"\nTurno de {atacante.Nombre}");
        Console.WriteLine($"Mana disponible: {atacante.Mana}, Stamina disponible: {atacante.Stamina}");
        Console.WriteLine("Selecciona una habilidad:");
        for (int i = 0; i < atacante.ArmaEquipada.Habilidades.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {atacante.ArmaEquipada.Habilidades[i].Nombre} (Costo Mana: {atacante.ArmaEquipada.Habilidades[i].CostoMana}, Costo Stamina: {atacante.ArmaEquipada.Habilidades[i].CostoStamina})");
        }
        int opcionHabilidad = int.Parse(Console.ReadLine());
        habilidadSeleccionada = atacante.ArmaEquipada.Habilidades[opcionHabilidad - 1];

        if (atacante.Stamina >= habilidadSeleccionada.CostoStamina && atacante.Mana >= habilidadSeleccionada.CostoMana)
        {
            habilidadValida = true;
        }
        else
        {
            Console.WriteLine("No tienes suficiente stamina o mana para usar esta habilidad. Selecciona otra habilidad.");
        }
    }

    // Solo seleccionar objetivo si la habilidad no es defensiva
    if (habilidadSeleccionada.Dano > 0)
    {
        if (equipoEnemigo.Count(j => j.Vida > 0) == 1)
        {
            objetivoSeleccionado = equipoEnemigo.First(j => j.Vida > 0);
            Console.WriteLine($"Objetivo seleccionado automáticamente: {objetivoSeleccionado.Nombre} (Vida restante: {objetivoSeleccionado.Vida})");
        }
        else
        {
            Console.WriteLine("Selecciona un objetivo:");
            for (int i = 0; i < equipoEnemigo.Count; i++)
            {
                if (equipoEnemigo[i].Vida > 0)
                {
                    Console.WriteLine($"{i + 1}. {equipoEnemigo[i].Nombre} (Vida restante: {equipoEnemigo[i].Vida})");
                }
            }
            int opcionObjetivo = int.Parse(Console.ReadLine());
            objetivoSeleccionado = equipoEnemigo[opcionObjetivo - 1];
        }
    }
    else
    {
        objetivoSeleccionado = atacante; // El objetivo es el propio atacante para habilidades defensivas
    }

    return new Accion(atacante, objetivoSeleccionado, habilidadSeleccionada);
}

private void EjecutarAccion(Accion accion)
{
    Personaje atacante = accion.Atacante;
    Personaje defensor = accion.Defensor;
    Habilidad habilidadSeleccionada = accion.Habilidad;

    Console.WriteLine($"\n{atacante.Nombre} usa {habilidadSeleccionada.Nombre} contra {defensor.Nombre}");

    if (atacante.Vida > 0 && defensor.Vida > 0)
    {
        bool esCritico = new Random().Next(100) < atacante.ProbabilidadCritico;
        int danoBase = atacante.ArmaEquipada.CalcularDano(atacante, habilidadSeleccionada);
        int dano = esCritico ? (int)(danoBase * habilidadSeleccionada.MultiplicadorCritico) : danoBase;

        bool esEsquivado = new Random().Next(100) < defensor.Evasion;
        if (esEsquivado)
        {
            Console.WriteLine($"{defensor.Nombre} ha esquivado el ataque!");
        }
        else
        {
            if (habilidadSeleccionada.Dano > 0)
            {
                // Lógica para habilidades ofensivas
                int danoReal = dano;

                // Aplicar la defensa del arma del defensor
                if (defensor.ArmaEquipada != null && defensor.ArmaEquipada.Defensa > 0)
                {
                    int porcentajeDefensa = defensor.ArmaEquipada.Defensa;
                    int danoBloqueado = danoReal * porcentajeDefensa / 100;
                    int staminaPerdida = danoBloqueado / 5;

                    defensor.ModificarStamina(-staminaPerdida);
                    danoReal -= danoBloqueado;

                    Console.WriteLine($"{defensor.Nombre} bloquea {danoBloqueado} puntos de daño y pierde {staminaPerdida} puntos de stamina.");
                }

                // Aplicar el daño restante al defensor
                defensor.ModificarVida(-danoReal);
                if (esCritico)
                {
                    Console.WriteLine("¡Es un golpe crítico!");
                }
                Console.WriteLine($"{atacante.Nombre} causa {danoReal} puntos de daño a {defensor.Nombre}");
                Console.WriteLine($"{defensor.Nombre} tiene {defensor.Vida} puntos de vida restantes.");
            }

            // Aplicar efecto pasivo
            if (!string.IsNullOrEmpty(habilidadSeleccionada.EfectoPasivo))
            {
                if (habilidadSeleccionada.Dano > 0)
                {
                    EfectosPasivos.AplicarEfectoPasivo(habilidadSeleccionada, atacante, defensor, efectosAplicados);
                }
                else
                {
                    EfectosPasivos.AplicarEfectoPasivo(habilidadSeleccionada, atacante, atacante, efectosAplicados);
                }
            }
        }
    }

    atacante.ModificarStamina(-habilidadSeleccionada.CostoStamina);
    atacante.ModificarMana(-habilidadSeleccionada.CostoMana);
}


    private void MostrarResultadosTurno(List<Personaje> equipo1, List<Personaje> equipo2)
    {
        Console.WriteLine("\n--- Resultados del Turno ---");
        MostrarEstadoEquipo(equipo1, "Equipo 1");
        MostrarEstadoEquipo(equipo2, "Equipo 2");
        Console.WriteLine("----------------------------\n");
    }

    private void MostrarEstadoEquipo(List<Personaje> equipo, string nombreEquipo)
    {
        Console.WriteLine($"{nombreEquipo}:");
        foreach (var jugador in equipo)
        {
            Console.WriteLine($"{jugador.Nombre} - Vida: {jugador.Vida}, Mana: {jugador.Mana}, Stamina: {jugador.Stamina}");
        }
    }
}

public class Accion
{
    public Personaje Atacante { get; }
    public Personaje Defensor { get; }
    public Habilidad Habilidad { get; }

    public Accion(Personaje atacante, Personaje defensor, Habilidad habilidad)
    {
        Atacante = atacante;
        Defensor = defensor;
        Habilidad = habilidad;
    }
}
