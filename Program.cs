namespace Ejercicio1;

public class Program
{
    static void Main(string[] args)
    {
        // Crear un nuevo héroe
        Character hero = new Character("Raúl", 100, 75, 57);
        Console.WriteLine($"Nombre: {hero.Name}");
        Console.WriteLine($"Puntos de vida máximos: {hero.MaxHitPoints}");
        Console.WriteLine($"Daño base: {hero.BaseDamage}");
        Console.WriteLine($"Armadura base: {hero.BaseArmor}");

        // Crear armas y armaduras
        IItem axe = new Axe();
        IItem sword = new Sword();
        IItem shield = new Shield();
        IItem helmet = new Helmet();
        IItem invo = new ItemInvo("Invocación", "Minion", 100, 25);


        // Agregar ítems al inventario
        hero.AddItemToInventory(axe);
        hero.AddItemToInventory(sword);
        hero.AddItemToInventory(shield);
        hero.AddItemToInventory(helmet);
        hero.AddItemToInventory(invo);

        // Usar ítems del inventario
        hero.UseItem(axe);
        Console.WriteLine($"Daño del hacha: {hero.BaseDamage}");

        hero.UseItem(shield);
        Console.WriteLine($"Armadura del escudo: {hero.BaseArmor}");

        // Atacar
        int damageDealt = hero.Attack();
        Console.WriteLine($"Daño infligido: {damageDealt}");

        // Recibir daño
        hero.ReceiveDamageToHero(20);
        Console.WriteLine($"Puntos de vida restantes: {hero.MaxHitPoints}");

        // Curar
        hero.Heal(10);
        Console.WriteLine($"Puntos de vida después de curar: {hero.MaxHitPoints}");

        // Crear un ítem para invocar un minion
        hero.UseItem(invo);

        // Atacar con el minion
        hero.AttackWithMinion(); // Esto hará que el minion ataque

        // Simular daño al minion
        hero.ReceiveDamageToMinion(60);
    }
}