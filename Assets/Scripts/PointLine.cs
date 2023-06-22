using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLine : MonoBehaviour
{
    public GameObject midCircle;
    private LineRenderer _lineRenderer;
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
        
    }

    
    void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        _lineRenderer.SetPosition(0,gameObject.transform.position);
        _lineRenderer.SetPosition(1,midCircle.transform.position);
        
    }
    
}
