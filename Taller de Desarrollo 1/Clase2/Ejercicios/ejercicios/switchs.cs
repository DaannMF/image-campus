namespace Ejercicios {
    public class Switchs {
        public void Ejercicio1() {
            Int16 numero;
            Console.WriteLine("Ingrese un número del 1 al 7");
            Int16.TryParse(Console.ReadLine(), out numero);

            switch (numero) {
                case 1:
                    Console.WriteLine("Lunes");
                    break;
                case 2:
                    Console.WriteLine("Martes");
                    break;
                case 3:
                    Console.WriteLine("Miércoles");
                    break;
                case 4:
                    Console.WriteLine("Jueves");
                    break;
                case 5:
                    Console.WriteLine("Viernes");
                    break;
                case 6:
                    Console.WriteLine("Sábado");
                    break;
                case 7:
                    Console.WriteLine("Domingo");
                    break;
                default:
                    Console.WriteLine("No es un día de la semana");
                    break;
            }
        }

        public void Ejercicio2() {
            Int16 numero;
            Console.WriteLine("Ingrese un número del 1 al 12");
            Int16.TryParse(Console.ReadLine(), out numero);

            switch (numero) {
                case 1:
                    Console.WriteLine("Enero");
                    break;
                case 2:
                    Console.WriteLine("Febrero");
                    break;
                case 3:
                    Console.WriteLine("Marzo");
                    break;
                case 4:
                    Console.WriteLine("Abril");
                    break;
                case 5:
                    Console.WriteLine("Mayo");
                    break;
                case 6:
                    Console.WriteLine("Junio");
                    break;
                case 7:
                    Console.WriteLine("Julio");
                    break;
                case 8:
                    Console.WriteLine("Agosto");
                    break;
                case 9:
                    Console.WriteLine("Septiembre");
                    break;
                case 10:
                    Console.WriteLine("Octubre");
                    break;
                case 11:
                    Console.WriteLine("Noviembre");
                    break;
                case 12:
                    Console.WriteLine("Diciembre");
                    break;
                default:
                    Console.WriteLine("No es un mes válido");
                    break;
            }
        }

        public void Ejercicio3() {
            Char letra;
            Console.WriteLine("Ingrese un número del 1 al 7");
            Char.TryParse(Console.ReadLine(), out letra);

            switch (letra) {
                case 'a':
                case 'A':
                case 'e':
                case 'E':
                case 'i':
                case 'I':
                case 'o':
                case 'O':
                case 'u':
                case 'U':
                    Console.WriteLine(letra);
                    break;
                default:
                    Console.WriteLine("No es una vocal");
                    break;
            }
        }
    }
}