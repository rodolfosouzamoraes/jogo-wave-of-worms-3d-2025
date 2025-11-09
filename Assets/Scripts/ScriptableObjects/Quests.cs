using UnityEngine;

[CreateAssetMenu(fileName = "Quests", menuName = "Scriptable Objects/Quests")]
public class Quests : ScriptableObject
{
    public int idQuest;
    public TextsGame Quest;
    public bool isDone;
}
