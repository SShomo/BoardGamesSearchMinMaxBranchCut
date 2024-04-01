using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int visits = 0;
    public float value;


    public Vector2 gridPos;
    [SerializeField] TileOptions setTile = TileOptions.Empty;

    private void Start()
    {
        gameObject.tag = "Tile";
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.AddComponent<Rigidbody2D>().gravityScale = 0;
    }
    public enum TileOptions
    { X, O, Empty  }

    public void SetX() {  setTile = TileOptions.X; }
    public TileOptions GetTile() { return setTile; }
    public void SetO() {  setTile = TileOptions.O; }
}
