using UnityEngine;

public class Portal2 : MonoBehaviour
{
    private Transform destination;

    public bool isTP4;
    public float distance = 0.2f;
    
    void Start()
    {
        if (isTP4 == false)
        {
            destination = GameObject.FindGameObjectWithTag("TP4").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("TP3").GetComponent<Transform>();
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
