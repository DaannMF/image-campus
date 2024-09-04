using System;
using System.Timers;

namespace Ejercicios;

public class AdivinaNumero
{

    const Int16 CNATIDAD_INTENTOS = 10;
    const string SI = "si";
    const string NO = "no";


    public void Ejercicio()
    {
        Int16 input, tries = 0;
        Int32 secret = 0;
        String? inputContinues;
        Boolean continues = true, adivinaNumero;
        Random r = new Random();

        while (continues)
        {
            Console.WriteLine("Inicio del juego, tienes 10 intentos, mucha suerte");
            secret = r.Next(1, 100);
            input = 0;
            inputContinues = "";
            adivinaNumero = false;

            for (int i = 0; i < CNATIDAD_INTENTOS; i++)
            {
                while (input == 0)
                {
                    Console.WriteLine("Ingrese un número del 1 al 100");
                    Int16.TryParse(Console.ReadLine(), out input);
                    if (input == 0) Console.WriteLine("Ingrese un número válido");
                }

                tries++;

                if (input == secret)
                {
                    adivinaNumero = true;
                    break;
                }
                else if (input > secret)
                {
                    Console.WriteLine("Ups no adivinaste, el número secreto es MENOR");
                }
                else
                {
                    Console.WriteLine("Ups no adivinaste, el número secreto es MAYOR");
                }

                Console.WriteLine($"Te quedan {CNATIDAD_INTENTOS - tries} intentos");
                input = 0;
            }

            if (adivinaNumero)
            {
                Console.WriteLine("Felicidades advinaste el número :)");
                Console.WriteLine($"Cantidad de intentos {tries}");

            }
            else
            {
                Console.WriteLine($"Perdiste :( el número secreto era : {secret}");
            }

            while (String.IsNullOrEmpty(inputContinues))
            {
                Console.WriteLine("Desea volver a jugar? Si/No");
                inputContinues = Console.ReadLine();
                if (inputContinues == null ||
                    (!inputContinues.Equals(SI, StringComparison.CurrentCultureIgnoreCase) && !inputContinues.Equals(NO, StringComparison.CurrentCultureIgnoreCase)))
                {
                    Console.WriteLine("Lo siento, no te he entendido");
                    inputContinues = "";
                }
            }

            if (inputContinues.Equals(NO, StringComparison.CurrentCultureIgnoreCase))
            {
                continues = false;
            }
        }

        Console.WriteLine("Gracias por jugar, Adivina el número");
    }
}

