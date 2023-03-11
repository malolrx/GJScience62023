using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        lastPos = transform.position; 
        transform.position = Input.mousePosition;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        // GameObject trace = new GameObject();
        // trace.AddComponent<SpriteRenderer>();


    }
}
