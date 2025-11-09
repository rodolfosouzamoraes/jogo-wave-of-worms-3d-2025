using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Icons;

public class QuestController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtQuest;
    [SerializeField] Quests[] mainQuests;
    private Quests currentQuest;
    private int idLanguage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        idLanguage = DBMng.GetIdLanguage();
        currentQuest = mainQuests[0];
        txtQuest.text = currentQuest.Quest.txtLanguage[idLanguage];
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
                    txtQuest.text = currentQuest.Quest.txtLanguage[idLanguage];
                    break;
                }
            }
        }        
    }
}
