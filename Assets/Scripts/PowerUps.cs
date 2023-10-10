using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameObject respawnEffect;

    public float duration = 0.5f;
    [HideInInspector] public float speedBoost = 700f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine (Pickup (other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //here type what the power up should do!
        WheelDrive wheelDrive = player.GetComponent<WheelDrive>();
        wheelDrive.torque += speedBoost;  

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(3f);

        //reset the stats here
        wheelDrive.torque -= speedBoost;

        Instantiate(respawnEffect, transform.position, transform.rotation);

        yield return new WaitForSeconds(0.5f);

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
