using UnityEngine;
using DialogueEditor;

public class NPC2 : MonoBehaviour
{
    public NPCConversation conversation;
    public GameObject karakter; // Karakter GameObject'ini buraya s�r�kleyin
    public float etkilesimMesafesi = 2f; // Etkile�im mesafesini ayarlay�n

    private bool diyalogBasladi = false;

    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, karakter.transform.position);

        if (mesafe <= etkilesimMesafesi && !diyalogBasladi)
        {

            DiyalogBaslat();

        }

        if (diyalogBasladi && Input.GetKeyDown(KeyCode.Q)) // "Q" tu�una bas�ld���nda diyalo�u bitir
        {
            DiyalogBitir();
        }
    }

    void DiyalogBaslat()
    {
        diyalogBasladi = true;
        ConversationManager.Instance.StartConversation(conversation); // Diyalo�u ba�lat
    }

    void DiyalogBitir()
    {
        diyalogBasladi = false;
        ConversationManager.Instance.EndConversation(); // Diyalo�u bitir
    }

    void OnDrawGizmosSelected() // Etkile�im mesafesini sahnede g�rselle�tir
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, etkilesimMesafesi);
    }
}
