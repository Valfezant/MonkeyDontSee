using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float drownTime;
    [SerializeField] private float currentDrownTime;

    private bool _isDrowning;

    private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            player.GetComponent<PlayerMovement>().EnterWater();

            _isDrowning = true;
            currentDrownTime = drownTime;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            player.GetComponent<PlayerMovement>().ExitWater();

            _isDrowning = false;
        }
    }

    private void Update()
    {
        if (_isDrowning && currentDrownTime > 0)
        {
            currentDrownTime += -1f * Time.deltaTime;
            currentDrownTime = Mathf.Clamp(currentDrownTime, 0f, 100f);
        }
        else if (_isDrowning && currentDrownTime == 0)
        {
            player.GetComponent<PlayerState>().playerHealth = 0;
        }
    }
}
