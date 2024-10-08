namespace Ejercicio1;

public class ItemInvo : IItem
{
    public string ItemName { get; }  // Nombre del ítem invocador
    public string MinionName { get; } // Nombre del minion que será invocado
    public int Health { get; } // Puntos de salud del minion invocado
    public int Damage { get; } // Daño que inflige el minion invocado

    // Constructor que inicializa las propiedades del ítem.
    public ItemInvo(string itemName, string minionName, int health, int damage)
    {
        ItemName = itemName; // Asigna el nombre del ítem
        MinionName = minionName; // Asigna el nombre del minion
        Health = health; // Asigna la salud del minion
        Damage = damage; // Asigna el daño del minion
    }

    // Método Apply, que implementa la interfaz IItem y aplica los efectos del ítem al personaje invocando un minion
    public void Apply(Character character)
    {
        // Llama al método SummonMinion en el personaje, creando un minion con los parámetros definidos
        character.SummonMinion(MinionName, Health, Damage);
    }

    // Sobrescribe el método ToString para devolver el nombre del ítem y que aparezca que se ha utilizado con ese nombre
    public override string ToString()
    {
        return ItemName;
    }
}
