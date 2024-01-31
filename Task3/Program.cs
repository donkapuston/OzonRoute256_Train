

int t = int.Parse(Console.ReadLine());

for (int i = 0; i < t; i++)
{
    string a = Console.ReadLine();
    ValidCarPlateString(a);   
}

void ValidCarPlateString (string a)
{
    string output = "";
    string tmp = a;
    
    
    while(!string.IsNullOrEmpty(tmp))
    {
        if (IsFourDigit(tmp))
        {
            output += tmp[0..4] + " ";          
            tmp = tmp.Remove(0,4);
        }
        else if (IsFiveDigit(tmp))
        {
            output += tmp[0..5] + " ";
            tmp = tmp.Remove(0, 5);
        }
        else if (!IsFourDigit(tmp) && !IsFiveDigit(tmp))
        {
            output = "-";
            break;
        }      
    }
    Console.WriteLine(output);
}
bool IsFourDigit(string tmp)
{
    if (tmp.Length >= 4 && Char.IsLetter(tmp[0]) && Char.IsDigit(tmp[1]) && Char.IsLetter(tmp[2]) && Char.IsLetter(tmp[3]))
    {
        return true;
    }
    else
    {
        return false;

    }
}
bool IsFiveDigit(string tmp)
{
    if (tmp.Length >= 5 && Char.IsLetter(tmp[0]) && Char.IsDigit(tmp[1]) && Char.IsDigit(tmp[2]) && Char.IsLetter(tmp[3]) && Char.IsLetter(tmp[4]))
    {
        return true;
    }
    else
    {
        return false;
    }
}