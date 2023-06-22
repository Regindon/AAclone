using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


[DisallowMultipleComponent]
public class GameManager : SingletonMonobehaviour<GameManager>
{
    [HideInInspector] public GameState gameState;
    [SerializeField]private int[] pointInfoArray;
    public int[] projectileInfoArray;
    public GameObject midCirclePrefab;
    public GameObject pointPrefab;
    private int _level = 1;
    
    
    

    protected override void Awake()
    {
        base.Awake();
        Screen.SetResolution(460,812,false);
    }

    private void Start()
    {
        gameState = GameState.gameStarted;

    }

    private void Update()
    {
        CheckGameState();
    }

    

    public void StartGame(int lvl)
    {
        GameObject spawnedCircle = Instantiate(midCirclePrefab, new Vector3(0f, 1f, 0f), Quaternion.identity);
        var numberOfPoints = pointInfoArray[lvl-1];
        var angleIncrement = 360f / numberOfPoints;
        var radius = 2;

        for (int i = 0; i < numberOfPoints; i++)
        {
            var angle = i * angleIncrement;
            var position = spawnedCircle.transform.position;
            var x = position.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            var y = position.y + radius * Mathf.Sin(Mathf.Deg2Rad * angle);
            
            GameObject spawnedPoint = Instantiate(pointPrefab, new Vector3(x, y, 0f), quaternion.identity);
            spawnedPoint.transform.SetParent(spawnedCircle.transform);
            
        }

        gameState = GameState.gamePlaying;
    }



    private void CheckGameState()
    {
        switch (gameState)
        {
            case GameState.gameStarted:
                StartGame(_level);
                break;
            case GameState.gameLost:
                GameLostFunc();
                break;
            case GameState.gameWon:
                GameWonFunc();
                break;
            default:
                Debug.Log("default");
                break;
        }
    }
    
    private void GameLostFunc()
    {
        throw new NotImplementedException();
    }
    
    private void GameWonFunc()
    {
        throw new NotImplementedException();
    }

    
}
