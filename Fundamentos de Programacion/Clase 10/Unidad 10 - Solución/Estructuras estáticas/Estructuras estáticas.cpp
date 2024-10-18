// Estructuras estáticas.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
//

#include <iostream>

using namespace std;

// Ejercicio 1
struct RoomThing
{
    char name[50];
    char type[20];
    float weight;
    int amount;
};

// Ejercicio 2
enum Material
{
    Wood,
    Iron,
    Gold,
    Diamond,
    Emerald
};

enum ItemType
{
    Normal,
    Special,
    Epic,
    Legendary
};

struct Sword
{
    char name[50];
    float large;
    Material materia;
    float damage;
    float wight;
    bool doubleHanded;
    ItemType type;
};

// Ejercicio 4
enum Race
{
    Human,
    Elf,
    Dwarf,
    Orc,
    Goblin
};

enum Class
{
    Warrior,
    Mage,
    Archer,
    Thief,
    Healer
};

// Estructura para modelar la posición en el mapa en 2D
struct Position
{
    int x;
    int y;
};

struct Character
{
    char name[50];
    enum Race race;
    enum Class classType;
    int healthPoints;
    int strength;
    int level;
    float experience;
    struct Position position;
};

struct Enemy
{
    int healthPoints;
    int armor;
    int givenExpPoints;
};

void Ejercicio3();
void Ejercicio5(Character hero);

int main()
{
    // Ejercicio 1
    struct RoomThing bed = {"Bed", "Furniture", 60.0f, 1};
    struct RoomThing book = {"Book", "Lecture", 0.5f, 15};
    struct RoomThing notebook = {"Notebook", "Electronics", 2.5f, 1};
    struct RoomThing lamp = {"Lamp", "Luminary", 1.5f, 2};
    struct RoomThing chart = {"Chart", "Decoration", 0.5f, 3};

    // Ejercicio 2
    struct Sword sword1 = {"Wooden Blade", 1.2, Wood, 10.0, 2.5, false, Normal};
    struct Sword sword2 = {"Iron Broadsword", 1.5, Iron, 25.0, 5.0, true, Special};
    struct Sword sword3 = {"Golden Rapier", 1.1, Gold, 20.0, 3.0, false, Epic};
    struct Sword sword4 = {"Diamond Great Sword", 1.8, Diamond, 40.0, 4.5, true, Legendary};
    struct Sword sword5 = {"Emerald Cutlass", 1.3, Emerald, 35.0, 3.5, false, Special};
    struct Sword sword6 = {"Iron Long Sword", 1.4, Iron, 28.0, 5.5, true, Epic};
    struct Sword sword7 = {"Diamond Excalibur", 1.6, Diamond, 50.0, 6.0, true, Legendary};

    Ejercicio3();

    // Ejercicio 4
    struct Character hero = {"Arthas", Human, Warrior, 100, 20, 5, 0, {10, 20}};

    Ejercicio5(hero);
}

void Ejercicio3()
{
    int total = 0, count = 0, damage;
    int damages[10];
    srand(time(0));
    for (int i : damages)
    {
        damage = (rand() % 100) + 1;
        total += damage;
        if (damage > 25)
        {
            count++;
        }
    }

    cout << "El daño total es de : " << total << " puntos" << endl;
    cout << "EL promedio de daño es de :" << total / 10 << " puntos" << endl;
    cout << "El porcentaje de daño mayor a 25 es de :" << count * 10 << " %" << endl;
}

void Ejercicio5(Character hero)
{
    int exp = 0, count = 0, damage = 0, totalDamage = 0;
    srand(time(0));
    Enemy enemies[5];
    for (int i = 0; i < 5; i++)
    {
        exp = (rand() % 51) + 50;
        enemies[i] = Enemy{100, 5+i, exp};
    }

    // Combat
    for (Enemy enemy : enemies)
    {
        while (enemy.healthPoints > 0)
        {
            count++;
            damage = hero.strength - enemy.armor;
            totalDamage += damage;
            enemy.healthPoints -= damage;
        }

        hero.experience += enemy.givenExpPoints;
    }

    std::cout << "Nuestro héroe : " << hero.name << " derrotó a todos los enemigos." << endl;
    std::cout << "Cantidad total de daño hecho : " << totalDamage << endl;
    std::cout << "Cantidad total de golpes : " << count << endl;
    std::cout << "Total de experiencia ganada : " << hero.experience << endl;
}
