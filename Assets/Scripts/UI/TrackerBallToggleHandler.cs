using UnityEngine;
using UnityEngine.UI;

// handles user input from tracker ball toggle button in UI
public class TrackerBallToggleHandler : MonoBehaviour
{

    private Toggle toggle;
    [SerializeField] private GameObject trackerBall;
    private bool trackerOn; // to store whether tracker is on/off

    void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    void Start()
    {
        SetInitToggleState();
    }

    // ensures toggle state is consistent between scenes; if this is the first scene, default is ON
    private void SetInitToggleState()
    {
        trackerOn = ControlledVars.instance.trackerOn;

        ToggleTrackerBall(trackerOn);

        toggle.isOn = trackerOn;
    }

    // enables/disables tracker ball based on current toggle state
    private void ToggleTrackerBall(bool trackerOn)
    {
        if (trackerOn)
            trackerBall.SetActive(true);
        else
            trackerBall.SetActive(false);
    }

    // called each time user clicks the "toggle detector cone" button
    public void HandleInputData(bool input)
    {
        ToggleTrackerBall(input);

        ControlledVars.instance.trackerOn = input;
    }

}
