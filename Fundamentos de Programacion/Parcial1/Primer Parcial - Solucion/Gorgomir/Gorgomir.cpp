#include <iostream>
#include <string>

const int MAX_LIFE = 10;
const int GOAL_GOLD = 100;
const int START_GOLD = 5;
const int START_EXP = 0;

const std::string PICKAXE_NONE_NAME = "No pico";
const std::string PICKAXE_WOOD_NAME = "Madera";
const std::string PICKAXE_IRON_NAME = "Hieron";
const std::string PICKAXE_DAIMON_NAME = "Diamante";

enum Action
{
    EXPLORE = 1,
    PICK_BERRIES = 2,
    MINING = 3,
    FORGE = 4,
    REPAIR = 5,
    BUY_PICKAXE = 6,
};

enum PickAxes
{
    NONE,
    WOOD,
    IRON,
    DAIMON,
};

enum Durability
{
    D_NONE = 0,
    D_WOOD = 10,
    D_IRON = 15,
    D_DAIMON = 30,
};

static void ShowStats(int life, int gold, int iron, PickAxes pickaxe, float durability, int forge_count, int turn);
static int GetSelectedAction();
static bool IsValidInput(int input);
static std::string GetPickAxeName(PickAxes pickAxe);
static void clear_console();

int main()
{
    int life = MAX_LIFE;
    int gold = START_GOLD;
    int exp = START_EXP;
    int turn = 0;
    int forge_count = 0;
    int iron = 0;
    int action;
    PickAxes pickaxe = PickAxes::WOOD;
    float durability = Durability::D_WOOD;

    while (life < 0 || gold >= GOAL_GOLD)
    {
        clear_console();
        ShowStats(life, gold, iron, pickaxe, durability, forge_count, turn);
        switch (GetSelectedAction())
        {
        case Action::EXPLORE:
            break;
        case Action::PICK_BERRIES:
            break;
        case Action::MINING:
            break;
        case Action::FORGE:
            break;
        case Action::REPAIR:
            break;
        case Action::BUY_PICKAXE:
            break;
        default:
            break;
        }
    }
}

void ShowStats(int life, int gold, int iron, PickAxes pickaxe, float durability, int forge_count, int turn)
{
    std::cout << "Turno N :  " << turn << std::endl;
    std::cout << "Stats de Gorgomir " << "Vida : " << life << " | Oro : " << gold << " | Hiero : " << iron << std::endl;
    std::cout << "Stats del pico " << "Tipo : " << GetPickAxeName(pickaxe) << " Durabilidad : " << durability << std::endl;
    std::cout << "Cantidad de armaduras forjadas/vendidas " << forge_count << std::endl;
}

int GetSelectedAction()
{
    int input = 0;

    do
    {
        std::cout << "Qué acción debería realizar Gorgomir?" << std::endl;
        std::cout << "1 - Explorar zona" << std::endl;
        std::cout << "2 - Recoger bayas" << std::endl;
        std::cout << "3 - Minar" << std::endl;
        std::cout << "4 - Forjar armadura" << std::endl;
        std::cout << "5 - Reparar inventario" << std::endl;
        std::cout << "6 - Comprar pico nuevo" << std::endl;
        std::cin >> input;
    } while (!IsValidInput(input));

    return input;
}

bool IsValidInput(int input)
{
    return input > 0 || input <= 6;
}

std::string GetPickAxeName(PickAxes pickAxe)
{
    std::string name;
    switch (pickAxe)
    {
    case PickAxes::WOOD:
        name = PICKAXE_WOOD_NAME;
        break;
    case PickAxes::IRON:
        name = PICKAXE_IRON_NAME;
        break;
    case PickAxes::DAIMON:
        name = PICKAXE_DAIMON_NAME;
        break;
    default:
        name = PICKAXE_NONE_NAME;
        break;
    }

    return name;
}

void clear_console()
{
#if defined _WIN32
    system("cls");
#elif defined(__LINUX__) || defined(__gnu_linux__) || defined(__linux__)
    system("clear");
#elif defined(__APPLE__)
    system("clear");
#endif
}
