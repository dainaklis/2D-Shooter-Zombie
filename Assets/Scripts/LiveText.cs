using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveText : MonoBehaviour
{
    [SerializeField] private Text liveText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        liveText.text = "Live: " + Player1Android.player1Android.currentHealth + " / 20 ";
        
    }
}
