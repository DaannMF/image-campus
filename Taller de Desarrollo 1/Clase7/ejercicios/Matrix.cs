namespace Clase7.ejercicios
{
    class Matrix
    {
        public void Ejercicio1(Int16[] arr1, Int16[] arr2)
        {
            Int16 maxLength = (Int16)Math.Max(arr1.Length, arr2.Length);
            Int32[] sum = new Int32[maxLength];
            Int32[] avg = new Int32[maxLength];
            Boolean[] equals = new Boolean[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                Int16 value1;
                Int16 value2;

                if (i > arr1.Length - 1) value1 = 0;
                else value1 = arr1[i];

                if (i > arr2.Length - 1) value2 = 0;
                else value2 = arr2[i];


                sum[i] = value1 + value2;
                avg[i] = (value1 + value2) / 2;
                equals[i] = value1 == value2;
            }

            for (int i = 0; i < maxLength; i++)
            {
                Console.WriteLine($"Suma {i + 1} : {sum[i]}");
                Console.WriteLine($"Promedio {i + 1} : {avg[i]}");
                Console.WriteLine($"Son iguales {i + 1} : {equals[i]}");
            }
        }
    }
}