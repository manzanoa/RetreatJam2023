using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{

    float oldSpeed;
    PlayerMovement pm = null;
    [SerializeField] SpriteRenderer sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            pm = collision.transform.GetComponent<PlayerMovement>();
            Time.timeScale = .5f;
            pm.moveSpeed *= 2;
            sprite.sprite = null;

            StartCoroutine(SpeedBoostTime(3));

        }
    }

    IEnumerator SpeedBoostTime(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 1;
        pm.moveSpeed /= 2;

        pm = null;

        Destroy(this);
        
    }
}
