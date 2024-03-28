using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeBoard : MonoBehaviour
{
    public List<Node> board;
    [SerializeField] GameObject nodeImage;

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

    public bool HasWinner()
    {
        bool checkWin = false;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                //board[i + 3 * j].GetComponent<Node>().gridPos = new Vector2()
            }
        }

        return checkWin;
    }
}
