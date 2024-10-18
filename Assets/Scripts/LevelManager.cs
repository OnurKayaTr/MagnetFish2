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
        Time.timeScale = 1; // Yeni seviyeye ge�meden �nce zaman� s�f�rla

        int currentLevelID = GetCurrentLevelID();
        int nextLevelID = currentLevelID + 1;

        // Mevcut sahneyi sil ve yeni seviyeyi y�kle
        SceneManager.LoadScene("level" + nextLevelID, LoadSceneMode.Single);  // Mevcut sahne silinir, yeni seviye y�klenir

        // Sahne y�klendikten sonra kaydetme i�lemi yapaca��z
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yaln�zca yeni seviyenin y�klendi�ini kontrol et
        int nextLevelID = GetCurrentLevelID() + 1;
        if (scene.name == "level" + nextLevelID)
        {
            // Sonraki seviyenin kilidini a� ve kaydet
            MainLevelManager.Instance.UnlockLevel(nextLevelID);  // Sonraki seviyeyi a�
            MainLevelManager.Instance.SaveLevel(nextLevelID);  // Sonraki seviyeyi kaydet

            // PlayerPrefs'e kaydetme i�lemi
            PlayerPrefs.SetInt("level" + nextLevelID.ToString(), 1);  // Seviyeyi kaydet
            PlayerPrefs.Save();  // PlayerPrefs'i kaydet

            // `sceneLoaded` olay�n� yaln�zca bir kez tetiklemek i�in event'ten ��kar�yoruz
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private int GetCurrentLevelID()
    {
        // Sahnenin ad�n� al ve ID'yi ��kart
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName.StartsWith("level"))
        {
            int levelID;
            if (int.TryParse(currentSceneName.Substring(5), out levelID))
            {
                return levelID;
            }
        }
        return 1; // Varsay�lan seviye ID'si 1
    }

    private void OnApplicationQuit()
    {
        // Oyun kapand���nda seviyeyi kaydet
        int currentLevelID = GetCurrentLevelID();
        PlayerPrefs.SetInt("level" + currentLevelID.ToString(), 1);  // �u anki seviyeyi kaydet
        PlayerPrefs.Save();  // PlayerPrefs'i kaydet
    }
}
