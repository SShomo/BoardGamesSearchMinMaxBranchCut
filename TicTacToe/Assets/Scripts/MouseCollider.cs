using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseCollider : MonoBehaviour
{
    public bool isOverlap;
    public Node clickedNode;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "MousePosition";
        CircleCollider2D circle = gameObject.AddComponent<CircleCollider2D>();//.isTrigger = true;
        gameObject.AddComponent<Rigidbody2D>().gravityScale = 0;
        circle.radius = 0.05f;
        circle.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position.z = Camera.main.nearClipPlane;
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        gameObject.transform.position = worldPosition;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            clickedNode = collision.gameObject.GetComponent<Node>();
            isOverlap = true;
            //Debug.Log(collision.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            isOverlap = false;
            clickedNode = null;
            //Debug.Log(collision.gameObject.name);
        }
    }
}
