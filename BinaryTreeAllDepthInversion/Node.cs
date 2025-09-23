namespace BinaryTreeAllDepthInversion;

/// <summary>
/// Узел дерева
/// </summary>
public class Node
{
    public int Value { get; set; }

    public Node Left { get; set; }

    public Node Right { get; set; }

    public Node(int value)
    {
        Value = value;
    }

    public Node(int value, Node right, Node left)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public override string ToString() => Value.ToString();
}
