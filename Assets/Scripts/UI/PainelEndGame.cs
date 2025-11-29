using System;
using TMPro;
using UnityEngine;

public class PainelEndGame : MonoBehaviour
{
    [SerializeField] GameObject pnlEndGame;
    [SerializeField] GameObject pnlGameOver;
    [SerializeField] TextMeshProUGUI txtTimer;
    [SerializeField] TextMeshProUGUI txtWormsKilled;
    [SerializeField] TextMeshProUGUI txtTotalFluids;
    [SerializeField] TextMeshProUGUI txtTotalKm;
    private float secondsInGame;
    [SerializeField] private int totalWormsKilled;
    private bool isEndGame;

    public bool IsEndGame
    {
        get { return isEndGame; }
    }
    
    void Start()
    {
        totalWormsKilled = 0;
    }

    public void ShowEndGame()
    {
        isEndGame = true;
        CalculateEndGame();        
        pnlEndGame.SetActive(true);
    }

    private void CalculateEndGame()
    {
        Save save = DBMng.GetSave();
        float km = (float)Math.Round(CarMng.Instance.TotalKm / 100, 2);
        float fluids = (float)Math.Round(CarMng.Instance.TotalFluids, 2);
        txtWormsKilled.text = $"{totalWormsKilled} / <color=#00FF00>{save.wormsKilled}</color>";
        txtTotalKm.text = $"{km}Km / <color=#00FF00>{save.carKm}</color>";
        txtTotalFluids.text = $"{Math.Round(CarMng.Instance.TotalFluids, 2)}L / <color=#00FF00>{save.fluidsL}</color>";

        secondsInGame = Time.timeSinceLevelLoad;

        TimeSpan time = TimeSpan.FromSeconds(secondsInGame);
        TimeSpan timeSave = TimeSpan.FromSeconds(save.timeGame);

        if (time.TotalHours >= 1)
        {
            txtTimer.text = $"{time.ToString(@"hh\:mm\:ss")} / <color=#00FF00>{timeSave.ToString(@"hh\:mm\:ss")}</color>";
        }
        else
        {
            txtTimer.text = $"{time.ToString(@"mm\:ss")} / <color=#00FF00>{timeSave.ToString(@"hh\:mm\:ss")}</color>";
        }

        DBMng.SaveEndGame(totalWormsKilled, km, fluids, secondsInGame);

    }

    public void IncrementWormsKilled()
    {
        totalWormsKilled++;
    }
    
    public void GameOver()
    {
        isEndGame = true;
        pnlGameOver.SetActive(true);
        Invoke("RestartGame", 5f);
    }

    private void RestartGame()
    {
        CanvasGameManager.Instance.RestartGame();
    }
}
