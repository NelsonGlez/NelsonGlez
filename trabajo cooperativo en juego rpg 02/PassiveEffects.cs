using System;
using System.Collections.Generic;

public class EfectoTemporal
{
    public string Nombre { get; set; }
    public Action<Personaje> Aplicar { get; set; }
    public Action<Personaje> Revertir { get; set; }

    public EfectoTemporal(string nombre, Action<Personaje> aplicar, Action<Personaje> revertir)
    {
        Nombre = nombre;
        Aplicar = aplicar;
        Revertir = revertir;
    }
    
}

public static class EfectosPasivos
{
    public static void AplicarEfectoPasivo(Habilidad habilidad, Personaje atacante, Personaje defensor, List<EfectoTemporal> efectosAplicados, bool esGrupal = false)
{
    List<Personaje> objetivos = new List<Personaje>();

    if (esGrupal)
    {
        if (EsEfectoPositivo(habilidad))
        {
            objetivos = ObtenerAliados(defensor);
        }
        else
        {
            objetivos = ObtenerEnemigos(atacante);
        }
    }
    else
    {
        objetivos.Add(EsEfectoPositivo(habilidad) ? defensor : atacante);
    }

    foreach (var objetivo in objetivos)
    {
        switch (habilidad.Nombre)
            {
                case "Guardia de Acero":
                    // Aumenta la vida del objetivo en 10 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ModificarVida(10), p => p.ModificarVida(-10)));
                    GuardiaDeAcero(objetivo);
                    break;
                case "Parada Doble":
                    // Aumenta la evasión del objetivo en 20 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ModificarEvasion(20), p => p.ModificarEvasion(-20)));
                    ParadaDoble(objetivo);
                    break;
                case "Flecha Perforante":
                    // Reduce la defensa del arma del objetivo en 20 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ArmaEquipada.ModificarDefensa(-20), p => p.ArmaEquipada.ModificarDefensa(20)));
                    FlechaPerforante(objetivo);
                    break;
                case "Esquiva Ágil":
                    // Aumenta la evasión del objetivo en 30 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ModificarEvasion(30), p => p.ModificarEvasion(-30)));
                    EsquivaAgil(objetivo);
                    break;
                case "Escudo Mágico":
                    // Aumenta la defensa del arma del objetivo en 50 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ArmaEquipada.ModificarDefensa(50), p => p.ArmaEquipada.ModificarDefensa(-50)));
                    EscudoMagico(objetivo);
                    break;
                case "Muro de Hierro":
                    // Aumenta la defensa del arma del objetivo en 70 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ArmaEquipada.ModificarDefensa(70), p => p.ArmaEquipada.ModificarDefensa(-70)));
                    MuroDeHierro(objetivo);
                    break;
                case "Guardia de Lanza":
                    // Aumenta la defensa del arma del objetivo en 40 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ArmaEquipada.ModificarDefensa(40), p => p.ArmaEquipada.ModificarDefensa(-40)));
                    GuardiaDeLanza(objetivo);
                    break;
                case "Armadura de Piedra":
                    // Aumenta la defensa del arma del objetivo en 60 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ArmaEquipada.ModificarDefensa(60), p => p.ArmaEquipada.ModificarDefensa(-60)));
                    ArmaduraDePiedra(objetivo);
                    break;
                case "Bloqueo Rápido":
                    // Aumenta la defensa del arma del objetivo en 30 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ArmaEquipada.ModificarDefensa(30), p => p.ArmaEquipada.ModificarDefensa(-30)));
                    BloqueoRapido(objetivo);
                    break;
                case "Escudo de Luz":
                    // Aumenta la defensa del arma del objetivo en 50 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ArmaEquipada.ModificarDefensa(50), p => p.ArmaEquipada.ModificarDefensa(-50)));
                    EscudoDeLuz(objetivo);
                    break;
                case "Escudo de Sombras":
                    // Aumenta la defensa del arma del objetivo en 50 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ArmaEquipada.ModificarDefensa(50), p => p.ArmaEquipada.ModificarDefensa(-50)));
                    EscudoDeSombras(objetivo);
                    break;
                case "Raíces Protectoras":
                    // Aumenta la defensa del arma del objetivo en 50 puntos
                    efectosAplicados.Add(new EfectoTemporal(objetivo.Nombre, p => p.ArmaEquipada.ModificarDefensa(50), p => p.ArmaEquipada.ModificarDefensa(-50)));
                    RaicesProtectoras(objetivo);
                    break;
                // Añade más casos para otras habilidades pasivas
            }
        }
    }

    private static bool EsEfectoPositivo(Habilidad habilidad)
    {
        // Determina si el efecto es positivo o negativo
        return habilidad.EfectoPasivo.Contains("aumenta") || habilidad.EfectoPasivo.Contains("cura") || habilidad.EfectoPasivo.Contains("protege");
    }

    private static List<Personaje> ObtenerAliados(Personaje personaje)
    {
        // Implementa la lógica para obtener la lista de aliados del personaje
        // Esto puede variar según cómo esté estructurado tu juego
        return new List<Personaje>(); // Placeholder
    }

    private static List<Personaje> ObtenerEnemigos(Personaje personaje)
    {
        // Implementa la lógica para obtener la lista de enemigos del personaje
        // Esto puede variar según cómo esté estructurado tu juego
        return new List<Personaje>(); // Placeholder
    }

    private static void GuardiaDeAcero(Personaje objetivo)
    {
        // Aumenta la vida del objetivo en 10 puntos
        objetivo.ModificarVida(10);
    }

    private static void ParadaDoble(Personaje objetivo)
    {
        // Aumenta la evasión del objetivo en 20 puntos
        objetivo.ModificarEvasion(20);
    }

    private static void FlechaPerforante(Personaje objetivo)
    {
        // Reduce la defensa del arma del objetivo en 20 puntos
        objetivo.ArmaEquipada.ModificarDefensa(-20);
    }

    private static void EsquivaAgil(Personaje objetivo)
    {
        // Aumenta la evasión del objetivo en 30 puntos
        objetivo.ModificarEvasion(30);
    }

    private static void EscudoMagico(Personaje objetivo)
    {
        // Aumenta la defensa del arma del objetivo en 50 puntos
        objetivo.ArmaEquipada.ModificarDefensa(50);
    }

    private static void MuroDeHierro(Personaje objetivo)
    {
        // Aumenta la defensa del arma del objetivo en 70 puntos
        objetivo.ArmaEquipada.ModificarDefensa(70);
    }

    private static void GuardiaDeLanza(Personaje objetivo)
    {
        // Aumenta la defensa del arma del objetivo en 40 puntos
        objetivo.ArmaEquipada.ModificarDefensa(40);
    }

    private static void ArmaduraDePiedra(Personaje objetivo)
    {
        // Aumenta la defensa del arma del objetivo en 60 puntos
        objetivo.ArmaEquipada.ModificarDefensa(60);
    }

    private static void BloqueoRapido(Personaje objetivo)
    {
        // Aumenta la defensa del arma del objetivo en 30 puntos
        objetivo.ArmaEquipada.ModificarDefensa(30);
    }

    private static void EscudoDeLuz(Personaje objetivo)
    {
        // Aumenta la defensa del arma del objetivo en 50 puntos
        objetivo.ArmaEquipada.ModificarDefensa(50);
    }

    private static void EscudoDeSombras(Personaje objetivo)
    {
        // Aumenta la defensa del arma del objetivo en 50 puntos
        objetivo.ArmaEquipada.ModificarDefensa(50);
    }

    private static void RaicesProtectoras(Personaje objetivo)
    {
        // Aumenta la defensa del arma del objetivo en 50 puntos
        objetivo.ArmaEquipada.ModificarDefensa(50);
    }
}
