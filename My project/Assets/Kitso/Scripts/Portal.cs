using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;

    public bool isTP2;
    public float distance = 0.2f;
    void Start()
    {
        if (isTP2 == false)
        {
            destination = GameObject.FindGameObjectWithTag("TP2").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("TP1").GetComponent<Transform>();
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