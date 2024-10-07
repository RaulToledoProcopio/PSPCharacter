namespace Ejercicio1;

public class ItemInvo : IItem
{
    public string ItemName { get; }
    public string MinionName { get; }
    public int Health { get; }
    public int Damage { get; }

    // Constructor
    public ItemInvo(string itemName, string minionName, int health, int damage)
    {
        ItemName = itemName; // Nombre del ítem
        MinionName = minionName; // Nombre del minion
        Health = health; // Salud del minion
        Damage = damage; // Daño del minion
    }

    public void Apply(Character character)
    {
        character.SummonMinion(MinionName, Health, Damage);
    }

    public override string ToString()
    {
        return ItemName;
    }
}
