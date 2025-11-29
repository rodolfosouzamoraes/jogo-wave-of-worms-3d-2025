using TMPro;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtQuest;
    [SerializeField] Quests[] mainQuests;
    [SerializeField] private Quests currentQuest;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        currentQuest = mainQuests[0];
        txtQuest.text = currentQuest.Quest.txtLanguage[CanvasGameManager.Instance.LanguageGame];
        foreach(Quests s in mainQuests)
        {
            s.isDone = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    txtQuest.text = currentQuest.Quest.txtLanguage[CanvasGameManager.Instance.LanguageGame];
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
