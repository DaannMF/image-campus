using System;
using System.Timers;

namespace Ejercicios;

public class AdivinaNumero
{

    const Int16 MAX_TRIES = 10;
    const String SI = "si";
    const String NO = "no";


    public void Ejercicio()
    {
        Int16 input, tries = 0;
        Int32 secret = 0;
        String? inputContinues;
        Boolean continues = true, guessed;
        Random r = new Random();

        while (continues)
        {
            Console.WriteLine("Inicio del juego, tienes 10 intentos, mucha suerte");
            secret = r.Next(1, 101);
            input = 0;
            inputContinues = "";
            guessed = false;

            for (int i = 0; i < MAX_TRIES; i++)
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
                    guessed = true;
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

                Console.WriteLine($"Te quedan {MAX_TRIES - tries} intentos");
                input = 0;
            }

            if (guessed)
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

        Console.WriteLine("Gracias por jugar a Adivina el número");
    }
}

