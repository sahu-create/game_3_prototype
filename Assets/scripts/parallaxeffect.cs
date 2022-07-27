using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxeffect : MonoBehaviour
{
    private float length;
    private float startpos;
    public GameObject Camera;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (Camera.transform.position.x * (1 - speed));
        float distance = (Camera.transform.position.x * speed);
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
        if (temp > startpos + length)
            startpos += length;
        else if (temp < startpos - length)
            startpos -= length;
    }
}
