// Estructuras-de-Control.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
//

#include <iostream>

using namespace std;

int main()
{
    Ejercicio1();
    Ejercicio2();
}

void Ejercicio1()
{
    int input;
    cout << "Ingrese un número" << endl;
    cin >> input;
    if (input > 17)
    {
        cout << "Es un buen número" << endl;
    }
    else
    {
        cout << "No es un número correcto" << endl;
    }
}

void Ejercicio2()
{
    float danio;

    cout << "Ingrese el daño de la flecha" << endl;
    cin >> danio;

    if (danio == 0)
    {
        cout << "El duende no nos hizo daño!" << endl;
    }
    else if (danio > 30.f)
    {
        cout << "Daño crítico! Daño realizado: " << danio << endl;
    }
    else
    {
        cout << "Daño normal. Daño realizado: " << danio << endl;
    }
}

void Ejercicio3()
{
    float notaParcial1, notaParcial2, promedio;

    cout << "Ingrese la nota del primer parcial" << endl;
    cin >> notaParcial1;

    cout << "Ingrese la nota del segundo parcial" << endl;
    cin >> notaParcial2;

    promedio = (notaParcial1 + notaParcial2) / 2;

    if (promedio >= 8)
    {
        cout << "El estudiante promocionó" << endl;
    }
    else if (promedio >= 4)
    {
        cout << "El estudiante debe el final." << endl;
    }
    else
    {
        cout << "El estudiante reprobó la materia." << endl;
    }

    cout << "El promedio de las notas es : " << promedio << endl;
}

void Ejercicio4()
{
    int action;

    cout << "Ingrese la acción a realizar" << endl;
    cout << "1. Atacar" << endl;
    cout << "2. Defender" << endl;
    cout << "3. Descansar" << endl;

    cin >> action;

    switch (action)
    {
    case 1:
        cout << "Se realizó la acción: Atacar" << endl;
        break;
    case 2:
        cout << "Se realizó la acción: Defender" << endl;
        break;
    case 3:
        cout << "Se realizó la acción: Descansar" << endl;
        break;
    default:
        cout << "Lo siento" << action << "no es una acción válida" << endl;
        break;
    }
}

void Ejercicio5()
{
    /*
    Acá tenia dudas si había que pedir por input que el usuario ingrese
    los 6 valores que obtiene de las tiradas, así que implementé el uso
    de un RAND.
    */
    int trie, minValue = INT8_MAX;

    for (int i = 0; i < 6; i++)
    {
        trie = (rand() % 6) + 1;
        if (trie < minValue)
        {
            minValue = trie;
        }
    }

    cout << "El dado con menor valor fue el número : " << minValue << endl;
}

void Ejercicio6()
{
    /*
    Tenía dudas de donde o como agregar la validaciones
    para ingresar sólo números positivos.
    Lo que definí es que sólo si es positivo va a contabilizar y sumar para el promedio.

    PD : Póngame un 10 :)
    */

    int input, count, sum, prom;

    cout << "Ingrese números positivos para calcular el promedio" << endl;

    do
    {
        cout << "Ingrese el número Nº" << count + 1 << endl;
        cin >> input;

        if (input > 0)
        {
            sum += input;
            count++;
        }
    } while (input != 0);

    prom = sum / count;

    cout << "El promedio es de: " << prom << endl;
    cout << "Se ingresaron: " << count << " números" << endl;
}

void Ejercicio7()
{
    int input;

    cout << "Ingrese un número" << endl;
    cin >> input;

    for (int i = 1; i <= 20; i++)
    {
        cout << input << "x" << i << " = " << input * i;
    }
}

void Ejercicio7()
{
    cout << "Números pares" << endl;

    for (int i = 2; i <= 100; i + 2)
    {
        cout << i << endl;
    }
}