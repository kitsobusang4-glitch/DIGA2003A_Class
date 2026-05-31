using TMPro;
using UnityEngine;

public class MoneyStuff : MonoBehaviour
{ 
    public static MoneyStuff Instance;

    public int moneyCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

