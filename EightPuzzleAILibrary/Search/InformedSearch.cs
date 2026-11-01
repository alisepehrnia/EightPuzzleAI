using Priority_Queue;
using System;
using System.Collections.Generic;
using EightPuzzleAI.Model;
using static EightPuzzleAI.Search.Base;

namespace EightPuzzleAI.Search
{
    public static class InformedSearch
    {
        /// <summary>
        /// Informed Search
        /// </summary>
        /// <param name="problem"></param>
        /// <param name="algorithm"></param>
        /// <param name="heuristic"></param>
        /// <param name="searchResult"></param>
        /// <returns></returns>
        public static Node Search(ref Problem problem, InformedSearchTypes algorithm, Heuristic heuristic, out SearchResult searchResult)                   
        {
            SimplePriorityQueue<Node> frontier = new SimplePriorityQueue<Node>();
            frontier.Enqueue(EvaluationFunction(problem.InitialState, ref problem, algorithm, heuristic, out uint fscore), fscore);
            //result ← failure
            searchResult = SearchResult.Failure;
            //visited ← a HashSet to save visited nodes
            HashSet<int> visited = new HashSet<int>();
            //while not IS-EMPTY(frontier) do
            while (frontier.Count > 0)
            {
                //node ← POP(frontier)
                var node = frontier.Dequeue();
                //visited.Push(node)
                visited.Add(node.GetHashCode());
                if (Goal_Test(problem, node))
                //if problem.IS-GOAL(node.STATE) then return node
                {
                    searchResult = SearchResult.Success;
                    return node;
                }
                foreach (var child in Expand(ref node, ref problem))
                {
                    if (!visited.Contains(child.GetHashCode()))
                    {
                        //add child to frontier
                        frontier.Enqueue(EvaluationFunction(child, ref problem, algorithm, heuristic, out fscore), fscore);
                    }
                }
            }
            return null; //return result
        }
        /// <summary>
        /// F(n)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="problem"></param>
        /// <param name="algorithm"></param>
        /// <param name="heuristic"></param>
        /// <param name="fscore"></param>
        /// <returns></returns>
        private static Node EvaluationFunction(Node node, ref Problem problem, InformedSearchTypes algorithm, Heuristic heuristic, out uint fscore)                                      
        {
            fscore = 0;
            switch(heuristic)
            {
                case Heuristic.MisplacedTilesCount:
                    fscore = Heuristics.TotalMisplacedTiles(ref node, ref problem);
                    break;
                case Heuristic.MisplacedTilesManhattan:
                    fscore = Heuristics.TotalManhattanDistances(ref node, ref problem);
                    break;
            }             
            //if search is A* then fscore <- fscore + g(n) (f=h+g)
            if (algorithm == InformedSearchTypes.AStar)
                fscore += node.Path_Cost;

            return new Node((byte[])node.Sequence.Clone(), node.Parent_Node, node.Direction, node.Cost, fscore);
        }

        /// <summary>
        /// Provide Functions to Handle Heuristic Functions
        /// </summary>
        public static class Heuristics
        {
            public static uint TotalManhattanDistances(ref Node node, ref Problem problem)
            {
                uint fscore = 0;
                for (byte i = 0; i < problem.GoalState.Sequence.Length; i++)
                {
                    int goalValue = problem.GoalState.Sequence[i];
                    if (node.Sequence[i] != goalValue)
                    {
                        int misplacedIndex = -1;
                        try
                        {
                            misplacedIndex = Array.FindIndex(node.Sequence, val => val == goalValue);
                        }
                        catch (Exception) { }

                        if (misplacedIndex > -1)
                            fscore += (uint)ManhattanDifference((byte)misplacedIndex, i);
                    }
                }
                return fscore;
            }
            public static uint TotalMisplacedTiles(ref Node node, ref Problem problem)
            {
                uint fscore = 0;
                for (byte i = 0; i < problem.GoalState.Sequence.Length; i++)
                {
                    if (node.Sequence[i] != problem.GoalState.Sequence[i])
                        fscore++;
                }
                return fscore;
            }
            public static int ManhattanDifference(Tile t1, Tile t2)
            {
                return Math.Abs(t1.Row - t2.Row) + Math.Abs(t1.Column - t2.Column);
            }
            public static int ManhattanDifference(byte i1, byte i2)
            {
                return ((i1 - i2) / 3) + ((i1 - i2) % 3);
            }
        }
    }
}
