using UnityEngine;
using UnityEngine.UI;

public class HowToPlayController : MonoBehaviour
{
    public GameObject howToPlayPanel; // Nas�l Oynan�r paneli (resim ve �arp� butonunun i�inde oldu�u panel)
    public Button closeButton; // �arp� i�areti butonu

    void Start()
    {
        // Oyun ba�lad���nda paneli kapal� tut
     // howToPlayPanel.SetActive(false);

        // �arp� butonuna t�klan�nca paneli kapatan bir i�lev ata
        closeButton.onClick.AddListener(CloseHowToPlay);

    }

    // "Nas�l Oynan�r" panelini a�an bir fonksiyon
    public void OpenHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    // "Nas�l Oynan�r" panelini kapatan fonksiyon
    void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }
}
