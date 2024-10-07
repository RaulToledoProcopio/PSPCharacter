namespace Ejercicio1;

// Clase Sword (Espada) 

public class Sword : Weapon { 

    public Sword() : base("Espada1", 15) {}
    
    public override void Apply(Character character) { 

        character.BaseDamage += Damage; 

    }
    
    public override string ToString()
    {
        return "Espada";
    }

}