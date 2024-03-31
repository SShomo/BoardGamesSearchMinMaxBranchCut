using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeBoard : MonoBehaviour
{
    public int winCon = 1;
    public List<Node> board;
    [SerializeField] GameObject nodeImage;
    [SerializeField] GameObject OImage;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject temp = Instantiate(nodeImage);
                temp.transform.position = new Vector2(i * 1.1f, j * 1.1f);
                temp.GetComponent<Node>().gridPos = new Vector2(i, j);
                temp.name = $"Tile_{i}_{j}";
                board.Add(temp.GetComponent<Node>());
            }
        }
    }

    void Update()
    {
        winCon = CheckForWinner();
    }

    public List<Node> GetEmptyNodes()
    {
        List<Node> emptyNodes = new List<Node>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i + 3 * j].GetComponent<Node>().GetTile() == Node.TileOptions.Empty)
                {
                    emptyNodes.Add(board[i + 3 * j]);
                }
            }
        }
        return emptyNodes;
    }

    public void AIMove()
    {
      List<Node> tempList = GetEmptyNodes();
      if(tempList.Count > 0)
      {
          int temp = Random.Range(0, tempList.Count);
          tempList[temp].SetO();
          GameObject OTile = Instantiate(OImage);
          OTile.transform.position = tempList[temp].transform.position;
      }
      else
      {  
          winCon = 4;
      }

    }

    public int CheckForWinner()
    {
        //if 1 = no one won 
        //if 2 = player won
        //if 3 = ai won

        if ((board[0].GetTile() == Node.TileOptions.O && board[1].GetTile() == Node.TileOptions.O && board[2].GetTile() == Node.TileOptions.O)
            || (board[3].GetTile() == Node.TileOptions.O && board[4].GetTile() == Node.TileOptions.O && board[5].GetTile() == Node.TileOptions.O)
            || (board[6].GetTile() == Node.TileOptions.O && board[7].GetTile() == Node.TileOptions.O && board[8].GetTile() == Node.TileOptions.O)
            || (board[0].GetTile() == Node.TileOptions.O && board[3].GetTile() == Node.TileOptions.O && board[6].GetTile() == Node.TileOptions.O)
            || (board[1].GetTile() == Node.TileOptions.O && board[4].GetTile() == Node.TileOptions.O && board[7].GetTile() == Node.TileOptions.O)
            || (board[2].GetTile() == Node.TileOptions.O && board[5].GetTile() == Node.TileOptions.O && board[8].GetTile() == Node.TileOptions.O)
            || (board[0].GetTile() == Node.TileOptions.O && board[4].GetTile() == Node.TileOptions.O && board[8].GetTile() == Node.TileOptions.O)
            || (board[6].GetTile() == Node.TileOptions.O && board[4].GetTile() == Node.TileOptions.O && board[2].GetTile() == Node.TileOptions.O))
        {
            return 3;
        }
        else if ((board[0].GetTile() == Node.TileOptions.X && board[1].GetTile() == Node.TileOptions.X && board[2].GetTile() == Node.TileOptions.X)
            || (board[3].GetTile() == Node.TileOptions.X && board[4].GetTile() == Node.TileOptions.X && board[5].GetTile() == Node.TileOptions.X)
            || (board[6].GetTile() == Node.TileOptions.X && board[7].GetTile() == Node.TileOptions.X && board[8].GetTile() == Node.TileOptions.X)
            || (board[0].GetTile() == Node.TileOptions.X && board[3].GetTile() == Node.TileOptions.X && board[6].GetTile() == Node.TileOptions.X)
            || (board[1].GetTile() == Node.TileOptions.X && board[4].GetTile() == Node.TileOptions.X && board[7].GetTile() == Node.TileOptions.X)
            || (board[2].GetTile() == Node.TileOptions.X && board[5].GetTile() == Node.TileOptions.X && board[8].GetTile() == Node.TileOptions.X)
            || (board[0].GetTile() == Node.TileOptions.X && board[4].GetTile() == Node.TileOptions.X && board[8].GetTile() == Node.TileOptions.X)
            || (board[6].GetTile() == Node.TileOptions.X && board[4].GetTile() == Node.TileOptions.X && board[2].GetTile() == Node.TileOptions.X))
        {
            return 2;
        }
        else if (winCon == 4)
            return 4;
        return 1;
    }

    public void MonteCarloTurn()
    {

    }
}
