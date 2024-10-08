﻿namespace Ejercicio1;

public class Program
{
    static void Main(string[] args)
    {
        // Crear un nuevo héroe con el nombre Raúl, que tiene 100 puntos de vida, 75 de daño base y 57 de armadura base.
        Character hero = new Character("Raúl", 100, 75, 57);
        Console.WriteLine($"Nombre: {hero.Name}"); // Muestra el nombre del héroe.
        Console.WriteLine($"Puntos de vida máximos: {hero.MaxHitPoints}"); // Muestra los puntos de vida máximos.
        Console.WriteLine($"Daño base: {hero.BaseDamage}"); // Muestra el daño base del héroe.
        Console.WriteLine($"Armadura base: {hero.BaseArmor}"); // Muestra la armadura base del héroe.

        // Crear armas y armaduras
        IItem axe = new Axe(); // Crea un objeto de tipo Axe.
        IItem sword = new Sword(); // Crea un objeto de tipo Sword.
        IItem shield = new Shield(); // Crea un objeto de tipo Shield.
        IItem helmet = new Helmet(); // Crea un objeto de tipo Helmet.
        IItem invo = new ItemInvo("Invocación", "Minion", 100, 25); // Crea un objeto de invocación de un minion.

        // Agregar ítems al inventario
        hero.AddItemToInventory(axe); // Agrega el hacha al inventario del héroe.
        hero.AddItemToInventory(sword); // Agrega la espada al inventario del héroe.
        hero.AddItemToInventory(shield); // Agrega el escudo al inventario del héroe.
        hero.AddItemToInventory(helmet); // Agrega el casco al inventario del héroe.
        hero.AddItemToInventory(invo); // Agrega el ítem de invocación al inventario del héroe.

        // Usar ítems del inventario
        hero.UseItem(axe); // Utiliza el hacha.
        Console.WriteLine($"Daño del hacha: {hero.BaseDamage}"); // Muestra el daño actualizado del héroe.

        hero.UseItem(shield); // Utiliza el escudo.
        Console.WriteLine($"Armadura del escudo: {hero.BaseArmor}"); // Muestra la armadura actualizada del héroe.

        // Atacar
        int damageDealt = hero.Attack(); // Llama al método Attack para calcular el daño infligido.
        Console.WriteLine($"Daño infligido: {damageDealt}"); // Muestra el daño infligido.

        // Recibir daño
        hero.ReceiveDamageToHero(20); // El héroe recibe daño especificado, en este caso 20 puntos.
        Console.WriteLine($"Puntos de vida restantes: {hero.MaxHitPoints}"); // Muestra los puntos de vida restantes del héroe.

        // Curar
        hero.Heal(10); // El héroe se cura 10 puntos de vida.
        Console.WriteLine($"Puntos de vida después de curar: {hero.MaxHitPoints}"); // Muestra los puntos de vida después de la curación.

        // Crear un ítem para invocar un minion
        hero.UseItem(invo); // Utiliza el ítem de invocación para invocar un minion.

        // Atacar con el minion
        hero.AttackWithMinion(); // Hace que el minion ataque, si existe.

        // Simular daño al minion
        hero.ReceiveDamageToMinion(50); // Simula que el minion recibe 50 puntos de daño.
    }
}