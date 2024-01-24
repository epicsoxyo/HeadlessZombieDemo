using UnityEngine;
using TMPro;

// handles user input from camera dropdown menu in UI
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

    // ensures camera is consistent between scenes; if this is the first scene, default is index 0
    private void SetInitialCamera()
    {
        activeCam = ControlledVars.instance.activeCam;

        EnableActiveCamera(activeCam);

        dropdown.value = activeCam;
    }

    // enables the camera at index specified by param + disables all other cameras
    private void EnableActiveCamera(int active)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == active) cameras[i].enabled = true;
            else cameras[i].enabled = false;
        }
    }

    // called each time user makes a choice from the camera dropdown menu
    public void HandleInputData(int input)
    {
        EnableActiveCamera(input);
        ControlledVars.instance.activeCam = input;
    }

}