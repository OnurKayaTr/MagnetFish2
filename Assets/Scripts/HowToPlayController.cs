using UnityEngine;
using UnityEngine.UI;

public class HowToPlayController : MonoBehaviour
{
    public GameObject howToPlayPanel; // Nasýl Oynanýr paneli (resim ve çarpý butonunun içinde olduðu panel)
    public Button closeButton; // Çarpý iþareti butonu

    void Start()
    {
        // Oyun baþladýðýnda paneli kapalý tut
     // howToPlayPanel.SetActive(false);

        // Çarpý butonuna týklanýnca paneli kapatan bir iþlev ata
        closeButton.onClick.AddListener(CloseHowToPlay);

    }

    // "Nasýl Oynanýr" panelini açan bir fonksiyon
    public void OpenHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    // "Nasýl Oynanýr" panelini kapatan fonksiyon
    void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }
}
