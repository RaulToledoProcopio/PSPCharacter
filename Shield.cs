namespace Ejercicio1;

// Clase Shield (Escudo) 

public class Shield : Protection

{
    public Shield() : base("Escudo", 20)
    {
    }

    public override void Apply(Character character)
    {
        character.BaseArmor += Armor;
    }
    
    public override string ToString()
    {
        return "Escudo";
    }
}