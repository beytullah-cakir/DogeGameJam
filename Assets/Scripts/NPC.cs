using UnityEngine;
using UnityEngine.SceneManagement;
using DialogueEditor;

public class NPC : MonoBehaviour
{
    public NPCConversation conversation;

    private void Start()
    {
        ConversationManager.OnConversationEnded += OnConversationEnd;
        ConversationManager.Instance.StartConversation(conversation);
    }

    private void OnConversationEnd()
    {
        // Yeni sahneye geç
        SceneManager.LoadScene("SecondGame");
        
        // Olayı temizle (tekrar çağrılmasını önlemek için)
        ConversationManager.OnConversationEnded -= OnConversationEnd;
    }
}
