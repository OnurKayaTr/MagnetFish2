using System.Collections;
using UnityEngine;

public class htp2 : MonoBehaviour
{
    public GameObject howToPlayPanel; // Nas�l Oynan�r paneli (resim ve �arp� butonunun i�inde oldu�u panel)

    void Start()
    {
        // Oyun ba�lad���nda paneli kapal� tut
       // howToPlayPanel.SetActive(false);
        OpenHowToPlay();
    }

    // "Nas�l Oynan�r" panelini a�an bir fonksiyon
    public void OpenHowToPlay()
    {
        howToPlayPanel.SetActive(true);
        // Panel a��ld���nda 3 saniye bekleyip paneli kapat
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
