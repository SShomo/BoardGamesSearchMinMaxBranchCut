using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class MonteCarloTree
{
    //https://www.youtube.com/watch?v=c8SLNEpFSrs
    //https://builtin.com/machine-learning/monte-carlo-tree-search
    [SerializeField] private int numSimulations = 1000;
    private int chosenConst = 3;
    TicTacToeBoard board;
    Node rootNode;
    List<Node> childNodes;

    public void Selection(Node parent)
    {
        float ucb;
        List<Node> possibleMoves = board.GetEmptyNodes();
        foreach (Node currentNode in possibleMoves) 
        {
            currentNode.visits++;
           // ucb = nodeMean + chosenConst * Mathf.Sqrt(Mathf.Log(((float)parent.visits) /currentNode.visits));
            Selection(currentNode);
        }
    }

    public void Expansion()
    {
        Selection(rootNode);
    }

    public int Simulation()
    {
        int results;
        TicTacToeBoard simulation;
        simulation = board;

        while (simulation.CheckForWinner() != 1 || simulation.GetEmptyNodes().Count < 1)
        {
            List<Node> tempList = simulation.GetEmptyNodes();
            if (tempList.Count > 0)
            {
                int temp = Random.Range(0, tempList.Count);
                tempList[temp].SetO();
            }

            tempList = simulation.GetEmptyNodes();
            if (tempList.Count > 0)
            {
                int temp = Random.Range(0, tempList.Count);
                tempList[temp].SetX();
            }
        }

        if (simulation.CheckForWinner() == 2)
            results = -1;
        else if(simulation.CheckForWinner() == 3)
            results = 1;
        else
            results = 0;

        return results;
    }
    public void Backpropagation()
    {
        Simulation();
    }
}
