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
    [SerializeField] List<AudioClip> FrieghtendAudio;
    [SerializeField] AudioSource audioSource;
    [SerializeField] SpriteRenderer CamperVisual;
    [SerializeField] GameObject SuprisedObject;
    [SerializeField] float timeUntilNotScared = 3f;
    [SerializeField] float screamRadius = 3f;
    float timerSinceLastSeenPlayer;
    public CamperState m_camperState = CamperState.Idle;
    CamperMovement camperMovement;
    private void Start()
    {
        camperMovement = GetComponent<CamperMovement>();
    }


    public void FoundPlayer(GameObject player, bool fromDeath = false)
    {
        if (m_camperState == CamperState.Idle)
        {
            GetScared(player, fromDeath);
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

    void GetScared(GameObject player, bool goingToDie)
    {

        if (!goingToDie)
        {
            int randomScaredIndex = Random.Range(0, FrieghtendAudio.Count);
            audioSource.clip = FrieghtendAudio[randomScaredIndex];
            audioSource.Play();
        }
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
        FindAnyObjectByType<AudioManager>().SomeoneScared();

    }

    void CalmDown()
    {
        camperMovement.ShowFieldOfView();
        m_camperState = CamperState.Idle;
        camperMovement.GoSlow();
        SuprisedObject.SetActive(false);
        CamperVisual.color = Color.white;

        FindAnyObjectByType<AudioManager>().SomoneChill();
    }

    public void Dying()
    {
        CamperVisual.color = Color.white;
        FindAnyObjectByType<AudioManager>().SomeoneDead();

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, screamRadius);
    }
}
