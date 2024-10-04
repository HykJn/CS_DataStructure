namespace MyGraph
{
    public struct MatrixGraph
    {
        public int vertices;
        int size;
        bool[,] matrix;

        public void Insert()
        {
            if (vertices + 1 > size) throw new Exception("Out of Size");
            vertices++;
        }

        public void Insert(int s, int e)
        {
            if (s < 0 || e < 0 || s >= vertices || e >= vertices) throw new Exception("Out of Range");
            matrix[s, e] = true;
            matrix[e, s] = true;
        }

        public void Delete()
        {
            if (vertices - 1 < 0) throw new Exception("Negative size");
            vertices--;
        }

        public void Delete(int s, int e)
        {
            if (s < 0 || e < 0 || s >= vertices || e >= vertices) throw new Exception("Out of Range");
            matrix[s, e] = false;
            matrix[e, s] = false;
        }

        public void PrintMatrix()
        {
            for(int i = 0; i < vertices; i++)
            {
                for(int j = 0; j < vertices; j++)
                {
                    Console.Write(matrix[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public MatrixGraph(int size)
        {
            vertices = 0;
            this.size = size;
            matrix = new bool[size,size];
        }
    }
/*
    public class GraphNode
    {
        public int vertex;
        public GraphNode? link;
    }

    public struct ListGraph
    {
        public int vertices;
        int size;
        GraphNode?[] nodes;

        public void Insert()
        {
            if (vertices + 1 > size) throw new Exception("Out of Size");
            nodes[vertices] = null;
            vertices++;
        }

        public void Insert(int s, int e)
        {
            if (s < 0 || e < 0 || s >= vertices || e >= vertices) throw new Exception("Out of Range");
            GraphNode node = new();
            node.vertex = e;
            node.link = nodes[s];
            nodes[s] = node;
        }

        public void PrintList()
        {
            for (int i = 0; i< vertices; i++)
            {
                GraphNode? node = nodes[i];
                Console.Write($"Vertex {i}'s Adjacency List: ");
                while (node != null)
                {
                    Console.Write($"-> {nodes[i].vertex} ");
                    node = node.link;
                }
                Console.WriteLine();
            }
        }

        public ListGraph(int size)
        {
            vertices = 0;
            this.size = size;
            nodes = new GraphNode[size];
        }
    }
*/
    public class GraphNode<T>
    {
        public T item;
        public List<GraphNode<T>> links;

        public GraphNode(T item)
        {
            this.item = item;
            links = new();
        }
    }

    public struct LinkGraph<T>
    {
        public int vertices;
        int size;
        GraphNode<T>[] list;

        public void Insert(GraphNode<T> node)
        {
            if (vertices + 1 > size) throw new Exception("Out of Size");
            list[vertices] = node;
            vertices++;
        }

        public void Link(GraphNode<T> s, GraphNode<T> e)
        {
            s.links.Add(e);
            e.links.Add(s);
        }

        public void PrintList()
        {
            for(int i = 0; i < vertices; i++)
            {
                GraphNode<T> temp = list[i];
                Console.Write($"Vertex {temp.item}'s Link: ");
                foreach(GraphNode<T> node in temp.links)
                {
                    Console.Write($"{node.item} -->");
                }
                Console.WriteLine();
            }
        }

        public LinkGraph(int size)
        {
            vertices = 0;
            this.size = size;
            list = new GraphNode<T>[size];
        }
    }
}