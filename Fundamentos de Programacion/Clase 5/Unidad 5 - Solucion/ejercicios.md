# Unidad 5

## Ejercicio 1

Definir 10 constantes que pueda llegar a tener un videojuego. Si pensaron en un
videojuego en particular, indicarlo con un comentario.

## Ejercicio 2

Crear un enumerador para las distintas luces de un semáforo y el tiempo que dura cada
una. Pedir al usuario que ingrese un número del 1 al 3 para mostrar la duración de la luz
correspondiente.
Ejemplo:
<< “¿Qué duración de luz desea conocer?”
<< “1 - Verde”
<< “2 - Amarilla”
<< “3 - Roja”
>> 3
<< “La duración de la luz roja es de 30 segundos”

## Ejercicio 3

Crear un enumerador con todos los dispositivos periféricos que tenga su computadora.
Ejemplo:
enum Dispositivos { TECLADO, CAMARA, … }

## Ejercicio 4

Crear un enumerador “Operations” que contenga las operaciones: suma, resta,
multiplicación y división.
Pedir al usuario que ingrese 2 valores y luego elija qué operación aplicarle a esos valores.
Ejemplo:
>> 5
>> 12
<< ¿Qué operación desea realizar?”
<< “1 - Suma”
<< “2 - Resta”
<< “3 - Multiplicación”
<< ”4 - Division”
>> 1
<< “El resultado de la suma de 5 y 12 es 17”

## Ejercicio 5

Crear un convertidor de kilómetros a millas o millas a kilómetros.
Se le pide al usuario que elija entre 3 opciones: “Kilómetros a millas”, “Millas a kilómetros” y
“Salir”.
Una vez que elije una opción de convertir, se le pide ingresar un número correspondiente
con la medida elegida y se debería imprimir la conversión.
Este programa se repite hasta que el usuario elige la opción “Salir”.
Ejemplo:
<< “¿Qué desea hacer?”
<< “1 - Kilómetros a millas”
<< “2 - Millas a kilómetros”
<< “3 - Salir”
>> 1
<< “Ingrese cantidad de kilómetros”
>> 5
<< “La cantidad de millas correspondientes a 5 kilómetros son: 3.10686 millas“

## Ejercicio 6

Crear un programa que le indique al usuario cuántos enemigos van a aparecer en
determinada oleada y con determinada dificultad.
Crear un enumerador “Difficulty” que tenga 3 constantes: easy, medium y hard.
Cada una de esas constantes va a tener un valor arbitrario elegido por el programador y
que sea coherente.
Además la cantidad de enemigos se ve afectada por una constante de incremento que es
igual a 3.67.
El usuario ingresa el valor de la oleada y la dificultad y el programa debe devolver la
cantidad de enemigos.
La ecuación para la cantidad de enemigos es la siguiente:
numero_oleada * dificultad * constante
Ejemplo:
Teniendo en cuenta que EASY = 5, MEDIUM = 15, HARD = 30
<< “Ingrese número de oleada:”
>> 3
<< “Ingrese dificultad:”
<< “1 - Fasil”
<< “2 - Medio”
<< “3 - Difícil”
>> 2
<< “La cantidad de enemigos para la oleada 3 y dificultad Medio es: 165“
