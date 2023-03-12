using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public GameObject ONgo;
    public GameObject OFFgo;

    private bool on;
    public bool ON
    {
        get
        {
            return on;
        }

        set
        {
            on = value;
            ONgo.SetActive(ON);
            OFFgo.SetActive(!ON);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ON = false;
        GetComponent<Button>().onClick.AddListener(OnSwitch);
    }

   
    private void OnSwitch()
    {
        ON = !ON;
    }
}
