using System.Numerics;
using Raylib_cs;

namespace Clase11;

class Program
{
    static readonly Int16 _screenWidth = 1240;
    static readonly Int16 _screenHeight = 720;
    static Rectangle _player = new(400, 560, 40, 40);
    static readonly Int16 _speed = 100;
    static float _cameraZoom = 1;
    static float _cameraRotation = 0;
    static readonly float _cameraLimit = -26f;
    static Camera2D _camera = new()
    {
        Target = new Vector2(_player.X, _player.Y),
        Offset = new Vector2(_screenWidth / 2, _screenHeight / 2),
        Rotation = _cameraRotation,
        Zoom = _cameraZoom
    };

    public static void Main()
    {
        Raylib.SetTargetFPS(60);

        Raylib.InitWindow(_screenWidth, _screenHeight, "Hello World");

        while (!Raylib.WindowShouldClose())
        {
            CameraController();
            PlayerController();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.SkyBlue);

            Raylib.BeginMode2D(_camera);

            DrawSky();

            Raylib.DrawRectangle(-6000, 600, 13000, 8000, Color.DarkGreen);

            Raylib.DrawRectangleRec(_player, Color.Purple);

            Raylib.EndMode2D();

            DrawInterFace();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }


    static void DrawInterFace()
    {
        Raylib.DrawText("Ejemplo camara 2D", 640, 10, 20, Color.Red);
        Raylib.DrawRectangle(0, 0, _screenWidth, 5, Color.Red);
        Raylib.DrawRectangle(0, 5, 5, _screenHeight - 10, Color.Red);
        Raylib.DrawRectangle(_screenWidth - 5, 5, 5, _screenHeight - 10, Color.Red);
        Raylib.DrawRectangle(0, _screenHeight - 5, _screenWidth, 5, Color.Red);

        Raylib.DrawText("Controles de la cámara:", 20, 20, 12, Color.Black);
        Raylib.DrawText("-Flechas para mover al jugador-", 40, 40, 12, Color.Black);
        Raylib.DrawText("-Usar la rueda del mouse para hacer zoom-", 40, 60, 12, Color.Black);
        Raylib.DrawText("-A y D para la rotación de la camara-", 40, 80, 12, Color.Black);
        Raylib.DrawText("-Espacio para saltar-", 40, 100, 12, Color.Black);
    }

    static void DrawSky()
    {
        Raylib.DrawRectangle(100, 0, 100, _screenHeight, Color.Blue);
        Raylib.DrawRectangle(500, 0, 100, _screenHeight, Color.Blue);
    }

    static Boolean isGrounded = true;
    static float verticalSpeed = 0;
    const float JUMP_FORCE = 6f;
    const float GRAVITY = 0.1f;

    static void PlayerController()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Space) && isGrounded)
        {
            verticalSpeed = -JUMP_FORCE;
            isGrounded = false;
        }

        if (Raylib.IsKeyDown(KeyboardKey.Left))
            _player.X -= _speed * Raylib.GetFrameTime();


        if (Raylib.IsKeyDown(KeyboardKey.Right))
            _player.X += _speed * Raylib.GetFrameTime();

        if (!isGrounded)
        {
            _player.Y += verticalSpeed;
            verticalSpeed += GRAVITY;
            
            if (_player.Y >= 560)
            {
                _player.Y = 560;
                isGrounded = true;
                verticalSpeed = 0;
            }
        }
    }

    static void CameraController()
    {
        if (Raylib.IsKeyDown(KeyboardKey.A))
            _cameraRotation -= 10 * Raylib.GetFrameTime();


        if (Raylib.IsKeyDown(KeyboardKey.D))
            _cameraRotation += 10 * Raylib.GetFrameTime();

        _cameraZoom += Raylib.GetMouseWheelMove() * Raylib.GetFrameTime();
        _cameraZoom = Math.Min(Math.Max(_cameraZoom, 0.63f), 3f);
        _cameraRotation = Math.Min(Math.Max(_cameraRotation, _cameraLimit), -_cameraLimit);
        _camera.Target = _player.Position;
        _camera.Zoom = _cameraZoom;
        _camera.Rotation = _cameraRotation;
    }
}