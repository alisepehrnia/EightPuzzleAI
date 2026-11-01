using System.Collections.Generic;
using static EightPuzzleAI.Search.Base;
using EightPuzzleAI.Model;

namespace EightPuzzleAI.Search
{
    public static class BFS
    {
        //function TREE-SEARCH(problem, fringe) returns a solution, or failure 
        /// <summary>
        /// BFS using Tree Search
        /// </summary>
        /// <param name="problem"></param>
        /// <param name="fringe"></param>
        /// <param name="searchResult"></param>
        /// <returns></returns>
        public static Node Tree_Search(ref Problem problem, ref Queue<Node> fringe, out SearchResult searchResult)
        {
            fringe.Enqueue(problem.InitialState); //fringe + INSERT(MAKE-NODE(INITIAL-STATE[problem]),fringe)

            do //loop do 
            {
                if (fringe.Count < 1) //if EMPTY?(fringe) then return failure 
                {
                    searchResult = SearchResult.Failure;
                    return null;
                }
                var node = fringe.Dequeue(); //node <- REMOVE-FIRST(fringe)
                if (Goal_Test(problem, node))
                //if GOAL-TEST[problem] applied to STATE[node] succeeds then return SOLUTION(node)
                {
                    searchResult = SearchResult.Success;
                    return node;
                }
                Insert_All(ref fringe, Expand(ref node, ref problem)); //fringe <- INSERT-ALL(EXPAND(node, problem), fringe) 
            }
            while (true);
        }

        //function GRAPH-SEARCH(problem, fringe) returns a solution, or failure 
        /// <summary>
        /// BFS using Graph Search
        /// </summary>
        /// <param name="problem"></param>
        /// <param name="searchResult"></param>
        /// <returns></returns>
        public static Node Graph_Search(ref Problem problem, out SearchResult searchResult)
        {
            //closed <- an empty set 
            HashSet<int> closed = new HashSet<int>();
            //fringe <- INSERT(MAKE-NODE(INITIAL-STATE[problem]),fringe)
            Queue<Node> fringe = new Queue<Node>();
            fringe.Enqueue(problem.InitialState);
            //loop do
            do
            {
                //if EMPTY?(fringe) then return failure
                if (fringe.Count < 1)
                {
                    searchResult = SearchResult.Failure;
                    return null;
                }
                //node <- REMOVE-FIRST(fringe)
                var node = fringe.Dequeue();
                //if GOAL-TEST[problem](STATE[node]) then return SOLUTION(node)
                if (Goal_Test(problem, node))
                {
                    searchResult = SearchResult.Success;
                    return node;
                }
                //if STATE[node] is not in closed then
                if (!closed.Contains(node.GetHashCode()))
                {
                    //add STATE[node] to closed 
                    closed.Add(node.GetHashCode());
                    //fringe <- INSERT-ALL(EXPAND(node, problem), fringe) 
                    Insert_All(ref fringe, Expand(ref node, ref problem));
                }
            }
            while (true);
        }
    }
}
