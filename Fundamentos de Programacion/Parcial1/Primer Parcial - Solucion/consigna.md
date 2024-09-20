# Un enano en Tlönbir

Es el año 157 en el poblado de Tlönbir y un pequeño enano llamado Gorgomir resalta por
su fuerza e inteligencia sobre los demás. Su sueño es ser el mejor minador y herrero de
toda la tierra media. Pero para ello, va a tener que usar su audacia y perspicacia para
desenvolverse en este vasto mundo lleno de peligros y desafíos.
Crear un juego con las siguientes reglas:

- El juego debe durar hasta que Gorgomir ya no tenga más vida o si cumplió su
sueño ganando más de 100 monedas de oro.

- Gorgomir empieza con 10 puntos de vida (que también es el máximo de vida que
puede tener), 5 monedas de oro y 0 puntos de experiencia en minado.

- En cada iteración se le pregunta al usuario que acción debe realizar Gorgomir en
ese turno, siendo las acciones:
  - “1 - Explorar zona”
  - “2 - Recoger bayas
  - “3 - Minar”
  - “4 - Forjar armadura”
  - “5 - Reparar inventario”
  - “6 - Comprar pico nuevo”

- Dependiendo de la acción a realizar pueden suceder una o más cosas:
    1. Explorar zona:
        - Hay una chance del 10% de conseguir oro entre 5 a 20 unidades,
        pero se resta 1 punto de vida por la picadura de una araña.

    2. Recoger bayas:
        - Hay una chance del 30% de conseguir bayas que restauran 3
        puntos de vida.

    3. Minar:
        - Solamente puede minar si su vida es mayor a 4 y si el pico no está roto.
        El pico está roto cuando tiene durabilidad 0.
        - Cuando realiza la acción de minar, golpea las piedras unas 4 veces y en
        cada una de esas veces puede pasar lo siguiente:
            - La chance de minar exitosamente 1 unidad de hierro corresponde a
            la tabla de picos dada más abajo.
            Nota: Si no mina exitosamente luego de los 4 golpes, gana 1
            punto de experiencia de minado. Por lo tanto, la próxima vez que
            mine se aumentan las chances antes mencionadas por la cantidad
            de puntos de experiencia que tenga.
            Cada vez que el pico golpea las piedras pierde 0.5 puntos de
            durabilidad. Una vez que termina de minar, pierde 1 punto de vida.

    4. Forjar armadura:
        - Solamente puede forjar una armadura si tiene 2 o más unidades de hierro.
        - Cada armadura cuesta 2 unidades de hierro, la cual se vende por 30
        unidades de oro. Una vez forjada imprimir: “Se forjó exitosamente la
        armadura y se vendió por 30 de oro.”

    5. Reparar inventario:
        - Reparar el pico cuesta 1 de oro por cada punto de durabilidad a
        arreglar y solamente se puede reparar los días/turnos impares.

    6. Comprar pico nuevo:
        - Existen 3 tipos de pico: madera, hierro y diamante. La siguiente tabla muestra su información:

        |Tipo       |Durabilidad    |Precio |Chance Minar % |
        |---------- |---------------|-------|---------------|
        |Madera     |10             |5      |30             |
        |Hierro     |15             |10     |50             |
        |Diamante   |30             |20     |60             |

        - Cada vez que se compre un pico, el nuevo va a ser el siguiente al actual. Por
        ende, si tiene el de madera, el próximo va a ser el de hierro.
        Hay que checkear si tiene las monedas suficientes para poder pagar el nuevo
        pico.
        Si ya se tiene el pico de Diamante, no se debería poder comprar más picos.

- Al finalizar cada turno existe un 5% de probabilidades de que Gorgomir gane 10 de
oro por invertir sus monedas de oro en NFTs.
Nota: Si no se cumple alguna probabilidad de las antes mencionadas, imprimir “No
pasó nada en este hermoso día”.

- En cada iteración se deberá mostrar la información de Gorgomir: su vida, la cantidad de
oro, la cantidad de hierro que tiene, la durabilidad de su pico, la cantidad de
armaduras forjadas/vendidas y el turno actual.
Una vez finalizado el juego se deberá imprimir si Gorgomir se quedó sin vida o si cumplió
su sueño más preciado y la cantidad de turnos que tomó toda la aventura.

A TENER EN CUENTA: Hacer uso de enumeradores y constantes
