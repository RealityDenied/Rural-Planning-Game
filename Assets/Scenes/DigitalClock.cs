using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DigitalClock : MonoBehaviour
{
    public Text clockText;

    void Start()
    {
        StartCoroutine(UpdateClock());
    }

    IEnumerator UpdateClock()
    {
        while (true)
        {
            // Get the current system time
            DateTime currentTime = DateTime.Now;

            // Format the time as HH:mm:ss
            clockText.text = currentTime.ToString("HH:mm:ss");

            // Wait for 1 second
            yield return new WaitForSeconds(1);
        }
    }
}
