namespace Ejercicios
{
    class DoWhiles
    {
        public void Ejercicio1()
        {
            Int16 input, count = 0, sum = 0;
            do
            {
                Int16.TryParse(Console.ReadLine(), out input);
                sum += input;
                count++;

            } while (count < 10);

            Console.WriteLine($"El promedio es {sum / 10}");
        }

        public void Ejercicio2()
        {
            Int16 input = 0;
            do
            {
                Int16.TryParse(Console.ReadLine(), out input);
                Console.WriteLine($"El numero ingresado es {input}");

            } while (input != 0);
        }
    }
}