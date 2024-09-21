#include <iostream>
#include <string>

const int MAX_LIFE = 10;
const int GOAL_GOLD = 100;
const int START_GOLD = 5;
const int START_EXP = 0;

const std::string PICKAXE_NONE_NAME = "No pico";
const std::string PICKAXE_WOOD_NAME = "Madera";
const std::string PICKAXE_IRON_NAME = "Hierro";
const std::string PICKAXE_DAIMON_NAME = "Diamante";

const int EXPLORE_CHANCE = 10;
const int PICK_BERRIES_CHANCE = 30;
const int NFT_CHANCE = 5;
const int MINING_TRIES = 4;


const int BERRIES_RESTORE_POINTS = 3;
const int MIN_LIFE_TO_MINE = 4;
const float MINING_DAMAGE = 0.5f;
const int FORGE_COST = 2;
const int FORGE_PRICE = 30;
const int MIN_IRON_TO_FORGE = 2;

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

enum Prices {
    P_NONE = 0,
    P_WOOD = 5,
    P_IRON = 10,
    P_DAIMON = 20,
    P_NFT = 10,
};

enum Chance
{
    CH_NONE = 0,
    CH_WOOD = 30,
    CH_IRON = 50,
    CH_DAIMON = 60,
};

static void ShowStats(int life, int gold, int iron, PickAxes pickaxe, float durability, int forge_count, int turn, int exp);
static int GetSelectedAction();
static bool IsValidInput(int input);
static std::string GetPickAxeName(PickAxes pickAxe);
static int GetPickAxeChance(PickAxes pickAxe);
float GetPickAxeDurabilty(PickAxes pickAxe);
static int GetPickAxePrice(PickAxes pickAxe);
static bool GetChance(int chance);
static int GetRandomNumber(int min, int max);
static void Explore(int &gold, int &life, bool &is_chance_meet);
static void PickBerries(int &life, bool &is_chance_meet);
static void Mining(int &life, float &durability, PickAxes &pickAxe, int &exp, int &iron, bool &is_chance_meet);
static void Forge(int &gold, int &iron);
static void Repair(int &gold, int &turn, PickAxes &pickAxes, float &durability);
static void BuyNewPickAxe(int &gold, PickAxes &pickAxe, float &durability);
static void NFT(int &gold, bool &is_chance_meet);
static void ShowFinalGame(int life, int gold, int turn);
static void clear_console();

int main()
{
    int life = MAX_LIFE;
    int gold = START_GOLD;
    int exp = START_EXP;
    int turn = 1;
    int forge_count = 0;
    int iron = 0;
    PickAxes pickaxe = PickAxes::WOOD;
    float durability = Durability::D_WOOD;
    bool is_chance_meet;

    while (life > 0 && gold <= GOAL_GOLD)
    {
        is_chance_meet = false;
        clear_console();
        ShowStats(life, gold, iron, pickaxe, durability, forge_count, turn, exp);
        switch (GetSelectedAction())
        {
        case Action::EXPLORE:
            Explore(gold, life, is_chance_meet);
            break;
        case Action::PICK_BERRIES:
            PickBerries(life, is_chance_meet);
            break;
        case Action::MINING:
            Mining(life, durability, pickaxe, exp, iron, is_chance_meet);
            break;
        case Action::FORGE:
            Forge(gold, iron);
            break;
        case Action::REPAIR:
            Repair(gold, turn, pickaxe, durability);
            break;
        case Action::BUY_PICKAXE:
            BuyNewPickAxe(gold, pickaxe, durability);
            break;
        }

        NFT(gold, is_chance_meet);

        if (!is_chance_meet) 
        {
            std::cout << "No pasó nada en este hermoso día" << turn << std::endl;
        }
        turn++;
        std::cout << "Presione Enter para continuar..." << std::endl;
        system("pause");
    }

    ShowFinalGame(life, gold, turn);
}

void ShowStats(int life, int gold, int iron, PickAxes pickaxe, float durability, int forge_count, int turn, int exp)
{
    std::cout << "Turno N :  " << turn << std::endl;
    std::cout << "- Stats de Gorgomir " << "[Vida : " << life << "] | [Oro : " << gold << "]| [Hierro : " << iron << "]" << std::endl;
    std::cout << "- Stats del pico " << "[Tipo : " << GetPickAxeName(pickaxe) << "] [Durabilidad : " << durability << "] [Exp : " << exp << "]" << std::endl;
    std::cout << "- Armaduras forjadas/vendidas [Cantidad :" << forge_count << "]" << std::endl;
}

int GetSelectedAction()
{
    int input = 0;
    std::cout << "Que accion deberia realizar Gorgomir?" << std::endl;
    std::cout << "1 - Explorar zona" << std::endl;
    std::cout << "2 - Recoger bayas" << std::endl;
    std::cout << "3 - Minar" << std::endl;
    std::cout << "4 - Forjar armadura" << std::endl;
    std::cout << "5 - Reparar inventario" << std::endl;
    std::cout << "6 - Comprar pico nuevo" << std::endl;
    std::cin >> input;

    while (!IsValidInput(input))
    {
        std::cout << "Ups, el valor ingresao no es correcto, ingresa un valor del 1 al 6" << std::endl;
        std::cin >> input;
    }

    return input;
}

bool IsValidInput(int input)
{
    return input > 0 && input <= 6;
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

int GetPickAxeChance(PickAxes pickAxe) {
    int chance;
    switch (pickAxe)
    {
    case PickAxes::WOOD:
        chance = Chance::CH_WOOD;
        break;
    case PickAxes::IRON:
        chance = Chance::CH_IRON;
        break;
    case PickAxes::DAIMON:
        chance = Chance::CH_DAIMON;
        break;
    default:
        chance = Chance::CH_NONE;
        break;
    }

    return chance;
}

float GetPickAxeDurabilty(PickAxes pickAxe) {
    float durabilty;
    switch (pickAxe)
    {
    case PickAxes::WOOD:
        durabilty = Durability::D_WOOD;
        break;
    case PickAxes::IRON:
        durabilty = Durability::D_IRON;
        break;
    case PickAxes::DAIMON:
        durabilty = Durability::D_DAIMON;
        break;
    default:
        durabilty = Durability::D_NONE;
        break;
    }

    return durabilty;
}

int GetPickAxePrice(PickAxes pickAxe) {
    int price;
    switch (pickAxe)
    {
    case PickAxes::WOOD:
        price = Prices::P_WOOD;
        break;
    case PickAxes::IRON:
        price = Prices::P_IRON;
        break;
    case PickAxes::DAIMON:
        price = Prices::P_DAIMON;
        break;
    default:
        price = Prices::P_NONE;
        break;
    }

    return price;
}

bool GetChance(int chance)
{
    std:: srand(time(0));
    return ((std::rand() % 100) + 1) <= chance;
}

int GetRandomNumber(int min, int max) {
    std::srand(time(0));
    int dif = max - min + 1;
    return rand() % dif + min;
}

void Explore(int &gold, int &life, bool &is_chance_meet)
{
    if (GetChance(EXPLORE_CHANCE)) {
        std::cout << "Conseguiste monedas! " << std::endl;
        gold += GetRandomNumber(5, 20);
        is_chance_meet = true;
    }

    std::cout << "Te ha picado una araña! " << std::endl;
    life--; 
}

void PickBerries(int &life, bool &is_chance_meet)
{
    if (GetChance(PICK_BERRIES_CHANCE)) {
        std::cout << "Encontraste bayas! " << std::endl;
        if (life + BERRIES_RESTORE_POINTS > MAX_LIFE)
        {
            life = MAX_LIFE;
        }
        else
        {
            life += BERRIES_RESTORE_POINTS;
        }
        is_chance_meet = true;
        return;
    }

    std::cout << "No encontraste bayas! " << std::endl;
}

void Mining(int &life, float &durability, PickAxes &pickAxe, int &exp, int &iron, bool &is_chance_meet)
{
    int chance = 0;
    int obtained_iron = 0;
    if (life < MIN_LIFE_TO_MINE || durability <= 0) {
        std::cout << "Lo siento, no se puede minar! " << std::endl;
        return;
    }

    chance = GetPickAxeChance(pickAxe) + exp;
    for (int i = 0; i < MINING_TRIES; i++)
    {
        if (durability <= 0) {
            std::cout << "El pico esta roto " << std::endl;
            break;
        }

        if (GetChance(chance)) {
            std::cout << "Obtuviste 1 de hierro! " << std::endl;
            obtained_iron++;
            is_chance_meet = true;
        }

        if (durability - MINING_DAMAGE == 0) {
            durability = 0;
        }
        else
        {
            durability -= MINING_DAMAGE;
        }
    }

    if (obtained_iron == 0) {
        exp++;
    }
    else
    {
        iron += obtained_iron;
    }

    life--;
}

void Forge(int &gold, int &iron)
{
    if (iron < FORGE_COST) {
        std::cout << "Lo siento, no se puede forjar una armadura! " << std::endl;
        return;
    }

    iron -= FORGE_COST;
    gold += FORGE_PRICE;
    std::cout << "Se forjó exitosamente la armadura y se vendió por 30 de oro." << std::endl;
}

void Repair(int &gold, int &turn, PickAxes &pickAxes, float &durability)
{
    int cost;
    if (turn % 2 == 0) {
        std::cout << "Lo siento, hoy no se puede reparar el pico" << std::endl;
        return;
    }

    cost = GetPickAxeDurabilty(pickAxes) - durability;
    if (gold < cost)
    {
        std::cout << "Lo siento, no tienes suficiente dinero para arreglar tu pico" << std::endl;
        return;
    }

    gold -= cost;
    durability = GetPickAxeDurabilty(pickAxes);
    std::cout << "Has arreglado tu pico!" << std::endl;
}

void BuyNewPickAxe(int &gold, PickAxes &pickAxe, float &durability)
{
    int cost;
    PickAxes new_pickaxe;
    if (pickAxe == PickAxes::DAIMON) {
        std::cout << "Lo siento, ya tienes un pico de diamante, no existe uno mejor!" << std::endl;
        return;
    }

    switch (pickAxe)
    {
    case PickAxes::WOOD:
        new_pickaxe = PickAxes::IRON;
        break;
    case PickAxes::IRON:
        new_pickaxe = PickAxes::DAIMON;
        break;
    default:
        new_pickaxe = PickAxes::NONE;
        break;
    }

    cost = GetPickAxePrice(new_pickaxe);
    if (cost > gold) {
        std::cout << "Lo siento, no tienes suficiente dinero para comprar un pico nuevo!" << std::endl;
        return;
    }

    pickAxe = new_pickaxe;
    durability = GetPickAxeDurabilty(pickAxe);
}

void NFT(int &gold, bool &is_chance_meet)
{
    if (GetChance(NFT_CHANCE))
    {
        std::cout << "Conseguiste NFT's! " << std::endl;
        gold += Prices::P_NFT;
        is_chance_meet = true;
    }
}

void ShowFinalGame(int life, int gold, int turn)
{
    std::cout << "Fin del juego" << std::endl;
    std::cout << "Cantidad de turnos " << turn << std::endl;

    if (life <= 0) 
    {
        std::cout << "Gorgomir se quedó sin vida :(" << std::endl;
        return;
    }

    std::cout << "Gorgomir cumplió el sueño de su vida consiguío " << GOAL_GOLD << " modenas de oro!" << std::endl;
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
