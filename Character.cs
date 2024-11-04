namespace Ejercicio1;

using System.Timers; // Importa el espacio de nombres para usar temporizadores

// Clase Character
public class Character
{
    public string Name { get; set; } // Nombre del personaje
    public int MaxHitPoints { get; set; } // Puntos de vida máximos
    public int CurrentHitPoints { get; private set; } // Puntos de vida actuales, solo se puede modificar dentro de la clase
    public int BaseDamage { get; set; } // Daño base del personaje
    public int BaseArmor { get; set; } // Armadura base del personaje
    public int temporalShield { get; private set; } = 0; // Escudo temporal para el overhealing

    private Timer _shieldTimer;

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
        if (temporalShield > 0)
        {
            if (amount <= temporalShield)
            {
                temporalShield -= amount;
                Console.WriteLine(
                    $"{Name} absorbió {amount} de daño con su escudo temporal. Escudo restante: {temporalShield}.");
                return;
            }
            else
            {
                amount -= temporalShield;
                Console.WriteLine($"{Name} absorbió {temporalShield} de daño con su escudo temporal.");
                temporalShield = 0;
            }
        }

        CurrentHitPoints -= amount;

        if (CurrentHitPoints <= 0)
        {
            Console.WriteLine($"{Name} ha muerto.");
            CurrentHitPoints = 0;
        }
        else
        {
            Console.WriteLine(
                $"{Name} ha recibido {amount} puntos de daño. Puntos de vida restantes: {CurrentHitPoints}.");
        }
    }

    // Inicia un temporizador de 15 segundos para el escudo temporal
    private void StartShieldTimer()
    {
        if (_shieldTimer != null)
        {
            _shieldTimer.Stop();
            _shieldTimer.Dispose();
        }

        _shieldTimer = new Timer(15000); // 15000 milisegundos = 15 segundos
        _shieldTimer.Elapsed += OnShieldTimerElapsed;
        _shieldTimer.AutoReset = false; // Solo se ejecuta una vez
        _shieldTimer.Start();
    }

    // Método que se ejecuta cuando el temporizador del escudo temporal finaliza
    private void OnShieldTimerElapsed(object sender, ElapsedEventArgs e)
    {
        temporalShield = 0;
        _shieldTimer.Dispose();
        Console.WriteLine($"{Name}'s escudo temporal ha expirado.");
    }

// Método para que el héroe ataque, devolviendo su daño base
    public int Attack()
    {
        return BaseDamage;
    }

// Método para curar al héroe
    public void Heal(int amount)
    {
        int healthToMax = MaxHitPoints - CurrentHitPoints;

        if (amount <= healthToMax)
        {
            CurrentHitPoints += amount;
        }
        else
        {
            CurrentHitPoints = MaxHitPoints;
            temporalShield += amount - healthToMax;
            StartShieldTimer(); // Inicia el temporizador cuando se añade el escudo
        }

        Console.WriteLine(
            $"{Name} se ha curado {amount} puntos de vida. Puntos de vida actuales: {CurrentHitPoints}, Escudo temporal: {temporalShield}.");
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