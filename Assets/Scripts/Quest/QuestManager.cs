using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest
{
    public string questTitle;
    public string questDescription;
    public bool isDone;

    public Dictionary<string, int> monsterToKill = new Dictionary<string, int>();
    public Dictionary<string, int> currentKilled = new Dictionary<string, int>();
    public Dictionary<string, int> itemToCollect = new Dictionary<string, int>();
}


public class QuestManager : MonoBehaviour
{

    public Quest AddQuest(int questNumber)
    {
        Quest q = new Quest();
        switch (questNumber)
        {
            case 1:
                q.questTitle = "Kill the Spider";
                q.questDescription = "Kill the Spider";
                q.monsterToKill.Add("spider", 1);
                q.currentKilled.Add("spider", 0);
                break;
        }
        return q;
    }

}
