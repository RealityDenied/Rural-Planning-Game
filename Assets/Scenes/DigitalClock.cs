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
            
            DateTime currentTime = DateTime.Now;

            
            clockText.text = currentTime.ToString("HH:mm:ss");

           
            yield return new WaitForSeconds(1);
        }
    }
}
