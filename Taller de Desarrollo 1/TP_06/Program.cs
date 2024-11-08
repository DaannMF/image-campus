using System;
using Raylib_cs;
using System.Numerics;

public class TP_06
{

    const int MAX_COLUMNS = 20;

    static void Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        Raylib.InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera first person");

        // Define the camera to look into our 3d world (position, target, up vector)
        Camera3D camera = new();
        camera.Position = new Vector3( 0.0f, 2.0f, 4.0f );    // Camera position
        camera.Target = new Vector3 ( 0.0f, 2.0f, 0.0f );      // Camera looking at point
        camera.Up = new Vector3( 0.0f, 1.0f, 0.0f );          // Camera up vector (rotation towards target)
        camera.FovY = 60.0f;                                // Camera field-of-view Y
        camera.Projection = CameraProjection.Perspective;   // Camera projection type

        CameraMode cameraMode = CameraMode.FirstPerson;

        // Generates some random columns
        Single[] heights = new Single[MAX_COLUMNS];
        Vector3[] positions = new Vector3[MAX_COLUMNS];
        Color[] colors = new Color[MAX_COLUMNS];

        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            heights[i] = Raylib.GetRandomValue(1, 12);
            positions[i] = new Vector3(Raylib.GetRandomValue(-15, 15), heights[i] / 2.0f, Raylib.GetRandomValue(-15, 15) );
            colors[i] = new Color(Raylib.GetRandomValue(20, 255), Raylib.GetRandomValue(10, 55), 30, 255);
        }

        Raylib.DisableCursor();                    // Limit cursor to relative movement inside the window

        Raylib.SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
                                            //--------------------------------------------------------------------------------------

        // Main game loop
        while (!Raylib.WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Update camera computes movement internally depending on the camera mode
            // Some default standard keyboard/mouse inputs are hardcoded to simplify use
            // For advance camera controls, it's reecommended to compute camera movement manually
            Raylib.UpdateCamera(ref camera, CameraMode.ThirdPerson);

            // Draw
            //----------------------------------------------------------------------------------
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RayWhite);

            Raylib.BeginMode3D(camera);

            // Draw some cubes around
            for (int i = 0; i < MAX_COLUMNS; i++)
            {
                Raylib.DrawCube(positions[i], 2.0f, heights[i], 2.0f, colors[i]);
                Raylib.DrawCubeWires(positions[i], 2.0f, heights[i], 2.0f, Color.Maroon);
            }

            
            Raylib.DrawCube(camera.Target, 0.5f, 0.5f, 0.5f, Color.Purple);
            Raylib.DrawCubeWires(camera.Target, 0.5f, 0.5f, 0.5f, Color.DarkPurple);
            
            Raylib.EndMode3D();

            // Draw info boxes
            Raylib.DrawRectangle(5, 5, 330, 100, Raylib.Fade(Color.SkyBlue, 0.5f));
            Raylib.DrawRectangleLines(5, 5, 330, 100, Color.Blue);

            Raylib.DrawText("Camera controls:", 15, 15, 10, Color.Black);
            Raylib.DrawText("- Move keys: W, A, S, D, Space, Left-Ctrl", 15, 30, 10, Color.Black);
            Raylib.DrawText("- Look around: arrow keys or mouse", 15, 45, 10, Color.Black);
            Raylib.DrawText("- Camera mode keys: 1, 2, 3, 4", 15, 60, 10, Color.Black);
            Raylib.DrawText("- Zoom keys: num-plus, num-minus or mouse scroll", 15, 75, 10, Color.Black);
            Raylib.DrawText("- Camera projection key: P", 15, 90, 10, Color.Black);

            Raylib.DrawRectangle(600, 5, 195, 100, Raylib.Fade(Color.SkyBlue, 0.5f));
            Raylib.DrawRectangleLines(600, 5, 195, 100, Color.Blue);

            Raylib.EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        Raylib.CloseWindow();        // Close window and OpenGL context
                              //-------------------------------------------------------------------------------------
    }
}
