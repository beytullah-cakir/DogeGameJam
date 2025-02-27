using UnityEngine;
using DialogueEditor;
public class NPCfnlscn : MonoBehaviour
{
    public NPCConversation conversation;
    private void Start()
    {
        ConversationManager.Instance.StartConversation(conversation);
    }

}
