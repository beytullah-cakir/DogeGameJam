using UnityEngine;
using DialogueEditor;
public class NPCscn3 : MonoBehaviour
{
    public NPCConversation conversation;

    public void Start()
    {
        ConversationManager.Instance.StartConversation(conversation);
    }
}
