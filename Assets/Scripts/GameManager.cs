using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


[DisallowMultipleComponent]
public class GameManager : SingletonMonobehaviour<GameManager>
{
    [HideInInspector] public GameState gameState;
    [HideInInspector] public GameStateEvent gameStateEvent;
    public LevelDetailsSO[] levelDetailsSOArray;
    [HideInInspector] public LevelDetailsSO lvlDetails;
    private int _level = 1;
    


    
    private void OnEnable()
    {
        gameStateEvent = GetComponent<GameStateEvent>();
        gameStateEvent.OnGameStateChange += HandleGameStateChange;

    }

    protected override void Awake()
    {
        base.Awake();
        Screen.SetResolution(460,812,false);
    }
    

    private void Start()
    {
        lvlDetails = levelDetailsSOArray[0];
        gameStateEvent.ChangeGameState(GameState.gameStarted);

    }

    private void Update()
    {
        

    }


    private void StartGame(int lvl)
    {
        var spawnedCircle = Instantiate(lvlDetails.midCirclePrefab, new Vector3(0f, 1f, 0f), Quaternion.identity);
        var numberOfPoints = lvlDetails.pointCounts;
        var angleIncrement = 360f / numberOfPoints;
        var radius = 2;

        for (int i = 0; i < numberOfPoints; i++)
        {
            var angle = i * angleIncrement;
            var position = spawnedCircle.transform.position;
            var x = position.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            var y = position.y + radius * Mathf.Sin(Mathf.Deg2Rad * angle);
            
            GameObject spawnedPoint = Instantiate(lvlDetails.pointPrefab, new Vector3(x, y, 0f), quaternion.identity);
            spawnedPoint.transform.SetParent(spawnedCircle.transform);
            
        }

        gameStateEvent.ChangeGameState(GameState.gamePlaying);
    }



    private void HandleGameStateChange(GameState newState)
    {
        
        switch (newState)
        {
            case GameState.gameStarted:
                gameState = GameState.gameStarted;
                StartGame(_level);
                break;
            case GameState.gameLost:
                gameState = GameState.gameLost;
                GameLostFunc();
                break;
            case GameState.gameWon:
                gameState = GameState.gameWon;
                GameWonFunc();
                break;
            
            
        }
    }
    
    private void GameLostFunc()
    {
        //clean objects on scene, mid circle and points
        Debug.Log("Game lost");
        // reload the same level on key pressed
    }
    
    private void GameWonFunc()
    {
        //clean objects on scene, mid circle and points
        Debug.Log("game won");
        //do something and lvl up
        _level++;
        //update level details 
        lvlDetails = levelDetailsSOArray[_level - 1];
        
        //after that i should create the new level with updated level details
    }

    

    
}
