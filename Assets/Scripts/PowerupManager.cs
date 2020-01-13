using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private static PowerupManager _instance;

    public static PowerupManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PowerupManager>();
            }

            return _instance;
        }
    }

    [SerializeField]
    private List<Powerup> powerupList = new List<Powerup>();

    public int instancedPowerups;

    private void Start()
    {
        SpawnRandomPowerup(SpawnPointGenerator());
    }


    public void Update()
    {
        while(instancedPowerups < 2)
        {
            SpawnRandomPowerup(SpawnPointGenerator());
        }
    }
    private void SpawnRandomPowerup(Vector3 spawnPoint)
    {
        int index = Random.Range(0, powerupList.Count);
        Instantiate(powerupList[index].gameObject, spawnPoint, Quaternion.identity);
    }

    private Vector3 SpawnPointGenerator()
    {
        float x = Random.Range(-8.9f, 8.9f);
        float z = Random.Range(-8.9f, 8.9f);
        float y = 0.49f;

        return new Vector3(x, y, z);
    }

    public void IncreasePowerups()
    {
        instancedPowerups++;
    }
    public void DecreasePowerups()
    {
        instancedPowerups--;
    }
}
