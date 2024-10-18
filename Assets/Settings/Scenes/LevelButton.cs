using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelId;
    public TMP_Text levelText;
    public Image lockedImage;
    public Button button;
    private void Start()
    {
        levelText.text = levelId.ToString();
        if (MainLevelManager.Instance.IsLevelLocked(levelId))
        {
        lockedImage.gameObject.SetActive(true);
        button.interactable = false;
        }
        else
        {
            lockedImage.gameObject.SetActive(false);
            button.interactable = true;

        }
    }
    public void OpenLevel()
    {
        SceneManager.LoadScene("level" + levelId.ToString());
    }
}
