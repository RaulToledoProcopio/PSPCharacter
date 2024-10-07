namespace Ejercicio1;

// Clase Axe (Hacha) 

public class Axe : Weapon
{
    public Axe() : base("Hacha1", 25)
    {
    }

    public override void Apply(Character character)
    {
        character.BaseDamage += Damage;
    }
    
    public override string ToString()
    {
        return "Hacha";
    }
}