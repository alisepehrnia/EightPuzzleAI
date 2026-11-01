using System;
using System.Collections.Generic;
using System.Text;
using EightPuzzleAI.Model;

namespace EightPuzzleAI.Search
{
    /// <summary>
    /// Provides common types and function to run search algorithms
    /// </summary>
    public static class Base
    {
        /// <summary>
        /// Indicates Search Result Message
        /// </summary>
        public enum SearchResult { Failure, Success, Cutoff };
        /// <summary>
        /// Available heuristic functions to use in search
        /// </summary>
        public enum Heuristic { MisplacedTilesCount, MisplacedTilesManhattan };
        /// <summary>
        /// Availalbe Informed Search algorithms
        /// </summary>
        public enum InformedSearchTypes { Greedy, AStar };

        /// <summary>
        /// Check node against problem goal state 
        /// </summary>
        /// <param name="problem"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool Goal_Test(Problem problem, Node node)
        {
            return node.Equals(problem.GoalState);
        }

        /// <summary>
        /// Returns a Stack of nodes from goal to root
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Stack<Node> Solution(ref Node node)
        {
            Stack<Node> path = new Stack<Node>();

            Node n = node;
            while (n != null)
            {
                path.Push(n);

                if (n.Parent_Node == null)
                    break;
                else
                    n = n.Parent_Node;
            }

            return path;
        }

        /// <summary>
        /// Insert a List of nodes into a queue
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="nodes"></param>
        public static void Insert_All(ref Queue<Node> queue, List<Node> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
                queue.Enqueue(nodes[i]);
        }

        //function EXPAND(node, problem) returns a set of nodes
        /// <summary>
        /// Expands a node with successor function
        /// </summary>
        /// <param name="node"></param>
        /// <param name="problem"></param>
        /// <returns></returns>
        public static List<Node> Expand(ref Node node, ref Problem problem)
        {
            //successors <- the empty set
            List<Node> successors = new List<Node>();

            //for each (action, result) in SUCCESSOR-FN[problem](STATE[node])
            foreach (var result in node.Successor_Function())
            {
                //s <- a new NODE
                Node s;
                //STATE[s] <- result 
                s = result;
                //PARENT-NODE[s] <- node
                s.Parent_Node = node;
                //Action(successor, action); //ACTION[s] <- action
                //NO ACTION
                //PATH-COST[s] <- PATH-COST[node] + STEP-COST(STATE[node], action, result)
                s.Path_Cost = (ushort)(node.Path_Cost + node.Cost);
                //DEPTH[s] <- DEPTH[node] 
                s.Depth = (ushort)(node.Depth + 1);
                //add s to successors 
                successors.Add(s); 
            }

            return successors; // return successors 
        }

        #region [Convert Solution To String Functions]
        public static string SolutionString(ref Node node)
        {
            var nodes = Solution(ref node).ToArray();
            var sb = new StringBuilder();
            sb.Append($"Total Cost: {node.Path_Cost} {Environment.NewLine}");
            sb.Append($"Total Actions: {node.Depth} {Environment.NewLine}");
            for (int i = 0; i < nodes.Length; i++)
            {
                sb.Append(nodes[i].ToString());

                if (i < nodes.Length - 1)
                {
                    sb.Append(nodes[i + 1].Direction);
                    sb.Append(" =>");
                }
            }
            string s = sb.ToString();
            sb.Clear();
            sb = null;
            return s;
        }
        public static string SolutionActions(ref Node node)
        {
            var nodes = Solution(ref node).ToArray();
            var sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                sb.Append(nodes[i + 1].Direction);

                if (i < nodes.Length - 2)
                    sb.Append(", ");
            }
            sb.Append(")");
            string s = sb.ToString();
            sb.Clear();
            return s;
        }
        public static string SolutionActions2(ref Node node)
        {
            var nodes = Solution(ref node).ToArray();
            var sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                Direction? dir = nodes[i + 1].Direction;
                if (dir.HasValue)
                {
                    //{ '↑', '↓', '←', '→' }
                    if (dir.Value == Direction.Up)
                        sb.Append('↑');
                    else if (dir.Value == Direction.Down)
                        sb.Append('↓');
                    else if (dir.Value == Direction.Left)
                        sb.Append('←');
                    else if (dir.Value == Direction.Right)
                        sb.Append('→');

                    if (i < nodes.Length - 2)
                        sb.Append(" ");
                }
            }
            sb.Append(")");
            var result = sb.ToString();
            sb.Clear();
            return result;
        }
        #endregion
    }
}
