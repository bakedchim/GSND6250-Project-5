using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    public GameControllerTrung gameController;
    float originalY;
    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < originalY - 10)
        {
            gameController.LoseGame();
        }
    }
}
