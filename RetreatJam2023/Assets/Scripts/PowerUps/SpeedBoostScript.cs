using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{

    float oldSpeed;
    PlayerMovement pm = null;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject m_light;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            pm = collision.transform.GetComponent<PlayerMovement>();

            m_light.SetActive(false);
            pm.GetMad();
            GetComponent<BoxCollider2D>().enabled = false;
            sprite.sprite = null;

            StartCoroutine(SpeedBoostTime(3));

        }
    }

    IEnumerator SpeedBoostTime(float time)
    {
        yield return new WaitForSeconds(time);
        pm.CalmDown();

        pm = null;

        Destroy(this);
        
    }
}
