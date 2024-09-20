#include <iostream>

using namespace std;

// Ejercicio 1
const int MAX_HEALTH = 100;               // Salud máxima del jugador
const int MAX_ENERGY = 50;                // Energía máxima del jugador
const int MAX_LEVEL = 10;                 // Nivel máximo alcanzable
const int MAX_INVENTORY_ITEMS = 20;       // Máxima cantidad de ítems en el inventario
const float MAX_INVENTORY_WEIGHT = 15.6f; // Máxima cantidad de ítems en el inventario
const int STARTING_LIVES = 3;             // Vidas con las que empieza el jugador
const int ATTACK_DAMAGE = 10;             // Daño base por ataque
const string VICTORY_MESSAGE = "YOU WIN"; // Puntos de defensa del jugador
const int MAX_ENEMY_HEALTH = 80;          // Salud máxima de un enemigo
const bool IS_ENEMY = 1;                  // Si la entidad es un enemigo

// Ejercicio 2
const float RED_TIME = 15.5f;
const float YELLOW_TIME = 1.f;
const float GREEN_TIME = 60.5f;

enum Semaphore
{
    GREEN = 1,
    YELLOW = 2,
    RED = 3
};

void Ejercicio2()
{
    int input;
    cout << "¿Qué duración de luz desea conocer?" << endl;
    cout << "1 - Verde" << endl;
    cout << "2 - Amarillo" << endl;
    cout << "3 - Rojo" << endl;

    cin >> input;
    switch (input)
    {
    case Semaphore::RED:
        cout << "La duración de la luz roja es " << RED_TIME << endl;
        break;
    case Semaphore::YELLOW:
        cout << "La duración de la luz amarilla es " << YELLOW_TIME << endl;
        break;
    case Semaphore::GREEN:
        cout << "La duración de la luz verde es " << GREEN_TIME << endl;
        break;
    default:
        cout << "Lo siento la opción que elegiste no es válida" << endl;
        break;
    }
}

// Ejercicio 3

enum Devices
{
    KEYBOARD,
    MOUSE,
    MONITOR,
    SPEAKERS,
    HEADSET,
    CPU,
    WEB_CAM
};

enum Operation
{
    SUM = 1,
    REST = 2,
    MULTIPLY = 3,
    DIVIDE = 4,
};

void Ejercicio4()
{
    int num1, num2, operation;

    cout << "Ingrese el primer número" << endl;
    cin >> num1;

    cout << "Ingrese el segundo número" << endl;
    cin >> num2;

    cout << "Bien, ahora ingrese la operación que desea realizar" << endl;
    cout << "1 - Suma" << endl;
    cout << "2 - Resta" << endl;
    cout << "3 - Multiplicación" << endl;
    cout << "4 - División" << endl;
    cin >> operation;

    switch (operation)
    {
    case Operation::SUM:
        cout << "El resultado de la suma es " << num1 + num2 << endl;
        break;
    case Operation::REST:
        cout << "El resultado de la resta es " << num1 - num2 << endl;
        break;
    case Operation::MULTIPLY:
        cout << "El resultado de la multiplicación es " << num1 * num2 << endl;
        break;
    case Operation::DIVIDE:
        cout << "El resultado de la división es " << num1 / num2 << endl;
        break;
    default:
        cout << "Lo siento la opción que elegiste no es válida" << endl;
        break;
    }
}

const float MILES_TO_KILOMETERS = 1.60934;
const float KILOMETER_TO_MILES = 0.621371;
const int EXIT_OPTION = 3;
enum ConversionType
{
    KILOMETERS = 1,
    MILES = 2,
};

void Ejercicio5()
{
    int num1, input;

    while (true)
    {
        cout << "¿Qué desea hacer?" << endl;
        cout << "1 - Kilómetros a millas" << endl;
        cout << "2 - Millas a kilómetros" << endl;
        cout << "3 - Salir" << endl;
        cin >> input;

        if (input == EXIT_OPTION)
        {
            break;
        }

        switch (input)
        {
        case ConversionType::KILOMETERS:
            cout << "Bien, ingrese cantidad de kilómetros" << endl;
            cin >> num1;
            cout << "La cantidad de millas correspondiente a " << num1 << "kilómetros es :" << num1 * MILES_TO_KILOMETERS << endl;
            break;
        case ConversionType::MILES:
            cout << "Bien, ingrese cantidad de millas" << endl;
            cin >> num1;
            cout << "La cantidad de kilómetros correspondiente a " << num1 << "millas es :" << num1 * KILOMETER_TO_MILES << endl;
            break;
        default:
            cout << "Lo siento la opción que elegiste no es válida" << endl;
            break;
        }

        cin.clear();
    }
}

enum Difficulty
{
    EASY = 1,
    MEDIUM = 2,
    HARD = 3
};

const float DIFFICULTY_CONSTANT = 3.67f;
const float EASY_DIFFICULTY_VALUE = 3;
const float MEDIUM_DIFFICULTY_VALUE = 10;
const float HARD_DIFFICULTY_VALUE = 25;

void Ejercicio6()
{
    int wave, difficulty, enemies = 0;

    cout << "Ingrese el número de oleada" << endl;
    cin >> wave;

    cout << "Ingrese la dificultad" << endl;
    cout << "1 - Fácil" << endl;
    cout << "2 - Medio" << endl;
    cout << "3 - Difícil" << endl;
    cin >> difficulty;

    switch (difficulty)
    {
    case Difficulty::EASY:
        enemies = wave * EASY_DIFFICULTY_VALUE * DIFFICULTY_CONSTANT;
        cout << "La cantidad de enemigos para la oleada " << wave << " y dificultad fácil es: " << enemies << endl;
        break;
    case Difficulty::MEDIUM:
        enemies = wave * MEDIUM_DIFFICULTY_VALUE * DIFFICULTY_CONSTANT;
        cout << "La cantidad de enemigos para la oleada " << wave << " y dificultad media es: " << enemies << endl;
        break;
    case Difficulty::HARD:
        enemies = wave * HARD_DIFFICULTY_VALUE * DIFFICULTY_CONSTANT;
        cout << "La cantidad de enemigos para la oleada " << wave << " y dificultad difícil es: " << enemies << endl;
        break;
    default:
        cout << "Lo siento la opción que elegiste no es válida" << endl;
        break;
    }
}

int main()
{
    Ejercicio2();
    Ejercicio4();
    Ejercicio5();
    Ejercicio6();
}
