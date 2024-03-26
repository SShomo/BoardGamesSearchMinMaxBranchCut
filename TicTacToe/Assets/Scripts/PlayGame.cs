using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI whoseTurn;
    private Turn turn = Turn.AI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
            MakeMove();
        //MakeMove();
    }

    public void MakeMove()
    {
        if (turn == Turn.Player)
        {
            
            whoseTurn.text = "Player Turn";

            //look at where the player clicked and if it is free, if yes make it X
        }
        else
        {
            Debug.Log("It is not your turn");
            whoseTurn.text = "AI Turn";
        }
    }

    enum Turn
    {
        Player, AI
    }
}
