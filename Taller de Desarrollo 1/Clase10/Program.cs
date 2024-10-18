using System.Numerics;
using Raylib_cs;

namespace Clase10
{
    class Program
    {
        static void Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 800;
            const int screenHeight = 450;

            Raylib.InitWindow(screenWidth, screenHeight, "raylib [textures] example - background scrolling");

            // NOTE: Be careful, background width must be equal or bigger than screen width
            // if not, texture should be draw more than two times for scrolling effect
            Texture2D background = Raylib.LoadTexture("/Users/dfimiani/Develop/image-campus/Taller de Desarrollo 1/Clase10/resources/Cyberpunk Street Background.png");
            Texture2D midground = Raylib.LoadTexture("/Users/dfimiani/Develop/image-campus/Taller de Desarrollo 1/Clase10/resources/Cyberpunk Street Midground.png");
            Texture2D foreground = Raylib.LoadTexture("/Users/dfimiani/Develop/image-campus/Taller de Desarrollo 1/Clase10/resources/Cyberpunk Street Foreground.png");

            float scrollingBack = 0.0f;
            float scrollingMid = 0.0f;
            float scrollingFore = 0.0f;

            Raylib.SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
                                                   //--------------------------------------------------------------------------------------

            // Main game loop
            while (!Raylib.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                scrollingBack -= 0.1f;
                scrollingMid -= 0.5f;
                scrollingFore -= 1.0f;

                // NOTE: Texture is scaled twice its size, so it sould be considered on scrolling
                if (scrollingBack <= -background.Width * 2) scrollingBack = 0;
                if (scrollingMid <= -midground.Width * 2) scrollingMid = 0;
                if (scrollingFore <= -foreground.Width * 2) scrollingFore = 0;
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                Raylib.BeginDrawing();

                Raylib.ClearBackground(Raylib.GetColor(0x052c46ff));

                // Draw background image twice
                // NOTE: Texture is scaled twice its size
                Raylib.DrawTextureEx(background, new Vector2(scrollingBack, 20), 0.0f, 2.0f, Color.White);
                Raylib.DrawTextureEx(background, new Vector2(background.Width * 2 + scrollingBack, 20 ), 0.0f, 2.0f, Color.White);

                // Draw midground image twice
                Raylib.DrawTextureEx(midground, new Vector2(scrollingMid, 20 ), 0.0f, 2.0f, Color.White);
                Raylib.DrawTextureEx(midground, new Vector2(midground.Width * 2 + scrollingMid, 20 ), 0.0f, 2.0f, Color.White);

                // Draw foreground image twice
                Raylib.DrawTextureEx(foreground, new Vector2(scrollingFore, 70 ), 0.0f, 2.0f, Color.White);
                Raylib.DrawTextureEx(foreground, new Vector2(foreground.Width * 2 + scrollingFore, 70 ), 0.0f, 2.0f, Color.White);

                Raylib.DrawText("BACKGROUND SCROLLING & PARALLAX", 10, 10, 20, Color.Red);
                Raylib.DrawText("(c) Cyberpunk Street Environment by Luis Zuno (@ansimuz)", screenWidth - 330, screenHeight - 20, 10, Color.RayWhite);

                Raylib.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            Raylib.UnloadTexture(background);  // Unload background texture
            Raylib.UnloadTexture(midground);   // Unload midground texture
            Raylib.UnloadTexture(foreground);  // Unload foreground texture

            Raylib.CloseWindow();              // Close window and OpenGL context
            //--------------------------------------------------------------------------------------
        }
    }
}