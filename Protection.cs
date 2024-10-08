namespace Ejercicio1;

// Clase Protection

public abstract class Protection : IItem
{
    public string Name { get; set; } //Almacena el nombre de la protección
    public int Armor { get; set; } //Almacena el valor de la armadura que ofrece la protección
    public Protection(string name, int armor) //Constructor para inicializar la protección
    {
        Name = name;
        Armor = armor;
    }

    public abstract void Apply(Character character); //Método abstracto que aplicará la protección al personaje
}