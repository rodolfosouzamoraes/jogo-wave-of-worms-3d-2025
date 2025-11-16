using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject gunHands;
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

        if (gunHands.activeSelf == true && context.performed)
        {
            PlayerManager.Animation.PlayFireGun();
        }
        else{ 
            PlayerManager.Animation.CanceledFireGun();
        }
    }
}
