using UnityEngine;
using TMPro;

public class CameraDropdownHandler : MonoBehaviour
{

    private TMP_Dropdown dropdown;
    [SerializeField] private Camera[] cameras; // array of cameras to switch between
    private int activeCam; // array index of currently active camera



    void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }



    void Start()
    {
        SetInitialCamera();
    }

    private void SetInitialCamera()
    // ensures camera is consistent between scenes; if this is the first scene, default is index 0
    {
        activeCam = ControlledVars.controlledVars.activeCam;
        EnableActiveCamera(activeCam);
        dropdown.value = activeCam;
    }
    
    private void EnableActiveCamera(int active)
    // enables the camera at index specified by arg & disables all other cameras.
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == active) cameras[i].enabled = true;
            else cameras[i].enabled = false;
        }
    }



    public void HandleInputData(int input)
    // called each time user makes a choice from the camera dropdown menu
    {
        EnableActiveCamera(input);
        ControlledVars.controlledVars.activeCam = input;
    }

}