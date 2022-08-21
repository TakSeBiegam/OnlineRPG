using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NPC_REFORGED : NetworkBehaviour
{
    public GameObject player;
    [SerializeField] private DialogueScriptables currentDialogue;
    [SerializeField] private ScriptableDialoguesManager DialogueManager;
    [SerializeField] GameObject dialogueCanvas;
    [SerializeField] public string npcName;
    public bool hasTalked = false;
    public bool isInDialog = false;
    private bool questDone = false;
    [SerializeField] private int npcQuestNumber = 0;
    [SerializeField] private int numberOfHandledActuallyQuest;

    public void startDialogue(GameObject p)
    {
        questDone = false;
        player = p;
        if (hasTalked)
        {
            askIsPlayerHasEndedQuest(player, numberOfHandledActuallyQuest);
            if (questDone)
            {
                currentDialogue = DialogueManager.EndingDialogue;
                triggerOnDialogueBox();
                //TurnOnDialogue and give reward by server 
                // * TO DO AFTER ADDED INVENTORY
                return;
            }
            currentDialogue = DialogueManager.HasTalkedDialogue;
            triggerOnDialogueBox();
            return;
        }
        else
        {
            currentDialogue = DialogueManager.StarterDialogue;
            triggerOnDialogueBox();
            triggerStartQuest(player, npcQuestNumber);
            hasTalked = true;
            return;
        }
    }

    private void triggerOnDialogueBox()
    {
        dialogueCanvas.gameObject.GetComponent<Dialogue>().turnOnDialogueBox(currentDialogue, npcName);
        dialogueCanvas.SetActive(true);
    }


    [Command]
    private void askIsPlayerHasEndedQuest(GameObject player, int qNumber)
    {
        //asking if player has done quest
        //normally i should do a request to sql server but for now i will do it locally and without any protection
        checkIsPlayerHasEndedQuest(player, qNumber);
    }

    [TargetRpc]
    private void checkIsPlayerHasEndedQuest(GameObject player, int qNumber)
    {
        //asking if player has done quest
        var activeQuests = player.GetComponent<PlayerData>().activeQuests;
        if (activeQuests[qNumber].isDone)
        {
            questDone = true;
        }
        questDone = false;
    }

    [Command]
    private void triggerStartQuest(GameObject player, int qNumber)
    {
        player.gameObject.GetComponent<PlayerData>().AddQuestForPlayer(qNumber);
    }
}
