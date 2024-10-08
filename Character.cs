namespace Ejercicio1;

// Clase Character
public class Character
{
    public string Name { get; set; } // Nombre del personaje
    public int MaxHitPoints { get; set; } // Puntos de vida máximos
    public int CurrentHitPoints { get; private set; } // Puntos de vida actuales, solo se puede modificar dentro de la clase
    public int BaseDamage { get; set; } // Daño base del personaje
    public int BaseArmor { get; set; } // Armadura base del personaje

    // Inventario del personaje y minion
    private List<IItem> _inventory = new List<IItem>(); // Lista de ítems en inventario
    private Minion _minion; // Minion invocado por el personaje

    // Constructor para inicializar el personaje con nombre, vida máxima, daño y armadura
    public Character(string name, int maxHitPoints, int baseDamage, int baseArmor)
    {
        Name = name; // Nombre del héroe
        MaxHitPoints = maxHitPoints; // Puntos de vida máximos
        CurrentHitPoints = maxHitPoints; // Establecemos que la salud inicial es igual a la máxima
        BaseDamage = baseDamage; // Daño base del héroe
        BaseArmor = baseArmor; // Armadura base del héroe
    }

    // Método para recibir daño el héroe
    public void ReceiveDamageToHero(int amount)
    {
        CurrentHitPoints -= amount; // Resta el daño a los puntos de vida actuales

        if (CurrentHitPoints <= 0)
        {
            Console.WriteLine($"{Name} ha muerto.");
            CurrentHitPoints = 0; // Asegura que no se tengan puntos de vida negativos
        }
        else
        {
            Console.WriteLine($"{Name} ha recibido {amount} puntos de daño. Puntos de vida restantes: {CurrentHitPoints}.");
        }
    }

    // Método para que el héroe ataque, devolviendo su daño base
    public int Attack()
    {
        return BaseDamage;
    }

    // Método para curar al héroe
    public void Heal(int amount)
    {
        CurrentHitPoints += amount;

        // Aseguramos que las curas no puedan excceder la vida máxima
        if (CurrentHitPoints > MaxHitPoints)
        {
            CurrentHitPoints = MaxHitPoints;
        }

        Console.WriteLine($"{Name} se ha curado {amount} puntos de vida. Puntos de vida actuales: {CurrentHitPoints}.");
    }

    // Método para agregar ítems al inventario del héroe
    public void AddItemToInventory(IItem item)
    {
        _inventory.Add(item);
        Console.WriteLine($"{item} ha sido agregado al inventario.");
    }

    // Método para usar ítems del inventario
    public void UseItem(IItem item)
    {
        if (_inventory.Contains(item))
        {
            item.Apply(this); // Aplica el efecto del ítem al héroe
            Console.WriteLine($"{item} ha sido utilizado.");
        }
        else
        {
            Console.WriteLine($"{item} no está en el inventario.");
        }
    }

    // Método para invocar un minion
    public void SummonMinion(string name, int health, int damage)
    {
        if (_minion == null) // Se permite solo invocar un minion a la vez
        {
            _minion = new Minion(name, health, damage); // Crea un nuevo minion
            Console.WriteLine("Has invocado a un minion!");
        }
        else
        {
            Console.WriteLine("Ya tienes un minion invocado.");
        }
    }

    // Método para atacar con el minion
    public void AttackWithMinion()
    {
        if (_minion != null)
        {
            while (_minion.IsAlive()) // Mientras el minion esté vivo
            {
                int damageDealt = _minion.Attack();
                Console.WriteLine($"{_minion.Name} inflige {damageDealt} de daño!");
                
                // Simulación de daño recibido por el minion
                int damageReceived = 50; 
                _minion.ReceiveDamage(damageReceived);
                Console.WriteLine($"{_minion.Name} recibe {damageReceived} de daño."); 
                
                // Si el minion muere, se elimina
                if (!_minion.IsAlive())
                {
                    Console.WriteLine($"{_minion.Name} ha muerto."); 
                    _minion = null; // Eliminar el minion
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("No tienes un minion invocado.");
        }
    }

    // Método para que el minion reciba daño
    public void ReceiveDamageToMinion(int amount)
    {
        if (_minion != null && _minion.IsAlive())
        {
            _minion.ReceiveDamage(amount); // Aplica el daño al minion
        }
        else
        {
            Console.WriteLine("No hay minion para recibir daño.");
        }
    }
}