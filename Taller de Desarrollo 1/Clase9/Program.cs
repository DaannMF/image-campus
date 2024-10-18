static void Ejercicio1()
{
    Console.WriteLine("Ingrese el ancho");
    Int16.TryParse(Console.ReadLine(), out Int16 width);

    Console.WriteLine("Ingrese el alto");
    Int16.TryParse(Console.ReadLine(), out Int16 height);

    Console.WriteLine("Lo pinto? S/N");
    Char.TryParse(Console.ReadLine(), out Char paint);

    DrawLimit(width);
    for (int i = 0; i < height; i++)
    {
        Console.Write("|");
        for (int j = 0; j < width; j++)
        {
            if (Char.ToUpper(paint) == 'S')
            {
                Console.Write("X");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.Write("|");
        Console.WriteLine();
    }
    DrawLimit(width);
}

static void DrawLimit(Int16 width)
{
    Console.Write(" ");
    for (int i = 0; i < width; i++)
    {
        Console.Write("-");
    }
    Console.Write(" ");
    Console.WriteLine();
}

static void Ejercicio2()
{
    Int16 y;
    Console.WriteLine("Ingrese el x1");
    Int16.TryParse(Console.ReadLine(), out Int16 x1);

    Console.WriteLine("Ingrese el x2");
    Int16.TryParse(Console.ReadLine(), out Int16 x2);

    for (int i = Math.Min(x1, x2); i <= Math.Max(x1,x2); i++)
    {
        y = (Int16)Math.Pow(i - 4, 2);
        for (int j = 0; j < y; j++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
}

Ejercicio1();

Ejercicio2();
