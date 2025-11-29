using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject gunHands;
    [SerializeField] GameObject projetilTarget;
    [SerializeField] GameObject projetil;
    [SerializeField] float projetilDamage;

    void Start()
    {
        DesactiveGunBack();
    }

    public void ActiveGunBack()
    {
        gunHands.SetActive(true);
        PlayerManager.Animation.PlayIdleGun();
    }

    public void DesactiveGunBack()
    {
        gunHands.SetActive(false);
    }

    private void OnEnable()
    {
        if (gunHands.activeSelf)
        {
            PlayerManager.Animation.PlayIdleGun();
        }
    }

    public void AttackBasic(InputAction.CallbackContext context) {
        if (CanvasGameManager.EndGame.IsEndGame == true) return;
        if (gunHands.activeSelf == true && context.performed)
        {
            PlayerManager.Animation.PlayFireGun();
        }
        else{ 
            PlayerManager.Animation.CanceledFireGun();
        }
    }

    public void InstantiateProjetil()
    {
        int axesY = -60;
        int axesX = -60;
        for(int i = 0; i < 6; i++)
        {
            GameObject newProjetilHorizontal = Instantiate(projetil);
            newProjetilHorizontal.transform.eulerAngles = new Vector3(
                    projetilTarget.transform.eulerAngles.x,
                    projetilTarget.transform.eulerAngles.y + axesY,
                    projetilTarget.transform.eulerAngles.z
            );
            newProjetilHorizontal.GetComponent<ProjetilController>().SetProjetilDamage(projetilDamage);
            newProjetilHorizontal.transform.position = projetilTarget.transform.position;
            newProjetilHorizontal.transform.SetParent(null);
            axesY += 20;

            GameObject newProjetilVertical = Instantiate(projetil);
            newProjetilVertical.transform.eulerAngles = new Vector3(
                    projetilTarget.transform.eulerAngles.x + axesX,
                    projetilTarget.transform.eulerAngles.y,
                    projetilTarget.transform.eulerAngles.z
            );
            newProjetilVertical.GetComponent<ProjetilController>().SetProjetilDamage(projetilDamage);
            newProjetilVertical.transform.position = projetilTarget.transform.position;
            newProjetilVertical.transform.SetParent(null);
            axesX += 20;
        }

        AudioMng.Instance.PlayAudioGun();
    }
}
