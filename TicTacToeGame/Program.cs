using System;
using Raylib_cs;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //GAME
            int screenWidth = 800;
            int screenHeight = 600;
            Raylib.InitWindow(screenWidth, screenHeight, "Tic Tac Toe");

            while (!Raylib.WindowShouldClose())
            {
                Rectangle playerRec = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 20, 20);
                Raylib.DrawRectangleRec(playerRec, Color.GREEN);
                InitRaylib();
                DrawBoard();
            }
        }
        static void DrawBoard()
        {
            for (int i = 1; i < 10; i++)
            {
                if (i > 0 && i < 4)
                {
                    Raylib.DrawRectangle(100 + i * 125, 100, 100, 100, Color.WHITE);
                }
                if (i > 3 && i < 7)
                {
                    Raylib.DrawRectangle(100 + i * 125 - 375, 225, 100, 100, Color.WHITE);
                }
                if (i > 6 && i < 10)
                {
                    Raylib.DrawRectangle(100 + i * 125 - 750, 350, 100, 100, Color.WHITE);
                }
            }
        }
        static void InitRaylib()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Raylib.EndDrawing();
        }
    }
}
