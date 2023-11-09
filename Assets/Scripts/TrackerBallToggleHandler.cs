using UnityEngine;
using UnityEngine.UI;

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

    private void SetInitToggleState()
    // ensures toggle state is consistent between scenes; if this is the first scene, default is ON
    {
        trackerOn = ControlledVars.controlledVars.trackerOn;
        ToggleTrackerBall(trackerOn);
        toggle.isOn = trackerOn;
    }

    private void ToggleTrackerBall(bool trackerOn)
    // enables/disables tracker ball based on current toggle state
    {
        if (trackerOn)
            trackerBall.SetActive(true);
        else
            trackerBall.SetActive(false);
    }



    public void HandleInputData(bool input)
    // called each time user clicks the "toggle detector cone" button
    {
        ToggleTrackerBall(input);
        ControlledVars.controlledVars.trackerOn = input;
    }

}
