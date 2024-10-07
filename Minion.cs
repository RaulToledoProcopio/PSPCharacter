namespace Ejercicio1;

// Clase Minion
public class Minion
{
    public string Name { get; }
    public int Health { get; private set; }
    public int Damage { get; }

    public Minion(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public int Attack()
    {
        return Damage; 
    }

    public void ReceiveDamage(int amount)
    {
        Health -= amount;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}