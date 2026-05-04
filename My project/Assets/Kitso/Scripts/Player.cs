using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 9f;
    private Animator animator;
    bool isWalking = false;
  
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        isWalking = false;


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y -= 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x -= 1;
            isWalking = true;
            transform.localScale = new Vector3(-1, transform.localScale.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x += 1;
            isWalking = true;
            transform.localScale = new Vector3(1, transform.localScale.y);
        }
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        
        animator.SetBool("RunRun", isWalking);
    }
}
