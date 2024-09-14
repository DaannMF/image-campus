namespace Clase6.Recursive
{
    class Recursive
    {
        public Int32 Ejercicio1(Int32 n)
        {
            if (n == 1) return 1;
            return n += Ejercicio1(n - 1);
        }

        public Boolean Ejercicio2(String n)
        {
            if (n.Length == 0) return true;


            if (n[0] != '0' && n[0] != '1')
            {
                return false;
            }

            return Ejercicio2(n.Substring(1));
        }

        public Boolean Ejercicio3(String palabra)
        {
            if (palabra.Length == 1) return true;

            Int32 len = palabra.Length;

            if (!palabra[0].Equals(palabra[len - 1]))
            {
                return false;
            }

            return Ejercicio3(palabra.Substring(1, len - 2));
        }
    }
}