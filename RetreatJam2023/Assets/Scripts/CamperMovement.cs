using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamperMovement : MonoBehaviour
{
    Vector2 moveDirection;
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed;
    [SerializeField] FieldOfView fieldOfView;
    [SerializeField] GameObject fieldOfViewPrefab;
    [SerializeField] List<GameObject> BodyParts;
    bool dying = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject fieldOfViewObj = Instantiate(fieldOfViewPrefab);
        fieldOfView = fieldOfViewObj.GetComponent<FieldOfView>();
        fieldOfView.SetCamper(GetComponent<CamperStateManager>());
        SetFieldOfView();

        CalculateRandomDirection();
    }
    public void HideFieldOfView()
    {
        fieldOfView.TurnOffLight();
    }

    public void ShowFieldOfView()
    {
        fieldOfView.TurnOnLight();
    }
    public void GoFast()
    {
        moveSpeed = moveSpeed * 3;
    }

    public void GoSlow()
    {
        moveSpeed = moveSpeed / 3;
    }

    public void ChangeDirection(Vector2 dir)
    {
        moveDirection = dir;
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        FindMoveDirection();
    }
        

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (fieldOfView != null)
        {
            SetFieldOfView();
        }
    }

    void SetFieldOfView()
    {
        fieldOfView.SetOrigin(transform.position);
    }

    void Move()
    {
        if (!dying)
        {
            Vector3 movement = moveDirection * moveSpeed * Time.fixedDeltaTime;

            transform.Translate(movement);
        }
    }

    void CalculateRandomDirection()
    {
        float horizontal = Random.Range(-1f, 1f);
        float vertical = Random.Range(-1f, 1f);
        moveDirection = new Vector2(horizontal, vertical).normalized;

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);


        //Always be moving
       // animator.SetFloat("Speed", 1f);
        FindMoveDirection();
    }

    void FindMoveDirection()
    {
        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            if (moveDirection.x > 0)
            {
                fieldOfView.SetAimDirection(transform.up);
            }
            else
            {
                fieldOfView.SetAimDirection(-transform.up);
            }
        }
        else
        {
            if (moveDirection.y > 0)
            {
                fieldOfView.SetAimDirection(-transform.right);
            }
            else
            {
                fieldOfView.SetAimDirection(transform.right);
            }
        }
    }

    public void DeathEvent()
    {
        if (FindObjectOfType<WinOrLoseCondition>() != null)
        {
            FindObjectOfType<WinOrLoseCondition>().CamperDied(this);
        }
        int randomIndex = Random.Range(0, BodyParts.Count);
        Instantiate(BodyParts[randomIndex], transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void HitTrap()
    {
        GetComponent<CamperStateManager>().Dying();
        dying = true;
        GetComponent<Animator>().SetTrigger("Dead");
        if (fieldOfView)
        {
            Destroy(fieldOfView.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<PlayerMovement>() != null)
        {
            if (fieldOfView)
            {
                Destroy(fieldOfView.gameObject);
            }
            GetComponent<CamperStateManager>().FoundPlayer(collision.gameObject);
            GetComponent<CamperStateManager>().Dying();
            dying = true;
            GetComponent<Animator>().SetTrigger("Dead");
        }
        else
        {
            MoveInDirectionFromObject(collision.GetContact(0).point);
        }
    }

    public void MoveInDirectionFromObject(Vector2 Pos)
    {
        Vector2 directionOfTouch = (Vector2)transform.position - Pos;
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
        FindMoveDirection();
    }
}
