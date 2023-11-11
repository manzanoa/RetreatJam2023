using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamperSpawner : MonoBehaviour
{
    
    [SerializeField] GameObject camper;
    [SerializeField] Transform spawnLoc1;
    [SerializeField] Transform spawnLoc2;
    [SerializeField] Transform spawnLoc3;
    [SerializeField] Transform spawnLoc4;
    [SerializeField] Transform spawnLoc5;
    [SerializeField] Transform spawnLoc6;
    [SerializeField] Transform spawnLoc7;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(camper, spawnLoc1.position, Quaternion.identity);
        Instantiate(camper, spawnLoc2.position, Quaternion.identity);
        Instantiate(camper, spawnLoc3.position, Quaternion.identity);
        Instantiate(camper, spawnLoc4.position, Quaternion.identity);
        Instantiate(camper, spawnLoc5.position, Quaternion.identity);
        Instantiate(camper, spawnLoc6.position, Quaternion.identity);
        Instantiate(camper, spawnLoc7.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
