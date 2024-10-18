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
        LoadLevels();  // Oyunun ba��nda seviyelerin durumunu y�kle
    }

    // Seviyelerin durumunu y�kle
    private void LoadLevels()
    {
        foreach (var level in levels)
        {
            bool isLevelUnlocked = GetLevel(level.levelID);  // PlayerPrefs'ten seviyenin durumu
            level.islocked = !isLevelUnlocked;  // Kilitli olup olmad���n� ayarla
        }

        UnlockLevel(1);
    }

    // Seviye a�ma fonksiyonu
    public void UnlockLevel(int levelID)
    {
        Level tempLevel = levels.Find(level => level.levelID == levelID);
        if (tempLevel != null)
        {
            tempLevel.islocked = false;  // Seviyeyi a�
            SaveLevel(levelID);  // Seviye a��ld���nda kaydet
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
        return true;  // Seviyeyi bulamazsan, varsay�lan olarak kilitli kabul et
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
        int status = PlayerPrefs.GetInt("level" + levelID.ToString(), 0);  // Varsay�lan olarak 0 d�nd�r
        return status == 1;  // 1 ise a��lm��, 0 ise kilitli
    }
}
