namespace Ejercicios {
    public class Whiles {

        public void Ejercicio2() {
            Int16 numero, suma = 0;
            while (suma < 100) {

                Console.WriteLine("Ingrese un número");
                Int16.TryParse(Console.ReadLine(), out numero);

                suma += numero;
            }

            Console.WriteLine("La suma es :" + suma);
        }

        public void Ejercicio3() {
            Int16 numero = 1;

            while (numero != 0) {
                Console.WriteLine("Ingrese un número");
                Int16.TryParse(Console.ReadLine(), out numero);

                if (numero % 2 == 0) {
                    Console.WriteLine("El numero es par");
                }
                else {
                    Console.WriteLine("La suma es impar");
                }
            }

            Console.WriteLine("Fin del programa");
        }
    }
}