namespace Ejercicio1;

//Clase Weapon (abstracta)

public abstract class Weapon : IItem
{
    public string Name { get; set; }   // Almacena el nombre del arma.
    public int Damage { get; set; }    // Almacena el daño que inflige el arma.

    public Weapon(string name, int damage) // Constructor para inicializar el arma.
    {
        Name = name;
        Damage = damage;
    }

    public abstract void Apply(Character character); // Método abstracto que aplicará el arma al personaje.
}