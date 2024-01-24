using UnityEngine;
using UnityEngine.UI;

// handles user input from detector cone toggle button in UI
public class DetectorConeToggleHandler : MonoBehaviour
{

    private Toggle toggle;
    [SerializeField] private MeshRenderer detectorConeMesh;
    private bool detectorOn; // to store whether the cone is on/off

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
        detectorOn = ControlledVars.instance.detectorOn;

        ToggleDetectorCone(detectorOn);

        toggle.isOn = detectorOn;
    }

    // enables/disables cone's render mesh based on current toggle state
    private void ToggleDetectorCone(bool detectorOn)
    {
        if (detectorOn)
            detectorConeMesh.enabled = true;
        else
            detectorConeMesh.enabled = false;
    }

    // called each time user clicks the "toggle detector cone" button
    public void HandleInputData(bool input)
    {
        ToggleDetectorCone(input);

        ControlledVars.instance.detectorOn = input;
    }

}