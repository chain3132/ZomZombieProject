using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (GameManager.Instance == null) return;
        
        SetScore(GameManager.Instance.GetScore());
    }
    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
