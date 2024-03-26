using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    private Turn turn = Turn.Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeMove()
    {
        if (turn == Turn.Player)
        {
            //look at where the player clicked and if it is free, if yes make it X
        }
        else
        {
            Debug.Log("It is not your turn");
        }
    }

    enum Turn
    {
        Player, AI
    }
}
