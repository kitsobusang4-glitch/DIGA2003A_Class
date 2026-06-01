using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 9f;
    private Animator animator;
    bool isWalking = false;
    bool isRunning = false;
    bool isBackwalk = false;
    public MoneyManager mm;
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (audioSource != null)
        {
            audioSource.loop = true; // keep footstep sound playing while moving
        }
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        isWalking = false;
        isRunning = false;
        isBackwalk = false;

        // build movement flags
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y += 1;
            isBackwalk = true;
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
            if (spriteRenderer != null) spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x += 1;
            isWalking = true;
            if (spriteRenderer != null) spriteRenderer.flipX = false;
        }

        // audio: play/stop only once per state change and based on whether we are moving
        bool isMoving = moveDirection != Vector3.zero;
        if (audioSource != null)
        {
            if (isMoving)
            {
                if (!audioSource.isPlaying) audioSource.Play();
            }
            else
            {
                if (audioSource.isPlaying) audioSource.Stop();
            }
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        animator.SetBool("RunRun", isWalking);
        animator.SetBool("ForwardWalk", isRunning);
        animator.SetBool("BackwardWalk", isBackwalk);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            mm.moneyCount++;
            Destroy(other.gameObject);
        }
    }
}
