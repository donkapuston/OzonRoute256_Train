
    int t = int.Parse(Console.ReadLine());
    for (int i = 0; i < t; i++)
    {
        ToArrayNum();
    }





void ToArrayNum()
{
    int k = int.Parse(Console.ReadLine());
    string a = Console.ReadLine();
    string[] parts = a.Split(','); 
    int[] arrDefault = new int[k];
    int[] arrDelete = new int[1000];
    int currIndex = 0;

    for (int i = 0; i < k; i++)
    {
        arrDefault[i] = i + 1;
    }
    foreach (string part in parts)
    {
        if (part.Contains('-'))
        {
            string[] range = part.Split('-');
            int start = int.Parse(range[0]);
            int end = int.Parse(range[1]);
            for (int i = start; i <= end; i++)
            {
                arrDelete[currIndex] = i;
                currIndex++;
            }
        }
        else
        {        
            arrDelete[currIndex]= int.Parse(part);
            currIndex++;
        }
    }
    arrDelete = arrDelete.Distinct().ToArray();

    arrDefault=arrDefault.Except(arrDelete).ToArray();
    ToStringPrint(arrDefault);
}

void ToStringPrint(int[] arr)
{
    string result = "";
    int start = arr[0], end = arr[0];

    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] == end + 1)
        {
            end = arr[i];
        }
        else
        {
            result += start == end ? $"{start}," : $"{start}-{end},";
            start = end = arr[i];
        }
    }
    result += start == end ? $"{start}," : $"{start}-{end},";
    result = result.Remove(result.Length - 1);
    Console.WriteLine(result);
}