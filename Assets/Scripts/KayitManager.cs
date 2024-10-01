using UnityEngine;
using UnityEngine.SceneManagement;

public class KayitManager : MonoBehaviour
{
    // Oyuncunun seviyesini kaydeder
    public void SaveLevel(int level)
    {
        // Level bilgisini "PlayerLevel" anahtarýyla kaydet
        PlayerPrefs.SetInt("PlayerLevel", level);
        PlayerPrefs.Save(); // Verilerin kalýcý olarak kaydedilmesi
        Debug.Log("Level " + level + " kaydedildi.");
    }

    // Oyuncunun kaydedilmiþ seviyesini yükler
    public void LoadSavedLevel()
    {
        // Kaydedilmiþ leveli al, eðer kaydedilmiþ bir level yoksa varsayýlan olarak level 1 baþlat
        int savedLevel = PlayerPrefs.GetInt("PlayerLevel", 1);

        // Kaydedilen leveli yükle
        Debug.Log("Kaydedilmiþ Level: " + savedLevel);
        SceneManager.LoadScene("Level" + savedLevel); // Örneðin sahne isimleri "Level1", "Level2" gibi olmalýdýr
    }

    // Bir sonraki seviyeye geçiþi saðlar
    public void NextLevel(int currentLevel)
    {
        int nextLevel = currentLevel + 1; // Bir sonraki seviyeye geç
        SaveLevel(nextLevel); // Yeni seviyeyi kaydet
        SceneManager.LoadScene("Level" + nextLevel); // Yeni seviyeyi yükle
    }

    // Oyuncunun level verilerini sýfýrlamak (yeniden baþlamak) için kullanýlýr
    public void ResetLevelProgress()
    {
        PlayerPrefs.DeleteKey("PlayerLevel");
        Debug.Log("Level kaydý sýfýrlandý.");
    }
}
