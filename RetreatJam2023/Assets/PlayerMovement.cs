using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed
    public Animator m_animator;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        m_animator.SetFloat("Horizontal", horizontalInput);
        float verticalInput = Input.GetAxis("Vertical");
        m_animator.SetFloat("Vertical", verticalInput);
        m_animator.SetFloat("Speed", new Vector2(horizontalInput, verticalInput).magnitude);

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
}
