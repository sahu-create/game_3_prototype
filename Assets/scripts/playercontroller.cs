using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public InventoryObject inventory;

    public float speed=3.0f;
    int playerfacing;
    Animator anim;
   
    Vector2 lookDirection=new Vector2(1,0);
    float horizontal;
    float vertical;
    Rigidbody2D rb;

    void Start()
    {
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
            Debug.Log("Save");
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Load();
            Debug.Log("Load");

        }

        Move();
    }
    void Move()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
      
        vertical = Input.GetAxisRaw("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        anim.SetFloat("look X", lookDirection.x);
        anim.SetFloat("look Y", lookDirection.y);
        anim.SetFloat("Speed", move.magnitude);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<GroundItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            inventory.AddItem(new Item( item.item),1);
            Destroy(collision.gameObject);
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rb.MovePosition(position);
    }
   
    private void OnApplicationQuit()
    {
       inventory.Container.Items= new InventorySlot[24];
    }
}
