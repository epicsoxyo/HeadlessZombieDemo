using UnityEngine;

public class ControlledVars : MonoBehaviour
{
    
    public static ControlledVars controlledVars;
    public int activeCam;   // stores currently active camera
    public bool trackerOn;  // stores whether player tracking ball is visible
    public bool detectorOn; // stores whether detection cone is visible



    void Awake()
    {
        DestroyDuplicateVars();
    }

    void DestroyDuplicateVars()
    // maintains only the initial controlled vars across scenes; destroys any duplicates
    {
        if (controlledVars == null)
        {
            DontDestroyOnLoad(gameObject);
            controlledVars = this;
        }
        else Destroy(gameObject);
    }

}