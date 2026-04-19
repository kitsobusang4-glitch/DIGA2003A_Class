using UnityEngine;

public class Portal4 : MonoBehaviour
{
    private Transform destination;

    public bool isTP8;
    public float distance = 0.2f;
    void Start()
    {
        if (isTP8 == false)
        {
            destination = GameObject.FindGameObjectWithTag("TP8").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("TP7").GetComponent<Transform>();
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
