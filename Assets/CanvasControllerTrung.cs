using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasControllerTrung : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public TMP_Text chargeText;

    // Update is called once per frame
    void Update()
    {
        chargeText.text = "Double Jump Charge: " + playerMovement.doubleJumpCharge;
    }
}
