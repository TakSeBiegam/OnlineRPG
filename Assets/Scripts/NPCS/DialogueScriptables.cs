    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueScriptables", menuName = "NPCS/DialogueScriptables", order = 1)]
public class DialogueScriptables : ScriptableObject
{   
        [field: SerializeField]
        public string DialogueText{ get; private set; }
        [field: SerializeField]
        public DialogueScriptables defaultDialogue = null;
        //Optional Dialogue is created when we wanna select one from a two options
        public DialogueScriptables optionalDialogue = null;
}
