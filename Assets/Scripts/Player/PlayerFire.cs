using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject gunHands;
    [SerializeField] GameObject projetilTarget;
    [SerializeField] GameObject projetil;
    [SerializeField] float projetilDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DesactiveGunBack();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            GameObject newProjetil = Instantiate(projetil);
            newProjetil.transform.eulerAngles = new Vector3(
                    projetilTarget.transform.eulerAngles.x,
                    projetilTarget.transform.eulerAngles.y + axesY,
                    projetilTarget.transform.eulerAngles.z
            );
            newProjetil.GetComponent<ProjetilController>().SetProjetilDamage(projetilDamage);
            newProjetil.transform.position = projetilTarget.transform.position;
            newProjetil.transform.SetParent(null);
            axesY += 20;
        }

        for (int i = 0; i < 6; i++)
        {
            GameObject newProjetil = Instantiate(projetil);
            newProjetil.transform.eulerAngles = new Vector3(
                    projetilTarget.transform.eulerAngles.x + axesX,
                    projetilTarget.transform.eulerAngles.y,
                    projetilTarget.transform.eulerAngles.z
            );
            newProjetil.GetComponent<ProjetilController>().SetProjetilDamage(projetilDamage);
            newProjetil.transform.position = projetilTarget.transform.position;
            newProjetil.transform.SetParent(null);
            axesX += 20;
        }

        AudioMng.Instance.PlayAudioGun();
    }
}
