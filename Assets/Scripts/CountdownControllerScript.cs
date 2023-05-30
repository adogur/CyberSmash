using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using Unity.VisualScripting;

public class CountdownControllerScript : MonoBehaviour
{
    public int time;
    public GameObject CountdownText;
    public GameObject Timer;
    private TMP_Text text;
    private VehicleController controller;
    private GameObject[] opponents;
    private GameObject manager;
    //private OpponentVehicleController[] opponents;
    private Counter counter;

    private void Start()
    {
        opponents = GameObject.FindGameObjectsWithTag("AI");
        foreach (GameObject ai in opponents)
        {
            ai.GetComponent<OpponentVehicleController>().enabled = false;
        }
        controller = GetComponent<VehicleController>();
        controller.enabled = false; 
        CountdownText = GameObject.FindGameObjectWithTag("CountDownText");
        Timer = GameObject.FindGameObjectWithTag("TimeCounter");
        counter = Timer.GetComponent<Counter>();
        text = CountdownText.GetComponent<TMP_Text>();
        manager = GameObject.FindGameObjectWithTag("AllCheckpoints");
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while(time > 0)
        {
            text.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }
        text.text = "GO!";
        controller.enabled = true;
        foreach (GameObject ai in opponents)
        {
            ai.GetComponent<OpponentVehicleController>().enabled = true;
        }
        manager.GetComponent<RaceManager>().enabled = true;
        counter.playing = true;
        yield return new WaitForSeconds(1f);
        text.gameObject.SetActive(false);
    }

}
