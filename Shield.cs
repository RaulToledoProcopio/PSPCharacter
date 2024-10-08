namespace Ejercicio1;

// Clase Shield (Escudo) 

public class Shield : Protection // Constructor de la clase Shield.

{
    public Shield() : base("Escudo", 20) // Al llamar a "base()", estamos invocando el constructor de la clase abstracta Protection.
    {
    }
    
    // Este método sobrescribe el método abstracto Apply de la clase Protection, el propósito es modificar las propiedades del personaje cuando se usa el escudo.
    public override void Apply(Character character)
    {
        // Incrementa la armadura base del personaje al sumar la armadura del escudo.
        character.BaseArmor += Armor;
    }
    
    // Sobrescribe el método ToString para que devuelva el nombre "Escudo" cuando se use el casco y no "Ejercicio1.xxx"
    public override string ToString()
    {
        return "Escudo";
    }
}