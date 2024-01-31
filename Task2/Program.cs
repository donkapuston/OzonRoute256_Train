
int t = int.Parse(Console.ReadLine());

for (int i = 0; i < t; i++)
{
    string a = Console.ReadLine();
    bool isValid = IsValidDateString(a);
    Console.WriteLine(isValid ? "YES" : "NO");
}

bool IsValidDateString(string? a)
{
    string [] date = a.Split(' ');

    int year = int.Parse(date[2]);
    int month = int.Parse(date[1]);
    int day = int.Parse(date[0]);

    int[] daysInMonth = { 31, (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    if(day <= daysInMonth[month-1])
    {
        return true;
    }
    else 
    {
        return false; 
    }


}