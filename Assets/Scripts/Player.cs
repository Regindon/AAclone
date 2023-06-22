using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject spawnedProjectile;
    private bool _projectileInstantiated;
    public GameObject projectile;
    void Start()
    {
        InstantiateProjectile();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spawnedProjectile.GetComponent<Projectile>().stopped = false;
            InstantiateProjectile();
        }
    }

    private void InstantiateProjectile()
    {
        spawnedProjectile = Instantiate(projectile, transform);
        
    }
}
