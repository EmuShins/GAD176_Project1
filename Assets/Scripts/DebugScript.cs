using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawAGizmo(Vector3 from, Vector3 to)
    {
        Gizmos.color= Color.red;
        Gizmos.DrawLine(from, to);

    }
}
