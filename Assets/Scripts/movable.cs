using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movable : MonoBehaviour
{
    static private GameObject mouse_obj;
    static public GameObject MouseObj{
        get {return mouse_obj;}
        set {
            if (mouse_obj == null)
                mouse_obj = value;
        }
    }
    static private mouse mouse_comp ;
    static public mouse MouseComponent{
        get {return mouse_comp;}
        set {
            if (mouse_comp == null)
                mouse_comp = value;
        }
    }

    Vector3 accel;
    // Start is called before the first frame update
    void Start()
    {
        accel = new Vector3(0,0,0);
        
        MouseObj = GameObject.Find("Mouse");
        // if (MouseObj == null) Debug.Log("can't find mouse");
        if (MouseObj)
        MouseComponent = MouseObj.GetComponent<mouse>();
        // if (MouseComponent == null) Debug.Log("can't find component mouse");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0)) {
            return;
        }
        
        Vector3 actupos = mouse_obj.transform.position;
        Vector3 lastpos = mouse_comp.LastPosition;
        // if (transform.position)

        // distance to mouse vector
        float distance_line = Mathf.Abs((lastpos.x - actupos.x)*(actupos.y - transform.position.y)
                        - (actupos.x - transform.position.x)*(lastpos.y - actupos.y));
        float distance_last = Vector3.Distance(lastpos, transform.position);
        float distance_actu = Vector3.Distance(actupos, transform.position);
        // float distance_midd = Vector3.Distance(mouse_comp.MiddleMovement, transform.position);
        float distance_midd = (distance_last+distance_actu)/2;
        float impulse_force = mouse_comp.DistanceLastPosition*7;

        if (distance_line < 3) {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce((actupos-lastpos)/(distance_midd)*(impulse_force));
            if (distance_actu > distance_last && distance_actu*distance_last < 2) 
                rb.AddForce((mouse_comp.MiddleMovement - transform.position)*(impulse_force));
            if (distance_actu < distance_last && distance_actu*distance_last < 2) 
                rb.AddForce((transform.position - mouse_comp.MiddleMovement)*(impulse_force));
        }

        // rb.AddForce((transform.position -  middle) * distrel / (dist));
        
/*
        Vector3 middle = (actual_mouse + mouse_lastPos)/2;
        float distrel = Vector3.Distance(actual_mouse, mouse_lastPos);
        if (Vector3.Distance(actual_mouse, transform.position) < distrel*distrel) {
            float dist = Vector3.Distance(transform.position, middle)+1;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce((transform.position -  middle) * distrel / (dist));
        }

        mouse_lastPos = actual_mouse;
        */
    }
}
