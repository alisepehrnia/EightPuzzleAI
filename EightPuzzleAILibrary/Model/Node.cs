using System;
using System.Collections.Generic;
using System.Text;

namespace EightPuzzleAI.Model
{
    //[[Level 1 : Node, Succsesor_Function, Node Compares,...]]

    /// <summary>
    /// Provides static objects for fast repeat use
    /// </summary>
    public static class Statics
    {
        public static readonly Direction[] Directions = new Direction[] { Direction.Up, Direction.Down,
                                                                    Direction.Left, Direction.Right };
    }

    /// <summary>
    /// Represents a puzzle node
    /// </summary>
    public class Node : IComparable<Node>, IEquatable<Node>
    {
        #region [Properties & Accessors]
        /// <summary>
        /// Sequence of Tile numbers in 1D Array
        /// </summary>
        public byte[] Sequence { get; set; }
        /// <summary>
        /// Board Blank Tile
        /// </summary>
        public Tile BlankTile { get; set; }
        /// <summary>
        /// Applied Direction to node (Direction wich leads to this node)
        /// </summary>
        public Direction? Direction { get; set; }
        /// <summary>
        /// Parent node
        /// </summary>
        public Node Parent_Node { get; set; }
        /// <summary>
        /// Depth of node in search tree
        /// </summary>
        public ushort Depth { get; set; }
        /// <summary>
        /// Cost of node
        /// </summary>
        public ushort Cost { get; set; }
        /// <summary>
        /// Cost from root to this node
        /// </summary>
        public uint Path_Cost { get; set; }
        /// <summary>
        /// F(n)
        /// </summary>
        public uint FScore { get; set; }
        #endregion

        /// <summary>
        /// Create new Node
        /// </summary>
        /// <param name="sequence">Board numbers</param>
        /// <param name="parent">Parent Node</param>
        /// <param name="dir">Applied Direction to node (Direction wich leads to this node)</param>
        /// <param name="cost">Cost of Node</param>
        public Node(byte[] sequence, Node parent = null, Direction? dir = null, ushort cost = 1, uint fscore = 0)
        {
            Sequence = sequence;
            sequence = null; //Memory*
            Parent_Node = parent;
            Direction = dir;
            Cost = cost;
            FScore = fscore;

            byte dimension = (byte)(Math.Sqrt(Sequence.Length));

            //Finds BlankTile
            int i = Array.IndexOf<byte>(Sequence, 0);
            BlankTile = new Tile((sbyte)(i / dimension), (sbyte)(i % dimension));

            //Calculates node depth
            if (parent == null)
            {
                this.Depth = 0;
                this.Path_Cost = 0;
            }
            else
            {
                this.Depth = (ushort)(parent.Depth + 1);
                this.Path_Cost = (uint)(parent.Cost + this.Cost);
            }
        }

        /// <summary>
        /// Produce all successor nodes
        /// </summary>
        /// <returns></returns>
        public List<Node> Successor_Function()
        {
            var successors = new List<Node>();

            //Check every possible direction to move blank tile
            for (byte i = 0; i < Statics.Directions.Length; i++)
            {
                //Add moved puzzle board to successors list
                if (CanMove(Statics.Directions[i]))
                {
                    var newState = MoveBlankTile(Statics.Directions[i]);
                    //!newState.IsEqualTo(Parent_Node) Added to prevent some duplicates
                    if (Parent_Node == null || !newState.Equals(Parent_Node))
                        successors.Add(newState);
                }
            }

            return successors;
        }

        #region [Move Functions]
        /// <summary>
        /// Move Blank Tile in specified direction
        /// </summary>
        /// <param name="dir">Direction to move Blank Tile toward</param>
        /// <returns>New State with moved Tiles</returns>
        public Node MoveBlankTile(Direction dir, byte dimension = 3, byte cost = 1)
        {
            if (!CanMove(dir))
                throw new ArgumentException("Illegal move");

            var newBlankTile = BlankTile.Move(dir);

            var newData = new List<byte>();
            for (byte i = 0; i < Sequence.Length; i++)
            {
                newData.Insert(i, this.Sequence[i]);
            }

            newData[this.BlankTile.GetIndex(dimension)] = newData[newBlankTile.GetIndex(dimension)];
            newData[newBlankTile.GetIndex(dimension)] = 0;

            return new Node(newData.ToArray(), this, dir, cost);
        }
        /// <summary>
        /// Check whether its legal to move Blank Tile in specified direction or not
        /// </summary>
        /// <param name="dir">Direction to move check</param>
        /// <returns>True/False</returns>
        public bool CanMove(Direction dir)
        {
            var temp = BlankTile.Move(dir);
            byte dimension = (byte)(Math.Sqrt(Sequence.Length));

            return temp.Row >= 0 && temp.Row < dimension && temp.Column >= 0 && temp.Column < dimension;
        }
        #endregion

        /// <summary>
        /// Show a Board in string format like a 2D matrix
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Environment.NewLine);

            byte dimension = (byte)(Math.Sqrt(Sequence.Length));
            for (int col = 0; col < dimension; col++)
            {
                sb.Append("|");
                for (int row = 0; row < dimension; row++)
                {
                    sb.Append(Sequence[col * dimension + row].ToString());

                    if (row < dimension - 1)
                        sb.Append(" ");
                }
                sb.Append("|");
                sb.Append(Environment.NewLine);
            }
            string s = sb.ToString();
            sb.Clear();
            return s;
        }

        #region [Compare Functions]
        /// <summary>
        /// Compare nodes by F(n)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Node other)
        {
            return FScore.CompareTo(other.FScore);
        }
        /// <summary>
        /// Check for nodes equality (by Sequence)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Node other)
        {
            if (this == null && other == null)
                return true;
            else if (this == null || other == null)
                return false;
            else if (this.Sequence.Length != other.Sequence.Length)
                return false;
            else
            {
                //Check Equality in Sequence Numbers one by one
                for (byte i = 0; i < this.Sequence.Length; i++)
                {
                    if (this.Sequence[i] != other.Sequence[i])
                        return false;
                }

                return true;
            }
        }
        /// <summary>
        /// HashCode: Convert Sequence (Array) To Int (e.g {1,2,3} => 123)
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < Sequence.Length; i++)
            {
                hash += Sequence[Sequence.Length - 1 - i] * (int)Math.Pow(10, i);
            }
            return hash;
        }
        #endregion
    }
}
