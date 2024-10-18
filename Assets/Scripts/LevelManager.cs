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
        Time.timeScale = 1; // Yeni seviyeye geçmeden önce zamaný sýfýrla

        int currentLevelID = GetCurrentLevelID();
        int nextLevelID = currentLevelID + 1;

        // Mevcut sahneyi sil ve yeni seviyeyi yükle
        SceneManager.LoadScene("level" + nextLevelID, LoadSceneMode.Single);  // Mevcut sahne silinir, yeni seviye yüklenir

        // Sahne yüklendikten sonra kaydetme iþlemi yapacaðýz
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yalnýzca yeni seviyenin yüklendiðini kontrol et
        int nextLevelID = GetCurrentLevelID() + 1;
        if (scene.name == "level" + nextLevelID)
        {
            // Sonraki seviyenin kilidini aç ve kaydet
            MainLevelManager.Instance.UnlockLevel(nextLevelID);  // Sonraki seviyeyi aç
            MainLevelManager.Instance.SaveLevel(nextLevelID);  // Sonraki seviyeyi kaydet

            // PlayerPrefs'e kaydetme iþlemi
            PlayerPrefs.SetInt("level" + nextLevelID.ToString(), 1);  // Seviyeyi kaydet
            PlayerPrefs.Save();  // PlayerPrefs'i kaydet

            // `sceneLoaded` olayýný yalnýzca bir kez tetiklemek için event'ten çýkarýyoruz
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private int GetCurrentLevelID()
    {
        // Sahnenin adýný al ve ID'yi çýkart
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName.StartsWith("level"))
        {
            int levelID;
            if (int.TryParse(currentSceneName.Substring(5), out levelID))
            {
                return levelID;
            }
        }
        return 1; // Varsayýlan seviye ID'si 1
    }

    private void OnApplicationQuit()
    {
        // Oyun kapandýðýnda seviyeyi kaydet
        int currentLevelID = GetCurrentLevelID();
        PlayerPrefs.SetInt("level" + currentLevelID.ToString(), 1);  // Þu anki seviyeyi kaydet
        PlayerPrefs.Save();  // PlayerPrefs'i kaydet
    }
}
