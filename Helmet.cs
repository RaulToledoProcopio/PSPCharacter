namespace Ejercicio1;

// Clase Helmet (Casco) 

public class Helmet : Protection
{
    public Helmet() : base("Casco", 15)
    {
    }

    public override void Apply(Character character)
    {
        character.BaseArmor += Armor;
    }
    
    public override string ToString()
    {
        return "Casco";
    }
}