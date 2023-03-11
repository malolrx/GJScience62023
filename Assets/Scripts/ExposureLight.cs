using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExposureLight : MonoBehaviour
{
    public enum ExposureLightType
    {
        RED,
        GREEN,
        NO
    }

    public ExposureLightType Type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsInLight(Vector3 position)
    {
        return GetComponent<Collider2D>().bounds.Contains(position);
    }

}
