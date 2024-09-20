// Aleatoriedad.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
//

#include <iostream>
#include <cstdlib> 
#include <ctime>

using namespace std;

// Ejercicio1
enum MarioParty {
    Dice, // Cada turno se lanzan los dados de manera aleatoria.
    MiniGame,  // Al final de cada ronda se juega un minujuego al azar.
};

enum Pokemon {
    Critical_Chance, // Durante los combates, los ataques tienen una pequeña probabilidad de hacer un "golpe crítico"
    Encounters,  //En la mayoría de los juegos de Pokémon, caminar por la hierba alta puede desencadenar encuentros con Pokémon de manera completamente aleatoria.
};

enum DaibloII {
    Loot, //Los enemigos derrotados sueltan objetos como armas, armaduras y pociones de forma completamente aleatoria
    Procedural_Levels //Al entrar en una nueva área o mazmorra, el mapa se genera aleatoriamente
};

// Ejercicio2
static void Ejercicio2() {
    int number;

    srand(time(0));
    number = rand() % 101;

    cout << "Número aleatorio entre 0 y 100: " << number << endl;
};

// Ejercicio3
enum Dices_Options {
    FACES6 = 1,
    FACES10 = 2,
    FACES12 = 3,
    FACES20 = 4
};

enum Dices_Values {
    FACESVALUE6 = 6,
    FACESVALUE10 = 10,
    FACESVALUE12 = 12,
    FACESVALUE20 = 20
};

static void Ejercicio3() {
    int input, value;
    Dices_Values faces;

    cout << "¿Eliga el dado que desea tirar?" << endl;
    cout << "1 - 6 Caras" << endl;
    cout << "2 - 10 Caras" << endl;
    cout << "3 - 12 Caras" << endl;
    cout << "4 - 20 Caras" << endl;

    cin >> input;

    switch (input)
    {
    case Dices_Options::FACES6:
        faces = Dices_Values::FACESVALUE6;
        break;
    case Dices_Options::FACES10:
        faces = Dices_Values::FACESVALUE10;
        break;
    case Dices_Options::FACES12:
        faces = Dices_Values::FACESVALUE12;
        break; 
    case Dices_Options::FACES20:
        faces = Dices_Values::FACESVALUE20;
        break; 
    default:
        cout << "Lo siento la opción que elegiste no es válida" << endl;
        return;
    }

    srand(time(0));
    value = rand() % faces + 1;
    cout << "El resultado para el dado de " << faces << " caras es : " << value << endl;
};

// Ejercicio4
const int RACES_AMOUNT = 4;
const int CLASSES_AMOUNT = 3;
enum Races {
    Human, 
    Orc, 
    Elf, 
    Dwar
};

enum Classes {
    Warrior, 
    Archer, 
    Wizard
};

static void Ejercicio4() {
    int input;
    string race, classe;

    cout << "Ingrese la cantidad de personajes a generar" << endl;
    cin >> input;
    
    srand(time(0));

    for (int i = 0; i < input; i++)
    {
        switch (rand() % RACES_AMOUNT)
        {
        case Races::Human:
            race = "Humano";
            break;
        case Races::Orc:
            race = "Orco";
            break;
        case Races::Elf:
            race = "Elfo";
            break;
        case Races::Dwar:
            race = "Enano";
            break;
        }

        switch (rand() % CLASSES_AMOUNT)
        {
        case Classes::Warrior:
            classe = "Guerrero";
            break;
        case Classes::Archer:
            classe = "Arquero";
            break;
        case Classes::Wizard:
            classe = "Hechizero";
            break;
        }

        cout << "El personaje " << i << " es un " << race << " " << classe << endl;
    }
};

static void Ejercicio5() {
    int input, number, tries = 0;
    bool guessed = false;
    
    cout << "Estoy pensando en un número aleatorio entre el 1 y el 100, Cuál es?" << endl;
    srand(time(0));
    number = (rand() % 100) + 1;
    while (!guessed)
    {
        tries++;
        cout << "Ingresa un número" << endl;
        cin >> input;

        if (input == number)
        {
            guessed = true;
            break;
        }
        else if (input > number)
        {
            cout << "El número es más bajo" << endl;
        }
        else 
        {
            cout << "El número es más alto" << endl;
        }
    }

    cout << "Ganaste! Tu cantidad de intentos fueron : " << tries << endl;
}

enum Choices {
    ROCK = 1,
    PAPER = 2,
    SCISSORS = 3,
};

const int ROUNDS = 3;
static void Ejercicio6() {
    int input, playerScore = 0,computerScore = 0;

    cout << "Esto es Piedra, Papel o tijeras! Al mejor de " << ROUNDS << endl;
    for (int i = 0; i < ROUNDS; i++)
    {
        cout << "Ronda " << i + 1 << endl;
        cout << "Elige una opcion" << endl;
        cout << "1 - Piedra" << endl;
        cout << "2 - Papel" << endl;
        cout << "3 - Tijeras" << endl;
        cin >> input;

        
    }
}

int main()
{
    Ejercicio5();
}
