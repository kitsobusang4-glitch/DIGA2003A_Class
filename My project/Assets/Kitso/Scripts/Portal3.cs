using UnityEngine;

public class Portal3 : MonoBehaviour
{
    private Transform destination;

    public bool isTP6;
    public float distance = 0.2f;
    void Start()
    {
        if (isTP6 == false)
        {
            destination = GameObject.FindGameObjectWithTag("TP6").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("TP5").GetComponent<Transform>();
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
