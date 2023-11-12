using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>() != null)
        {
            GetComponent<Animator>().SetTrigger("Trapped");
            GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<PlayerMovement>().Trapped();
        } else if(collision.GetComponent<CamperMovement>() != null)
        {
            if (collision.GetComponent<CamperStateManager>().m_camperState == CamperState.Terrified)
            {
                GetComponent<Animator>().SetTrigger("Trapped");
                GetComponent<BoxCollider2D>().enabled = false;
                collision.GetComponent<CamperMovement>().HitTrap();
            }
            else
            {
                collision.GetComponent<CamperMovement>().MoveInDirectionFromObject(transform.position);
            }
        }
    }
}
