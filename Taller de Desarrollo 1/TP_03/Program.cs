class Program
{
    enum Players
    {
        Player,
        Computer
    }

    enum GameState
    {
        Playing,
        TaTeTi,
        Draw
    }
    
    const Char X = 'X';
    const Char O = 'O';
    const Int16 MIN_VALUE = 1;
    const Int16 MAX_VALUE = 9;
    const Int16 MIN_MOVES_TO_CHECK = 5;
    const Int16 MESSAGE_WAIT_TIME = 2000;

    static Char[,] board = {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
        };

    static readonly Random rand = new();
    static GameState gameState = GameState.Playing;
    static Players currentPlayer = Players.Player;
    static Int16 choice;

    static void Main()
    {
        Int16 moves = 0;

        Console.WriteLine("Bienvenidos a Ta-Te-Ti");
        Console.WriteLine("Competirás con la computadora para ganar, el Jugador elije X y la computadora O");

        do
        {
            moves++;

            DrawBoard();

            if (currentPlayer.Equals(Players.Player))
                PLayerMove();
            else
                ComputerMove();

            UpdateBoard();

            if (moves >= MIN_MOVES_TO_CHECK)
                gameState = CheckWin();

            NextPlayer();
        }
        while (IsPlaying());

        DrawBoard();

        DrawFinalResult();
    }

    static void DrawBoard()
    {
        Console.Clear();
        Console.WriteLine($"Jugador 1: {X} y Computadora : {O}");
        Console.WriteLine();

        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[0, 0], board[0, 1], board[0, 2]);
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[1, 0], board[1, 1], board[1, 2]);
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[2, 0], board[2, 1], board[2, 2]);
        Console.WriteLine("     |     |     ");
    }

    static void UpdateBoard()
    {
        Int16 row = (Int16)((choice - 1) / 3);
        Int16 col = (Int16)((choice - 1) % 3);
        board[row, col] = currentPlayer == Players.Player ? X : O;
    }

    static void PLayerMove()
    {
        do
        {
            Console.WriteLine("Turno del Jugador, elige una casilla: ");
            Int16.TryParse(Console.ReadLine(), out choice);
        } while (!IsValidMove());
        Console.WriteLine($"Elegiste la casilla {choice} ");
        Thread.Sleep(MESSAGE_WAIT_TIME);
    }

    static void ComputerMove()
    {
        do
        {
            choice = (Int16)rand.Next(1, 10);
        } while (!IsValidMove());

        Console.WriteLine($"Turno de la computadora, elige la casilla {choice} ");
        Thread.Sleep(MESSAGE_WAIT_TIME);
    }

    static Boolean IsValidMove()
    {
        if ((choice < MIN_VALUE || choice > MAX_VALUE) && currentPlayer == Players.Player)
        {
            Console.WriteLine($"El valor {choice} ingresado es inválido");
            return false;
        }

        Int16 row = (Int16)((choice - 1) / 3);
        Int16 col = (Int16)((choice - 1) % 3);
        Boolean bAlreadyFill = board[row, col].Equals(X) || board[row, col].Equals(O);

        if (bAlreadyFill)
        {
            if (currentPlayer == Players.Player)
                Console.WriteLine($"La casilla {choice} ya está ocupada");

            return false;
        }

        return true;
    }

    static Boolean IsPlaying()
    {
        return gameState == GameState.Playing;
    }

    static void NextPlayer()
    {
        if (IsPlaying())
        {
            currentPlayer = currentPlayer == Players.Player ? Players.Computer : Players.Player;
        }
    }

    static GameState CheckWin()
    {
        // Verificar filas
        for (Int16 row = 0; row < 3; row++)
        {
            if (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                return GameState.TaTeTi;
        }

        // Verificar columnas
        for (Int16 col = 0; col < 3; col++)
        {
            if (board[0, col] == board[1, col] && board[1, col] == board[2, col])
                return GameState.TaTeTi;
        }

        // Verificar diagonales
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return GameState.TaTeTi;

        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return GameState.TaTeTi;

        // Verificar empate
        Boolean allFilled = true;
        for (Int16 i = 0; i < 3; i++)
        {
            for (Int16 j = 0; j < 3; j++)
            {
                if (!board[i, j].Equals(X) && !board[i, j].Equals(O))
                {
                    allFilled = false;
                    break;
                }
            }
        }

        if (allFilled)
            return GameState.Draw;

        return GameState.Playing;
    }

    static void DrawFinalResult()
    {
        Console.WriteLine("Fin del juego!");
        if (gameState.Equals(GameState.Draw))
            Console.WriteLine("El resultado es Empate!");
        else if (currentPlayer.Equals(Players.Player))
            Console.WriteLine("Ganaste el juego!");
        else
            Console.WriteLine("Gano la computadora");
    }
}
