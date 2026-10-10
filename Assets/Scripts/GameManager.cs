using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public TMP_Text collectiblesNumbersText;
    
    private int collectiblesNumber;

    public TMP_Text totalCollectiblesNumbersText;
    
    private int totalCollectiblesNumber;


    void Start()
    {
        totalCollectiblesNumber = transform.childCount;
        totalCollectiblesNumbersText.text = totalCollectiblesNumber.ToString();
    }


    void Update ()
    {
        if (transform.childCount <= 0)
        {
            Debug.Log("You Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }




    public void AddCollectible()
    {
       collectiblesNumber = collectiblesNumber + 1;
       
       collectiblesNumbersText.text = collectiblesNumber.ToString(); 

    }





}
