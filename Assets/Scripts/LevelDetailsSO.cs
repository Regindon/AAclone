using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelDetails_", menuName = "Scriptable Objects/Level/Level Details")]
public class LevelDetailsSO : ScriptableObject
{
    #region Header LEVEL DETAILS

    [Space(10)]
    [Header("LEVEL DETAILS")]

    #endregion

    #region Tooltip

    [Tooltip("Mid Circle Prefab")]

    #endregion

    public GameObject midCirclePrefab;
    
    #region Tooltip

    [Tooltip("Point Prefab")]

    #endregion

    public GameObject pointPrefab;
    
    #region Tooltip

    [Tooltip("Rotation speed of Mid Circle")]

    #endregion

    public float midCircleRotateSpeed;
    
    #region Tooltip

    [Tooltip("Number of Points will be spawned in level")]

    #endregion

    public int pointCounts;
    
    #region Tooltip

    [Tooltip("How many projectiles player have")]

    #endregion

    public int playerProjectileCount;
    
    
    #region Tooltip

    [Tooltip("Which mechanic does level have")]

    #endregion

    public MechanicType mechanicType;
    
    
    
    public enum MechanicType
    {
        None,
        SpeedChange,
        RotationChange,
    }

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        Debug.Log("check if values are null or not here");
    }
#endif
    #endregion

}
