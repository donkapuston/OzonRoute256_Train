
    int t = int.Parse(Console.ReadLine());
    for (int i = 0; i < t; i++)
    {
        CompressionData();
    }
   


void CompressionData()
{
    int n = int.Parse(Console.ReadLine());


    string a = Console.ReadLine();
    string[] splitA = a.Split(' ');
    int[] arr = Array.ConvertAll(splitA, int.Parse);
    int start = arr[0];
    string output = "";

    int count = 0;

    bool IsFirst = true;
    for ( int i = 1; i < arr.Length; i++)
    {
        int difference = arr[i] - arr[i-1];
        bool SameSign = difference * count > 0;

        if ((difference==1 && SameSign && count!=0) || (difference==-1 && SameSign && count!=0) || IsFirst&&difference==1 || IsFirst && difference == -1)
        {
            count += difference;
            IsFirst = false;
        }
        else if(difference!=1 && difference!=-1 || !SameSign)
        {
            if (difference == 0 && !IsFirst)
            {
                difference = arr[i - 1] - arr[i-2];
                if(difference==1 || difference==-1) 
                {
                    output += start + " " + count + " ";
                    start = arr[i];
                    count = 0;
                    IsFirst = true;
                }
                else
                {
                    count = 0;
                    output += start + " " + count + " ";
                    start = arr[i];
                    IsFirst = true;
                }
               
            }
            else
            {
                output += start + " " + count + " ";
                start = arr[i];
                count = 0;
                IsFirst = true;
            }
            
        }
    }

    output += start + " " + count;
    string[] splitOutput = output.Split(" ");
    Console.WriteLine(splitOutput.Length);
    Console.WriteLine(output);
}