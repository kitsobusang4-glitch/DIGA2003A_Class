using UnityEngine;
using UnityEngine.InputSystem;

public class PLAYER : MonoBehaviour
{
    public float speed;

    
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Pressed the arrow key");


        }
    }
}
