class Program
{
    static void Main()
    {
        Clase8.ejercicios.Lists lists = new();
        
        lists.MorseCode("Hola");
        lists.MorseToAlphabet(".... --- .-.. .-"); // HOLA
        lists.MorseToAlphabet(".-. --- .--. .-"); // ROPA
    }
}