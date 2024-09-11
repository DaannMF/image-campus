namespace Clase5.Ejercicios
{
    class Functions
    {
        static void Ejercicio1()
        {
            Int16 input;
            Console.WriteLine("Ingrese un número");
            Int16.TryParse(Console.ReadLine(), out input);
            IsPositive(input);
        }


        static void Ejercicio2()
        {
            Int16 n1, n2;
            Console.WriteLine("Ingrese el primer número");
            Int16.TryParse(Console.ReadLine(), out n1);

            Console.WriteLine("Ingrese el primer número");
            Int16.TryParse(Console.ReadLine(), out n2);
            Multiply(n1, n2);
        }

        static void Ejercicio3()
        {
            Int16 input;
            Console.WriteLine("Ingrese un número");
            Int16.TryParse(Console.ReadLine(), out input);
            IsGraterLessOrEqualTwenty(input);
        }

        static void Ejercicio4()
        {
            Int16 input;
            Console.WriteLine("Ingrese un número");
            Int16.TryParse(Console.ReadLine(), out input);
            if (IsDivisibleByFive(input))
            {
                Console.WriteLine("Es divisible");
            }
            else
            {
                Console.WriteLine("No es divisible");
            }
        }

        static void IsPositive(Int16 n)
        {
            if (n > 0)
            {
                Console.WriteLine("Es positivo");
            }
            else
            {
                Console.WriteLine("Es negativo");
            }
        }

        static void Multiply(Int16 n1, Int16 n2)
        {
            Console.WriteLine($"El resultado de la multiplicación es {n1 * n2}");
        }

        static void IsGraterLessOrEqualTwenty(Int16 n)
        {
            if (n == 20)
            {
                Console.WriteLine("El número es 20");
            }
            else if (n < 20)
            {
                Console.WriteLine("El número es menor 20");
            }
            else
            {
                Console.WriteLine("El número es mayor 20");
            }
        }

        static bool IsDivisibleByFive(Int16 n)
        {
            return n % 5 == 0;
        }
    }
}