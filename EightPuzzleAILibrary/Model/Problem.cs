namespace EightPuzzleAI.Model
{
    // [[Level 2 : Problem]]

    public class Problem
    {
        #region [Properties]
        /// <summary>
        /// Puzzle root state
        /// </summary>
        public Node InitialState { get; }
        /// <summary>
        ///  Puzzle goal state
        /// </summary>
        public Node GoalState { get; }
        #endregion

        /// <summary>
        /// Create a new puzzle
        /// </summary>
        /// <param name="initialState">Root state</param>
        /// <param name="goalState">Goal state</param>
        public Problem(Node initialState, Node goalState)
        {
            InitialState = initialState;
            GoalState = goalState;
        }
    }
}
