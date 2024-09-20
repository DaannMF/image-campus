namespace Clase7
{
    class Program
    {
        static void Main()
        {
            // Clase7.ejercicios.Arrays ejercicios = new();

            // Clase7.ejercicios.Arrays.Ejercicio1();
            // Clase7.ejercicios.Arrays.Ejercicio2();
            // Console.WriteLine($"La suma es : {Clase7.ejercicios.Arrays.AddNumbers([4, 5, 6, 7])}");

            Clase7.ejercicios.Matrix matrix = new();
            matrix.Ejercicio1([4, 5, 6, 7], [3, 5, 6, 8, 9]);
        }
    }
}