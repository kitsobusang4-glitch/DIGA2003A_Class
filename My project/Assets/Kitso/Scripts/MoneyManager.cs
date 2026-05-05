using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int moneyCount;
    public TextMeshProUGUI moneyText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Cash found: " + moneyCount.ToString();
    }
}
