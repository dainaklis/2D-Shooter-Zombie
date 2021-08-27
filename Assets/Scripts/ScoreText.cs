using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public static ScoreText scoreText;
    [SerializeField] private Text killText;
    [SerializeField] private Text highKillText;
    public int killAmount;
    public int highKillAmount;

    public int killAmountSave;

    [SerializeField] private GameObject misionCompleteText;
    [SerializeField] private GameObject misionText;

    [SerializeField] private GameObject door1;


    void Awake()
    {
        scoreText = this;

        
    }


    void Start()
    {
        highKillAmount = PlayerPrefs.GetInt("highKillAmount", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject == null || door1 == null)
        {
            return;  
        }
        
        killText.text = "Kill: " + killAmount;
        highKillText.text = "High Kill: " + highKillAmount;
        
        if (killAmount == 15)
        {
            door1.SetActive(true);
            misionCompleteText.SetActive(true);
            misionText.SetActive(false);
        }

    }

}
