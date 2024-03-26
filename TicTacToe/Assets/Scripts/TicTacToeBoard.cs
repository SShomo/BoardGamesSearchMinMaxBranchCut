using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeBoard : MonoBehaviour
{
    //public static TicTacToeBoard board;
    public List<Node> board;
    [SerializeField] GameObject nodeImage;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++)
            {
                GameObject temp = Instantiate(nodeImage);
                temp.transform.position = new Vector2(i * 1.1f, j * 1.1f);
                temp.GetComponent<Node>().gridPos = new Vector2(i, j);
                board.Add(temp.GetComponent<Node>());
            }
        }
    }
}
