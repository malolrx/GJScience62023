using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_mov : MonoBehaviour
{
    int force = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!MainManager.Pause)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (Random.Range(0, 10) >= force)
            {
                int x = Random.Range(-2, 3);
                int y = Random.Range(-2, 3);
                rb.AddForce(new Vector3(x, y, 0));
                force += 2 * (x * x + y * y);
            }
            else
            {
                force--;
            }
        }
        
    }
}
