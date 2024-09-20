namespace Clase7.ejercicios
{
    public class Arrays
    {
        const Int16 PERSON_AMOUNT = 5;
        const Int16 UNDER_AGE = 18;
        public static void Ejercicio1()
        {
            Int16 age;
            String?[] names = new String[PERSON_AMOUNT];
            Int16[] ages = new Int16[PERSON_AMOUNT];

            for (Int16 i = 0; i < PERSON_AMOUNT; i++)
            {
                Console.WriteLine($"Ingresar nombre número {i + 1}");
                String? name = Console.ReadLine();
                names[i] = name;

                Console.WriteLine($"Ingrese edad número {i + 1}");
                Int16.TryParse(Console.ReadLine(), out age);
                ages[i] = age;
            }

            for (Int16 i = 0; i < PERSON_AMOUNT; i++)
            {
                if (ages[i] > UNDER_AGE)
                {
                    Console.WriteLine($"{names[i]} : {ages[i]}");
                }
            }
        }

        const Int16 NUMBER_AMOUNT = 4;
        public static void Ejercicio2()
        {
            Int16 input, sum = 0;
            float avg = 0;
            Int16[] numbers = new Int16[NUMBER_AMOUNT];

            for (Int16 i = 0; i < NUMBER_AMOUNT; i++)
            {
                Console.WriteLine($"Ingresar nombre número {i + 1}");
                Int16.TryParse(Console.ReadLine(), out input);
                numbers[i] = input;
            }

            foreach (Int16 item in numbers)
            {
                sum += item;
            }

            avg = sum / NUMBER_AMOUNT;
            Console.WriteLine($"El promedio es : {avg}");
        }

        public static Int16 AddNumbers(Int16[] numbers)
        {
            Int16 sum = 0;
            foreach (Int16 item in numbers)
            {
                sum += item;
            }

            return sum;
        }
    }
}