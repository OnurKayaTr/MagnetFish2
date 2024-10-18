using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public int levelID;    // Seviye ID'si
    public bool islocked;  // Seviye kilitli mi?
}


public class MainLevelManager : MonoBehaviour
{
    public static MainLevelManager Instance;
    [SerializeField] private List<Level> levels = new List<Level>();

    private void Awake()
    {
       //PlayerPrefs.DeleteAll();
        Instance = this;
        LoadLevels();  // Oyunun baþýnda seviyelerin durumunu yükle
    }

    // Seviyelerin durumunu yükle
    private void LoadLevels()
    {
        foreach (var level in levels)
        {
            bool isLevelUnlocked = GetLevel(level.levelID);  // PlayerPrefs'ten seviyenin durumu
            level.islocked = !isLevelUnlocked;  // Kilitli olup olmadýðýný ayarla
        }

        UnlockLevel(1);
    }

    // Seviye açma fonksiyonu
    public void UnlockLevel(int levelID)
    {
        Level tempLevel = levels.Find(level => level.levelID == levelID);
        if (tempLevel != null)
        {
            tempLevel.islocked = false;  // Seviyeyi aç
            SaveLevel(levelID);  // Seviye açýldýðýnda kaydet
        }
    }

    // Seviye kilitli mi?
    public bool IsLevelLocked(int levelID)
    {
        Level tempLevel = levels.Find(level => level.levelID == levelID);
        if (tempLevel != null)
        {
            return tempLevel.islocked;  // Kilitli mi?
        }
        return true;  // Seviyeyi bulamazsan, varsayýlan olarak kilitli kabul et
    }

    // Seviye durumunu kaydet
    public void SaveLevel(int levelID)
    {
        int save = IsLevelLocked(levelID) ? 1 : 0;
        PlayerPrefs.SetInt("level" + levelID.ToString(), save);
    }

    // Kaydedilen seviyenin durumunu al
    public bool GetLevel(int levelID)
    {
        int status = PlayerPrefs.GetInt("level" + levelID.ToString(), 0);  // Varsayýlan olarak 0 döndür
        return status == 1;  // 1 ise açýlmýþ, 0 ise kilitli
    }
}
