using Xunit;

/* Una prueba unitaria es es un tipo de prueba de software que se utiliza para verificar que una unidad individual
 de código, generalmente una función o un método, funciona correctamente de manera aislada.

Patrón AAA (Arrange, Act, Assert), el cual se usa comúnmente para escribir pruebas unitarias.
AAA: Arrange, Act, Assert

Arrange (Preparar): En esta fase, se preparan todos los objetos, datos y configuraciones 
necesarias para realizar la prueba.

Act (Actuar): En este paso, se ejecuta la acción o método que se quiere probar. Es la parte donde invocamos la 
funcionalidad específica que queremos verificar.

Assert (Afirmar): Aquí es donde se verifica el resultado de la acción. Se compara el resultado real con el resultado 
esperado usando afirmaciones (asserts). Si el resultado no es el esperado, la prueba falla.*/

//Lo de arriba es para utilizarlo yo como apuntes cuando vuelva a este código

namespace Ejercicio1
{
    public class PruebaMinion
    {
        [Fact]
        public void TestMinionSummonAndActions()
        {
            // Arrange: Crear un personaje y un ítem de invocación
            Character hero = new Character("Raúl", 100, 50, 30);
            IItem invocationItem = new ItemInvo("Invocación", "Minion", 100, 25); // Invocará un minion con 100 de salud y 25 de daño

            // ACT 1: El personaje usa el ítem para invocar al minion
            hero.UseItem(invocationItem);

            // ASSERT 1: Verificar que el minion fue invocado correctamente
            Assert.NotNull(hero); // Verificamos que el héroe existe
            Assert.Equal("Raúl", hero.Name); // Verificamos el nombre del héroe
            Assert.NotNull(invocationItem); // Verificamos que el ítem de invocación no es nulo

            // ACT 2: Hacer que el minion ataque
            hero.AttackWithMinion();

            // ACT 3: El minion recibe daño
            hero.ReceiveDamageToMinion(60);

            // ASSERT 2: Verificar que el minion sigue vivo (ya que tenía 100 de salud)
            Assert.True(hero != null, "El minion sigue vivo tras recibir 60 de daño."); // Verificamos que el minion está vivo

            // ACT 4: El minion recibe más daño (más de su salud restante)
            hero.ReceiveDamageToMinion(50); // Esto debe hacer que el minion muera

            // ASSERT 3: Verificar que el minion ha muerto
            Assert.Null(hero); // Verificamos que el minion está muerto (eliminado)
        }
    }
}