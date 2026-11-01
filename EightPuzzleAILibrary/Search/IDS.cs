using System;
using System.Collections.Generic;
using System.IO;
using EightPuzzleAI.Model;
using static EightPuzzleAI.Search.Base;

namespace EightPuzzleAI.Search
{
    public static class IDS
    {
        //function ITERATIVE-DEEPENING-SEARCH(problem) returns a solution, or failure
        /// <summary>
        /// Iterative Deepening Search
        /// </summary>
        /// <param name="problem"></param>
        /// <param name="max_depth"></param>
        /// <param name="searchResult"></param>
        /// <returns></returns>
        public static Node Iterative_Deepening_Search(ref Problem problem, int max_depth, out SearchResult searchResult)
        {
            //for depth <- 0 to infinity do
            for (int depth = 0; depth <= max_depth; depth++)
            {
                //result <- DEPTH-LIMITED-SEARCH(problem,depth)
                var result = Depth_Limited_Search(ref problem, depth, out searchResult);
                //if result != cutoff then return result 
                if (searchResult != SearchResult.Cutoff) return result;
            }

            searchResult = SearchResult.Failure;
            return null;
        }

        //function DEPTH-LIMITED-SEARCH(problem, ℓ) returns a node or failure or cutoff
        /// <summary>
        /// Depth Limited Search
        /// </summary>
        /// <param name="problem"></param>
        /// <param name="limit"></param>
        /// <param name="searchResult"></param>
        /// <returns></returns>
        public static Node Depth_Limited_Search(ref Problem problem, int limit, out SearchResult searchResult)
        {
            File.AppendAllText(@"E:\log.txt", $"{DateTime.Now.ToLongTimeString()} Depth:{limit} \r\n");
            //frontier ← a LIFO queue (stack) with NODE(problem.INITIAL) as an element
            Stack<Node> frontier = new Stack<Node>();
            frontier.Push(problem.InitialState);
            //result ← failure
            searchResult = SearchResult.Failure; 
            HashSet<int> visited = new HashSet<int>();
            //while not IS-EMPTY(frontier) do
            while (frontier.Count > 0)
            {
                //node ← POP(frontier)
                var node = frontier.Pop();
                //if problem.IS-GOAL(node.STATE) then return node
                if (Goal_Test(problem, node))
                {
                    searchResult = SearchResult.Success;
                    return node;
                }
                //if DEPTH(node) > ℓ then
                if (node.Depth >= limit)
                {
                    //result ← cutoff
                    searchResult = SearchResult.Cutoff; 
                }
                //else do
                else
                {
                    //for each child in EXPAND(problem, node) do
                    foreach (var child in Expand(ref node, ref problem))
                    {
                        int hash = child.GetHashCode();
                        if (!visited.Contains(hash))
                        {
                            visited.Add(hash);
                            //add child to frontier
                            frontier.Push(child);
                        }
                    }
                }
            }
            File.AppendAllText(@"E:\log.txt", $"{DateTime.Now.ToLongTimeString()} Visited:{visited.Count} \r\n----\r\n");
            return null; //return result
        }
    }
}
