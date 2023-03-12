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

    public ExposureLightType BaseExposureLightType;

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
            on = value;
            if (!value)
            {
                GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                ChangeColor();
            }
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Type = BaseExposureLightType;
        ChangeColor();
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

    
}
