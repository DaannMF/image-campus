using Raylib_cs;
using System.Numerics;

public class TP_06 {
    const Int16 TARGET_FPS = 60;
    const Int16 SCREEN_WIDTH = 800;
    const Int16 SCREEN_HEIGHT = 600;
    const Single PLAYER_SPEED = 5.0f;
    const Single OBSTACLE_SPEED = 6.0f;
    const Int16 OBSTACLE_POOL_SIZE = 5;
    const Single OBSTACLE_SPAWN_INTERVAL = 2.0f;
    const Single COIN_SPEED = 7.0f;
    const Int16 COIN_POOL_SIZE = 5;
    const Single COIN_SPAWN_INTERVAL = 3.0f;
    const Int16 COIN_VALUE = 10;
    const String HIGHSCORE_FILE = "highscore.txt";

    private static Camera3D _camera;
    private static Vector3 _playerPosition = new(0.0f, 1.0f, 65.0f);
    private static Single _playerSize = 0.2f;
    private static Int16 _playerScore = 0;
    private static Vector3 _positionWall01 = new(-7.0f, 2.5f, 5.0f);
    private static Vector3 _sizeWall01 = new(1.0f, 5.0f, 130.0f);
    private static Vector3 _positionWall02 = new(7.0f, 2.5f, 5.0f);
    private static Vector3 _sizeWall02 = new(1.0f, 5.0f, 130.0f);
    private static Vector3 _positionWinWall = new(0.0f, 2.5f, -130.0f / 2);
    private static Vector3 _sizeWinWall = new(20.0f, 5.0f, 1);
    private static List<Vector3> _obstaclesPool = new();
    private static Vector3 _obstacleSize = new(1.0f, 3.0f, 1.0f);
    private static float _timeSinceLastObstacleSpawn = 0.0f;
    private static List<Vector3> _coinsPool = new();
    private static Vector3 _coinSize = new(0.5f, 0.5f, 0.5f);
    private static float _timeSinceLastCoinSpawn = 0.0f;
    static GameState _gameState;
    enum GameState {
        Playing,
        Win,
        GameOver,
        Exit
    }

    static void Main() {
        Raylib.SetTargetFPS(TARGET_FPS);
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "TP_06 Obstacles Race - Daniel Fimiani");
        InstantiateCamera();

        _gameState = GameState.Playing;

        while (!Raylib.WindowShouldClose() && _gameState != GameState.Exit) {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.LightGray);

            if (_gameState == GameState.Playing) {
                Raylib.BeginMode3D(_camera);
                {
                    PlayerController();

                    SpawnController();

                    DrawGame();
                }
                Raylib.EndMode3D();

                DrawInterface();
            }

            if (_gameState == GameState.GameOver || _gameState == GameState.Win) {
                CheckRetry();
            }

            Raylib.EndDrawing();
        }
    }

    private static void DrawGame() {
        // Player
        Raylib.DrawSphere(_playerPosition, _playerSize, Color.White);

        // Walls
        Raylib.DrawCubeV(_positionWall01, _sizeWall01, Color.Red);
        Raylib.DrawCubeV(_positionWall02, _sizeWall02, Color.Red);
        Raylib.DrawCubeV(_positionWinWall, _sizeWinWall, Color.Green);

        // Plane
        Raylib.DrawPlane(new Vector3(0.0f, 0.0f, 0.0f), new Vector2(130.0f, 130.0f), Color.Black);
    }

    private static void InstantiateCamera() {
        _camera = new Camera3D {
            Position = new Vector3(_playerPosition.X, _playerPosition.Y + 2, _playerPosition.Z + 6),
            Target = new Vector3(0.0f, 2.0f, 0.0f),
            Up = new Vector3(0.0f, 2.5f, 0.0f),
            FovY = 45.0f,
            Projection = CameraProjection.Perspective
        };
    }

    private static void PlayerController() {
        Single deltaSpeed = PLAYER_SPEED * Raylib.GetFrameTime();
        _playerPosition.Z -= deltaSpeed;

        if (Raylib.IsKeyDown(KeyboardKey.A)) {
            _playerPosition.X -= deltaSpeed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.D)) {
            _playerPosition.X += deltaSpeed;
        }

        UpdateCameraPosition();

        CheckCollisions();
    }

    private static void UpdateCameraPosition() {
        _camera.Target = new Vector3(_camera.Target.X, _camera.Target.Y, _playerPosition.Z);
        _camera.Position = new Vector3(_camera.Position.X, _camera.Position.Y, _playerPosition.Z + 6);
    }

    private static void SpawnController() {
        ObstacleSpawnManager();
        CoinSpawnManager();
    }

    private static void ObstacleSpawnManager() {
        _timeSinceLastObstacleSpawn += Raylib.GetFrameTime();
        Boolean isTimeToSpawn = _timeSinceLastObstacleSpawn >= OBSTACLE_SPAWN_INTERVAL;

        if (isTimeToSpawn) {
            _timeSinceLastObstacleSpawn = 0.0f;
        }

        if (_obstaclesPool.Count < OBSTACLE_POOL_SIZE && isTimeToSpawn) {
            _obstaclesPool.Add(new Vector3(Raylib.GetRandomValue(-5, 5), _playerPosition.Y, _positionWinWall.Z));
        }

        for (Int16 i = 0; i < _obstaclesPool.Count; i++) {
            Vector3 position = _obstaclesPool[i];
            position.Z += OBSTACLE_SPEED * Raylib.GetFrameTime();
            Raylib.DrawCubeV(position, _obstacleSize, Color.Red);
            Raylib.DrawCubeWiresV(position, _obstacleSize, Color.Black);
            if (position.Z > _playerPosition.Z && isTimeToSpawn) {
                position.Z = _positionWinWall.Z;
                position.X = Raylib.GetRandomValue(-5, 5);
                isTimeToSpawn = false;
            }
            _obstaclesPool[i] = position;
        }
    }

    private static void CoinSpawnManager() {
        _timeSinceLastCoinSpawn += Raylib.GetFrameTime();
        Boolean isTimeToSpawn = _timeSinceLastCoinSpawn >= COIN_SPAWN_INTERVAL;

        if (isTimeToSpawn) {
            _timeSinceLastCoinSpawn = 0.0f;
        }

        if (_coinsPool.Count < COIN_POOL_SIZE && isTimeToSpawn) {
            _coinsPool.Add(new Vector3(Raylib.GetRandomValue(-6, 6), _playerPosition.Y, _positionWinWall.Z));
        }

        for (Int16 i = 0; i < _coinsPool.Count; i++) {
            Vector3 position = _coinsPool[i];
            position.Z += COIN_SPEED * Raylib.GetFrameTime();
            Raylib.DrawSphere(position, _coinSize.X, Color.Gold);
            if (position.Z > _playerPosition.Z && isTimeToSpawn) {
                position.Z = _positionWinWall.Z;
                position.X = Raylib.GetRandomValue(-6, 6);
                isTimeToSpawn = false;
            }
            _coinsPool[i] = position;
        }
    }

    private static void CheckCollisions() {
        CheckCollisionsWithObstacles();
        CheckCollisionsWithCoins();
        CheckCollisionsWithWalls();
        CheckCollisionsWithWinWall();
    }

    private static void CheckCollisionsWithObstacles() {
        for (Int16 i = 0; i < _obstaclesPool.Count; i++) {
            Vector3 obstacle = _obstaclesPool[i];
            BoundingBox obstacleBox = new BoundingBox(
                new Vector3(obstacle.X - _obstacleSize.X / 2, obstacle.Y - _obstacleSize.Y / 2, obstacle.Z - _obstacleSize.Z / 2),
                new Vector3(obstacle.X + _obstacleSize.X / 2, obstacle.Y + _obstacleSize.Y / 2, obstacle.Z + _obstacleSize.Z / 2)
            );
            if (Raylib.CheckCollisionBoxSphere(obstacleBox, _playerPosition, _playerSize))
                if (Raylib.CheckCollisionSpheres(_playerPosition, _playerSize, obstacle, _obstacleSize.X)) {
                    _gameState = GameState.GameOver;
                }
        }
    }

    private static void CheckCollisionsWithCoins() {
        for (Int16 i = 0; i < _coinsPool.Count; i++) {
            Vector3 coin = _coinsPool[i];
            if (Raylib.CheckCollisionSpheres(_playerPosition, _playerSize, coin, _coinSize.X)) {
                _playerScore += COIN_VALUE;
                _coinsPool.RemoveAt(i);
            }
        }
    }

    private static void CheckCollisionsWithWalls() {
        BoundingBox wallBox01 = new BoundingBox(
            new Vector3(_positionWall01.X - _sizeWall01.X / 2, _positionWall01.Y - _sizeWall01.Y / 2, _positionWall01.Z - _sizeWall01.Z / 2),
            new Vector3(_positionWall01.X + _sizeWall01.X / 2, _positionWall01.Y + _sizeWall01.Y / 2, _positionWall01.Z + _sizeWall01.Z / 2)
        );

        BoundingBox wallBox02 = new BoundingBox(
            new Vector3(_positionWall02.X - _sizeWall02.X / 2, _positionWall02.Y - _sizeWall02.Y / 2, _positionWall02.Z - _sizeWall02.Z / 2),
            new Vector3(_positionWall02.X + _sizeWall02.X / 2, _positionWall02.Y + _sizeWall02.Y / 2, _positionWall02.Z + _sizeWall02.Z / 2)
        );

        if (Raylib.CheckCollisionBoxSphere(wallBox01, _playerPosition, _playerSize) || Raylib.CheckCollisionBoxSphere(wallBox02, _playerPosition, _playerSize)) {
            _gameState = GameState.GameOver;
        }
    }

    private static void CheckCollisionsWithWinWall() {
        BoundingBox winWallBox = new BoundingBox(
            new Vector3(_positionWinWall.X - _sizeWinWall.X / 2, _positionWinWall.Y - _sizeWinWall.Y / 2, _positionWinWall.Z - _sizeWinWall.Z / 2),
            new Vector3(_positionWinWall.X + _sizeWinWall.X / 2, _positionWinWall.Y + _sizeWinWall.Y / 2, _positionWinWall.Z + _sizeWinWall.Z / 2)
        );

        if (Raylib.CheckCollisionBoxSphere(winWallBox, _playerPosition, _playerSize)) {
            _gameState = GameState.Win;
        }
    }

    private static void ResetGame() {
        _playerPosition = new Vector3(0.0f, 1.0f, 65.0f);
        _playerScore = 0;
        _obstaclesPool.Clear();
        _coinsPool.Clear();
        _timeSinceLastObstacleSpawn = 0.0f;
        _timeSinceLastCoinSpawn = 0.0f;
    }

    static void DrawInterface() {
        Raylib.DrawText($"SCORE : {_playerScore:000000}", 10, 10, 20, Color.Green);
        Raylib.DrawText("Move Keys : A & D ", 10, 30, 20, Color.Green);
    }

    static void CheckRetry() {
        if (_gameState == GameState.Win)
            Raylib.DrawText("YOU WIN!", 320, 70, 30, Color.Green);
        else
            Raylib.DrawText("¡Game Over!", 300, 70, 30, Color.Red);


        Raylib.DrawText($"Your Score : {_playerScore:000000}", 300, 150, 20, Color.Black);
        Int16 highScore = CheckScore(_playerScore);
        Raylib.DrawText($"High Score : {highScore:000000}", 300, 170, 20, Color.Black);

        Raylib.DrawText("Press R to restart", 250, 250, 30, Color.Red);
        Raylib.DrawText("Press Esc to exit", 260, 280, 30, Color.Red);
        Raylib.DrawText("Author Daniel Fimiani", 300, 400, 20, Color.Black);
        Raylib.DrawText("Taller de desarrollo de videojuegos", 270, 430, 15, Color.Black);


        if (Raylib.IsKeyPressed(KeyboardKey.R)) {
            ResetGame();
            _gameState = GameState.Playing;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Escape)) {
            _gameState = GameState.Exit;
        }
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
