namespace EightPuzzleAI.Model
{
    //[[Level 0 : Tile, Direction, Move,...]]

    /// <summary>
    /// Empty tile move direction
    /// </summary>
    public enum Direction { Up, Down, Left, Right };

    /// <summary>
    /// Represents a cell in Board
    /// </summary>
    public class Tile //1+1+1 byte
    {
        #region [Properties & Accessors]

        /// <summary>
        /// Tile row number
        /// </summary>
        public sbyte Row { get; set; }

        /// <summary>
        /// Tile column number
        /// </summary>
        public sbyte Column { get; set; }

        #endregion

        /// <summary>
        /// Create new Tile with specified position
        /// </summary>
        /// <param name="row">Tile Row number</param>
        /// <param name="column">Tile Column number</param>
        public Tile(sbyte row, sbyte column)
        {
            Row = row;
            Column = column;
        }

        #region [Functions]

        /// <summary>
        /// Calculates 1D Index of Tile
        /// </summary>
        /// <param name="dimension">Puzzle dimension</param>
        /// <returns></returns>
        public byte GetIndex(byte dimension=3)
        {
            return (byte)(this.Row * dimension + this.Column);
        }

        /// <summary>
        /// Move this Tile to a new position specified by direction
        /// </summary>
        /// <param name="direction">Direction to move</param>
        /// <returns></returns>
        public Tile Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Tile((sbyte)(this.Row - 1), this.Column);

                case Direction.Down:
                    return new Tile((sbyte)(this.Row + 1), this.Column);

                case Direction.Left:
                    return new Tile(this.Row, (sbyte)(this.Column - 1));

                case Direction.Right:
                    return new Tile(this.Row, (sbyte)(this.Column + 1));

                default:
                    return this;
            }
        }

        #endregion

        /// <summary>
        /// Show a Tile row and column number in "(row,column)" format
        /// </summary>
        /// <returns>"(row,column)"</returns>
        public override string ToString()
        {
            return $"({Row.ToString()},{Column.ToString()})";
        }
    }
}
