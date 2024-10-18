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
        UpdateLevelButtonState();  // Buton durumunu güncelle
    }

    private void UpdateLevelButtonState()
    {
        if (MainLevelManager.Instance.IsLevelLocked(levelId))
        {
            lockedImage.gameObject.SetActive(true);
            button.interactable = false;  // Kilitli ise týklanamaz yap
        }
        else
        {
            lockedImage.gameObject.SetActive(false);
            button.interactable = true;  // Kilitli deðilse týklanabilir yap
        }
    }

    public void OpenLevel()
    {
        if (!MainLevelManager.Instance.IsLevelLocked(levelId))
        {
            SceneManager.LoadScene("level" + levelId.ToString());  // Seviyeyi yükle
        }
    }
}
