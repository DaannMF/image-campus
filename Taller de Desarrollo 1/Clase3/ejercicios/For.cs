namespace Ejercicios
{
    class For
    {
        public void Ejercicio1()
        {
            Int16 input, sum = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Ingrese un numero");
                Int16.TryParse(Console.ReadLine(), out input);
                if (input < 0)
                {
                    sum += input;
                }
            }

            Console.WriteLine($"El resultado es {sum}");
        }

        public void Ejercicio2()
        {
            Int16 input, min = Int16.MaxValue;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Ingrese un numero");
                Int16.TryParse(Console.ReadLine(), out input);
                if (input < min)
                {
                    min = input;
                }
            }

            Console.WriteLine($"El menor es el numero {min}");
        }

        public void Ejercicio3()
        {
            Int32 input, res;

            Console.WriteLine($"Ingrese un numero");
            Int32.TryParse(Console.ReadLine(), out input);
            res = input;
            for (int i = input - 1; i > 0; i--)
            {
                res *= i;
            }

            if (input == 0) res = 1;

            Console.WriteLine($"El factorial es {res}");
        }
    }
}