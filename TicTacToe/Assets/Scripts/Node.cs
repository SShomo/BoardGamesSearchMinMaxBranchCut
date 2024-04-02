using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int visits = 0;
    public int value;

    [SerializeField] TicTacToeBoard board;
    public Vector2 gridPos;
    public TileOptions setTile = TileOptions.Empty;

    private void Start()
    {
        gameObject.tag = "Tile";
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.AddComponent<Rigidbody2D>().gravityScale = 0;
    }
    public enum TileOptions
    { X, O, Empty  }

    public void SetX() {  setTile = TileOptions.X; }
    public TileOptions GetTile() { return setTile; }
    public void SetO() {  setTile = TileOptions.O; }
}
