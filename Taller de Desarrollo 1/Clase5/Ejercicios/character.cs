namespace Clase5.Ejercicios
{
    class Character
    {
        const Int32 MAX_WIDTH = 170;
        const Int32 MAX_HEIGHT = 20;

        public void Ejercicio()
        {
            String character = @"\(*.*)/";

            Int32 posX = 0;
            Int32 posY = 0;

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        posX = Math.Max(0, posX - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        posX = Math.Min(posX + 1, MAX_WIDTH);
                        break;
                    case ConsoleKey.UpArrow:
                        posY = Math.Max(0, posY - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        posY = Math.Min(posY + 1, MAX_HEIGHT);
                        break;
                    default:
                        break;
                }

                Console.Clear();
                Console.WriteLine("Mover personaje con las flechas <- o ->");

                for (int i = 0; i < posY; i++)
                {
                    Console.Write("\n");
                }

                for (int i = 0; i < posX; i++)
                {
                    Console.Write(" ");
                }

                Console.Write(character);
            }
        }
    }
}