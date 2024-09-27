# Unidad 7

##  Ejercicio 1

¡Una horda de orcos viene a atacar Lordaeron! Por suerte, los humanos tienen tiempo para
crear una arena y retenerlos hasta la llegada del mago Medivh.
Crear una función llamada crear_arena(ancho, largo) que devuelva el área de la arena a
partir de un ancho y un largo.
Calcular una arena de 25 de ancho y 30 de largo.
Calcular una arena de 37 de ancho y 55 de largo.

##  Ejercicio 2

Los orcos pudieron pasar la primera defensa de los humanos! Ahora hay que ver la relación
entre las fuerzas humanas y las orcas para aplicar la correcta estrategia. Crear una función
relacion_fuerza(fuerza_humana, fuerza_horca) que cumpla:
● Si la fuerza_humana es mayor que la orca, debe devolver 1
● Si la fuerza_horca es mayor que la humana, debe devolver -1
● Si ambas son iguales debe devolver 0
Probar la función con los valores:
15 y 10
5 y 30
17 y 17

##  Ejercicio 3

Las fuerzas de asedio humanas tienen problemas para calcular el punto medio entre dos
valores para lanzar sus proyectiles. Crear una función punto_intermedio(a, b) que
devuelva el punto intermedio entre esos 2 valores.
Probar con los valores:
-10 y 20
33 y 40

##  Ejercicio 4

Los elfos de la noche mandan a sus cazadores que con sigilo emboscan a los orcos. Pero
para que esto funcione, la cantidad de cazadores debe tener un mínimo y un máximo que la
suma sacerdote Tyrande decidirá en el momento.
Crear una función enviar_cazadores(cazadores, mínimo_cazadores,
máximo_cazadores) que cumpla:
● Devolver mínimo_cazadores si cazadores es menor que éste
● Devolver máximo_cazadores si cazadores es mayor que éste.
● Devolver cazadores si no se supera ningún límite.
Probar la función con:
enviar_cazadores(20,5,10)
enviar_cazadores(1,2,17)
enviar_cazadores(7,1,10)

##  Ejercicio 5

Crear un programa que imprima por pantalla el promedio de daño que hace un enemigo y
cuantos golpes dió.
El ingreso de cada golpe debe hacerse hasta que se recibe un daño NEGATIVO.

##  Ejercicio 6

Necesitamos calcular la vida final de nuestro personaje en TOP. Somos un Garen y
peleamos contra un Teemo, un Chogat y una Riven. Tenemos que crear un procedimiento
que nos imprima por pantalla cuanto daño nos hizo el enemigo y quien fue.
Los daños de los enemigos son:
Teemo -> 3
Cho'gath -> 5
Riven -> 7
Hasta que nuestro personaje esté vivo, voy a recibir un daño aleatorio de alguno de estos
enemigos. La vida de Garen es de 100.
Mostrar en pantalla quien me golpeó y cuanta vida tengo al momento.
Ejemplo:
<< “Vida Garen: 100”
<< “Golpe Riven: 7”
<< “Vida Garen después de golpe: 93”
<< “Vida Garen: 93”
<< “Golpe Teemo: 3”
<< “Vida Garen después de golpe: 90”
