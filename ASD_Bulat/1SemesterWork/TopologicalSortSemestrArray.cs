using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Bulat.Semester_papers
{
    //при добавлении ребер 0 вершина записывается как -1
    internal class TopologicalSortSemestrArray :IEnumerable,IEnumerator
    {
        // Количество вершин
        private int V;

        // Список смежности как ArrayList списки ArrayList'ов
        private int[,] adj;

        public object Current => throw new NotImplementedException();

        public TopologicalSortSemestrArray(int v)
        {
            V = v;
            adj = new int[v,v-1];
        }

        // Функция для добавления ребра в граф
        public void AddEdge(int v, int w) 
        {
            int i = 1;
            while (adj[v,i] != 0)
            {
                i++;
            }
            if (w == 0)
                w = -1;
            adj[v,i] = w;
            i = 1;
        }

        // Рекурсивная функция, используемая topologicalSort
        void TopologicalSortUtil(int v, bool[] visited,
                                 Stack<int> stack)
        {

            // Пометить текущий узел как посещенный.
            visited[v] = true;

            // Повторите для всех вершин смежных с этой вершиной
            //foreach (var vertex in adj[v,0])
            //{
            //    if (!visited[vertex])
            //        TopologicalSortUtil(vertex, visited, stack);
            //}

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
        }

        public IEnumerator GetEnumerator()
        {
            return adj.GetEnumerator();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    
}
