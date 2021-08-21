using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    int score;
    const string pretext = "Score: ";
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = pretext + score.ToString();
    }
    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = pretext + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
