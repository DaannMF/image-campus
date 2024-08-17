namespace Ejercicios {
    public class Inputs {
        public void Ejercicio1() {
            Int16 numero;
            Console.WriteLine("Ingrese un número");
            Int16.TryParse(Console.ReadLine(), out numero);

            if (numero == 0) {
                Console.WriteLine("El número ingresado es 0");
            }
            else {
                Console.WriteLine("El número ingresado no es 0");
            }
        }

        public void Ejercicio2() {
            Int16 numero;
            Console.WriteLine("Ingrese un número");
            Int16.TryParse(Console.ReadLine(), out numero);

            if (numero % 2 == 0) {
                Console.WriteLine("El número es par");
            }
            else {
                Console.WriteLine("El número no es par");
            }
        }

        public void Ejercicio3() {
            char letra;
            Console.WriteLine("Desea salir del juego? [S/N]");
            Char.TryParse(Console.ReadLine(), out letra);

            if (letra == 's') {
                Console.WriteLine("Has elegido salir del juego");
            }
            else if (letra == 'n') {
                Console.WriteLine("Has elegido seguir divirtiéndote!");
            }
        }

        public void Ejercicio4() {
            Int16 numero1, numero2, numero3;

            Console.WriteLine("Ingrese el primer número");
            Int16.TryParse(Console.ReadLine(), out numero1);

            Console.WriteLine("Ingrese el segundo número");
            Int16.TryParse(Console.ReadLine(), out numero2);

            Console.WriteLine("Ingrese el tercer número");
            Int16.TryParse(Console.ReadLine(), out numero3);

            if (numero3 == numero1 + numero2) {
                Console.WriteLine("El tercero es igual a la suma de los primeros");
            }
        }

        public void Ejercicio5() {
            Boolean puedeDisparar = true;
            Int16 codigo;

            Console.WriteLine("Ingrese el codigo");
            Int16.TryParse(Console.ReadLine(), out codigo);

            if (puedeDisparar && codigo == 2) {
                Console.WriteLine("Puede disparar ya que adivinó el código");
            }
        }

        public void Ejercicio6() {
            Int16 numero1, numero2;
            Single promedio;

            Console.WriteLine("Ingrese el primer número");
            Int16.TryParse(Console.ReadLine(), out numero1);

            Console.WriteLine("Ingrese el primer número");
            Int16.TryParse(Console.ReadLine(), out numero2);

            promedio = (numero1 + numero2) / 2;

            if (promedio < 1) {
                Console.WriteLine("El promedio es muy bajo");
            }
            else {
                Console.WriteLine($"El promedio es {promedio}");
            }
        }

        public void Ejercicio7() {
            Int16 numero1;

            Console.WriteLine("Ingrese un número");
            Int16.TryParse(Console.ReadLine(), out numero1);

            if (numero1 > 45 && numero1 < 500 && numero1 != 84) {
                Console.WriteLine("El número ingresado es válido");
            }
            else {
                Console.WriteLine("El valor ingresado no es válido");
            }
        }

        public void Ejercicio8() {
            Int16 numero1;

            Console.WriteLine("Ingrese un número");
            Int16.TryParse(Console.ReadLine(), out numero1);

            if (numero1 == 0) {
                Console.WriteLine("El número es 0");
            }
            else if (numero1 < 0) {
                if (numero1 < -20) {
                    Console.WriteLine("El número es menor a -20");
                }
                else {
                    Console.WriteLine("El número es mayor a -20");
                }
            }
            else if (numero1 < 5) {
                if (numero1 == 1)
                    Console.WriteLine("uno");
                else if (numero1 == 2)
                    Console.WriteLine("dos");
                else if (numero1 == 3)
                    Console.WriteLine("tres");
                else 
                    Console.WriteLine("cuatro");
            }
        }
    }
}