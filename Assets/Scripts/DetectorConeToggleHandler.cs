using UnityEngine;
using UnityEngine.UI;

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

    private void SetInitToggleState()
    // ensures toggle state is consistent between scenes; if this is the first scene, default is ON
    {
        detectorOn = ControlledVars.controlledVars.detectorOn;
        ToggleDetectorCone(detectorOn);
        toggle.isOn = detectorOn;
    }

    private void ToggleDetectorCone(bool detectorOn)
    // enables/disables cone's render mesh based on current toggle state
    {
        if (detectorOn)
            detectorConeMesh.enabled = true;
        else
            detectorConeMesh.enabled = false;
    }



    public void HandleInputData(bool input)
    // called each time user clicks the "toggle detector cone" button
    {
        ToggleDetectorCone(input);
        ControlledVars.controlledVars.detectorOn = input;
    }

}