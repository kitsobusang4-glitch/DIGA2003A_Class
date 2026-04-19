using UnityEngine;

public class Portal8 : MonoBehaviour
{
    private Transform destination;

    public bool isTP16;
    public float distance = 0.2f;
    void Start()
    {
        if (isTP16 == false)
        {
            destination = GameObject.FindGameObjectWithTag("TP16").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("TP15").GetComponent<Transform>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
        }

    }
}
