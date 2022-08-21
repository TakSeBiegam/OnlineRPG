using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialoguesManager", menuName = "NPCS/DialogueManager", order = 2)]
public class ScriptableDialoguesManager : ScriptableObject
{
    [SerializeField] public DialogueScriptables StarterDialogue;
    [SerializeField] public DialogueScriptables FirstQuestDialogue;
    [SerializeField] public DialogueScriptables EndingDialogue;
    [SerializeField] public DialogueScriptables HasTalkedDialogue;
}
