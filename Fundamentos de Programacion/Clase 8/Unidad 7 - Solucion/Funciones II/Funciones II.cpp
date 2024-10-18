// Funciones II.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
//

#include <iostream>

using namespace std;

struct Position {
    float x, y, z;
};

enum Armor {
    Iron,
    Gold,
    Diamon,
};

enum HealthPotion {
    SmallPotion = 5,
    NormalPotion = 10,
    GrandPotion = 15,
};

/*
Anapneo	Hechizo para despejar la garganta de una víctima que está ahogándose.
Episkey	Hechizo para tratar heridas leves que incluyen labios rotos y narices fracturadas.[1]
Ferula	Ata y entablilla fracturas.
Reparifors	Cura dolencias menores generadas por magia como la parálisis.
Tergeo	Hechizo para limpiar sangre seca de una herida sangrante, similar al Fregotego.
Vulnera Sanentur Hechizo usado para curar cortes profundos como los ocasionados por la maldición Sectumsempra.[2]
*/

enum Speels {
    Anapneo = 5,
    Episkey = 10,
    Ferula = 15,
    Reparifors = 20,
    Tergeo = 25,
    Vulnera = 30,
};

void enviar_cazadores(int& cazadores, int minimo_cazadores, int maximo_cazadores);
void change(int& num1, int& num2);
void update_position(Position& player_position, Position new_position);
void take_damage(float& life, float& damage);
void change_armor(Armor& player_armor, Armor& new_armor);
void move(Position& player_position, float deltaX, float deltaY);
void move(Position& player_position, float deltaX, float deltaY, float deltaZ);
void move(Position& player_position, Position objective);
void heal_player(float& life, float amount);
void heal_player(float& life, HealthPotion potion);
void heal_player(float& life, Speels spell);

int main()
{
    int cazadores;
    int num1 = 5, num2 = 10;

    cazadores = 20;
    enviar_cazadores(cazadores, 5, 10);
    cout << "Cazadores enviados :" << cazadores << endl;

    cazadores = 1;
    enviar_cazadores(cazadores, 2, 17);
    cout << "Cazadores enviados :" << cazadores << endl;
    
    cazadores = 7;
    enviar_cazadores(cazadores, 1, 10);
    cout << "Cazadores enviados :" << cazadores << endl;
    
    cout << "Antes num1: " << num1 << " num2: " << num2 << endl;
    change(num1, num2);
    cout << "Despues num1: " << num1 << " num2: " << num2 << endl;
}

void enviar_cazadores(int& cazadores, int minimo_cazadores, int maximo_cazadores)
{
    if (cazadores < minimo_cazadores)
    {
        cazadores = minimo_cazadores;
    }
    else if (cazadores > maximo_cazadores)
    {
        cazadores = maximo_cazadores;
    }
}

void change(int& num1, int& num2)
{
    int aux;
    aux = num1;
    num1 = num2;
    num2 = aux;
}

// Escribir 3 casos en que sea necesario utilizar una variable de referencia dentro de un juego.

// Ejemplo 1: Una funcion que actualice la posicion del jugador y reciba su posicion actual como referencia
void update_position(Position& player_position, Position new_position) {
    player_position.x = new_position.x;
    player_position.y = new_position.y;
    player_position.z = new_position.z;
}

// Ejemplo 2: Una funcion que actualice para recibir danio a un jugador y reciba su vida como referencia
void take_damage(float& life, float& damage) {
    life -= damage;
}

// Ejemplo 3: Una funcion que cambie la armadura de un personaje y reciba la actual como referencia
void change_armor(Armor& player_armor, Armor& new_armor) {
    player_armor = new_armor;
}


// Dar ejemplos de sobrecarga de funciones dentro de un juego

// Ejemplo1 para hacer moever un personaje, se peude mover en 2D 3D o hacia una posicion objetivo.
// Mover en coordenadas 2D
void move(Position& player_position, float deltaX, float deltaY) {
    player_position.x += deltaX;
    player_position.y += deltaY;
}

// Mover en coordenadas 3D
void move(Position& player_position, float deltaX, float deltaY, float deltaZ) {
    player_position.x += deltaX;
    player_position.x += deltaY;
    player_position.x += deltaZ;
}

// Mover hacia un objetivo
void move(Position& player_position, Position objective) {
    player_position.x = objective.x;
    player_position.y = objective.y;
    player_position.z = objective.z;
}

// Sobrecargar la función heal_player() con los parámetros que ustedes crean convenientes.
// Se debe sobrecargar más de una vez.

//1. Curar al jugador por una cantidad fija
void heal_player(float& life, float amount) {
    life = +amount;
}

//2. Curar al jugador utilizando un item
void heal_player(float& life, HealthPotion potion) {
    life = +potion;
}

//3. Curar al jugador utilizando un hechizo
void heal_player(float& life, Speels spell) {
    life = +spell;
}