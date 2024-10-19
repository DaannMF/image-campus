using System.Numerics;
using Raylib_cs;

namespace TP_05;

class Program {
    const Int16 SCREEN_WIDTH = 800;
    const Int16 SCREEN_HEIGHT = 480;
    const float SCROLL_SPEED_CLOUD = 50f;
    const float SCROLL_SPEED_GROUND = 60f;
    const float CLOUD_Y = 100f;
    const float GROUND_Y = 350f;
    const float GRAVITY = 900f;
    const float JUMP_FORCE = -500f;
    const float PLAYER_START_POSITION_X = 50f;
    const float PLAYER_START_POSITION_Y = 300f;
    const float CACTUS_SPEED = 450f;
    const Int16 TARGET_FPS = 60;
    static float scrollingCloud1 = 0f;
    static float scrollingCloud2 = 0f;
    static float scrollingGround = 0f;
    static float cloudOffset = SCREEN_WIDTH / 2;
    static readonly float textureCloudOffset = 40f;
    static Texture2D cloudsTexture;
    static Texture2D groundTexture;
    static Texture2D dinoTexture;
    static Texture2D cactus1;
    static Texture2D cactus2;
    static Texture2D cactus3;
    static List<Texture2D> cactusPool = [];
    static Vector2 player;
    static Vector2 cactus;
    static Boolean isGrounded = true;
    static float velocityY = 0;
    static Texture2D cactusTexture;
    static readonly Random rand = new();
    static float score;
    static GameState gameState;
    enum GameState {
        Playing,
        GameOver,
        Exit
    }

    public static void Main() {

        Raylib.SetTargetFPS(TARGET_FPS);
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "TP 05 Dino Run Daniel Fimiani");
        LoadTextures();

        // Posición jugador (dino)
        player = new Vector2(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y);
        cactus = new Vector2(SCREEN_WIDTH, PLAYER_START_POSITION_Y);

        gameState = GameState.Playing;

        while (!Raylib.WindowShouldClose() && gameState != GameState.Exit) {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RayWhite);

            if (gameState == GameState.Playing) {
                DrawBackGround();

                PLayerController();

                CactusController();

                DrawInterface();
            }

            if (gameState == GameState.GameOver) {
                CheckRetry();
            }

            Raylib.EndDrawing();
        }

        UnloadTextures();

        Raylib.CloseWindow();
    }

    static void LoadTextures() {
        cloudsTexture = Raylib.LoadTexture("cloud.png");
        groundTexture = Raylib.LoadTexture("ground.png");
        dinoTexture = Raylib.LoadTexture("Dino1.png");
        cactus1 = Raylib.LoadTexture("cactus1.png");
        cactus2 = Raylib.LoadTexture("cactus2.png");
        cactus3 = Raylib.LoadTexture("cactus3.png");
        cactusPool = [cactus1, cactus2, cactus3];
    }

    static void DrawBackGround() {
        if (scrollingCloud1 <= -SCREEN_WIDTH - cloudsTexture.Width - textureCloudOffset) scrollingCloud1 = 0;
        if (scrollingCloud2 <= -SCREEN_WIDTH - cloudOffset - cloudsTexture.Width - textureCloudOffset) {
            scrollingCloud2 = 0;
            cloudOffset = 0;
        }
        if (scrollingGround <= -groundTexture.Width * 2) scrollingGround = 0;

        scrollingCloud1 -= SCROLL_SPEED_CLOUD * Raylib.GetFrameTime();
        scrollingCloud2 -= SCROLL_SPEED_CLOUD * Raylib.GetFrameTime();
        scrollingGround -= SCROLL_SPEED_GROUND * Raylib.GetFrameTime();

        Raylib.DrawTextureEx(cloudsTexture, new Vector2(SCREEN_WIDTH + scrollingCloud1, CLOUD_Y), 0.0f, 2.0f, Color.SkyBlue);
        Raylib.DrawTextureEx(cloudsTexture, new Vector2(SCREEN_WIDTH + cloudOffset + scrollingCloud2, CLOUD_Y + 20f), 0.0f, 2.0f, Color.SkyBlue);

        Raylib.DrawTextureEx(groundTexture, new Vector2(scrollingGround, GROUND_Y), 0.0f, 2.0f, Color.Red);
        Raylib.DrawTextureEx(groundTexture, new Vector2(groundTexture.Width * 2 + scrollingGround, GROUND_Y), 0.0f, 2.0f, Color.Red);
    }

    static void PLayerController() {
        if (Raylib.IsKeyPressed(KeyboardKey.Space) && isGrounded) {
            velocityY = JUMP_FORCE;
            isGrounded = false;
        }

        if (!isGrounded) {
            player.Y += velocityY * Raylib.GetFrameTime();
            velocityY += GRAVITY * Raylib.GetFrameTime();

            if (player.Y >= PLAYER_START_POSITION_Y) {
                player.Y = PLAYER_START_POSITION_Y;
                isGrounded = true;
                velocityY = 0;
            }
        }

        Raylib.DrawTextureEx(dinoTexture, player, 0.0f, 2f, Color.White);
    }

    static void CactusController() {
        cactusTexture = PeekRandomCactusTexture();
        cactus.X -= CACTUS_SPEED * Raylib.GetFrameTime();
        if (cactus.X + cactusTexture.Width < 0) {
            cactus.X = SCREEN_WIDTH;
            cactusTexture.Id = 0;
        }

        Raylib.DrawTextureEx(cactusTexture, cactus, 0.0f, 2.0f, Color.DarkGreen);

        Rectangle playerBounds = new(player.X, player.Y, dinoTexture.Width, dinoTexture.Height);
        Rectangle cactusBounds = new(cactus.X, cactus.Y, cactusTexture.Width, cactusTexture.Height);
        if (Raylib.CheckCollisionRecs(playerBounds, cactusBounds)) {
            gameState = GameState.GameOver;
        }
    }

    static Texture2D PeekRandomCactusTexture() {
        if (cactusTexture.Id == 0) {
            return cactusPool[rand.Next(0, cactusPool.Count)];
        }
        return cactusTexture;
    }

    static void DrawInterface() {
        score += Raylib.GetFrameTime() * 10;
        Raylib.DrawText(score.ToString("00000000"), 700, 10, 20, Color.DarkGray);
        Raylib.DrawText("¡Salta con Espacio!", 10, 10, 20, Color.DarkGray);
    }

    static void CheckRetry() {
        Raylib.DrawText("¡Game Over!", 300, 150, 30, Color.Red);
        Raylib.DrawText("Press R to restart", 250, 200, 30, Color.Red);
        Raylib.DrawText("Press Esc to exit", 260, 250, 30, Color.Red);
        Raylib.DrawText("Author Daniel Fimiani", 300, 400, 20, Color.Black);
        Raylib.DrawText("Taller de desarrollo de videojuegos", 270, 430, 15, Color.Black);

        ResetGame();

        if (Raylib.IsKeyPressed(KeyboardKey.R)) {
            gameState = GameState.Playing;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Escape)) {
            gameState = GameState.Exit;
        }
    }

    static void ResetGame() {
        player = new Vector2(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y);
        cactus = new Vector2(SCREEN_WIDTH, PLAYER_START_POSITION_Y);
        cloudOffset = SCREEN_WIDTH / 2;
        score = 0;
        cactusTexture.Id = 0;
        scrollingCloud1 = 0;
        scrollingCloud2 = 0;
        scrollingGround = 0;
        isGrounded = true;
    }

    static void UnloadTextures() {
        Raylib.UnloadTexture(cloudsTexture);
        Raylib.UnloadTexture(groundTexture);
        Raylib.UnloadTexture(dinoTexture);
        Raylib.UnloadTexture(cactus1);
        Raylib.UnloadTexture(cactus2);
        Raylib.UnloadTexture(cactus3);
    }
}