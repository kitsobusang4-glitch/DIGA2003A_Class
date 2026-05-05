using UnityEngine;

public class CombatAnimation : MonoBehaviour
{
    public Animator characterAnimation;
    
    public void OnPunchButtonPressed()
    {
        characterAnimation.SetTrigger("Punch");
    }
}
