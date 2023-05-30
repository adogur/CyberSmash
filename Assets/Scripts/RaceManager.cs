
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;


public class RaceManager : MonoBehaviour
{
    public GameObject Cp;
    public GameObject Checkpoints;

    public GameObject[] Cars;
    public int[] CPS;
    public int[] Positions;
    public TMP_Text posText;

    private int totalCars;
    private int totalCheckpoints;
    private int playerPos;

    private void Start()
    {
        totalCars = GameObject.FindGameObjectsWithTag("AI").Length + 1;
        Cars = new GameObject[totalCars];
        Cars[0] = GameObject.FindGameObjectWithTag("Player");
        int i = 1;
        foreach(GameObject car in GameObject.FindGameObjectsWithTag("AI"))
        {
            Cars[i] = car;
            i++;
        }
        posText = GameObject.FindGameObjectWithTag("PositionText").GetComponent<TMP_Text>();
        CPS = new int[totalCars];
        i = 0;
        foreach (GameObject car in Cars)
        {
            CPS[i] = 0;
            i++;
        }
    }

    private void Update()
    {
        CalculateCP();
        CalculatePosition();
        posText.text = "" + playerPos;
    }

    private void CalculateCP()
    {
        CPS[0] = Cars[0].GetComponent<VehicleController>().currentCP;
        for (int i = 1; i < totalCars; i++)
        {
            CPS[i] = Cars[i].GetComponent<OpponentVehicleController>().currentCP;
        }
    }

    private void CalculatePosition()
    {
        List<int> A = CPS.ToList();
        var sorted = A
        .Select((x, i) => new KeyValuePair<int, int>(x, i))
        .OrderByDescending(x => x.Key)
        .ToList();
        List<int> B = sorted.Select(x => x.Key).ToList();
        List<int> idx = sorted.Select(x => x.Value).ToList();
        playerPos = idx.FindIndex(x => x == 0) + 1;
    }
}