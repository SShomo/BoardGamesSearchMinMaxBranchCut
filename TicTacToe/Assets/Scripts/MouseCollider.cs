using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseCollider : MonoBehaviour
{
    delegate Node ClickedNode();
    ClickedNode clickedNode;
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
            //Debug.Log(collision.gameObject.name);
        }
    }
}
