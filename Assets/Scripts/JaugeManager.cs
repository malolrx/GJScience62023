using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaugeManager : MonoBehaviour
{
    public BacteriaManager Manager;
    public MainManager main;
    public Image Jauge;
    public Image Empty;
    public Image Full;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(transform.position.x, (float)Manager.Production);
        // Transform pos = Full.GetComponent<Transform>();
        // pos.position += new Vector3(0, -40f + (float)Manager.Production/1000 - pos.position.y);
        // Debug.Log("jauge pos " + pos.position );
        // Full.fillAmount = (float)Manager.Production/10000 ;
        
        Full.GetComponent<Image>().fillAmount = (float)Manager.Production/main.ScoreToJauge ;
    }
}

