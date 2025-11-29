using TMPro;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtQuest;
    [SerializeField] Quests[] mainQuests;
    [SerializeField] private Quests currentQuest;
    
    void Start()
    {
        
        currentQuest = mainQuests[0];
        txtQuest.text = currentQuest.Quest.txtLanguage[DBMng.GetIdLanguage()];
        foreach(Quests s in mainQuests)
        {
            s.isDone = false;
        }
    }

    void Update()
    {
        txtQuest.text = currentQuest.Quest.txtLanguage[DBMng.GetIdLanguage()];
    }

    public void NextQuest(int questIdDone)
    {
        if(questIdDone == currentQuest.idQuest)
        {
            currentQuest.isDone = true;
            foreach (var quest in mainQuests)
            {
                if (quest.isDone == false)
                {
                    currentQuest = quest;
                    break;
                }
            }
        }        
    }

    public bool IsCurrentQuests(int idQuest)
    {
        return currentQuest.idQuest == idQuest;
    }
}
