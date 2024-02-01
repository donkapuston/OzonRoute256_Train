using System.ComponentModel.Design.Serialization;
using System.Reflection;

string path = "D:\\OzonTechPoint\\10\\50\\1";
using (StreamReader sr = new StreamReader(path))
{
    int t = int.Parse(sr.ReadLine());
    for (int i = 0; i < t; i++)
    {
        int n = int.Parse(sr.ReadLine());
        List<Comment> tree = new List<Comment>();
        for (int j = 0; j < n; j++)
        {

            string input = sr.ReadLine();
            int index = 0;
            foreach (char item in input)
            {
                if (Char.IsLetter(item))
                {
                    break;
                }
                else
                {
                    index++;
                }
            }
            string text = input.Substring(index);
            string ids = input.Substring(0, index);
            string[] id = ids.Split(' ');
            int[] arr = new int[2];
            for (int k = 0; k < 2; k++)
            {
                if (!string.IsNullOrEmpty(id[k]))
                {
                    arr[k] = int.Parse(id[k]);
                }
            }

            tree.Add(new Comment { Id = arr[0], parentId = arr[1], Text = text });
        }
        Dictionary<int, Node> dict = new Dictionary<int, Node>();

        foreach (var item in tree)
        {
            dict[item.Id] = new Node(item);
        }
        List <Node> roots = new List<Node>();
        foreach (var item in dict.Values)
        {
            if (item.Value.parentId == -1)
            {
                roots.Add(item);
            }
            else
            {
                dict[item.Value.parentId].Children.Add(item);
            }

        }
        foreach (var item in dict.Values)
        {
            
            item.Children.Sort((a, b) =>
            a.Value.Id.CompareTo(b.Value.Id));
        }
        foreach (var root in roots)
        {
            root.Print("", true);
        }
    }
}

public class Comment
{
	public int Id { get; set; }
	public int parentId { get; set; }
	public string Text { get; set; }
}
public class Node
{
    public Comment Value { get; set; }
    public List<Node> Children { get; set; }

    public Node(Comment value)
    {
        Value = value;
        Children = new List<Node>();
    }

    public void AddChild(Node child)
    {
        Children.Add(child);
    }
    bool isFirst = true;

    public void Print(string indent = "", bool last = true)
    {
        
        if(Value.parentId == -1) 
        {
            if(isFirst)
            {
                Console.WriteLine(Value.Text);
                isFirst = false;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(Value.Text);
            }           
        }
        else
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("|--");
                indent += "  ";
            }
            else
            {
                Console.Write("|--");
                indent += "|  ";
            }
            Console.WriteLine(Value.Text);
        }     
        for (int i = 0; i < Children.Count; i++)
        {
            if (i == Children.Count - 1)
            {
                Console.WriteLine(indent + "|");
                Children[i].Print(indent, true);
            }
            else
            {
                Console.WriteLine(indent + "|");
                Children[i].Print(indent, false);
            }
        }      
    }
}

