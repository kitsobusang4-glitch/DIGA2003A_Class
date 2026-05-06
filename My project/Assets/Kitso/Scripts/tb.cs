using System.Collections;
using UnityEngine;

public class tb : MonoBehaviour
{
    public Animator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PunchAnim()
    {
        playerAnimator.SetTrigger("Punchch");

        StartCoroutine(Delayer());

        playerAnimator.SetTrigger("Stand");
    }

    public void KickAnim()
    {
        playerAnimator.SetTrigger("PlayerKick");

        StartCoroutine(Delayer());

        playerAnimator.SetTrigger("Stand");
    }
    IEnumerator Delayer()
    {
        yield return new WaitForSeconds(4f);
    }
}
