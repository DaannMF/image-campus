namespace Ejercicios
{
    class Tarea
    {
        public void Tarea_Bucles()
        {
            Int16 input, sum = 0, count = 0;
            Int16 max = Int16.MinValue, min = Int16.MaxValue;

            Console.WriteLine($"Ingrese 10 numeros");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i + 1} Ingrese el numero :");
                Int16.TryParse(Console.ReadLine(), out input);

                sum += input;

                if (input % 2 == 0) count++;

                if (input > max) max = input;

                if (input < min) min = input;
            }

            Console.WriteLine($"a) Cantidad de numeros pares ingresados : {count}");
            Console.WriteLine($"b) Sumatoria de los numeros ingresados : {sum}");
            Console.WriteLine($"b) Promedio de los numeros ingresados : {sum / 10}");
            Console.WriteLine($"d) Promedio de los numeros ingresados : [ Max:{max}, Min:{min} ]");
        }
    }
}