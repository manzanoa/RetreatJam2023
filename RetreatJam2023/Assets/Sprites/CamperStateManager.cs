using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CamperState
{
    Idle = 1,
    Terrified = 2
}
public class CamperStateManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer CamperVisual;
    [SerializeField] GameObject SuprisedObject;
    [SerializeField] float timeUntilNotScared = 3f;
    [SerializeField] float screamRadius = 3f;
    float timerSinceLastSeenPlayer;
    CamperState m_camperState = CamperState.Idle;
    CamperMovement camperMovement;
    private void Start()
    {
        camperMovement = GetComponent<CamperMovement>();
    }


    public void FoundPlayer(GameObject player)
    {
        if (m_camperState == CamperState.Idle)
        {
            GetScared(player);
        }
        timerSinceLastSeenPlayer = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        if (m_camperState == CamperState.Terrified)
        {
            if (Time.time > timerSinceLastSeenPlayer + timeUntilNotScared)
            {
                CalmDown();
            }
        }
    }

    void GetScared(GameObject player)
    {
        m_camperState = CamperState.Terrified;
        camperMovement.HideFieldOfView();
        //Alert others
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, screamRadius);
        foreach(Collider2D collider in colliders)
        {
            if (collider.GetComponent<CamperStateManager>() != null)
            {
                collider.GetComponent<CamperStateManager>().FoundPlayer(player);
            }
        }
        
        camperMovement.GoFast();
        Vector2 dir = (transform.position - player.transform.position).normalized;
        camperMovement.ChangeDirection(dir);
        CamperVisual.color = Color.red;
        SuprisedObject.SetActive(true);
    }

    void CalmDown()
    {
        camperMovement.ShowFieldOfView();
        m_camperState = CamperState.Idle;
        camperMovement.GoSlow();
        SuprisedObject.SetActive(false);
        CamperVisual.color = Color.white;
    }

    public void Dying()
    {
        CamperVisual.color = Color.white;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, screamRadius);
    }
}
