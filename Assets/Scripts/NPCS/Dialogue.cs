using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public PlayerData player;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private int currentDialogNumber = 0;
    public int npc_questNumber;

    private DialogueScriptables currentScriptableQuest;
    private string currentNpcName;

    public void turnOnDialogueBox(DialogueScriptables currentDialogueToShow, string npcName)
    {
        currentScriptableQuest = currentDialogueToShow;
        currentNpcName = npcName;
        nameText.text = currentNpcName;
        dialogueText.text = currentDialogueToShow.DialogueText;
    }

    public void Next()
    {
        if (currentScriptableQuest.defaultDialogue != null)
        {
            turnOnDialogueBox(currentScriptableQuest.defaultDialogue, currentNpcName);
        }
        else
        {
            closeDialogWindow();
        }
    }
    private void closeDialogWindow()
    {
        currentNpcName = "";
        currentScriptableQuest = null;
        this.gameObject.SetActive(false);
    }
}
