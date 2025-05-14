using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameSelectManager : MonoBehaviour
{
    [SerializeField] private Sprite[] levelSprites;
    [SerializeField] private Image levelImage;
    [SerializeField] private Button confirmButton;
    [SerializeField] private int currentLevelIndex = 0;
    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject lockImage;
    [SerializeField] private int[] scoresToUnlockLevels;

    private void Start()
    {
        SetDefault();
    }

    public void SetDefault()
    {
        currentLevelIndex = 0;
        levelImage.sprite = levelSprites[currentLevelIndex];
        lockImage.SetActive(false);
        warningText.gameObject.SetActive(false);
        levelText.text = "Level " + (currentLevelIndex + 1);
    }
    public void ConfirmLevel()
    {
        GameManager.Instance.SetLevel(currentLevelIndex );
        
    }
    public void IsCanPlay()
    {
        if (GameManager.Instance == null) return;
        if (GameManager.Instance.GetScore() >= scoresToUnlockLevels[currentLevelIndex])
        {
            lockImage.SetActive(false);
            warningText.gameObject.SetActive(false);
            confirmButton.interactable = true;
        }
        else
        {
            lockImage.SetActive(true);
            warningText.gameObject.SetActive(true);
            warningText.text = "Level " + (currentLevelIndex + 1) + " is locked. \n You need " + (scoresToUnlockLevels[currentLevelIndex] - GameManager.Instance.GetScore()) + " more points to unlock this level.";
            confirmButton.interactable = false;
        }
    }
    public void NextLevel()
    {
        if (currentLevelIndex < levelSprites.Length - 1)
        {
            currentLevelIndex++;
            UpdateLevelImage();
        }
        else if(currentLevelIndex >= levelSprites.Length - 1)
        {
            currentLevelIndex = 0;
            UpdateLevelImage();
        }
        IsCanPlay();
    }
    public void PreviousLevel()
    {
        if (currentLevelIndex > 0)
        {
            currentLevelIndex--;
            UpdateLevelImage();
        }
        else if (currentLevelIndex <= 0)
        {
            currentLevelIndex = levelSprites.Length - 1;
            UpdateLevelImage();
        }
        IsCanPlay();
    }
    private void UpdateLevelImage()
    {
        levelImage.sprite = levelSprites[currentLevelIndex];
        lockImage.SetActive(false);
        warningText.gameObject.SetActive(false);
        levelText.text = "Level " + (currentLevelIndex + 1);
        
    }
}
