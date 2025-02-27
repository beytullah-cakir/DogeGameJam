using UnityEngine;
using DialogueEditor;
public class NPCGames : MonoBehaviour
{
    public NPCConversation conversation;
    private void Start()
    {
        ConversationManager.Instance.StartConversation(conversation);
    }
}
