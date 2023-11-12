using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CopCar : MonoBehaviour
{
    [SerializeField] GameObject CopCarObject;
    [SerializeField] CopsDeployed Cops;
    [SerializeField] GameObject CopCarLights;
    bool copCarCreated = false;
    public bool copCarParking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cops.copsDepolyed && !copCarCreated)
        {
            copCarCreated = true;
        }
        if(copCarCreated == true && copCarParking == false)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
            if(transform.position.x >= -4)
            {
                copCarParking = true;
            }
        }
        if (Cops.copsDepolyed)
        {
            CopCarLights.SetActive(true);
            CopCarLights.transform.Rotate(0, 0, 200 * Time.deltaTime);
        }
    }
}
