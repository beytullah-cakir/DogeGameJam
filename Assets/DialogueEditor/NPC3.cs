using UnityEngine;
using DialogueEditor;
public class NPC3 : MonoBehaviour
{
    public NPCConversation conveersation;

    private void Start()
    {
        ConversationManager.Instance.StartConversation(conveersation);
    }
    
}
