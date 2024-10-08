namespace Ejercicio1;

// Clase Minion
public class Minion
{
    public string Name { get; } // Nombre del minion
    public int Health { get; private set; } // Salud del minion, solo puede modificarse dentro de la clase
    public int Damage { get; } // Daño que el minion puede infligir en combate

    // Constructor que inicializa las propiedades del minion
    public Minion(string name, int health, int damage)
    {
        Name = name; // Asigna el nombre del minion
        Health = health; // Asigna la salud inicial del minion
        Damage = damage; // Asigna el daño que puede infligir
    }

    // Método que devuelve el daño del minion
    public int Attack()
    {
        return Damage;
    }

    // Método que reduce la salud del minion según el daño recibido
    public void ReceiveDamage(int amount)
    {
        Health -= amount;
    }

    // Método que devuelve si el minion está vivo
    public bool IsAlive()
    {
        return Health > 0; // True si el minion tiene salud mayor a 0
    }
}
