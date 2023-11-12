using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] AudioSource WalkingAudio;
    public float moveSpeed = 5f;  // Movement speed
    public Animator m_animator;
    bool trapped = false;

    void FixedUpdate()
    {
        if (!trapped)
        {
            Move();
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        m_animator.SetFloat("Horizontal", horizontalInput);
        float verticalInput = Input.GetAxis("Vertical");
        m_animator.SetFloat("Vertical", verticalInput);
        m_animator.SetFloat("Speed", new Vector2(horizontalInput, verticalInput).magnitude);

        Vector2 direction = new Vector2(horizontalInput, verticalInput).normalized;
        float magnitude = new Vector2(horizontalInput, verticalInput).magnitude;
        if (magnitude > .1f)
        {
            if (!WalkingAudio.isPlaying)
            {
                WalkingAudio.Play();
            }
        }
        else
        {
            if (WalkingAudio.isPlaying)
            {
                WalkingAudio.Stop();
            }
        }
        if (magnitude > 1) { magnitude = 1; }

        Vector3 movement = direction * magnitude * moveSpeed * Time.fixedDeltaTime;

        transform.Translate(movement);
    }

    public void GetMad()
    {
        moveSpeed *= 2f;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void CalmDown()
    {
        moveSpeed /= 2f;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Trapped()
    {
        trapped = true;
        m_animator.SetFloat("Speed", 0);
        StartCoroutine("GotTrapped");
    }

    IEnumerator GotTrapped()
    {
        yield return new WaitForSeconds(2f);
        trapped = false;
    }
}
