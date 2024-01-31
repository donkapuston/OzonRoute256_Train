// See https://aka.ms/new-console-template for more information
using Task1;


int t = int.Parse(Console.ReadLine());

for (int i = 0; i < t; i++)
{
    string a = Console.ReadLine();
    bool isValid = IsValidBattleShipString(a);
    Console.WriteLine(isValid ? "YES" : "NO");
}
    

    static bool IsValidBattleShipString(string a)
    {
    int count1 = a.Count(f => f == '1');
    int count2 = a.Count(f => f == '2');
    int count3 = a.Count(f => f == '3');
    int count4 = a.Count(f => f == '4');

    return count1 == 4 && count2 == 3 && count3 == 2 && count4 == 1;
    }
