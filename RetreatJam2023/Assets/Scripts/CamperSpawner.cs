using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamperSpawner : MonoBehaviour
{
    
    [SerializeField] GameObject camper;
    [SerializeField] List<Transform> spawLocations;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Transform spawnLocal in spawLocations)
        {
            Instantiate(camper, spawnLocal.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
