using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iteminventory : MonoBehaviour
{
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Delete()
    {
        Destroy(gameObject);
    }
}
