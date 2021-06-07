using System;
using System.Collections.Generic;
using Raylib_cs;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //BOARD REC LIST
            List<Rectangle> recList = new List<Rectangle>();
            CreateBoard(recList);

            //BOARD INT LIST
            List<Int32> boardList = new List<Int32>();
            EmptyBoard(boardList);

            //PLAYER
            int player = 1;
            bool gameOver = false;

            //GAME
            int screenWidth = 800;
            int screenHeight = 600;
            Raylib.InitWindow(screenWidth, screenHeight, "Tic Tac Toe");

            while (!Raylib.WindowShouldClose())
            {
                Rectangle playerRec = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 20, 20);
                InitRaylib();
                DrawBoard(recList);

                //CHECK COLLISION ON BOARD AND CHANGE VALUE DEPENDING ON WHICH PLAYER CHOOSES A SQUARE
                for (int i = 0; i < boardList.Count; i++)
                {
                    if (boardList[i] == 0 && gameOver == false)
                    {
                        if (Raylib.CheckCollisionRecs(playerRec, recList[i]) && Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                        {
                            if (player == 1)
                            {
                                boardList[i] = 1;
                                if (CheckWin(boardList) || CheckDraw(boardList))
                                {
                                    gameOver = true;
                                }

                                player = 2;
                            }
                            else if (player == 2)
                            {
                                boardList[i] = 2;
                                if (CheckWin(boardList))
                                {
                                    gameOver = true;
                                }
                                player = 1;
                            }
                        }
                    }
                }

                //DRAW THE RESULT
                for (int i = 0; i < boardList.Count; i++)
                {
                    if (boardList[i] == 1)
                    {
                        Raylib.DrawRectangle((int)recList[i].x, (int)recList[i].y, 100, 100, Color.RED);
                    }
                    else if (boardList[i] == 2)
                    {
                        Raylib.DrawRectangle((int)recList[i].x, (int)recList[i].y, 100, 100, Color.GREEN);
                    }
                }

                if (gameOver == true)
                {
                    if (CheckWin(boardList) == true)
                    {
                        if (player == 2)
                        {
                            Raylib.DrawText("PLAYER 1 WINS!", 180, 10, 64, Color.RED);
                        }
                        else if (player == 1)
                        {
                            Raylib.DrawText("PLAYER 2 WINS!", 180, 10, 64, Color.GREEN);
                        }
                    }
                    if (CheckDraw(boardList) == true && CheckWin(boardList) == false)
                    {
                        Raylib.DrawText("IT'S A DRAW!", 180, 10, 64, Color.WHITE);
                    }

                    Raylib.DrawText("Press SPACE to exit", 100, 550, 16, Color.WHITE);
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        break;
                    }
                }

            }
        }

        static void CreateBoard(List<Rectangle> list)
        {
            for (int i = 1; i < 10; i++)
            {
                if (i > 0 && i < 4)
                {
                    list.Add(new Rectangle(100 + i * 125, 100, 100, 100));
                }
                if (i > 3 && i < 7)
                {
                    list.Add(new Rectangle(100 + i * 125 - 375, 225, 100, 100));
                }
                if (i > 6 && i < 10)
                {
                    list.Add(new Rectangle(100 + i * 125 - 750, 350, 100, 100));
                }
            }
        }

        static void EmptyBoard(List<Int32> list)
        {
            for (int i = 0; i < 9; i++)
            {
                list.Add(0);
            }
        }

        static void DrawBoard(List<Rectangle> list)
        {
            foreach (Rectangle rec in list)
            {
                Raylib.DrawRectangleRec(rec, Color.WHITE);
            }
        }

        static bool CheckWin(List<Int32> list)
        {
            //HORIZONTAL WIN CHECK
            if (list[0] == list[1] && list[1] == list[2] && list[0] != 0)
            {
                return true;
            }
            if (list[3] == list[4] && list[4] == list[5] && list[3] != 0)
            {
                return true;
            }
            if (list[6] == list[7] && list[7] == list[8] && list[6] != 0)
            {
                return true;
            }
            //VERTICAL WIN CHECK
            if (list[0] == list[3] && list[3] == list[6] && list[0] != 0)
            {
                return true;
            }
            if (list[1] == list[4] && list[4] == list[7] && list[1] != 0)
            {
                return true;
            }
            if (list[2] == list[5] && list[5] == list[8] && list[2] != 0)
            {
                return true;
            }
            //HORIZONTAL WIN CHECK
            if (list[0] == list[4] && list[4] == list[8] && list[0] != 0)
            {
                return true;
            }
            if (list[2] == list[4] && list[4] == list[6] && list[2] != 0)
            {
                return true;
            }
            return false;
        }

        static bool CheckDraw(List<Int32> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void InitRaylib()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Raylib.EndDrawing();
        }
    }
}
