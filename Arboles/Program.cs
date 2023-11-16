using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        IArbolBinario arbol = new ArbolBinario();

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------Arbol binario númerico-----");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("¿Qué deseas hacer?");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Dibujar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("------Recorridos-------");
            Console.WriteLine("4. Ordenar en Amplitud");
            Console.WriteLine("5. Ordenar en PreOrden");
            Console.WriteLine("6. Ordenar en InOrden");
            Console.WriteLine("7. Ordenar en PosOrden");
            Console.WriteLine("8. Busqueda Binaria");
            Console.WriteLine("9. Salir");
            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el valor a insertar (Númerico):");
                        if (int.TryParse(Console.ReadLine(), out int valorInsertar))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            arbol.Insertar(valorInsertar);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Valor no valido. Por favor, ingresa un número.");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        arbol.DibujarArbol();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el valor a eliminar:");
                        if (int.TryParse(Console.ReadLine(), out int valorEliminar))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            arbol.Eliminar(valorEliminar);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Valor no valido. Por favor, ingresa un número.");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        
                        Console.WriteLine("Recorrido en Amplitud:");
                        Console.ForegroundColor = ConsoleColor.Green;
                        arbol.RecorridoAmplitud();
                        Console.WriteLine("Presiona para continuar");
                        Console.ReadKey();
                        break;
                    case 5:
                        
                        Console.WriteLine("Recorrido en PreOrden:");
                        Console.ForegroundColor = ConsoleColor.Green;
                        arbol.RecorridoPreOrden();
                        Console.WriteLine("Presiona para continuar");
                        Console.ReadKey();
                        break;
                    case 6:
                        
                        Console.WriteLine("Recorrido en InOrden:");
                        Console.ForegroundColor = ConsoleColor.Green;
                        arbol.RecorridoInOrden();
                        Console.WriteLine("Presiona para continuar");
                        Console.ReadKey();
                        break;
                    case 7:
                        
                        Console.WriteLine("Recorrido en PosOrden:");
                        Console.ForegroundColor = ConsoleColor.Green;
                        arbol.RecorridoPosOrden();
                        Console.WriteLine("Presiona para continuar");
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.WriteLine("Busqueda binaria:");
                        Console.Write("Ingrese el valor a buscar: ");
                        
                        if (int.TryParse(Console.ReadLine(), out int valorBuscar))
                        {
                            if (arbol.Buscar(valorBuscar))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"El valor {valorBuscar} se encuentra en el árbol.");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"El valor {valorBuscar} no se encuentra en el árbol.");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Entrada no válida. Por favor, ingresa un número.");
                        }
                        Console.ReadKey();
                        break;
                    case 9:
                        Console.WriteLine("Au revoir!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
            }
        }
    }
}
public interface IArbolBinario
{
    void Insertar(int valor);
    void DibujarArbol();
    void Eliminar(int valor);
    void RecorridoAmplitud();
    void RecorridoPreOrden();
    void RecorridoInOrden();
    void RecorridoPosOrden();
    bool Buscar(int valor);
}
public class ArbolBinario : IArbolBinario
{
    private TreeNode  root;
    private int n; 
    public void Insertar(int valor)
    {
        root = InsertarRec(root, valor);
        Console.WriteLine($"Valor {valor} insertado correctamente en el árbol.");
    }
    public bool Buscar(int valor)
    {
        return BuscarRec(root, valor);
    }

    private bool BuscarRec(TreeNode node, int valor)
    {
        if (node == null)
        {
            return false;
        }

        if (valor == node.value)
        {
            return true;
        }
        else if (valor < node.value)
        {
            return BuscarRec(node.left, valor);
        }
        else
        {
            return BuscarRec(node.right, valor);
        }
    }
    private TreeNode InsertarRec(TreeNode node, int valor)
    {
        if (node == null)
        {
            node = new TreeNode { value = valor, left = null, right = null };
            n++;
        }
        else if (valor < node.value)
        {
            node.left = InsertarRec(node.left, valor);
        }
        else if (valor > node.value)
        {
            node.right = InsertarRec(node.right, valor);
        }

        return node;
    }
    public void DibujarArbol()
    {
        imprimirArbol(root, 0, Console.WindowWidth - 5);
        Console.WriteLine();
    }
    private void imprimirArbol(TreeNode node, int xmin, int xmax)
    {
        if (node == null)
            return;
        else
        {
            int x = xmin + (xmax - xmin) / 2;
            int y = level(node) * 2 + 5;
            Console.SetCursorPosition(x - 2, y);
            Console.Write(node.value);
            imprimirArbol(node.left, xmin, x);
            imprimirArbol(node.right, x, xmax);
        }
    }
    private int level(TreeNode node)
    {
        TreeNode temp = root;
        int counter = 1;
        while (temp != null && temp.value != node.value)
        {
            if (node.value == temp.value)
                continue;
            else if (node.value < temp.value)
            {
                temp = temp.left;
                counter++;
            }
            else
            {
                temp = temp.right;
                counter++;
            }
        }
        return counter;
    }
    public void Eliminar(int valor)
    {
        root = EliminarRec(root, valor);
    }
    private TreeNode EliminarRec(TreeNode node, int valor)
    {
        if (node == null)
            return node;

        if (valor < node.value)
        {
            node.left = EliminarRec(node.left, valor);
        }
        else if (valor > node.value)
        {
            node.right = EliminarRec(node.right, valor);
        }
        else
        {
            if (node.left == null)
                return node.right;
            else if (node.right == null)
                return node.left;

            node.value = MinValue(node.right);

            node.right = EliminarRec(node.right, node.value);
        }

        return node;
    }

    private int MinValue(TreeNode node)
    {
        int minValue = node.value;
        while (node.left != null)
        {
            minValue = node.left.value;
            node = node.left;
        }
        return minValue;
    }
    public void RecorridoAmplitud()
    {
        if (root != null)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode temp = queue.Dequeue();
                Console.Write($"{temp.value} ");

                if (temp.left != null)
                    queue.Enqueue(temp.left);

                if (temp.right != null)
                    queue.Enqueue(temp.right);
            }
        }
        else
        {
            Console.WriteLine("El árbol está vacío.");
        }
    }

    public void RecorridoPreOrden()
    {
        RecorridoPreOrden(root);
        Console.WriteLine();
    }
    private void RecorridoPreOrden(TreeNode node)
    {
        if (node != null)
        {
            Console.Write($"{node.value} ");
            RecorridoPreOrden(node.left);
            RecorridoPreOrden(node.right);
        }
    }
    public void RecorridoInOrden()
    {
        RecorridoInOrden(root);
        Console.WriteLine();
    }
    private void RecorridoInOrden(TreeNode node)
    {
        if (node != null)
        {
            RecorridoInOrden(node.left);
            Console.Write($"{node.value} ");
            RecorridoInOrden(node.right);
        }
    }
    public void RecorridoPosOrden()
    {
        RecorridoPosOrden(root);
        Console.WriteLine();
    }
    private void RecorridoPosOrden(TreeNode node)
    {
        if (node != null)
        {
            RecorridoPosOrden(node.left);
            RecorridoPosOrden(node.right);
            Console.Write($"{node.value} ");
        }
    }
}
public class TreeNode
{
    public int value;
    public TreeNode left;
    public TreeNode right;
}
public class BinaryTree
{
    private TreeNode root;
    private int n; 
    public void imprimirArbol(TreeNode node, int xmin, int xmax)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        if (node == null)
            return;
        else
        {
            int x = xmin + (xmax - xmin) / 2;
            int y = level(node) * 2 + 5;
            Console.SetCursorPosition(x - 2, y);
            Console.Write(node.value);
            imprimirArbol(node.left, xmin, x); 
            Console.Beep((y + 10) * 100, 100);
            imprimirArbol(node.right, x, xmax);  
        }
        Console.ResetColor();
    }
    public void DibujarArbol()
    {
        imprimirArbol(root, 10, Console.WindowWidth - 5);
        Console.ReadKey();
        Console.Clear();
    }
    public int level(TreeNode node)
    {
        TreeNode temp = root;
        int counter = 1;
        while (temp != null && temp.value != node.value)
        {
            if (node.value == temp.value)
                continue;
            else if (node.value < temp.value)
            {
                temp = temp.left;
                counter++;
            }
            else
            {
                temp = temp.right;
                counter++;
            }
            return counter;
        }
        return counter; 
    }
    public void deleteCopying(int data)
    {
        TreeNode node, a = root, prev = null;
        while (a != null && a.value != data)
        {
            prev = a;
            if (a.value < data)
                a = a.right;
            else
                a = a.left;
        }
        node = a;
        if (a != null && a.value == data)
        {
            if (node.right == null)
                node = node.left;
            else if (node.left == null)
                node = node.right;
            else
            {
                TreeNode temp = node.left;
                TreeNode previous = node;
                while (temp.right != null)
                {
                    previous = temp;
                    temp = temp.right;
                }
                node.value = temp.value;
                if (previous == node)
                    previous.left = temp.left;
                else
                    previous.right = temp.left;
            }
            if (a == root)
                root = node;
            else if (prev.left == a)
                prev.left = node;
            else
                prev.right = node;
            System.Console.WriteLine("\t\t\t el elemento " + data + " fue eliminado del arbol");
            n--;
        }
        else if (root != null)
            System.Console.WriteLine("\t\t\t El elemento " + data + " no se encuentra en el arbol");
        else
            System.Console.WriteLine("\t\t\t El arbol esta vacio");
    }
}
