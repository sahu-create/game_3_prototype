using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonemancontroller : MonoBehaviour
{
    public float speed;
    int playerfacing;
    Animator anim;
    public float jumpForce;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        Itemscollected = new int[3];
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       // playerfacing = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            playerfacing = 0;
        } 
        else
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {   
            playerfacing = 1;
        }
        else
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            playerfacing = 2;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerfacing = 3;
        }
        anim.SetInteger("direction", playerfacing);

        Move();
        Jump();
        
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    //int ballcollected, squarecollected, circlecollected;
    int[] Itemscollected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "InventoryItem")
        {
            InventoryItemType itemType =collision.gameObject.GetComponent<inventoryitem>().itemType;
            
            switch (itemType)
            {
                case InventoryItemType.ball:
                    Itemscollected[0]++;
                    Debug.Log("item is" +Itemscollected[0]+"   "+ itemType);
                    break;
                case InventoryItemType.square:
                    Itemscollected[1]++;
                    Debug.Log("item is" + Itemscollected[1] + "   " + itemType);
                    break;
                case InventoryItemType.circle:
                    Itemscollected[2]++;
                    Debug.Log("item is" + Itemscollected[2] + "   " + itemType);
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
}
