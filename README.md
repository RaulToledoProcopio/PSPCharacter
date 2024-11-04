# Clases del Juego

## Character

La clase `Character` representa a un héroe en el juego. Se encarga de gestionar la vida, el daño, la armadura y las interacciones con ítems y minions.

### Propiedades
- **Name**: `string` - El nombre del héroe.
- **MaxHitPoints**: `int` - Los puntos de vida máximos del héroe.
- **CurrentHitPoints**: `int` - Los puntos de vida actuales del héroe.
- **BaseDamage**: `int` - El daño base del héroe.
- **BaseArmor**: `int` - La armadura base del héroe.
- **temporalShield**: `int` - El escudo temporal para el overhealing.

### Métodos
- **ReceiveDamageToHero(int amount)**: Aplica daño al héroe, teniendo en cuenta el escudo temporal.
- **Attack()**: Devuelve el daño base del héroe.
- **Heal(int amount)**: Cura al héroe, aplicando overhealing si es necesario.
- **AddItemToInventory(IItem item)**: Agrega un ítem al inventario del héroe.
- **UseItem(IItem item)**: Aplica el efecto del ítem al héroe.
- **SummonMinion(string name, int health, int damage)**: Invoca un minion.
- **AttackWithMinion()**: Hace que el minion ataque si está invocado.
- **ReceiveDamageToMinion(int amount)**: Aplica daño al minion.

---

## IItem

La interfaz `IItem` define un contrato para los ítems que pueden ser utilizados por el héroe.

### Métodos
- **Apply(Character character)**: Aplica el efecto del ítem al héroe.

---

## Axe

La clase `Axe` representa un ítem de tipo hacha que puede ser utilizado por el héroe.

### Herencia
- Implementa `IItem`.

### Métodos
- **Apply(Character character)**: Aplica el efecto del hacha al héroe.

---

## Sword

La clase `Sword` representa un ítem de tipo espada que puede ser utilizado por el héroe.

### Herencia
- Implementa `IItem`.

### Métodos
- **Apply(Character character)**: Aplica el efecto de la espada al héroe.

---

## Shield

La clase `Shield` representa un ítem de tipo escudo que puede ser utilizado por el héroe.

### Herencia
- Implementa `IItem`.

### Métodos
- **Apply(Character character)**: Aplica el efecto del escudo al héroe.

---

## Helmet

La clase `Helmet` representa un ítem de tipo casco que puede ser utilizado por el héroe.

### Herencia
- Implementa `IItem`.

### Métodos
- **Apply(Character character)**: Aplica el efecto del casco al héroe.

---

## ItemInvo

La clase `ItemInvo` representa un ítem de invocación que permite al héroe invocar un minion.

### Herencia
- Implementa `IItem`.

### Propiedades
- **Name**: `string` - Nombre del ítem.
- **Type**: `string` - Tipo de invocación.
- **Health**: `int` - Puntos de vida del minion.
- **Damage**: `int` - Daño del minion.

### Métodos
- **Apply(Character character)**: Aplica el efecto de invocación al héroe.

---

## Minion

La clase `Minion` representa un minion que puede ser invocado por el héroe.

### Propiedades
- **Name**: `string` - Nombre del minion.
- **Health**: `int` - Puntos de vida del minion.
- **Damage**: `int` - Daño que inflige el minion.

### Métodos
- **IsAlive()**: Devuelve `true` si el minion está vivo, `false` de lo contrario.
- **Attack()**: Devuelve el daño que inflige el minion.
- **ReceiveDamage(int amount)**: Aplica daño al minion.

---

Changelog 

07/10/2024:

- Cambio en el método de heal, ya que si el pj tenía 100 de vida y se curaba 50 se ponía con 150 de vida, ahora respeta 100 como vida máxima, aunque le entren curas.
- Añadida una clase para usar un item que pueda sumonear un minion, el minion ataca hasta que muere.
- Añadido el draw.io aún por finalizar.
- Añadida prueba unitaria para el item que sumonea el minion. (No funciona)

04/11/2024:

- Agregado escudo temporal para el overhealing

Por hacer:

- Markdown
- Crear una clase target para saber si el objetivo está vivo.
- Prueba unitaria

![imagen](https://github.com/user-attachments/assets/584dbe29-b191-496d-88ce-344fc65a1dd8)
