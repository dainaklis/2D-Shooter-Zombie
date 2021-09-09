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

    [Header("Mission Text")]
    [SerializeField] private GameObject misionCompleteText;
    [SerializeField] private GameObject misionText;
    [SerializeField] private Text misionTextScore;

    [SerializeField] private GameObject door1;

    [Header("Defense Mission Text")]

    [SerializeField] private GameObject triusis;
    [SerializeField] private GameObject loseText;
    private GameObject player;


   void Awake()
    {
        scoreText = this;

        
    }


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        highKillAmount = PlayerPrefs.GetInt("highKillAmount", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject == null || door1 == null || player == null)
        {
            return;  
        }
        
        killText.text = "Kill: " + killAmount;
        misionTextScore.text = "Kill " + killAmount +" / 15 to Next Lvl" ;
        highKillText.text = "High Kill: " + highKillAmount;
        
        if (killAmount >= 15)
        {
            door1.SetActive(true);
            misionCompleteText.SetActive(true);
            misionText.SetActive(false);
        }

        // if (triusis == null)
        // {
        //     //loseText.SetActive(true);
            
        //     Destroy(player);
        //     Player1Android.player1Android.CaroutineEplotionPlayer();
        // }


    }

}
