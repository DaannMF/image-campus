namespace TP_04
{
    class HangMan
    {
        const Char YES = 's';
        const String TITLE = "JUEGO DEL AHORCADO";
        const Int16 MAX_TRIES = 7;
        static readonly String[] HANGMAN_ASCII_ART = [
            @"
            +---+
            |   |
                |
                |                
                |
                |
                |
            =========",
            @"
            +---+
            |   |
            O   |
                |
                |                
                |
                |
            =========",
            @"
            +---+
            |   |
            O   |
            |   |
                |            
                |
                |
            =========",
            @"
            +---+
            |   |
            O   |
           /|   |
                |
                |                
                |
            =========",
            @"
            +---+
            |   |
            O   |
           /|\  |
                |
                |
                |                
            =========",
            @"
            +---+
            |   |
            O   |
           /|\  |
            |   |
                |            
                |
            =========",
            @"
            +---+
            |   |
            O   |
           /|\  |
            |   |
           /    |
                |
            =========",
            @"
            +---+
            |   |
            O   |
           /|\  |
            |   |           
           / \  |
                |
            ========="
        ];
        static readonly String[] words = {
            "AMIGOS", "PERROS", "CASITA", "CIUDAD", "CIELOS", "FLORES", "MONTAÑA", "GATITOS", "CAMINOS", "ARBOLES",
            "VIENTOS", "AGUACERO", "FUEGOS", "TIERRAS", "MARINOS", "JUEGOS", "SOMBRAS", "LUCEROS", "NOCHES", "DIARIOS",
            "PALABRA", "LIBROS", "SOMBRERO", "COCHES", "RIEGOS", "MONEDAS", "NUBOSAS", "SILENCIO", "AVIONES", "ROPAJES"
        };

        static List<Char> secretWord = [];
        static Int16 fails;
        static List<Char> givenLetters = [];
        static Boolean playerWin;

        static void Main()
        {

            do
            {
                Console.Clear();
                fails = 0;
                PeekRandomWord();
                playerWin = false;
                givenLetters = [];

                do
                {
                    DrawBoard();
                    GetAndValidatePlayerInput();
                } while (ShouldContinue());

                DrawBoard();

                if (playerWin)
                    Console.WriteLine("¡¡Ganaste!!");
                else
                    Console.WriteLine($"Perdiste!!! La palabra secreta es : {String.Join("", secretWord)}");

                Console.WriteLine();
                Console.WriteLine($"Desea volver a jugar? S/N");

            } while (Char.ToLower(Console.ReadKey().KeyChar) == YES);
        }

        static void PeekRandomWord()
        {
            Random random = new();
            int indiceAleatorio = random.Next(words.Length);
            secretWord = [.. words[indiceAleatorio]];
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine(TITLE);
            Console.WriteLine(HANGMAN_ASCII_ART[fails]);
            DrawSecretWord();
            Console.WriteLine();
            Console.WriteLine($"Intentos fallidos ({fails}) : {String.Join(",", givenLetters)}");
        }

        static void DrawSecretWord()
        {
            foreach (Char c in secretWord)
            {
                Console.Write(givenLetters.Contains(c) ? c : "_");
            }
            Console.WriteLine();
        }

        static void GetAndValidatePlayerInput()
        {
            Char input;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Escoge una letra...");
                input = Char.ToUpper(Console.ReadKey().KeyChar);
            } while (!Char.IsLetter(input) || givenLetters.Contains(input));

            if (!secretWord.Contains(input))
                fails++;

            givenLetters.Add(input);
        }

        static Boolean ShouldContinue()
        {
            if (fails >= MAX_TRIES)
                return false;


            foreach (Char c in secretWord)
            {
                if (!givenLetters.Contains(c))
                    return true;
            }

            playerWin = true;
            return false;
        }
    }
}