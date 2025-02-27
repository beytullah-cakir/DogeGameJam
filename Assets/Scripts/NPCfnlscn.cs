using UnityEngine;
using DialogueEditor;
using UnityEngine.SceneManagement; // Sahne y�netimi i�in gerekli

public class NPCfnlscn : MonoBehaviour
{
    public NPCConversation conversation;

    private void Start()
    {
        // Diyalog ba�lad���nda, diyalog bitince bir sahneye ge�mek i�in dinleyici ekliyoruz.
        ConversationManager.Instance.StartConversation(conversation);

        // Diyalog bitiminde sahne de�i�tirme i�lemi i�in event'e abone olal�m
        DialogueEditor.ConversationManager.OnConversationEnded += OnConversationEnded;
    }

    private void OnConversationEnded()
    {
        // Konu�ma bitti�inde ba�ka bir sahneye ge�i� yap
        SceneManager.LoadScene("GameOver"); // Ge�mek istedi�iniz sahne ismini yaz�n
    }

    private void OnDestroy()
    {
        // Bu script yok oldu�unda event dinleyicisini kald�r�yoruz
        DialogueEditor.ConversationManager.OnConversationEnded -= OnConversationEnded;
    }
}
