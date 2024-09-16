using System;

class Program
{
    const Char ROCK = 'p';
    const Char PAPER = 'a';
    const Char SCISSOR = 't';
    const Char YES = 's';

    const String ROCK_NAME = "Piedra";
    const String PAPER_NAME = "Papel";
    const String SCISSOR_NAME = "Tijeras";

    const Int16 WAIT_TITLE_TIME = 5000;
    const Int16 WAIT_INVALID_MESSAGE_TIME = 2000;

    const String PLAYER = "Jugador";
    const String COMPUTER = "Computadora";

    const Int16 ROUNDS = 5;

    enum Result
    {
        PlayerWin,
        PCWin,
        Draw
    }

    static void Main()
    {
        Random random = new();
        Char userChoice;
        Char computerChoice;

        do
        {
            Int16 userScore = 0, computerScore = 0;

            Console.Clear();
            Console.WriteLine("¡Bienvenido a Piedra, Papel o Tijera!");
            Console.WriteLine($"Juega al mejor de {ROUNDS} intentos.");
            Thread.Sleep(WAIT_TITLE_TIME);

            for (int i = 0; i < ROUNDS; i++)
            {

                Console.Clear();
                Console.WriteLine($"Marcador - {PLAYER}: {userScore} | {COMPUTER}: {computerScore}");
                Console.WriteLine($"Ronda {i + 1} de {ROUNDS}");

                // Obtener la elección del usuario
                userChoice = GetUserChoice();

                // Obtener la elección de la computadora
                computerChoice = GetPCChoice(random);

                // Mostrar ASCII ART
                ShowArt(userChoice, PLAYER);
                ShowArt(computerChoice, COMPUTER);

                switch (DetermineWinner(userChoice, computerChoice))
                {
                    case Result.PlayerWin:
                        Console.WriteLine("¡Ganaste esta ronda!");
                        userScore++;
                        break;
                    case Result.PCWin:
                        Console.WriteLine("La computadora ganó esta ronda.");
                        computerScore++;
                        break;
                    default:
                        Console.WriteLine("Empate.");
                        break;
                }


                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            }

            ShowFinalResult(userScore, computerScore);

            Console.WriteLine("¿Quieres jugar otra vez? (s/n)");

        } while (Char.ToLower(Console.ReadKey().KeyChar) == YES);
    }

    static Char GetUserChoice()
    {
        Char choice;
        do
        {
            Console.WriteLine("Elige: Piedra (p), Papel (a) o Tijera (t): ");
            choice = Char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

        } while (!IsValidChoice(choice));

        return choice;
    }

    static Boolean IsValidChoice(Char choice)
    {
        if (choice == ROCK || choice == PAPER || choice == SCISSOR)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Opción inválida por favor vuelve a ingresar");
            Thread.Sleep(WAIT_INVALID_MESSAGE_TIME);
            Console.Clear();
            return false;
        }
    }

    static Char GetPCChoice(Random random)
    {
        Int16 value = (Int16)random.Next(3);
        return value switch
        {
            0 => ROCK,
            1 => PAPER,
            _ => SCISSOR,
        };
    }

    static String GetChoiceName(Char choice)
    {
        return choice switch
        {
            ROCK => ROCK_NAME,
            PAPER => PAPER_NAME,
            _ => SCISSOR_NAME,
        };
    }

    static Result DetermineWinner(Char userChoice, Char computerChoice)
    {
        if (userChoice == computerChoice)
            return Result.Draw;

        Boolean playerWins = userChoice == ROCK && computerChoice == SCISSOR;
        playerWins = playerWins || (userChoice == PAPER && computerChoice == ROCK);
        playerWins = playerWins || (userChoice == SCISSOR && computerChoice == PAPER);

        return playerWins ? Result.PlayerWin : Result.PCWin;
    }

    static void ShowFinalResult(Int16 userScore, Int16 computerScore)
    {
        Console.Clear();
        Console.WriteLine("Juego terminado.");
        Console.WriteLine($"Marcador - {PLAYER}: {userScore} | {COMPUTER}: {computerScore}");
        if (userScore > computerScore)
        {
            Console.WriteLine("¡Felicidades! Ganaste el juego.");
        }
        else if (userScore < computerScore)
        {
            Console.WriteLine("La computadora ganó el juego. Mejor suerte la próxima vez.");
        }
        else
        {
            Console.WriteLine("El juego terminó en empate.");
        }
    }

    static void ShowArt(Char choice, String player)
    {
        String art = choice switch
        {
            PAPER => ASCII_ART.ASCII.ASCII_PAPER,
            ROCK => ASCII_ART.ASCII.ASCII_ROCK,
            SCISSOR => ASCII_ART.ASCII.ASCII_SCISSOR,
            _ => String.Empty,
        };

        Console.WriteLine($"{player} elige: {GetChoiceName(choice)}");
        Console.WriteLine(art);
    }
}
