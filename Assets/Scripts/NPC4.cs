using UnityEngine;
using DialogueEditor;

public class NPC5 : MonoBehaviour
{
    public NPCConversation conversation;
    public float kutucukBeklemeSuresi = 2f; // Kutucuklar arasý bekleme süresi

    private bool diyalogBasladi = false;
    private float sonKutucukZamani = 0f;
    private bool kutucukBekleniyor = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !diyalogBasladi)
        {
            diyalogBasladi = true;
            ConversationManager.Instance.StartConversation(conversation);
            sonKutucukZamani = Time.time;
            kutucukBekleniyor = true;
        }
    }

    private void Update()
    {
        if (diyalogBasladi && kutucukBekleniyor)
        {
            if (Time.time - sonKutucukZamani >= kutucukBeklemeSuresi)
            {
                // Dialogue Editor'e özgü ilerletme yöntemini kullanýn.
                // Örneðin, eðer Dialogue Editor'de diyalog kutucuklarýnýn ilerlemesini
                // kontrol eden bir "Next" düðmesi varsa:
                // ConversationManager.Instance.ShowNext();
                // veya
                // ConversationManager.Instance.ContinueConversation(); // (Eðer bu fonksiyon varsa)

                sonKutucukZamani = Time.time;

                if (!ConversationManager.Instance.IsConversationActive)
                {
                    diyalogBasladi = false;
                    kutucukBekleniyor = false;
                }
            }
        }
    }
}
