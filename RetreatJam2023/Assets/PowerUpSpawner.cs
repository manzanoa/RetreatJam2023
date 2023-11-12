using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> PowerUpPrefabs;
    [SerializeField] float timeBetweenSpawningPowerUps = 10f;
    [SerializeField] float radiusOfPowerUpSpawn = 6f;
    [SerializeField] float xMax;
    [SerializeField] float yMax;
    [SerializeField] float xMin;
    [SerializeField] float yMin;
    float LastTimeSinceSpawnedPowerUp;
    PlayerMovement playerMovement;
    [SerializeField] LayerMask EnvironmentLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        AttemptToSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > LastTimeSinceSpawnedPowerUp + timeBetweenSpawningPowerUps)
        {
            AttemptToSpawn();
        }
    }

    void AttemptToSpawn()
    {
        float xPosIncrease = Random.Range(-radiusOfPowerUpSpawn, radiusOfPowerUpSpawn);
        float yPosIncrease = Random.Range(-radiusOfPowerUpSpawn, radiusOfPowerUpSpawn);
        Vector2 pos = new Vector2(Mathf.Clamp(playerMovement.transform.position.x + xPosIncrease, xMin,  xMax), Mathf.Clamp(playerMovement.transform.position.y + yPosIncrease, yMin, yMax));
        //Try again
        if (Physics2D.OverlapCircle(pos, 1f, EnvironmentLayerMask)){
            AttemptToSpawn();
        }
        else
        {
            LastTimeSinceSpawnedPowerUp = Time.time;
            int randomIndex = Random.Range(0, PowerUpPrefabs.Count);
            Instantiate(PowerUpPrefabs[randomIndex], pos, Quaternion.identity);
        }
    }
}
