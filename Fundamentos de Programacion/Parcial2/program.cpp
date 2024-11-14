#include <iostream>
#include <conio.h>

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
void check_player_input(char input, Player &player, Entities forest[10][10], GameStates &gameState);
void set_color(int textColor);
void reset_color();
void clear_console();

int main()
{
    do
    {
        GameStates gameState = Playing;
        Player player(0, 0);

        Entities forest[10][10] = {
            {Dirt, Dirt, Tree, Tree, Tree, Tree, Tree, Tree, Tree, Tree},
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
            while (!kbhit())
                draw_board(forest, player);
            
            char input = getch();
            check_player_input(input, player, forest, gameState);
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

void check_player_input(char input, Player &player, Entities forest[10][10], GameStates &gameState)
{
    Vector2 nextPos = player.position;
    clear_console();

    switch (tolower(input))
    {
    case 'w':
        nextPos.x = max(nextPos.x - 1, 0);
        break;
    case 'a':
        nextPos.y = max(nextPos.y - 1, 0);
        break;
    case 's':
        nextPos.x = min(nextPos.x + 1, 9);
        break;
    case 'd':
        nextPos.y = min(nextPos.y + 1, 9);
        break;
    }

    switch (forest[nextPos.x][nextPos.y])
    {
    case Tree:
        cout << "You can't move there!" << endl;
        break;
    case Sand:
        if (player.hasHearth)
        {
            cout << "Oh no ! You break the hearth" << endl;
            gameState = GameOver;
        }
        else
        {
            player.position = nextPos;
        }
        break;
    case Hole:
        cout << "You fell into a hole!" << endl;
        gameState = GameOver;
        break;
    case Crystal_Hearth:
        cout << "You found the crystal hearth!" << endl;
        player.hasHearth = true;
        player.position = nextPos;
        break;
    case Exit:
        if (player.hasHearth)
        {
            cout << "You won the game!" << endl;
            gameState = Win;
        }
        else
        {
            cout << "You need the crystal hearth to exit!" << endl;
        }
        break;
    default:
        player.position = nextPos;
        break;
    }
}

void draw_board(Entities forest[10][10], Player player)
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            if (player.position.x == i && player.position.y == j)
            {
                if (player.hasHearth)
                {
                    set_color(31);
                };
                cout << "P ";
                continue;
            }
            switch (forest[i][j])
            {
            case Dirt:
                set_color(95);
                cout << "X ";
                break;
            case Sand:
                set_color(34);
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

void reset_color() { cout << "\033[0m"; }

void clear_console()
{
    cout << "\033[2J\033[1;1H";
}