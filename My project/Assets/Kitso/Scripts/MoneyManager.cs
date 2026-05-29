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
        moneyText.text = " found: R" + moneyCount.ToString() + "00";
        DontDestroyOnLoad(moneyText);
    }
}
