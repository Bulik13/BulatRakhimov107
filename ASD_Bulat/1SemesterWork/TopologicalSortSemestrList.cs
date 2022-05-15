using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD_Bulat.Semester_papers
{
    public class TopologicalSortSemestr
    {
        // Количество вершин
        private int V;

        private int iterations = 0;

        // Список смежности как ArrayList списки ArrayList'ов
        private List<List<int>> adj;

        public TopologicalSortSemestr(int v)
        {
            V = v;
            adj = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
                adj.Add(new List<int>());
        }

        // Функция для добавления ребра в граф
        public void AddEdge(int v, int w) { adj[v].Add(w); }

        // Рекурсивная функция, используемая topologicalSort
        void TopologicalSortUtil(int v, bool[] visited,
                                 Stack<int> stack)
        {

            // Пометить текущий узел как посещенный.
            visited[v] = true;

            // Повторите для всех вершин смежных с этой вершиной
            foreach (var vertex in adj[v])
            {
                iterations++;
                if (!visited[vertex])
                    TopologicalSortUtil(vertex, visited, stack);
            }

            // Переместите текущую вершину в стек, в котором хранится результат
            stack.Push(v);
        }

        // Функция для выполнения топологической сортировки. Она использует рекурсивную функцию topologicalSortUtil()
        public void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();

            // Пометить все вершины как не посещенные
            var visited = new bool[V];

            // Вызовите рекурсивную вспомогательную функцию для хранения топологической сортировки, начинающейся от всех вершин по очереди
            for (int i = 0; i < V; i++)
            {
                if (visited[i] == false)
                    TopologicalSortUtil(i, visited, stack);
            }

            // Вывести содержимое стека
            foreach (var vertex in stack)
            {
                Console.Write(vertex + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Количество итераций = " + iterations);
        }
    }
}
