using UnityEngine;
using DialogueEditor;

public class NPC5 : MonoBehaviour
{
    public NPCConversation conversation;
    public float kutucukBeklemeSuresi = 2f; // Kutucuklar aras� bekleme s�resi

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
                // Dialogue Editor'e �zg� ilerletme y�ntemini kullan�n.
                // �rne�in, e�er Dialogue Editor'de diyalog kutucuklar�n�n ilerlemesini
                // kontrol eden bir "Next" d��mesi varsa:
                // ConversationManager.Instance.ShowNext();
                // veya
                // ConversationManager.Instance.ContinueConversation(); // (E�er bu fonksiyon varsa)

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
