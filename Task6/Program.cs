int t = int.Parse(Console.ReadLine());

for (int i = 0; i < t; i++)
{
    Terminal();
    Console.WriteLine("-");
}


void Terminal ()
{
    string[] lines = new string[1] { "" };
    int lineIndex = 0;
    int charIndex = 0;

    string input = Console.ReadLine();

    foreach (char c in input)
    {
        switch (c)
        {
            case 'L':
                if (charIndex > 0) charIndex--;
                break;
            case 'R':
                if (charIndex < lines[lineIndex].Length) charIndex++;
                break;
            case 'U':
                if (lineIndex > 0)
                {
                    lineIndex--;
                    charIndex = Math.Min(charIndex, lines[lineIndex].Length);
                }
                break;
            case 'D':
                if (lineIndex < lines.Length - 1 && lines[lineIndex + 1] != null)
                {
                    lineIndex++;
                    charIndex = Math.Min(charIndex, lines[lineIndex].Length);
                }
                break;
            case 'B':
                charIndex = 0;
                break;
            case 'E':
                charIndex = lines[lineIndex].Length;
                break;
            case 'N':
                Array.Resize(ref lines, lines.Length + 1);
                for (int i = lines.Length - 1; i > lineIndex + 1; i--)
                    lines[i] = lines[i - 1];
                lines[lineIndex + 1] = lines[lineIndex].Substring(charIndex);
                lines[lineIndex] = lines[lineIndex].Substring(0, charIndex);
                lineIndex++;
                charIndex = 0;
                break;             
            default:
                if (char.IsLetterOrDigit(c))
                {
                    lines[lineIndex] = lines[lineIndex].Insert(charIndex, c.ToString());
                    charIndex++;
                }
                break;
        }
    }
    int lastLineIndex = Array.FindLastIndex(lines, line => line != null);
    for (int i = 0; i <= lastLineIndex; i++)
    {
        Console.WriteLine(lines[i]);
    }
}


