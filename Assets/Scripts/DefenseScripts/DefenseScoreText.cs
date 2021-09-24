using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseScoreText : MonoBehaviour
{
    public static DefenseScoreText scoreText;
    [SerializeField] private Text killTextDefense;
    [SerializeField] private Text defenseHighKillText;

    [SerializeField] private Text missionText;

    public int killAmountDefense;
    public int highKillAmountDefense;

    public int killAmountSave;






   void Awake()
    {
        scoreText = this;

        
    }


    void Start()
    {
        highKillAmountDefense = PlayerPrefs.GetInt("highKillAmountDefense", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject == null)
        {
            return;  
        }
        
        killTextDefense.text = "Kill: " + killAmountDefense;
        defenseHighKillText.text = "High Kill: " + highKillAmountDefense;

        if (killAmountDefense >= 5)
        {
            missionText.text = "Taip ir toliau !!!";
        }
        if (killAmountDefense >= 20)
        {
            missionText.text = "You are MONSTER !!!";
        }
        

    }
}
