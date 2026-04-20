using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialText;

    void Update()
    {
        // If player presses any movement key hide tutorail
        if (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            tutorialText.SetActive(false);
        }
    }
}