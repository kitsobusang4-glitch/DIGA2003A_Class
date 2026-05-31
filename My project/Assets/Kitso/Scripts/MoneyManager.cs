using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int moneyCount;
    public TMP_Text moneyText;
   private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        moneyText.text = " found: R" + moneyCount.ToString() + "00";
        
    }
}
