using DialogueEditor;
using UnityEngine;

public class Sarkıt : MonoBehaviour
{
    public NPCConversation conversation;

    private void Start()
    {
        ConversationManager.Instance.StartConversation(conversation);
    }
}
