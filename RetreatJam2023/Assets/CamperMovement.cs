using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamperMovement : MonoBehaviour
{
    Vector2 moveDirection;
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        CalculateRandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

    void CalculateRandomDirection()
    {
        float horizontal = Random.Range(-1f, 1f);
        float vertical = Random.Range(-1f, 1f);
        moveDirection = new Vector2(horizontal, vertical).normalized;

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);


        //Always be moving
        animator.SetFloat("Speed", 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 directionOfTouch = (Vector2)transform.position - collision.GetContact(0).point;
        if (Mathf.Abs(directionOfTouch.x) > Mathf.Abs(directionOfTouch.y))
        {
            moveDirection = new Vector2(-moveDirection.x, moveDirection.y);
        }
        else
        {
            moveDirection = new Vector2(moveDirection.x, -moveDirection.y);
        }
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
    }
}
