#include <iostream>

using namespace std;

enum Entities
{
    PlayerEntity,
    Dirt,
    Sand,
    Tree,
    Crystal_Hearth,
    Hole,
    Exit,
};

enum GameStates
{
    Playing,
    GameOver,
    Win,
};

struct Vector2
{
    int x, y;
};

struct Player
{
    Vector2 position;
    bool hasHearth;
    Player(int x, int y)
    {
        position.x = x;
        position.y = y;
        hasHearth = false;
    }
};

bool check_restart();
void draw_board(Entities forest[10][10], Player player);
void check_player_input(Player &player, Entities forest[10][10], GameStates &gameState);
void set_color(int textColor);
void reset_color();

int main()
{
    do
    {
        GameStates gameState = Playing;
        Player player(0, 0);

        Entities forest[10][10] = {
            {PlayerEntity, Dirt, Tree, Tree, Tree, Tree, Tree, Tree, Tree, Tree},
            {Dirt, Dirt, Dirt, Dirt, Dirt, Sand, Sand, Hole, Hole, Tree},
            {Tree, Tree, Hole, Sand, Dirt, Dirt, Sand, Tree, Sand, Tree},
            {Tree, Sand, Sand, Sand, Sand, Dirt, Hole, Dirt, Dirt, Tree},
            {Tree, Dirt, Dirt, Dirt, Dirt, Dirt, Sand, Sand, Dirt, Tree},
            {Tree, Dirt, Sand, Tree, Sand, Dirt, Tree, Sand, Dirt, Tree},
            {Tree, Dirt, Dirt, Dirt, Dirt, Hole, Sand, Sand, Dirt, Tree},
            {Tree, Dirt, Sand, Sand, Dirt, Dirt, Dirt, Dirt, Dirt, Dirt},
            {Tree, Dirt, Tree, Hole, Dirt, Sand, Sand, Sand, Sand, Dirt},
            {Tree, Exit, Tree, Tree, Tree, Tree, Tree, Tree, Hole, Crystal_Hearth}};

        while (gameState == Playing)
        {
            draw_board(forest, player);

            check_player_input(player, forest, gameState);
        }

    } while (check_restart());
}

bool check_restart()
{
    char restart;
    cout << "Do you want to restart the game? (y/n): ";
    cin >> restart;
    return restart == 'y';
}

void check_player_input(Player &player, Entities forest[10][10], GameStates &gameState)
{
    Vector2 nextPos = player.position;
    char input;
    cout << "Enter your move (w, a, s, d): ";
    cin >> input;

    switch (input)
    {
    case 'w':
        if (player.position.x > 0)
        {
            nextPos.x--;
        }
        break;
    case 'a':
        if (player.position.y > 0)
        {
            nextPos.y--;
        }
        break;
    case 's':
        if (player.position.x < 9)
        {
            nextPos.x++;
        }
        break;
    case 'd':
        if (player.position.y < 9)
        {
            nextPos.y++;
        }
        break;
    }

    if (forest[nextPos.x][nextPos.y] == Tree)
    {
        cout << "You can't move there!" << endl;
    }
    else if (forest[nextPos.x][nextPos.y] == Hole)
    {
        cout << "You fell into a hole!" << endl;
        gameState = GameOver;
    }
    else if (forest[nextPos.x][nextPos.y] == Crystal_Hearth)
    {
        cout << "You found the crystal hearth!" << endl;
        player.hasHearth = true;
        forest[nextPos.x][nextPos.y] = PlayerEntity;
        player.position = nextPos;
    }
    else if (forest[nextPos.x][nextPos.y] == Exit)
    {
        if (player.hasHearth)
        {
            cout << "You won the game!" << endl;
            gameState = Win;
        }
        else
        {
            cout << "You need the crystal hearth to exit!" << endl;
        }
    }
    else
    {
        forest[player.position.x][player.position.y] = Dirt;
        forest[nextPos.x][nextPos.y] = PlayerEntity;
        player.position = nextPos;
    }
}

void draw_board(Entities forest[10][10], Player player)
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            switch (forest[i][j])
            {
            case PlayerEntity:
                cout << "P ";
                break;
            case Dirt:
                set_color(95);
                cout << "X ";
                break;
            case Sand:
                cout << "S ";
                break;
            case Tree:
                set_color(92);
                cout << "T ";
                break;
            case Crystal_Hearth:
                if (player.hasHearth)
                {
                    set_color(95);
                    cout << "X ";
                }
                else
                {
                    set_color(31);
                    cout << "H ";
                }
                break;
            case Hole:
                set_color(96);
                cout << "O ";
                break;
            case Exit:
                set_color(33);
                cout << "E ";
                break;
            }
            reset_color();
        }
        cout << endl;
    }
}

/*
30	Black	90	Bright Black
31	Red	91	Bright Red
32	Green	92	Bright Green
33	Yellow	93	Bright Yellow
34	Blue	94	Bright Blue
35	Magenta	95	Bright Magenta
36	Cyan	96	Bright Cyan
37	White	97	Bright White
*/
void set_color(int textColor)
{
    cout << "\033[" << textColor << "m";
}

// Function to reset the console color
void reset_color() { cout << "\033[0m"; }