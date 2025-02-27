using UnityEngine;
using DialogueEditor;
public class Kedi_atla : MonoBehaviour
{
    public NPCConversation conversation;
    private void Start()
    {
        ConversationManager.Instance.StartConversation(conversation);
    }
}
