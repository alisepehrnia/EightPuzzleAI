using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using EightPuzzleAI.Model;
using EightPuzzleAI.Search;
using static EightPuzzleAI.Search.Base;

namespace EightPuzzleAIApp
{
    public partial class MainForm : Form
    {
        private Node initialState, goalState;
        private Problem problem;
        private static readonly Random random = new Random(Environment.TickCount);
        private static readonly Stopwatch stopwatch = new Stopwatch();
        private readonly Process process = Process.GetCurrentProcess();
        private long memory = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initialState = new Node(new byte[] { 2, 3, 5,
                                                 1, 4, 0,
                                                 8, 7, 6 }, null, null);

            goalState = new Node(new byte[] { 1, 2, 3,
                                              8, 0, 4,
                                              7, 6, 5 }, null, null);

            problem = new Problem(initialState, goalState);

            heuristicComboBox.Items.Clear();
            heuristicComboBox.DataSource = Enum.GetValues(typeof(Heuristic));
            heuristicComboBox.SelectedIndex = 0;

            puzzleGrid1.Initialize(initialState.Sequence);
            puzzleGrid2.Initialize(goalState.Sequence);
        }

        private byte[] RandomByte()
        {
            stopwatch.Stop();

            var bytes = new byte[9];
            for (int i = 0; i < 9; i++)
            {
                bytes[i] = (byte)random.Next(0, 9);
            }

            stopwatch.Start();
            return bytes;
        }

        private void Log(SearchResult searchResult, Node result, string title = "")
        {
            var sb = new System.Text.StringBuilder();
            sb.Append("-----------------------------------------");
            sb.Append(Environment.NewLine);
            sb.Append($"                {title}                 ");
            sb.Append(Environment.NewLine);
            sb.Append("Root:");
            sb.Append(problem.InitialState.ToString());
            sb.Append("Goal:");
            sb.Append(problem.GoalState.ToString());
            sb.Append(Environment.NewLine);
            sb.Append($"Result: {searchResult.ToString()}");
            sb.Append(Environment.NewLine);
            sb.Append($"Time Elapsed: {stopwatch.ElapsedMilliseconds} ms");
            sb.Append(Environment.NewLine);
            sb.Append($"Memory used: {memory / 1024} KB");
            sb.Append(Environment.NewLine);
            if (searchResult == SearchResult.Success)
            {
                //sb.Append(Environment.NewLine);
                //sb.Append(SolutionActions(ref result));
                sb.Append(Environment.NewLine);
                sb.Append("Solution:");
                sb.Append(Environment.NewLine);
                sb.Append(SolutionActions2(ref result));
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append(SolutionString(ref result));
            }
            logBox.Text = sb.ToString();
            sb.Clear();
        }

        private void StartPerformanceCounter()
        {
            memory = 0;
            process.Refresh();
            memory = process.WorkingSet64;
            stopwatch.Restart();
        }
        private void StopPerformanceCounter()
        {
            stopwatch.Stop();
            process.Refresh();
            memory = process.WorkingSet64 - memory;
        }

        #region [Buttoc Click Events]
        private void IdsButton_Click(object sender, EventArgs e)
        {
            StartPerformanceCounter();
            var result = IDS.Iterative_Deepening_Search(ref problem, (int)maxDepthNumeric.Value, out SearchResult searchResult);
            StopPerformanceCounter();

            Log(searchResult, result, "IDS");
        }
        private void GreedyButton_Click(object sender, EventArgs e)
        {
            StartPerformanceCounter();
            var result = InformedSearch.Search(ref problem, InformedSearchTypes.Greedy, (Heuristic)heuristicComboBox.SelectedItem,
                                            out SearchResult searchResult);
            StopPerformanceCounter();

            Log(searchResult, result, "Greedy");
        }
        private void AstarButton_Click(object sender, EventArgs e)
        {
            StartPerformanceCounter();
            var result = InformedSearch.Search(ref problem, InformedSearchTypes.AStar, (Heuristic)heuristicComboBox.SelectedItem,
                                            out SearchResult searchResult);
            StopPerformanceCounter();

            Log(searchResult, result, "A*");
        }
        private void BfsButton_Click(object sender, EventArgs e)
        {
            StartPerformanceCounter();
            var result = BFS.Graph_Search(ref problem, out SearchResult searchResult);
            StopPerformanceCounter();

            Log(searchResult, result, "BFS");
        }
        private void PerformanceButton_Click(object sender, EventArgs e)
        {
            //Node Performance Memory Test
            Queue<Node> nodes = new Queue<Node>();
            StartPerformanceCounter();
            nodes.Enqueue(new Node(RandomByte(), new Node(RandomByte()), Direction.Up));
            for (int i = 0; i < 100000; i++)
            {
                nodes.Enqueue(new Node(RandomByte(), nodes.Peek(), Direction.Left));
            }
            StopPerformanceCounter();

            logBox.Clear();
            logBox.Text += $"Elapsed: {stopwatch.ElapsedMilliseconds.ToString()} ms {Environment.NewLine}";
            logBox.Text += $"Memory used: {memory / 1024} KB {Environment.NewLine}";
            logBox.Text += $"Elapsed time (for each node):{stopwatch.ElapsedMilliseconds * 1F / nodes.Count * 1000000 } ns {Environment.NewLine}";
            logBox.Text += $"Memory used (for each node): {memory / nodes.Count} B {Environment.NewLine}";
        }
        #endregion
    }
}
