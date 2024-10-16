using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCharge : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            playerMovement.ResetDoubleJump();
        }
    }
}
