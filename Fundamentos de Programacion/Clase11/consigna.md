#  Unidad 11

Realizar los siguientes ejercicios en una solución que se llame “Unidad 11 -
Solución” y el proyecto se llame “Clases y Objetos”

##  Ejercicio 1

Modelar en forma de clases 3 objetos que tengan en su cuarto.
Instanciar un objeto de cada una de esas clases.

##  Ejercicio 2

Crear una clase Pokemon con los atributos y métodos que crean correspondientes.
Instanciar los 3 primeros pokemones “principales” de la primera generación.
Intentar implementar que los pokemones se puedan atacar entre si.

##  Ejercicio 3

Crear una clase Personaje que contenga una estructura Posición. Mediante un método, ir
moviendo el personaje a la posición que nosotros queramos.

##  Ejercicio 4

Estamos haciendo un juego de aviones y nos piden crear 5 aviones de una clase Airplane.
Esa clase Ariplane va a tener las siguientes características:

- Nombre avion
- Gasolina
- Tipo
- Cantidad pasajeros
- Cantidad viajes

Después tenemos una clase País que va a ser un origen para el avión y también un destino.
Country:

- Posición (x,y)
- Nombre

Crear la cantidad de países que ustedes crean convenientes y almacenarlos en un array.
El avión va a tener un método fly(Country source, Country target) que recibe un país origen
y un país destino. La gasolina que va a gastar el avión es igual a 1.5 * la distancia entre un
país y otro.
Hasta que todos los aviones se queden sin gasolina, cada uno va a viajar desde un país
origen hacia un país destino, siendo origen y destino países distintos.
La cantidad de pasajeros que van a llevar depende del tipo de avión, ahí va a depender de
ustedes los tipos de avión que crean y la cantidad de pasajeros que puede llevar cada tipo
de avión. Esta cantidad va a ser un número aleatorio entre 1 y la cantidad de pasajeros que
pueden llevar según el tipo.
Imprimir al finalizar las estadísticas de cada uno de los aviones.
