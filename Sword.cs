namespace Ejercicio1;

// Clase Sword (Espada) 

public class Sword : Weapon // Constructor de la clase Sword.
{
    public Sword() : base("Espada", 15) {} // Al llamar a "base()", estamos invocando el constructor de la clase abstracta Weapon.

    // Este método sobrescribe el método abstracto Apply de la clase Weapon, el propósito es modificar las propiedades del personaje cuando se usa el arma.
    public override void Apply(Character character)
    {
        // Incrementa el daño base del personaje al sumar el daño del arma.
        character.BaseDamage += Damage;
    }
    
    // Sobrescribe el método ToString para que devuelva el nombre "Espada" cuando se usa la espada y no "Ejercicio1.xxx"
    public override string ToString()
    {
        return "Espada";
    }
}