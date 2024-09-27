// Funciones.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
//

#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

enum Enemy {
    Teemo,
    Chogath,
    Riven
};

const int GAREN_LIFE = 100;
const int TEEMO_DAMAGE = 3;
const int CHOGAT_DAMAGE = 5;
const int RIVEN_DAMAGE = 7;

static int crear_arena(int ancho, int largo);
static int relacion_fuerza(int fuerza_humana, int fuerza_orca);
static int punto_medio(int a, int b);
static int enviar_cazadores(int cazadores, int minimo_cazadores, int maximo_cazadores);
static void promedio_danio();
static void calcular_vida();

int main()
{
    cout << "El area calculada es de " << crear_arena(25, 30) << endl;
    cout << "El area calculada es de " << crear_arena(37, 55) << endl;

    relacion_fuerza(15, 10);
    relacion_fuerza(5, 30);
    relacion_fuerza(17, 17);

    cout << "Punto medio " << punto_medio(-10, 20) << endl;
    cout << "Punto medio " << punto_medio(33, 40) << endl;

    cout << "Cazadores enviados :" << enviar_cazadores(20, 5, 10) << endl;
    cout << "Cazadores enviados :" << enviar_cazadores(1, 2, 17) << endl;
    cout << "Cazadores enviados :" << enviar_cazadores(7, 1, 10) << endl;

    promedio_danio();

    calcular_vida();
}

int crear_arena(int ancho, int largo)
{
    return ancho * largo;
}

int relacion_fuerza(int fuerza_humana, int fuerza_orca)
{
    if (fuerza_humana > fuerza_orca)
    {
        cout << "La fuerza humana es mayor" << endl;
        return 1;
    }
    else if (fuerza_orca > fuerza_humana)
    {
        cout << "La fuerza orca es mayor" << endl;
        return -1;
    }
    else
    {
        cout << "La fuerzas son iguales" << endl;
        return 0;
    }
}

int punto_medio(int a, int b)
{
    return a + ((b - a) / 2);
}

int enviar_cazadores(int cazadores, int minimo_cazadores, int maximo_cazadores)
{
    if (cazadores < minimo_cazadores)
    {
        return minimo_cazadores;
    }
    else if (cazadores > maximo_cazadores)
    {
        return maximo_cazadores;
    }
    else
    {
        return cazadores;
    }
}

void promedio_danio()
{
    int input = 0, sum = 0, prom = 0, count = 0;

    do
    {
        count++;
        cout << "Ingrese el daño" << endl;
        cin >> input;

        sum += input;
    } while (input >= 0);

    prom = sum / count;
    cout << "El promedio para " << count << " golpes es : " << prom << endl;
}

void calcular_vida()
{
    int damage = 0, life = GAREN_LIFE;
    srand(time(0));

    cout << "Vida Garen : " << life << endl;

    while (life > 0)
    {
        switch (rand() % 3)
        {
        case Enemy::Teemo:
            cout << "Golpe de Teemo: " << TEEMO_DAMAGE << endl;
            damage = TEEMO_DAMAGE;
            break;
        case Enemy::Chogath:
            cout << "Golpe de Cho'gath: " << CHOGAT_DAMAGE << endl;
            damage = CHOGAT_DAMAGE;
            break;
        case Enemy::Riven:
            cout << "Golpe de Riven: " << RIVEN_DAMAGE << endl;
            damage = RIVEN_DAMAGE;
            break;
        default:
            damage = 0;
            break;
        }

        life -= damage;
        cout << "Vida Garen después de golpe: " << max(life, 0) << endl;
    }
}
