using UnityEngine;

// stores controlled variables for the project
public class ControlledVars : MonoBehaviour
{

    public static ControlledVars instance;
    public int activeCam;   // stores currently active camera
    public bool trackerOn;  // stores whether player tracking ball is visible
    public bool detectorOn; // stores whether detection cone is visible

    void Awake()
    {
        DestroyDuplicateVars();
    }

    // maintains only the initial controlled vars across scenes; destroys any duplicates
    void DestroyDuplicateVars()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(gameObject);
    }

}