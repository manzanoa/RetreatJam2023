using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassSprite : MonoBehaviour
{
    public List<CamperMovement> campers;

    public CamperMovement closestCamper;

    public GameObject arrow;

    public PlayerMovement pm = null;

    public WinOrLoseCondition wlc;

    public SpriteRenderer sprite;

    public static bool inUse = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player") && !inUse)
        {
            inUse = true;
            pm = collision.GetComponent<PlayerMovement>();
            campers = wlc.allCampers;
            float closestDist = Mathf.Infinity;
            foreach (CamperMovement camper in campers)
            {
                float x = collision.transform.position.x - camper.transform.position.x;
                float y = collision.transform.position.y - camper.transform.position.y;
                float distance = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
                if (distance < closestDist)
                {
                    closestDist = distance;
                    closestCamper = camper;
                }
            }

            StartCoroutine(ShowClosestCamper(5));

            sprite.sprite = null;

        }
    }

    IEnumerator ShowClosestCamper(float time)
    {
        float currentTime = 0f;
        Debug.Log("Showing closest camper");

        Vector2 dir = arrow.transform.position - closestCamper.transform.position;
        dir.Normalize();
        arrow.transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90);

        GameObject newArrow = Instantiate(arrow, pm.transform.position, Quaternion.Euler(0, 0, (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90));
        while (currentTime <= time && closestCamper != null)
        {
            currentTime += Time.deltaTime;
            newArrow.transform.position = pm.transform.position;

            dir = newArrow.transform.position - closestCamper.transform.position;
            dir.Normalize();
            newArrow.transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90);


            yield return new WaitForEndOfFrame();
        }

        inUse = false;

        Destroy(newArrow);

        Destroy(this);
    }
}
