using UnityEngine;
using DialogueEditor;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli

public class NPCfnlscn : MonoBehaviour
{
    public NPCConversation conversation;

    private void Start()
    {
        // Diyalog baþladýðýnda, diyalog bitince bir sahneye geçmek için dinleyici ekliyoruz.
        ConversationManager.Instance.StartConversation(conversation);

        // Diyalog bitiminde sahne deðiþtirme iþlemi için event'e abone olalým
        DialogueEditor.ConversationManager.OnConversationEnded += OnConversationEnded;
    }

    private void OnConversationEnded()
    {
        // Konuþma bittiðinde baþka bir sahneye geçiþ yap
        SceneManager.LoadScene("GameOver"); // Geçmek istediðiniz sahne ismini yazýn
    }

    private void OnDestroy()
    {
        // Bu script yok olduðunda event dinleyicisini kaldýrýyoruz
        DialogueEditor.ConversationManager.OnConversationEnded -= OnConversationEnded;
    }
}
