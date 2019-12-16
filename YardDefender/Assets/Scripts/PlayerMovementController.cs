using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    RigidBody2D rb2d = null;
    int fingerId;
    bool active = false;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<RigidBody2D>();
    }
#if UNITY_IOS || UNITY_ANDROID
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = __Camera__.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray))
                {
                    // Create a particle if hit
                    Instantiate(particle, transform.position, transform.rotation);
                }
            }
        }
    }
#else
    void Update()
    {
        
    }
#endif
}
