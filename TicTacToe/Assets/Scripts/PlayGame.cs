using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayGame : MonoBehaviour
{
    [SerializeField] TicTacToeBoard game;
    [SerializeField] private TextMeshProUGUI whoseTurn;
    private Turn turn = Turn.Player;
    [SerializeField] MouseCollider mouseCollider;

    [SerializeField] GameObject XImage;
    [SerializeField] GameObject OImage;

    // Update is called once per frame
    void Update()
    {
        if(turn == Turn.AI)
            whoseTurn.text = "AI Turn";
        else
             whoseTurn.text = "Player Turn";

        if (Input.GetMouseButtonUp(0) && mouseCollider.isOverlap)
        {
            MakeMove(mouseCollider.clickedNode);
        }
        else if (Input.GetMouseButtonDown(0))
            AIMove();
    }

    public void MakeMove(Node tile)
    {
        if (turn == Turn.Player && tile.GetTile() == Node.TileOptions.Empty)
        {
            GameObject xTile = Instantiate(XImage);
            xTile.transform.position = tile.gridPos;
            tile.SetX();
            turn = Turn.AI;
        }
        else if (tile.GetTile() != Node.TileOptions.Empty)
        {
            Debug.Log("Choose an Empty Space");
            Debug.Log(tile.GetTile());
        }    
        else
        {
            Debug.Log("It is not your turn");
        }
    }

    public void AIMove()
    {
        if(turn == Turn.AI)
        {
            int temp = Random.Range(0, game.GetEmptyNodes().Count);
            game.GetEmptyNodes()[temp].SetO();
            GameObject OTile = Instantiate(OImage);
            OTile.transform.position = game.GetEmptyNodes()[temp].transform.position;
            turn = Turn.Player;
        }
    }

    enum Turn
    {
        Player, AI
    }
}
