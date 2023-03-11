using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{
    public ExposureLight Top;
    public ExposureLight Bot;
    public ExposureLight Right;
    public ExposureLight Left;

    public Button SelectTop;
    public Button SelectBot;
    public Button SelectRight;
    public Button SelectLeft;

    public Button SwithcRed;
    public Button SwitchGreen;

    public ExposureLight selected;
    public Button selectedButton;

    public Sprite HilightGreen;
    public Sprite HilightRed;
    public Sprite DarkGreen;
    public Sprite DarkRed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Deselect()
    {
        
    }

    private void OnSelectTop()
    {
        Deselect();
        selected = Top;
        selectedButton = SelectTop;
    }

    private void OnSelectBot()
    {
        Deselect();
        selected = Bot;
        selectedButton = SelectBot;
    }

    private void OnSelectRight()
    {
        Deselect();
        selected = Right;
        selectedButton = SelectRight;
    }

    private void OnSelectLeft()
    {
        Deselect();
        selected = Left;
        selectedButton = SelectLeft;
    }
}
