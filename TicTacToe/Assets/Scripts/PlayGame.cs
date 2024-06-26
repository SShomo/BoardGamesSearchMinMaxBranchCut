using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayGame : MonoBehaviour
{
    [SerializeField] TicTacToeBoard game;
    [SerializeField] private TextMeshProUGUI whoseTurn;
    public Turn turn = Turn.Player;
    [SerializeField] MouseCollider mouseCollider;
    public MonteCarloTree mcts;

    [SerializeField] GameObject XImage;


    private void Start()
    {
        mcts = new MonteCarloTree();
    }
    // Update is called once per frame
    void Update()
    {
        if(game.winCon == 1)
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
        else if(game.winCon == 2)
        {
            whoseTurn.text = "PLAYER WON";
        }
        else if (game.winCon == 3)
        {
            whoseTurn.text = "AI WON";
        }
        else if( game.winCon == 4) 
        {
            whoseTurn.text = "TIE";
        }
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
        if(turn == Turn.AI && game.GetEmptyNodes().Count > 0)
        {
            List<Node> holder = game.board;
            Node bestMove = mcts.GetBestMove(game, Turn.AI);
            game.board = holder;
            game.MCTSMove(bestMove);
            //game.RandAIMove();
            turn = Turn.Player;
        }
        else if(turn == Turn.AI)
        {
            game.winCon = 4;
        }
    }

    public enum Turn
    {
        Player, AI
    }
}
