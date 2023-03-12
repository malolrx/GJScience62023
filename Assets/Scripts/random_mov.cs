using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class random_mov : MonoBehaviour
{

    private int power;
    public int BasePower;
    public int ShakePower;
    public Shaker Shake;

    int force = 0;
    // Start is called before the first frame update
    void Start()
    {
        power = BasePower;
        Shake = GameObject.Find("Shake").GetComponent<Shaker>();
    }

    // void shakeOnClick() {
    //     power = ShakePower;
    // }

    // void stopShaking() {
    //     power = BasePower;
    // }

    // Update is called once per frame
    void Update()
    {
        if (Shake.isPressed) {
            power = ShakePower;
            force = 0;
        } else {
            power = BasePower;
        }

        if (!MainManager.Pause)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (5 >= force)
            {
                int x = Random.Range(-1, 2)*power;
                int y = Random.Range(-1, 2)*power;
Debug.Log("random mov :" + x + " " + y);
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
