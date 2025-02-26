using UnityEngine;
using DialogueEditor;
public class NPC : MonoBehaviour
{
    public NPCConversation conversation;
    private void Start()
    {
        ConversationManager.Instance.StartConversation(conversation);
    }
   
}
