using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Level
{
    public int levelID;
    public bool islocked;
}
public class MainLevelManager : MonoBehaviour
{
    public static MainLevelManager Instance;
    [SerializeField] private List<Level> levels = new List<Level>();
    private void Awake()
    {
        Instance = this;
    }
    public void UnlockLevel(int levelID)
    {
        Level tempLevel = levels.Find(level => level.levelID == levelID);
        if (tempLevel != null) {

            tempLevel.islocked = false;
        }
    }

    public bool IsLevelLocked(int levelID)
    {
        Level tempLevel = levels.Find(level => level.levelID == levelID);
        if (tempLevel != null)
        
            {
        
        return tempLevel.islocked;}
        return false;
    }
    
}
