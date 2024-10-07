namespace Ejercicio1;

// Clase Character
public class Character
{
    public string Name { get; set; }
    public int MaxHitPoints { get; set; }
    public int CurrentHitPoints { get; private set; } // Puntos de vida actuales
    public int BaseDamage { get; set; }
    public int BaseArmor { get; set; }

    private List<IItem> _inventory = new List<IItem>(); // Lista de ítems en el inventario
    private Minion _minion;

    public Character(string name, int maxHitPoints, int baseDamage, int baseArmor)
    {
        Name = name;
        MaxHitPoints = maxHitPoints; // Asigna el valor máximo
        CurrentHitPoints = maxHitPoints; // Inicializa los puntos de vida actuales en el máximo
        BaseDamage = baseDamage;
        BaseArmor = baseArmor;
    }

    // Método para recibir daño al héroe
    public void ReceiveDamageToHero(int amount)
    {
        CurrentHitPoints -= amount; // Resta el daño a los puntos de vida actuales del héroe

        if (CurrentHitPoints <= 0)
        {
            Console.WriteLine($"{Name} ha muerto.");
            CurrentHitPoints = 0; // Asegurar de que no tenga puntos de vida negativos
        }
        else
        {
            Console.WriteLine($"{Name} ha recibido {amount} puntos de daño. Puntos de vida restantes: {CurrentHitPoints}.");
        }
    }

    // Método para atacar al enemigo
    public int Attack()
    {
        return BaseDamage;
    }

    // Método para curar
    public void Heal(int amount)
    {
        CurrentHitPoints += amount;

        // Asegurar de que no exceda el límite máximo
        if (CurrentHitPoints > MaxHitPoints)
        {
            CurrentHitPoints = MaxHitPoints;
        }

        Console.WriteLine($"{Name} se ha curado {amount} puntos de vida. Puntos de vida actuales: {CurrentHitPoints}.");
    }

    // Método para agregar un ítem al inventario
    public void AddItemToInventory(IItem item)
    {
        _inventory.Add(item);
        Console.WriteLine($"{item} ha sido agregado al inventario.");
    }

    // Método para usar un ítem del inventario
    public void UseItem(IItem item)
    {
        if (_inventory.Contains(item))
        {
            item.Apply(this);
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
        if (_minion == null) // Para que solo se pueda invocar un minion
        {
            _minion = new Minion(name, health, damage);
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
            while (_minion.IsAlive())
            {
                int damageDealt = _minion.Attack();
                Console.WriteLine($"{_minion.Name} inflige {damageDealt} de daño!");
                
                // Daño que recibe el minion
                int damageReceived = 50; 
                _minion.ReceiveDamage(damageReceived);
                Console.WriteLine($"{_minion.Name} recibe {damageReceived} de daño."); 
                
                if (!_minion.IsAlive())
                {
                    Console.WriteLine($"{_minion.Name} ha muerto."); 
                    _minion = null; // Eliminar el minion cuando muere
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("No tienes un minion invocado.");
        }
    }

    // Método para recibir daño al minion
    public void ReceiveDamageToMinion(int amount)
    {
        if (_minion != null && _minion.IsAlive())
        {
            _minion.ReceiveDamage(amount);
            if (!_minion.IsAlive()) // Verificar si el minion ha muerto
            {
                Console.WriteLine($"{_minion.Name} ha muerto por daño recibido.");
                _minion = null; // Eliminar el minion si ha muerto
            }
        }
        else
        {
            Console.WriteLine("No hay minion para recibir daño.");
        }
    }
}