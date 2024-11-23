using System.Numerics;
using Raylib_cs;

class SpaceInvaders {
    const Int16 WIDTH = 1280;
    const Int16 HEIGHT = 720;
    const Int16 TARGET_FPS = 60;
    const Int16 LIFES = 3;
    const Int16 ENEMY_ROWS = 3;
    const Int16 ENEMY_COLS = 8;
    const Int16 PLAYER_SPEED = 300;
    const Int16 BULLET_SPEED = 500;
    const Int16 ENEMY_SPEED = 100;
    const Int16 ENEMY_SCORE = 1;
    const Single SHOOT_COOLDOWN = 0.5f;
    const Single ENEMY_SCALE = 0.7f;
    const Single BULLET_SCALE = 0.5f;

    public static Texture2D playerTexture;
    public static Texture2D enemyTexture1;
    public static Texture2D enemyTexture2;
    public static Texture2D enemyTexture3;
    public static Texture2D bulletTexture;
    public static Texture2D explosionTexture;

    private static Single dt;
    private static Vector2 playerPosition;
    private static Int16 playerLifes;
    private static Int16 playerScore;
    private static Single playerShootTimer;
    private static Vector2 playerBulletPosition;
    private static Boolean playerBulletIsActive;
    private static Vector2 enemyBulletPosition;
    private static Boolean enemyBulletIsActive;
    const String HIGHSCORE_FILE = "highscore.txt";

    private static Vector2[] enemies = new Vector2[ENEMY_ROWS * ENEMY_COLS];
    private static Boolean[] enemiesAlive = new Boolean[ENEMY_ROWS * ENEMY_COLS];
    private static Boolean movingRight = true;
    private static GameState gameState = GameState.Start;

    enum GameState {
        Start,
        Playing,
        Win,
        GameOver,
        Exit
    }


    static void Main() {
        Raylib.InitWindow(WIDTH, HEIGHT, "Final - Space Invaders - Daniel Fimiani");
        Raylib.SetTargetFPS(TARGET_FPS);

        LoadTextures();

        while (!Raylib.WindowShouldClose() && gameState != GameState.Exit) {
            dt = Raylib.GetFrameTime();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            switch (gameState) {
                case GameState.Start:
                    DrawStartScreen();
                    break;

                case GameState.Playing: {
                        DrawInterface();

                        PLayerController();

                        EnemyController();

                        CheckCollisions();

                        DrawEntities();
                    }
                    break;

                case GameState.Win:
                case GameState.GameOver:
                    DrawOverScreen();
                    break;

                case GameState.Exit:
                    break;
            }

            Raylib.EndDrawing();
        }

        UnloadTextures();

        Raylib.CloseWindow();
    }

    private static void StartGame() {
        // Inicializar variables
        playerPosition = new Vector2(WIDTH / 2 - playerTexture.Width, HEIGHT - playerTexture.Height);
        playerLifes = LIFES;
        playerScore = 0;
        gameState = GameState.Playing;
        playerShootTimer = 0;
        playerBulletIsActive = false;
        movingRight = true;

        // Crear enemigos
        enemies = new Vector2[ENEMY_ROWS * ENEMY_COLS];

        for (int i = 0; i < ENEMY_ROWS; i++) {
            for (int j = 0; j < ENEMY_COLS; j++) {
                enemies[i * ENEMY_COLS + j] = new Vector2(100 + j * 100, 50 + i * 100);
                enemiesAlive[i * ENEMY_COLS + j] = true;
            }
        }
    }

    private static void DrawStartScreen() {
        Raylib.DrawText("Space Invaders", 250, 100, 100, Color.White);

        Int16 score = CheckScore(playerScore);
        Raylib.DrawText("High Score: " + score, 430, 350, 60, Color.White);

        Raylib.DrawText("Press Enter to start", 310, 600, 60, Color.White);


        if (Raylib.IsKeyPressed(KeyboardKey.Enter)) {
            StartGame();
        }
    }

    private static void DrawOverScreen() {
        Raylib.DrawText("Space Invaders", 250, 100, 100, Color.White);

        if (gameState == GameState.Win)
            Raylib.DrawText("YOU WIN!", 460, 250, 80, Color.White);
        else
            Raylib.DrawText("Game Over", 430, 250, 80, Color.White);

        Int16 score = CheckScore(playerScore);
        Raylib.DrawText("High Score: " + score, 430, 350, 60, Color.White);

        Raylib.DrawText("Press Enter to start", 400, 540, 40, Color.White);
        Raylib.DrawText("Press Esc to exit", 450, 600, 40, Color.White);


        if (Raylib.IsKeyPressed(KeyboardKey.Enter)) {
            StartGame();
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Escape)) {
            gameState = GameState.Exit;
        }
    }

    private static void PLayerController() {
        if (Raylib.IsKeyDown(KeyboardKey.Left) && playerPosition.X > 0)
            playerPosition.X -= PLAYER_SPEED * dt;
        if (Raylib.IsKeyDown(KeyboardKey.Right) && playerPosition.X < WIDTH - playerTexture.Width)
            playerPosition.X += PLAYER_SPEED * dt;

        playerShootTimer += dt;
        if (Raylib.IsKeyPressed(KeyboardKey.Space) && playerShootTimer >= SHOOT_COOLDOWN && !playerBulletIsActive) {
            playerBulletPosition = new Vector2(playerPosition.X + playerTexture.Width / 2 - 5, playerPosition.Y - 10);
            playerBulletIsActive = true;
            playerShootTimer = 0;
        }

        if (playerBulletIsActive) {
            playerBulletPosition.Y -= BULLET_SPEED * dt;
            if (playerBulletPosition.Y < 0) playerBulletIsActive = false;
        }

    }

    private static void EnemyController() {
        for (int i = 0; i < ENEMY_ROWS; i++) {
            for (int j = 0; j < ENEMY_COLS; j++) {
                if (!enemiesAlive[i * ENEMY_COLS + j]) continue;

                enemies[i * ENEMY_COLS + j].X += (movingRight ? ENEMY_SPEED : -ENEMY_SPEED) * dt;

                if (enemies[i * ENEMY_COLS + j].X > WIDTH - enemyTexture1.Width || enemies[i * ENEMY_COLS + j].X < 0) {
                    movingRight = !movingRight;
                }
            }
        }


        if (!enemyBulletIsActive) {
            Random random = new Random();
            do {
                Int16 enemyIndex = (Int16)random.Next(0, ENEMY_ROWS * ENEMY_COLS);
                if (enemiesAlive[enemyIndex]) {
                    enemyBulletPosition = new Vector2(enemies[enemyIndex].X + enemyTexture1.Width / 2 - 5, enemies[enemyIndex].Y + enemyTexture1.Height);
                    enemyBulletIsActive = true;
                }
            } while (!enemyBulletIsActive);
        }


        if (enemyBulletIsActive) {
            enemyBulletPosition.Y += BULLET_SPEED * dt;
            if (enemyBulletPosition.Y > HEIGHT) enemyBulletIsActive = false;
        }
    }

    private static void CheckCollisions() {
        if (playerBulletIsActive) {
            for (int i = 0; i < ENEMY_ROWS; i++) {
                for (int j = 0; j < ENEMY_COLS; j++) {
                    if (!enemiesAlive[i * ENEMY_COLS + j]) continue;

                    Vector2 enemySize = new Vector2(enemyTexture1.Width, enemyTexture1.Height) * ENEMY_SCALE;
                    Vector2 bulletSize = new Vector2(bulletTexture.Width, bulletTexture.Height) * BULLET_SCALE;
                    Rectangle bulletBounds = new Rectangle(playerBulletPosition, bulletSize);
                    Rectangle enemyBounds = new Rectangle(enemies[i * ENEMY_COLS + j], enemySize);
                    if (Raylib.CheckCollisionRecs(bulletBounds, enemyBounds) && playerBulletIsActive) {
                        playerBulletIsActive = false;
                        enemiesAlive[i * ENEMY_COLS + j] = false;
                        playerScore += ENEMY_SCORE;
                    }
                }
            }
        }

        if (enemyBulletIsActive) {
            Vector2 playerSize = new Vector2(playerTexture.Width, playerTexture.Height);
            Vector2 bulletSize = new Vector2(bulletTexture.Width, bulletTexture.Height) * BULLET_SCALE;
            Rectangle bulletBounds = new Rectangle(enemyBulletPosition, bulletSize);
            Rectangle playerBounds = new Rectangle(playerPosition, playerSize);
            if (Raylib.CheckCollisionRecs(bulletBounds, playerBounds)) {
                enemyBulletIsActive = false;
                playerLifes--;
                if (playerLifes <= 0) {
                    gameState = GameState.GameOver;
                }
            }
        }

        if (enemiesAlive.All(x => x == false)) {
            gameState = GameState.Win;
        }
    }

    private static void DrawEntities() {
        // Dibujar jugador
        Raylib.DrawTexture(playerTexture, (int)playerPosition.X, (int)playerPosition.Y, Color.White);

        // Dibujar balas
        if (playerBulletIsActive)
            Raylib.DrawTextureEx(bulletTexture, playerBulletPosition, 0, 0.5f, Color.White);

        if (enemyBulletIsActive)
            Raylib.DrawTextureEx(bulletTexture, enemyBulletPosition, 0, 0.5f, Color.White);

        // Dibujar enemigos
        Texture2D texture = enemyTexture1;
        for (int i = 0; i < ENEMY_ROWS; i++) {
            for (int j = 0; j < ENEMY_COLS; j++) {
                if (enemiesAlive[i * ENEMY_COLS + j]) {
                    if (i == 0)
                        texture = enemyTexture1;
                    else if (i == 1)
                        texture = enemyTexture2;
                    else
                        texture = enemyTexture3;

                    Vector2 position = new Vector2(enemies[i * ENEMY_COLS + j].X, enemies[i * ENEMY_COLS + j].Y);
                    Raylib.DrawTextureEx(texture, position, 0, 0.7f, Color.White);
                }
            }
        }
    }

    private static void DrawInterface() {
        Raylib.DrawText("Score: " + playerScore, 10, 10, 20, Color.White);
        Raylib.DrawText("Lifes: " + playerLifes, WIDTH - 100, 10, 20, Color.White);
        Raylib.DrawText("Controls: Left, Right, Space", 450, 10, 20, Color.White);
    }

    private static void LoadTextures() {
        playerTexture = Raylib.LoadTexture("assets/player.png");
        enemyTexture1 = Raylib.LoadTexture("assets/enemy1.png");
        enemyTexture2 = Raylib.LoadTexture("assets/enemy2.png");
        enemyTexture3 = Raylib.LoadTexture("assets/enemy3.png");
        bulletTexture = Raylib.LoadTexture("assets/bullet.png");
        explosionTexture = Raylib.LoadTexture("assets/explosion.png");
    }

    private static void UnloadTextures() {

        Raylib.UnloadTexture(playerTexture);
        Raylib.UnloadTexture(enemyTexture1);
        Raylib.UnloadTexture(enemyTexture2);
        Raylib.UnloadTexture(enemyTexture3);
        Raylib.UnloadTexture(bulletTexture);
        Raylib.UnloadTexture(explosionTexture);
    }

    static Int16 CheckScore(Int16 _playerScore) {
        Int16 highScore = 0;
        if (File.Exists(HIGHSCORE_FILE)) {
            highScore = Int16.Parse(File.ReadAllText(HIGHSCORE_FILE));
        }
        else {
            File.WriteAllText(HIGHSCORE_FILE, "0");
        }

        if (_playerScore > highScore) {
            File.WriteAllText(HIGHSCORE_FILE, _playerScore.ToString());
        }

        return Math.Max(_playerScore, highScore);
    }
}