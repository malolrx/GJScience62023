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

    private ExposureLightType type;
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

    private bool on;
    public bool ON
    {
        get
        {
            return on;
        }

        set
        {
            if (value)
            {
                GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                ChangeColor();
            }
        }
    }

    public GameObject Controllers;
    private Button Redbut;
    private Button Nobut;
    private Button Greenbut;
    private ExposureLightType beforeNo;

    // Start is called before the first frame update
    void Start()
    {
        beforeNo = ExposureLightType.GREEN;
        ChangeColor();
        Debug.Log(Controllers.GetComponentsInChildren<Button>().Length);
        Nobut = Controllers.GetComponentsInChildren<Button>()[0];
        Greenbut = Controllers.GetComponentsInChildren<Button>()[1];
        Redbut = Controllers.GetComponentsInChildren<Button>()[2];

        Nobut.onClick.AddListener(SwitchOn);
        Greenbut.onClick.AddListener(Green);
        Redbut.onClick.AddListener(Red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsInLight(Vector3 position)
    {
        return GetComponent<Collider2D>().bounds.Contains(position) && ON;
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

    public void SwitchOn()
    {
        ON = !ON;
    }
}
