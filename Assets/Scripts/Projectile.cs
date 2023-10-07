using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    [SerializeField] private float speed = 11f;
    [HideInInspector] public bool stopped = true;
    
    public GameObject midCircle;
    private LineRenderer _lineRenderer;
    private bool _attached;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (_attached)
        {
            UpdateLine();
        }
        if (stopped) return;
        var newPosition = transform.position + Vector3.up * speed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        stopped = true;
        //transform.position = Vector2.zero;
        if (other.gameObject.CompareTag("MidCircle"))
        {
            //setting parent
            transform.SetParent(other.gameObject.transform);
            transform.tag = "Point";
            _attached = true;
            
        }
        else if (other.gameObject.CompareTag("Point"))
        {
            Debug.Log("projectile touched point");
            GameManager.Instance.gameStateEvent.ChangeGameState(GameState.gameLost);
        }
    }
    
    private void UpdateLine()
    {
        _lineRenderer.SetPosition(0,gameObject.transform.position);
        _lineRenderer.SetPosition(1,midCircle.transform.position);
        
    }
}
