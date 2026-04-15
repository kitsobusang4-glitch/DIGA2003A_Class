using System.Collections;
using UnityEngine;

public abstract class SceneTransitions : MonoBehaviour
{
    public abstract IEnumerator AnimateTransitionIn();
    public abstract IEnumerator AnimateTransitionOut();
}
