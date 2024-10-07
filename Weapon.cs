namespace Ejercicio1;

//Clase Weapon (abstracta)

public abstract class Weapon : IItem
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public abstract void Apply(Character character);
}