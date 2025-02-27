using UnityEngine;
using DialogueEditor;

public class NPC2 : MonoBehaviour
{
    public NPCConversation conversation;
    public GameObject karakter; // Karakter GameObject'ini buraya sürükleyin
    public float etkilesimMesafesi = 2f; // Etkileþim mesafesini ayarlayýn

    private bool diyalogBasladi = false;

    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, karakter.transform.position);

        if (mesafe <= etkilesimMesafesi && !diyalogBasladi)
        {
            if (Input.GetKeyDown(KeyCode.E)) // "E" tuþuna basýldýðýnda diyaloðu baþlat
            {
                DiyalogBaslat();
            }
        }

        if (diyalogBasladi && Input.GetKeyDown(KeyCode.Q)) // "Q" tuþuna basýldýðýnda diyaloðu bitir
        {
            DiyalogBitir();
        }
    }

    void DiyalogBaslat()
    {
        diyalogBasladi = true;
        ConversationManager.Instance.StartConversation(conversation); // Diyaloðu baþlat
    }

    void DiyalogBitir()
    {
        diyalogBasladi = false;
        ConversationManager.Instance.EndConversation(); // Diyaloðu bitir
    }

    void OnDrawGizmosSelected() // Etkileþim mesafesini sahnede görselleþtir
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, etkilesimMesafesi);
    }
}
