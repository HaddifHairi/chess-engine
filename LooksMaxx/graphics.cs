using Raylib_cs;

const int tileSize = 80;
const int boardSize = tileSize * 8;

Raylib.InitWindow(boardSize, boardSize, "Chess Engine");
Raylib.SetTargetFPS(60);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);

    for (int rank = 0; rank < 8; rank++)
    {
        for (int file = 0; file < 8; file++)
        {
            bool isLight = (rank + file) % 2 == 0;

            Color squareColor = isLight
                ? new Color(240, 217, 181, 255)
                : new Color(181, 136, 99, 255);

            Raylib.DrawRectangle(
                file * tileSize,
                rank * tileSize,
                tileSize,
                tileSize,
                squareColor
            );
        }
    }

    Raylib.EndDrawing();
}

Raylib.CloseWindow();