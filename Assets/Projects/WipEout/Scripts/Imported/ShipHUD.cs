using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ShipHUD : MonoBehaviour
{
    /* Description --
     *  this script appears to manage the ui for each ship
     */
    /* Notes --
     *  may need to update this script when update ui
     */

    [SerializeField] public Canvas HUD;

    private float speed, momentum;
    private Text speedText, posText, lapText, momentumText;
    private GameManager g_manager;
    private ShipController ship;

    // My code ---------------

    [Space]
    public GameObject RaceUI;
    public GameObject EndRaceUI;
    [Space]
    public TextMeshProUGUI recordText;
    public TextMeshProUGUI currentText;
    public TextMeshProUGUI bestTimeText;
    public TextMeshProUGUI gEarnedText;
    [Space]
    public float fastestTime;
    public float currentTime;
    [Space]
    public UnityEvent NewLapRecord;

    private bool x = true;
    private int currentLap = 1;
    private int nextLap;

    // Old code --------------

    void Start()
    {
        if (!HUD) return;

        foreach (Transform child in HUD.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.name == "Speed")
            {
                speedText = child.GetComponent<Text>();
            }
            else if (child.gameObject.name == "Position")
            {
                posText = child.GetComponent<Text>();
            }
            else if (child.gameObject.name == "Lap")
            {
                lapText = child.GetComponent<Text>();
            }
            else if (child.gameObject.name == "Momentum")
            {
                momentumText = child.GetComponent<Text>();
            }
            else if (child.gameObject.name == "Record")
            {
                recordText = child.GetComponent<TextMeshProUGUI>();
            }
            else if (child.gameObject.name == "Current")
            {
                currentText = child.GetComponent<TextMeshProUGUI>();
            }
            else if (child.gameObject.name == "Race UI")
            {
                RaceUI = child.gameObject;
            }
            else if (child.gameObject.name == "End Race UI")
            {
                EndRaceUI = child.gameObject;
            }
            else if (child.gameObject.name == "Best Time")
            {
                bestTimeText = child.GetComponent<TextMeshProUGUI>();
            }
            else if (child.gameObject.name == "G Earned")
            {
                gEarnedText = child.GetComponent<TextMeshProUGUI>();
            }
        }

        g_manager = FindObjectOfType<GameManager>();
        ship = GetComponent<ShipController>();

        // My code ---------


        setUpUI();
        startTimer();
    }
	
	void Update()
    {
        UpdateHUD();
	}

    void UpdateHUD()
    {
        if (!HUD) return;

        // My code ------------

        nextLap = g_manager.GetLaps(ship.GetID());

        if (nextLap > currentLap)
        {
            newLap();

            currentLap = nextLap;
        }

        currentText.text = "Current : " + currentTime.ToString("F2");

        // -----------

        //actual kph conversion is 3.6f but the ships are 60% too big
        speedText.text = (speed * 3.6f).ToString("F2") + " KPH";
        posText.text = "POS " + g_manager.GetPosition(ship.GetID()).ToString() + "/" + g_manager.GetShipCount();
        lapText.text = "LAP " + currentLap.ToString();
        momentumText.text = momentum.ToString("F2");
    }

    public void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void UpdateMomentum(float newMomentum)
    {
        momentum = newMomentum;
    }

    // My code ---------------

    public void newLap()
    {
        stopTimer();
        compareTimes();
        resetTimer();
        g_manager.ReportLap(ship.GetID());
        startTimer();
    }

    public void startTimer()
    {
        StartCoroutine("runTimer");
    }

    public void stopTimer()
    {
        StopCoroutine("runTimer");
    }

    public void compareTimes()
    {
        if (fastestTime == 0)
        {
            newLapRecord();
        }
        else if (currentTime < fastestTime)
        {
            newLapRecord();
        }
    }

    public void newLapRecord()
    {
        fastestTime = currentTime;
        recordText.text = "Record : " + fastestTime.ToString("F2");
        NewLapRecord.Invoke();
    }

    public void resetTimer()
    {
        currentTime = 0.0f;
    }

    public IEnumerator runTimer()
    {
        while (x)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
    }

    public void setUpUI()
    {
        EndRaceUI.SetActive(false);
    }

    public void PlayEndRaceUI(int gEarned = 10)
    {
        RaceUI.SetActive(false);
        EndRaceUI.SetActive(true);

        bestTimeText.text = "Best Time : " + fastestTime.ToString("F2");
        gEarnedText.text = "G Earned : " + gEarned.ToString();
    }
}
