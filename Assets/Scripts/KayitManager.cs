using UnityEngine;
using UnityEngine.SceneManagement;

public class KayitManager : MonoBehaviour
{
    // Oyuncunun seviyesini kaydeder
    public void SaveLevel(int level)
    {
        // Level bilgisini "PlayerLevel" anahtar�yla kaydet
        PlayerPrefs.SetInt("PlayerLevel", level);
        PlayerPrefs.Save(); // Verilerin kal�c� olarak kaydedilmesi
        Debug.Log("Level " + level + " kaydedildi.");
    }

    // Oyuncunun kaydedilmi� seviyesini y�kler
    public void LoadSavedLevel()
    {
        // Kaydedilmi� leveli al, e�er kaydedilmi� bir level yoksa varsay�lan olarak level 1 ba�lat
        int savedLevel = PlayerPrefs.GetInt("PlayerLevel", 1);

        // Kaydedilen leveli y�kle
        Debug.Log("Kaydedilmi� Level: " + savedLevel);
        SceneManager.LoadScene("Level" + savedLevel); // �rne�in sahne isimleri "Level1", "Level2" gibi olmal�d�r
    }

    // Bir sonraki seviyeye ge�i�i sa�lar
    public void NextLevel(int currentLevel)
    {
        int nextLevel = currentLevel + 1; // Bir sonraki seviyeye ge�
        SaveLevel(nextLevel); // Yeni seviyeyi kaydet
        SceneManager.LoadScene("Level" + nextLevel); // Yeni seviyeyi y�kle
    }

    // Oyuncunun level verilerini s�f�rlamak (yeniden ba�lamak) i�in kullan�l�r
    public void ResetLevelProgress()
    {
        PlayerPrefs.DeleteKey("PlayerLevel");
        Debug.Log("Level kayd� s�f�rland�.");
    }
}
