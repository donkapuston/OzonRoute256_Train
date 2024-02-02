using System.ComponentModel.Design.Serialization;
using System.Reflection;

string path = "D:\\OzonTechPoint\\10\\50\\1";
using (StreamReader sr = new StreamReader(path))
{
    int t = int.Parse(sr.ReadLine());
    for (int i = 0; i < t; i++)
    {
        int n = int.Parse(sr.ReadLine());
        int countWhiteSpace = 0;
        List<Comment> tree = new List<Comment>();
        for (int j = 0; j < n; j++)
        {

            string input = sr.ReadLine();
            int firstSpaceIndex = input.IndexOf(' ');
            int secondSpaceIndex = -1;
            if (firstSpaceIndex != -1)
            {
                secondSpaceIndex = input.IndexOf(' ', firstSpaceIndex + 1);
            }
            string text = input.Substring(secondSpaceIndex+1);
            string ids = input.Substring(0, secondSpaceIndex);
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
        bool IsFirst = true;
        foreach (var root in roots)
        {   
            root.Print(IsFirst, "", true);
            IsFirst= false;
        }
        if (i!=t-1)
        {
            Console.WriteLine();
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
    public void Print(bool IsFirst, string indent = "", bool last = true)
    {
        
        if (Value.parentId == -1) 
        {
            if(IsFirst)
            {
                Console.WriteLine(Value.Text);
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
                Children[i].Print(IsFirst, indent, true);
            }
            else
            {
                Console.WriteLine(indent + "|");
                Children[i].Print(IsFirst, indent, false);
            }
        }      
    }
}

