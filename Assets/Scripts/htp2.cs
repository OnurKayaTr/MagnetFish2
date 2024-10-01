using System.Collections;
using UnityEngine;

public class htp2 : MonoBehaviour
{
    public GameObject howToPlayPanel; // Nasýl Oynanýr paneli (resim ve çarpý butonunun içinde olduðu panel)

    void Start()
    {
        // Oyun baþladýðýnda paneli kapalý tut
       // howToPlayPanel.SetActive(false);
        OpenHowToPlay();
    }

    // "Nasýl Oynanýr" panelini açan bir fonksiyon
    public void OpenHowToPlay()
    {
        howToPlayPanel.SetActive(true);
        // Panel açýldýðýnda 3 saniye bekleyip paneli kapat
        StartCoroutine(CloseAfterDelay());
    }

    // Coroutine: 3 saniye bekledikten sonra paneli kapat
    IEnumerator CloseAfterDelay()
    {
        // 3 saniye bekle
        yield return new WaitForSeconds(3f);

        // Paneli kapat
        CloseHowToPlay();
    }

    // Paneli kapatan fonksiyon
    void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }
}
