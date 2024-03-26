using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector2 gridPos;
    [SerializeField] TileOptions setTile;

    enum TileOptions
    { X, O  }

    public void SetX() {  setTile = TileOptions.X; }
    public void SetO() {  setTile = TileOptions.O; }
}
