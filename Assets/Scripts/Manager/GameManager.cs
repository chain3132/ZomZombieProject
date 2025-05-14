using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int level  { get; private set; }
    public int currentscore{ get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region  Setters and Getters
    
    public void SetLevel(int level)
    {
        this.level = level;
        SceneManager.LoadScene(level + 2);
    }
    public int GetLevel()
    {
        return this.level;
    }
    public void AddScore(int score)
    {
        this.currentscore += score;
    }
    public int GetScore()
    {
        return this.currentscore;
    }
    #endregion
    
}
