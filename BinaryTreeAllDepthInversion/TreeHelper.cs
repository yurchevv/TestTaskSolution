namespace BinaryTreeAllDepthInversion;

/// <summary>
/// Класс, позволяющий производить операции с бинарным деревом
/// </summary>
public static class TreeHelper
{
    /// <summary>
    /// Метод, меняющий местами левую и правую ноды поддерева
    /// </summary>
    /// <param name="tree"> Текущая нода корня поддерева </param>
    /// <returns> Корень поддерева </returns>
    public static Node Swap(Node tree)
    {
        // Если нода является листом - просто возвращаем её
        if (tree == null)
        {
            return tree;
        }

        // Рекурсивно проходим по всем левым, далее правым нодам поддерева
        Swap(tree.Left);
        Swap(tree.Right);

        // Меняем местами левую и правую ноды поддерева каждой ноды,
        // которая не является листом (не содержит ссылки на левую и правую ноды)
        Node temp = tree.Left;
        tree.Left = tree.Right;
        tree.Right = temp;

        return tree;
    }

    /// <summary>
    /// Метод для обхода дерева и заполнения списка значениями посещенных нод
    /// </summary>
    /// <param name="tree"> Корень поддерева </param>
    /// <param name="expectedResult"> Список значений посещенных нод </param>
    public static void TraceTree(Node tree, List<int> expectedResult)
    {
        if (tree == null)
        {
            return;
        }

        expectedResult.Add(tree.Value);

        // Проходим в глубину сначала по левым
        TraceTree(tree.Left, expectedResult);

        // Далее по правым нодам и заполняем список
        TraceTree(tree.Right, expectedResult);
    }

    /// <summary>
    /// Метод для создания бинарного дерева из списка значений
    /// </summary>
    /// <param name="values"> Список значений будущего бинарного дерева </param>
    /// <returns> Корень бинарного дерева </returns>
    public static Node CreateBinaryTreeFromArray(int[] values)
    {
        // Начинаем с первого элемента
        return CreateBinaryTreeFromArray(values, 0);
    }

    /// <summary>
    /// Метод для создания поддерева бинарного дерева из списка значений
    /// </summary>
    /// <param name="values"> Список значений будущего бинарного поддерева </param>
    /// <param name="index"> Индекс для выбора элемента из списка значений для заполнения ноды </param>
    /// <returns></returns>
    private static Node CreateBinaryTreeFromArray(int[] values, int index)
    {
        if (index < 0 || index >= values.Length)
        {
            return null;
        }

        // Далее пока не выйдем за границы массива, последовательно берем 2 следующих элемента
        var node = new Node(values[index])
        {
            Right = CreateBinaryTreeFromArray(values, (index + 1) * 2 - 1),
            Left = CreateBinaryTreeFromArray(values, (index + 1) * 2)
        };

        return node;
    }
}
