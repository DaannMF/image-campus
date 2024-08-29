
Int32 sum = 0;
String input = "";
int posD, cantidad = 0, caras = 0;

int[] carasDisponibles = { 4, 6, 8, 10, 12, 20 };

Console.WriteLine("Ingrese el comando para tirar dados");

while (String.IsNullOrEmpty(input))
{
    input = Console.ReadLine();
    posD = input.IndexOf("d");
    cantidad = int.Parse(input.Substring(0, posD));
    caras = int.Parse(input.Substring(posD + 1));
    if (!carasDisponibles.Contains(caras)) input = "";
}

Random r = new Random();

for (int i = 0; i < cantidad; i++)
{
    sum += r.Next(1, caras);
}

Console.WriteLine($"El resultado es {sum}");