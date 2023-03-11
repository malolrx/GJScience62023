using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movable : MonoBehaviour
{
    Vector3 accel;
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        accel = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 middle = (mouse + lastPos)/2;
        float distrel = Vector3.Distance(mouse, lastPos);
        if (Vector3.Distance(mouse, transform.position) < distrel*distrel) {
            float dist = Vector3.Distance(transform.position, middle)+1;
            accel += (transform.position -  middle) / (1*dist);
        }
        if (accel[0] > 0.001f || accel[1] > 0.001f) {
            
            transform.position += accel;
            accel /= 1.3f;
        }

        lastPos = mouse;
    }
}
