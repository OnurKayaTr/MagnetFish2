using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    private void Start()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(LoadNextLevel);
        }
    }
    private void LoadNextLevel()
    {
        Time.timeScale = 1; // Yeni seviyeyi y�klemeden �nce zaman� s�f�rla

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // E�er sonraki level var ise o leveli y�kle
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("T�m seviyeler tamamland�!");
        }
    }
}
