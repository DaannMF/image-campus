namespace TP_01
{
    class Program
    {
        static void Main()
        {
            Boolean bIsWoman, bHasGlasses, bHasBlackHair, bHasHeader, bHasMask;
            String? line;

            do
            {
                Console.WriteLine("¿Es una nena?");
                Console.Write("User : ");
            } while (String.IsNullOrEmpty(line = Console.ReadLine()));
            bIsWoman = String.Equals(line, "si");

            do
            {
                Console.WriteLine("¿Usa lentes?");
                Console.Write("User : ");
            } while (String.IsNullOrEmpty(line = Console.ReadLine()));
            bHasGlasses = String.Equals(line, "si");

            do
            {
                Console.WriteLine("¿Tiene algo en la cabeza?");
                Console.Write("User : ");
            } while (String.IsNullOrEmpty(line = Console.ReadLine()));
            bHasHeader = String.Equals(line, "si");

            do
            {
                Console.WriteLine("¿Tiene pelo negro?");
                Console.Write("User : ");
            } while (String.IsNullOrEmpty(line = Console.ReadLine()));
            bHasBlackHair = String.Equals(line, "si");


            if (bHasGlasses)
            {
                if (bHasHeader)
                {
                    Console.WriteLine("Tu personaje es Patricia");
                }
                else if (bIsWoman)
                {
                    Console.WriteLine("Tu personaje es Carmen");
                }
                else
                {
                    Console.WriteLine("Tu personaje es Mario");
                }
            }
            else
            {
                if (bIsWoman)
                {
                    if (!bHasHeader)
                    {
                        Console.WriteLine("Tu personaje es Ana");
                    }
                    else if (bHasBlackHair)
                    {
                        Console.WriteLine("Tu personaje es Andrea");
                    }
                    else
                    {
                        Console.WriteLine("Tu personaje es María");
                    }
                }
                else
                {
                    if (bHasHeader)
                    {
                        if (bHasBlackHair)
                        {
                            Console.WriteLine("Tu personaje es Fernando");
                        }
                        else
                        {
                            Console.WriteLine("Tu personaje es Rubén");
                        }
                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("¿Usa máscara?");
                            Console.Write("User : ");
                        } while (String.IsNullOrEmpty(line = Console.ReadLine()));
                        bHasMask = String.Equals(line, "si");

                        if (bHasMask && bHasBlackHair)
                        {
                            Console.WriteLine("Tu personaje es Hugo");
                        }
                        else if (bHasMask && !bHasBlackHair)
                        {
                            Console.WriteLine("Tu personaje es Juan");
                        }
                        else if (!bHasMask && bHasBlackHair)
                        {
                            Console.WriteLine("Tu personaje es Pedro");
                        }
                        else
                        {
                            Console.WriteLine("Tu personaje es Iván");
                        }
                    }
                }
            }
        }
    }
}