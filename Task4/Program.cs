int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            BattleToAirConditioner();
        }




void BattleToAirConditioner()
{
    int lowerBound = 15;
    int upperBound = 30;
    int prevLowerBound = lowerBound;
    int prevUpperBound = upperBound;
    bool IsCorrect = true;
    int n = int.Parse(Console.ReadLine());
   
    for (int i = 0; i < n; i++)
    {
        string a = Console.ReadLine();
        if (IsCorrect)
        {
            if (a.StartsWith("<="))
            {
                upperBound = int.Parse(a.Remove(0, 2));
                if (!(upperBound < lowerBound))
                {
                    if (prevUpperBound < upperBound)
                    {
                        upperBound = prevUpperBound;
                        Console.WriteLine("{0}", Math.Min(lowerBound, upperBound));
                    }
                    else
                    {
                        prevUpperBound = upperBound;
                        Console.WriteLine("{0}", Math.Min(lowerBound, upperBound));
                    }
                   
                }
                else
                {
                    Console.WriteLine("-1");
                    IsCorrect = false;
                }

            }
            else if (a.StartsWith(">="))
            {
                lowerBound = int.Parse(a.Remove(0, 2));
                if (!(upperBound < lowerBound))
                {
                    if (prevLowerBound > lowerBound)
                    {
                        lowerBound = prevLowerBound;
                        Console.WriteLine("{0}", Math.Min(lowerBound, upperBound));
                    }
                    else
                    {
                        prevLowerBound = lowerBound;
                        Console.WriteLine("{0}", Math.Min(lowerBound, upperBound));
                    }
                    
                }
                else
                {
                    Console.WriteLine("-1");
                    IsCorrect = false;
                }
            }
        }
        else
        {
            Console.WriteLine("-1");
        }        
    }
    Console.WriteLine(" ");
}


