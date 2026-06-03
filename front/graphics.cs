using Raylib_cs;
using System.Collections.Generic;

const int tileSize = 80;
const int boardSize = tileSize * 8;

Raylib.InitWindow(boardSize, boardSize, "Chess");
Raylib.SetTargetFPS(60);

// example board
char[,] board =
{
    { 'r','n','b','q','k','b','n','r' },
    { 'p','p','p','p','p','p','p','p' },
    { '.','.','.','.','.','.','.','.' },
    { '.','.','.','.','.','.','.','.' },
    { '.','.','.','.','.','.','.','.' },
    { '.','.','.','.','.','.','.','.' },
    { 'P','P','P','P','P','P','P','P' },
    { 'R','N','B','Q','K','B','N','R' }
};

// load textures AFTER InitWindow
Dictionary<char, Texture2D> textures = new()
{
    ['P'] = Raylib.LoadTexture("Images/Chess_blt60.png"),
    ['N'] = Raylib.LoadTexture("Images/Chess_nlt60.png"),
    ['B'] = Raylib.LoadTexture("Images/Chess_blt60.png"),
    ['R'] = Raylib.LoadTexture("Images/Chess_rlt60.png"),
    ['Q'] = Raylib.LoadTexture("Images/Chess_qlt60.png"),
    ['K'] = Raylib.LoadTexture("Images/Chess_klt60.png"),

    ['p'] = Raylib.LoadTexture("Images/Chess_bdt60.png"),
    ['n'] = Raylib.LoadTexture("Images/Chess_ndt60.png"),
    ['b'] = Raylib.LoadTexture("Images/Chess_bdt60.png"),
    ['r'] = Raylib.LoadTexture("Images/Chess_rdt60.png"),
    ['q'] = Raylib.LoadTexture("Images/Chess_qdt60.png"),
    ['k'] = Raylib.LoadTexture("Images/Chess_kdt60.png"),
};

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);

    // draw board
    for (int rank = 0; rank < 8; rank++)
    {
        for (int file = 0; file < 8; file++)
        {
            bool isLight = (rank + file) % 2 == 0;

            Color color = isLight
                ? new Color(240, 217, 181, 255)
                : new Color(181, 136, 99, 255);

            Raylib.DrawRectangle(
                file * tileSize,
                rank * tileSize,
                tileSize,
                tileSize,
                color
            );
        }
    }

    // draw pieces
    for (int rank = 0; rank < 8; rank++)
    {
        for (int file = 0; file < 8; file++)
        {
            char piece = board[rank, file];

            if (piece == '.')
                continue;

            Texture2D texture = textures[piece];

            Rectangle source = new Rectangle(
                0,
                0,
                texture.Width,
                texture.Height
            );

            Rectangle dest = new Rectangle(
                file * tileSize,
                rank * tileSize,
                tileSize,
                tileSize
            );

            Raylib.DrawTexturePro(
                texture,
                source,
                dest,
                new System.Numerics.Vector2(0, 0),
                0f,
                Color.White
            );
        }
    }

    Raylib.EndDrawing();
}

// unload textures
foreach (Texture2D texture in textures.Values)
{
    Raylib.UnloadTexture(texture);
}

Raylib.CloseWindow();