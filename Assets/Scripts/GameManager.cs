using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TMP_Text collectiblesNumbersText;
    
    private int collectiblesNumber;

    public void AddCollectible()
    {
       collectiblesNumbersText.text = collectiblesNumber.ToString();
       
       collectiblesNumber = collectiblesNumber + 1; 

    }





}
