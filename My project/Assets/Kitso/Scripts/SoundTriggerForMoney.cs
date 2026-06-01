using UnityEngine;

public class SoundTriggerForMoney : MonoBehaviour
{
    AudioSource source;
    Collider2D soundTrigger;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (source != null && source.clip != null)
            {
                AudioSource.PlayClipAtPoint(source.clip, transform.position);
            }
        }
    }
}
