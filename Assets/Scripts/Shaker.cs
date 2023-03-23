using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shaker : MonoBehaviour
{

    public Sprite PressedButton;
    public Sprite NotPressedButton;
    
    public bool ispressed;
    public bool isPressed {
        get {return ispressed;}
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnPointerDown);
        ispressed = false;
    }

    public void OnPointerDown(){
        Debug.Log("bouton pressé");
        ispressed = !ispressed;
        if  (ispressed) 
            GetComponent<Image>().sprite = PressedButton;
        else 
            GetComponent<Image>().sprite = NotPressedButton;
    }
    
    public void OnPointerUp(){
        ispressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
