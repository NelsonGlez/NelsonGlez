using System;
using System.Collections.Generic;

public static class Armas
{
    public static List<Arma> ListaDeArmas = new List<Arma>
    {
        new Arma("Espada Larga", 90, NivelArma.T1, Encantamiento.Normal, 'A', 'C', 'E',
            new List<Habilidad>
            {
                new Habilidad("Corte Rápido", 20, 0, 0, 90, 1.5),
                new Habilidad("Estocada Poderosa", 30, 0, 20, 80, 1.8),
                new Habilidad("Guardia de Acero", 0, 0, 10, 100, 0, "Reduce el daño causado por el enemigo seleccionado en 50% durante 1 turno")
            }),
        new Arma("Doble Espada", 8, NivelArma.T1, Encantamiento.Normal, 'B', 'A', 'D',
            new List<Habilidad>
            {
                new Habilidad("Corte Gemelo", 18, 0, 0, 110, 1.5),
                new Habilidad("Danza de Espadas", 25, 0, 30, 100, 1.8),
                new Habilidad("Parada Doble", 0, 0, 15, 115, 0, "Reduce el daño recibido en un 40% durante 1 turno")
            }),
        new Arma("Daga", 5, NivelArma.T1, Encantamiento.Normal, 'D', 'S', 'C',
            new List<Habilidad>
            {
                new Habilidad("Puñalada Rápida", 15, 0, 0, 120, 1.8),
                new Habilidad("Asesinato Silencioso", 25, 0, 25, 110, 2.0),
                new Habilidad("Desvanecerse", 0, 0, 20, 130, 0, "Aumenta la evasión en un 50% durante 1 turno")
            }),
        new Arma("Arco", 7, NivelArma.T1, Encantamiento.Normal, 'C', 'A', 'D',
            new List<Habilidad>
            {
                new Habilidad("Flecha Rápida", 18, 0, 0, 110, 1.5),
                new Habilidad("Flecha Perforante", 25, 0, 20, 100, 1.8, "Reduce la defensa del enemigo en un 20% durante 2 turnos"),
                new Habilidad("Esquiva Ágil", 0, 0, 15, 115, 0, "Aumenta la evasión en un 30% durante 1 turno")
            }),
        new Arma("Bastón Mágico", 5, NivelArma.T1, Encantamiento.Normal, 'E', 'D', 'A',
            new List<Habilidad>
            {
                new Habilidad("Rayo Arcano", 20, 0, 0, 80, 1.5),
                new Habilidad("Bola de Fuego", 35, 40, 0, 70, 1.8),
                new Habilidad("Escudo Mágico", 0, 30, 0, 85, 0, "Absorbe 50% del daño recibido durante 2 turnos")
            }),
        new Arma("Hacha de Guerra", 15, NivelArma.T1, Encantamiento.Normal, 'S', 'B', 'E',
            new List<Habilidad>
            {
                new Habilidad("Golpe Brutal", 25, 0, 0, 70, 1.5),
                new Habilidad("Ciclón de Hacha", 30, 0, 50, 60, 1.8),
                new Habilidad("Muro de Hierro", 0, 0, 20, 75, 0, "Reduce el daño recibido en un 70% durante 1 turno")
            }),
        new Arma("Lanza", 10, NivelArma.T1, Encantamiento.Normal, 'B', 'B', 'C',
            new List<Habilidad>
            {
                new Habilidad("Estocada Rápida", 20, 0, 0, 100, 1.5),
                new Habilidad("Barrido Circular", 25, 0, 25, 90, 1.8, "Reduce la velocidad del enemigo en un 20% durante 2 turnos"),
                new Habilidad("Guardia de Lanza", 0, 0, 15, 105, 0, "Reduce el daño recibido en un 40% durante 1 turno")
            }),
        new Arma("Martillo de Guerra", 20, NivelArma.T1, Encantamiento.Normal, 'S', 'D', 'E',
            new List<Habilidad>
            {
                new Habilidad("Golpe Aplastante", 30, 0, 0, 60, 1.5),
                new Habilidad("Martillazo Sísmico", 35, 0, 50, 50, 1.8),
                new Habilidad("Armadura de Piedra", 0, 0, 30, 65, 0, "Reduce el daño recibido en un 60% durante 2 turnos")
            }),
        new Arma("Espada Corta", 8, NivelArma.T1, Encantamiento.Normal, 'C', 'B', 'D',
            new List<Habilidad>
            {
                new Habilidad("Corte Ligero", 18, 0, 0, 100, 1.5),
                new Habilidad("Estocada Veloz", 20, 0, 20, 95, 1.8, "Aumenta la velocidad del usuario en un 10% durante 2 turnos"),
                new Habilidad("Bloqueo Rápido", 0, 0, 10, 105, 0, "Reduce el daño recibido en un 30% durante 1 turno")
            }),
        new Arma("Vara de Curación", 5, NivelArma.T1, Encantamiento.Normal, 'E', 'D', 'A',
            new List<Habilidad>
            {
                new Habilidad("Golpe de Luz", 15, 0, 0, 90, 1.5),
                new Habilidad("Rayo Sanador", 0, 30, 0, 80, 0, "Cura 30 puntos de vida a un aliado"),
                new Habilidad("Escudo de Luz", 0, 20, 0, 95, 0, "Absorbe 50% del daño recibido por un aliado durante 2 turnos")
            }),
        new Arma("Bastón de Invocación", 5, NivelArma.T1, Encantamiento.Normal, 'E', 'D', 'A',
            new List<Habilidad>
            {
                new Habilidad("Golpe Espiritual", 20, 0, 0, 80, 1.5),
                new Habilidad("Invocar Espectro", 30, 20, 0, 70, 1.8, "Invoca un espectro que ataca al enemigo durante 2 turnos"),
                new Habilidad("Escudo de Sombras", 0, 15, 0, 85, 0, "Absorbe 50% del daño recibido durante 2 turnos")
            }),
        new Arma("Bardo", 6, NivelArma.T1, Encantamiento.Normal, 'D', 'B', 'A',
            new List<Habilidad>
            {
                new Habilidad("Nota Discordante", 15, 0, 0, 100, 1.5),
                new Habilidad("Canción de Guerra", 25, 0, 15, 90, 1.8, "Aumenta el ataque de todos los aliados en un 10% durante 2 turnos"),
                new Habilidad("Melodía Sanadora", 0, 20, 0, 95, 0, "Cura 20 puntos de vida a todos los aliados")
            }),
        new Arma("Clérigo", 6, NivelArma.T1, Encantamiento.Normal, 'E', 'D', 'A',
            new List<Habilidad>
            {
                new Habilidad("Golpe Divino", 15, 0, 0, 90, 1.5),
                new Habilidad("Luz Purificadora", 25, 20, 0, 80, 1.8, "Reduce la defensa del enemigo en un 20% durante 2 turnos"),
                new Habilidad("Bendición", 0, 15, 0, 95, 0, "Aumenta la defensa de todos los aliados en un 20% durante 2 turnos")
            }),
        new Arma("Druida", 10, NivelArma.T1, Encantamiento.Normal, 'D', 'C', 'A',
            new List<Habilidad>
            {
                new Habilidad("Golpe de Ramas", 20, 0, 0, 85, 1.5),
                new Habilidad("Invocar Bestia", 30, 25, 0, 75, 1.8, "Invoca una bestia que ataca al enemigo durante 2 turnos"),
                new Habilidad("Raíces Protectoras", 0, 20, 0, 90, 0, "Absorbe 50% del daño recibido por un aliado durante 2 turnos")
            })
    };
}