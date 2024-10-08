namespace Ejercicio1;

// Clase Helmet (Casco) 

public class Helmet : Protection // Constructor de la clase Helmet.
{
    public Helmet() : base("Casco", 15) // Al llamar a "base()", estamos invocando el constructor de la clase abstracta Protection.
    {
    }
    
    // Este método sobrescribe el método abstracto Apply de la clase Protection, el propósito es modificar las propiedades del personaje cuando se usa el casco.
    public override void Apply(Character character)
    {
        // Incrementa la armadura base del personaje al sumar la armadura del casco.
        character.BaseArmor += Armor;
    }
    
    // Sobrescribe el método ToString para que devuelva el nombre "Casco" cuando se use el casco y no "Ejercicio1.xxx"
    public override string ToString()
    {
        return "Casco";
    }
}