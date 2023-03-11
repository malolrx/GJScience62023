using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExposureLight : MonoBehaviour
{
    public enum ExposureLightType
    {
        RED,
        GREEN,
        NO
    }

    public ExposureLightType type;
    public ExposureLightType Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
            ChangeColor();
        }
    }

    public GameObject Controllers;
    private Button Redbut;
    private Button Nobut;
    private Button Greenbut;

    // Start is called before the first frame update
    void Start()
    {
        ChangeColor();
        Debug.Log(Controllers.GetComponentsInChildren<Button>().Length);
        Nobut = Controllers.GetComponentsInChildren<Button>()[0];
        Greenbut = Controllers.GetComponentsInChildren<Button>()[1];
        Redbut = Controllers.GetComponentsInChildren<Button>()[2];

        Nobut.onClick.AddListener(No);
        Greenbut.onClick.AddListener(Green);
        Redbut.onClick.AddListener(Red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsInLight(Vector3 position)
    {
        return GetComponent<Collider2D>().bounds.Contains(position);
    }

    public void ChangeColor()
    {
        switch (Type)
        {
            case ExposureLightType.RED:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case ExposureLightType.GREEN:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case ExposureLightType.NO:
                GetComponent<SpriteRenderer>().color = Color.gray;
                break;
        }
    }

    public void Red()
    {
        Type = ExposureLightType.RED;
    }

    public void Green()
    {
        Type = ExposureLightType.GREEN;
    }

    public void No()
    {
        Type = ExposureLightType.NO;
    }
}
