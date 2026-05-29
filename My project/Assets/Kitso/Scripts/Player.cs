using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 9f;
    private Animator animator;
    bool isWalking = false;
    bool isRunning = false;
    public MoneyManager mm;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        isWalking = false;
        isRunning = false;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y += 1;
            isRunning = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y -= 1;
            isRunning = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x -= 1;
            isWalking = true;
            //transform.localScale = new Vector3(-1, transform.localScale.y);
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x += 1;
            isWalking = true;
            //transform.localScale = new Vector3(1, transform.localScale.y);
            spriteRenderer.flipX = false;
        }
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        
        animator.SetBool("RunRun", isWalking);
        animator.SetBool("ForwardWalk", isRunning);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Money"))
        {
           Destroy(other.gameObject);
            mm.moneyCount++;
        }
    }

}
