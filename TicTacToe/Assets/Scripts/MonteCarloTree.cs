using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

//Credit to: https://www.youtube.com/watch?v=gvlO_-Fdk9w for helping with the algorithm
public class MonteCarloTree
{
    [SerializeField] private int numSimulations = 100;

    public Node GetBestMove(TicTacToeBoard bord, PlayGame.Turn turn)
    {
        List<Node> holder = bord.CloneBoard();
        int[] moreLists = new int[9];
        for(int e = 0; e < 9; e++)
            moreLists[e] = 0;

        for (int i = 0; i < numSimulations; i++)
        {
            bord.board = holder;
            TicTacToeBoard simulation = bord;
            PlayGame.Turn currentTurn = turn;

            List<Node> simBoards = new List<Node>();
            List<Node> nextMove = simulation.GetEmptyNodes();

            int score = 3 * 3;

            while (nextMove.Count > 0)
            {
                //AI Move
                int temp = Random.Range(0, nextMove.Count);
                simBoards.Add(nextMove[temp]);
                nextMove[temp].SetO();

                if (simulation.CheckForWinner() == 3)
                    break;

                score -= 1;

                currentTurn = (currentTurn == PlayGame.Turn.Player) ? PlayGame.Turn.AI : PlayGame.Turn.Player;
                nextMove = simulation.GetEmptyNodes();
            }

            Node firstMove = simBoards[0];
            if (currentTurn == PlayGame.Turn.Player && simulation.CheckForWinner() == 2)
                score *= -1;

            moreLists[firstMove.value] += score;
        } 
        int best = 0;
        int highScore = -1;
        for(int y = 0; y < moreLists.Length; y++)
        {
            if (moreLists[y] > highScore)
            {
                highScore = moreLists[y];
                best = y;
            }
        }
        Node[] ee = bord.GetEmptyNodes().ToArray();
        return ee[best];
    }
}
