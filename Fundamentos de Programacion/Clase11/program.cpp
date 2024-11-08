#include <iostream>
#include <string>
#include <cmath>
#include <vector>

using namespace std;

// Ejercicio 1
class Cama
{
public:
    string tamano;
    string material;

    Cama(string t, string m) : tamano(t), material(m) {}
};

class Mesa
{
public:
    string forma;
    int numPatas;

    Mesa(string f, int n) : forma(f), numPatas(n) {}
};

class Lampara
{
public:
    string tipo;
    int potencia;

    Lampara(string t, int p) : tipo(t), potencia(p) {}
};

// Ejercicio 2
class Pokemon
{
public:
    string nombre;
    string tipo;
    int nivel;
    int puntosVida;

    Pokemon(string n, string t, int nv, int pv) : nombre(n), tipo(t), nivel(nv), puntosVida(pv) {}
};

// Ejercicio 3
class Personaje
{
public:
    struct Posicion
    {
        int x;
        int y;
    };

    string nombre;
    Posicion posicion;

    Personaje(string n, int x, int y) : nombre(n), posicion()
    {
        posicion.x = x;
        posicion.y = y;
    }

    void mover(int nuevoX, int nuevoY)
    {
        posicion.x = nuevoX;
        posicion.y = nuevoY;
        cout << nombre << " se ha movido a la posición (" << posicion.x << ", " << posicion.y << ")." << endl;
    }

    void mostrarPosicion()
    {
        cout << nombre << " está en la posición (" << posicion.x << ", " << posicion.y << ")." << endl;
    }
};

// Ejercicio 4
class Country {
public:
    struct Posicion {
        int x;
        int y;
    };

    string nombre;
    Posicion posicion;

    Country(string n, int x, int y) : nombre(n) {
        posicion.x = x;
        posicion.y = y;
    }
};

class Airplane {
public:
    string nombre;
    double gasolina;
    string tipo;
    int cantidadPasajeros;
    int cantidadViajes = 0;
    int cantidadPasajerosTotal = 0;

    Airplane(string n, double g, string t, int cp) : nombre(n), gasolina(g), tipo(t), cantidadPasajeros(cp) {}

    double calcularDistancia(Country::Posicion a, Country::Posicion b) {
        return sqrt(pow(b.x - a.x, 2) + pow(b.y - a.y, 2));
    }

    bool fly(Country &source, Country &target) {
        if (source.nombre == target.nombre) {
            cout << "El origen y el destino no pueden ser el mismo." << endl;
            return false;
        }

        double distancia = calcularDistancia(source.posicion, target.posicion);
        double gasolinaNecesaria = 1.5 * distancia;
        int pasajeros = rand() % cantidadPasajeros + 1;

        if (gasolina >= gasolinaNecesaria) {
            gasolina -= gasolinaNecesaria;
            cantidadViajes++;
            cantidadPasajerosTotal += pasajeros;
            cout << nombre << " voló de " << source.nombre << " a " << target.nombre << ". Gasolina restante: " << gasolina;
            cout << ". Pasajeros: " << pasajeros << ". Distancia: " << distancia << " km." << endl;
            return true;
        } else {
            cout << nombre << " no tiene suficiente gasolina para volar de " << source.nombre << " a " << target.nombre << "." << endl;
            return false;
        }
    }

    void mostrarInfo() {
        cout << "Nombre: " << nombre << endl;
        cout << "Gasolina: " << gasolina << endl;
        cout << "Tipo: " << tipo << endl;
        cout << "Cantidad de pasajeros: " << cantidadPasajeros << endl;
        cout << "Cantidad de viajes: " << cantidadViajes << endl;
    }
};

void ejercicio4();

int main()
{
    Cama miCama("Queen", "Madera");
    Mesa miMesa("Redonda", 4);
    Lampara miLampara("LED", 60);

    Pokemon bulbasaur("Bulbasaur", "Planta", 5, 100);
    Pokemon charmander("Charmander", "Fuego", 5, 100);
    Pokemon squirtle("Squirtle", "Agua", 5, 100);

    Personaje heroe("Heroe", 0, 0);
    heroe.mostrarPosicion();
    heroe.mover(10, 20);
    heroe.mostrarPosicion();
    
    ejercicio4();

    return 0;
}

void ejercicio4()
{
    Country paises[] = {
        Country("Argentina", 0, 0),
        Country("Brasil", 10, 10),
        Country("Chile", 20, 5),
        Country("Uruguay", 15, 15),
        Country("Paraguay", 5, 20)
    };

    Airplane aviones[] = {
        Airplane("Avion1", 100, "Comercial", 150),
        Airplane("Avion2", 120, "Carga", 50),
        Airplane("Avion3", 80, "Privado", 10),
        Airplane("Avion4", 90, "Militar", 200),
        Airplane("Avion5", 110, "Comercial", 180)
    };

    int cantAviones = sizeof(aviones) / sizeof(aviones[0]);
    int cantPaises = sizeof(paises) / sizeof(paises[0]);

    while (true) {
        bool todosSinGasolina = true;
        for (int i = 0; i < cantAviones; i++)
        {
            if (aviones[i].gasolina > 0) {
                int origen = rand() % cantPaises;
                int destino;
                do {
                    destino = rand() % cantPaises;
                } while (origen == destino);

                if (aviones[i].fly(paises[origen], paises[destino])){
                    todosSinGasolina = false;
                }
            }
        }
        if (todosSinGasolina) break;
    }

    for (int i = 0; i < cantAviones; i++)
    {
        aviones[i].mostrarInfo();
    }
}