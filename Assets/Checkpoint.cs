using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        WheelDrive wheelDrive = collision.GetComponent<WheelDrive>();
        if (collision.gameObject.name == "Player 1")
        {
            wheelDrive.Lap = true;
            wheelDrive.ResetSpawnPosition();
        }
        if (collision.gameObject.name == "Player 2")
        {
            wheelDrive.Lap = true;
            wheelDrive.ResetSpawnPosition();
        }
        //|| collision.gameObject.name == "Player2"
        if (collision.gameObject.name == "Player 1")
        {
            FindFirstObjectByType<StartLine>().PlayerScored();
        }

        if (collision.gameObject.name == "Player 2")
        {
            FindFirstObjectByType<StartLine>().PlayerScored();
        }
    }
}
