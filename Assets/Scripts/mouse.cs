using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouse : MonoBehaviour
{

    public Sprite notclicking;
    public Sprite clicking;


    private Vector3 lastPos;
    public Vector3 LastPosition {
        get {
            return lastPos;
        }
    }

    private float distanceLastPos;
    public float DistanceLastPosition {
        get {
            return distanceLastPos;
        }
    }

    private Vector3 middleMov;
    public Vector3 MiddleMovement {
        get {
            return middleMov;
        }
    }

    Vector3 MousePositionInScreen() {
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = +100;
        return Camera.main.ScreenToWorldPoint(mousepos);
    }

    // Start is called before the first frame update
    void Start()
    {
        name = "Mouse";
        lastPos = MousePositionInScreen();
        distanceLastPos = 0;
    }




    // Update is called once per frame
    void LateUpdate()
    {
        if (!MainManager.Pause)
        {
            lastPos = transform.position;
            transform.position = MousePositionInScreen();
            distanceLastPos = Vector3.Distance(lastPos, transform.position);
            middleMov = (lastPos + transform.position) / 2;

            // Rigidbody2D rb = GetComponent<Rigidbody2D>();
            // GameObject trace = new GameObject();
            // trace.AddComponent<SpriteRenderer>();
        }

    }
}
