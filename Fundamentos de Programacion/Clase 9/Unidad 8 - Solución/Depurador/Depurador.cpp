// Depurador.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
//

#include <iostream>

using namespace std;

enum SIM_OPTIONS {
    EAT,
    DRINK,
    SLEEP,
    WORK,
    LAST
};

//Ejercicio1
void Ejercicio1();
void mistery_function(int& a);

//Ejercicio2
void Ejercicio2();
void print_options();
SIM_OPTIONS get_input();

//Ejercicio3
void Ejercicio3();
void attack_player(float& health, float damage);
bool is_alive(float health);

//Ejercicio4
void Ejercicio4();
int clamp(int value, int min, int max);

int main()
{
    //Ejercicio1();
    //Ejercicio2();
    //Ejercicio3();
    Ejercicio4();
}

void Ejercicio1()
{
    /*
        Observando el código se detecta que nunca va a entrar en los bloques
        else
        {
            b *= 3;
            if (b == a)
            {
                a /= 3;
            }
        }

        y 

        if (a > 52)
        {
            a /= 2;
        }

        Debido a que cuando el valor es distinto de cero el condicional if (b && a) siempre será verdadero.
        A demás cuando el magic number es disinto de cero siempre devolverá +- 17.
        Cuando és cero el condicional if (a > 52) nunca será verdadero.
    */
    int magic_number;
    magic_number = 7;
    mistery_function(magic_number);
    cout << magic_number << endl;

    magic_number = 0;
    mistery_function(magic_number);
    cout << magic_number << endl;

    magic_number = -7;
    mistery_function(magic_number);
    cout << magic_number << endl;
}

void Ejercicio2()
{
    /*
        La primera observación es que los valores del enumerador están
        desfasados con las opciones que se muestran, por lo que dos posibles 
        soluciones son: 
        Acomodar el enum
        enum SIM_OPTIONS {
            EAT = 1,
            DRINK = 2,
            SLEEP = 3,
            WORK = 4,
            LAST = 5
        };
        ó 
        Refactorizar la función get_input para restarle uno al input para que retorne
        el valor correcto y además validar que los valores ingresados sean entre 1 y 4. (Elegí esta opción para este caso)
        Por úlitmo se puede eliminar el case LAST y dejár sólo el default ya que sabemos que get_input nos va a devolver valores
        entre 1 y 4.
    */
    print_options();
    SIM_OPTIONS option = get_input();
    switch (option)
    {
    case EAT:
        cout << "Voy comer algo..." << endl;
        break;
    case DRINK:
        cout << "Voy beber algo..." << endl;
    case SLEEP:
        cout << "Voy dormir un poco..." << endl;
    case WORK:
        cout << "Voy a trabajar un poco..." << endl;
    default:
        cout << "Algo voy a hacer..." << endl;
        break;
    }
}

void Ejercicio3()
{
    /*
        La primera observación es que en la función attack_player el parámetro health
        debe ser pasado por referencia.
        Segundo, no se inicializó la semilla del rand, además no debería arrojar cero como
        posibilidad por lo que hay que modificar la forma en que se genera.
        Como extra se podría agregar que muestre la vida restante contemplando que no muestre menos de cero.
    */
    float player_health = 100.0f;
    srand(time(0));

    while (is_alive(player_health)) {
        attack_player(player_health, (rand() % 10) + 1);
        cout << "Player attacked, current life : " << max(0.f, player_health)<< endl;
    }
}

void Ejercicio4()
{
    /*
        Tuve que buscar que hacia una función clamp ajaja
        Lo que entiendo es que se asegura de que un valor esté dentro de un rango dado.
        Refactorizé la función para que contemple tambien rangos negativos por ejemplo (-1, -4, 10) 
        y que valide que el min sea menor que el max.
    */
    float number;

    number = 17;
    number = clamp(number, 20, 50);
    cout << number << endl;

    number = 25;
    number = clamp(number, 20, 50);
    cout << number << endl;

    number = 40;
    number = clamp(number, 20, 30);
    cout << number << endl;
    
    number = -1;
    number = clamp(number, -4, 10);
    cout << number << endl;

    number = -5;
    number = clamp(number, -4, 10);
    cout << number << endl;

    number = -4;
    number = clamp(number, -10, -3);
    cout << number << endl;

    number = -2;
    number = clamp(number, -10, -3);
    cout << number << endl;

    number = -2;
    number = clamp(number, 10, 2);
    cout << number << endl;
}

//Ejercicio 1
void mistery_function(int& a) {
    int b = a * 5;
    if (b != 0)
    {
        if (b && a)
        {
            b *= 2;
            a = 3;
        }
        else
        {
            b *= 3;
            if (b == a)
            {
                a /= 3;
            }
        }
        if (a == 3)
        {
            a = 10;
            a += 7;
        }
    }
    else
    {
        a *= 6;
        if (a > 52)
        {
            a /= 2;
        }
    }
}

//Ejercicio 2
void print_options() {
    cout << "Elija una opcion:" << endl;
    cout << "1 - Comer" << endl;
    cout << "2 - Beber" << endl;
    cout << "3 - Dormir" << endl;
    cout << "4 - Trabajar" << endl;
}

SIM_OPTIONS get_input() {
    int input;
    bool valid;
    do
    {
      cin >> input;
      valid = input >= 1 && input <= 4;
      if (!valid) {
        cout << "Elija una opcion válida" << endl;
      }
    } while (!valid);
    input--;
    return (SIM_OPTIONS)input;
}

//Ejercicio 3
void attack_player(float& health, float damage) {
    health -= damage;
}

bool is_alive(float health) {
    return health >= 0;
}

//Ejercicio 4
int clamp(int value, int min_value, int max_value) {
    if (min_value > max_value) {
        cout << "Los rangos máximos y mínimos son incorrectos." << endl;
        return 0;
    }
    
    return min(max(value, min_value), max_value);
}