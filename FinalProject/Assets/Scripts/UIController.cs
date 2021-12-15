using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    public TextMeshProUGUI scoreText;


    //Set the score on the screen after update
    private void scoreUpdate(int score)
    {
        scoreText.text = score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.scoreUpdate.AddListener(scoreUpdate); //Sub to score update event
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
