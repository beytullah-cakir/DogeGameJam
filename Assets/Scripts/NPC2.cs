using UnityEngine;
using UnityEngine.SceneManagement;
using DialogueEditor;
using System.Collections;

public class NPC2 : MonoBehaviour
{
    public NPCConversation conversation; // Diyalog verisi
    public GameObject karakter; // Oyuncu karakteri
    public float etkilesimMesafesi = 2f; // Etkileşim mesafesi
    public string yeniSahneAdi; // Hedef sahne adı

    private bool diyalogBasladi = false; // Diyalog başladı mı kontrolü

    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, karakter.transform.position);

        if (mesafe <= etkilesimMesafesi && !diyalogBasladi)
        {
            DiyalogBaslat();
        }
    }

    void DiyalogBaslat()
    {
        diyalogBasladi = true;
        ConversationManager.Instance.StartConversation(conversation);
        StartCoroutine(DiyalogBitinceSahneDegistir());
        Debug.Log("Diyalog başladı.");
    }

    IEnumerator DiyalogBitinceSahneDegistir()
    {
        // Diyalog bitene kadar bekle
        while (ConversationManager.Instance.IsConversationActive)
        {
            yield return null; // Bir sonraki frame'e kadar bekle
        }

        Debug.Log("Diyalog bitti, sahne değiştiriliyor...");
        SahneDegistir();
    }

    void SahneDegistir()
    {
        if (!string.IsNullOrEmpty(yeniSahneAdi))
        {
            Debug.Log("Yeni sahne yükleniyor: " + yeniSahneAdi);
            SceneManager.LoadScene(yeniSahneAdi);
        }
        else
        {
            Debug.LogWarning("Yeni sahne adı atanmadı! Sahne değiştirilemiyor.");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, etkilesimMesafesi);
    }
}
