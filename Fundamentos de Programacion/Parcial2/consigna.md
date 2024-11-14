# Ledian y el Corazón de Cristal

Ledian se aventura en una selva tropical del Amazonas para conseguir el sagrado Corazón
de Cristal. Este artefacto permite encantar a cualquier criatura o persona que habite en el
mundo. Pero a pesar de su gran poder, su defecto es la fragilidad que tiene, ya que ante
cualquier cambio brusco en el terreno, el corazón se partirá y su poder desaparecerá para
siempre.

##  Ejemplo Selva Amazónica (10 X 10)

P X T T T T T T T T
X X X X X S S O O T
T T O S X X S T S T
T S S S S X O X X T
T X X X X X S S X T
T X S T S X T S X T
T X X X X O S S X T
T X S S X X X X X X
T X T O X S S S S X
T E T T T T T T O H

## Referencias

* P: Player (Jugador)
* X: Dirt (Tierra)
* S: Sand (Arena)
* T: Tree (Árbol)
* H: Crystal Heart (Corazón de Cristal)
* E: Exit (Salida)
* O: Hole (Agujero)

##  Consideraciones

* Crear una estructura Vector2 para manejar los movimientos de nuestro juego.
* Usar un enumerador para manejar las entidades del mapa.
* No hace falta probar inicialmente con el mapa dado de ejemplo, pueden probar con
uno de menor dimensión y todos las entidades.
Mecánicas:
* El jugador (Player) se mueve con las teclas WASD y sin salirnos del mapa.
* El jugador puede caminar sobre la arena y la tierra.
* El jugador no puede caminar sobre los árboles.
* Si el jugador cae en un agujero, se termina el juego. Se le pide al usuario si desea
reiniciar el juego.
* Si el jugador tiene el corazón de cristal, no puede caminar sobre la arena.
* El juego se gana si el jugador agarra el corazón y sale por la salida.
* Mostrar en pantalla la cantidad de turnos/pasos del jugador.
* Si se gana el juego, mostrar por pantalla: “Ledian consiguió el corazón de
cristal en X pasos!”. Reemplazar la “X” con la cantidad de turnos/pasos. Luego se
le pide al usuario si desea reiniciar el juego.

NOTA:
Utilizar la libreria #include <conio.h> para chequear input del teclado utilizando las funciones
_kbhit() y_getch()
