using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassSprite : MonoBehaviour
{
    [SerializeField] GameObject m_light;
    public List<CamperMovement> campers;

    public CamperMovement closestCamper;

    public GameObject arrow;

    public PlayerMovement pm = null;

    public WinOrLoseCondition wlc;

    public SpriteRenderer sprite;

    public static bool inUse = false;

    private void Start()
    {
        wlc = FindObjectOfType<WinOrLoseCondition>();
    }


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

            m_light.SetActive(false);
            sprite.sprite = null;
            GetComponent<BoxCollider2D>().enabled = false;

            StartCoroutine(ShowClosestCamper(5));
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
            Quaternion newRot = Quaternion.Euler(0, 0, (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90);
            newArrow.transform.rotation = Quaternion.Lerp(newArrow.transform.rotation, newRot, .2f);

            yield return new WaitForFixedUpdate();
        }

        inUse = false;

        Destroy(newArrow);

        Destroy(this);
    }
}
