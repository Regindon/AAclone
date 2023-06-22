using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidCircle : MonoBehaviour
{
    private float rotationSpeed = 90f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.gamePlaying) return;
        
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        
    }
}

