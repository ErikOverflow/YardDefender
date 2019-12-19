using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public static TouchManager instance;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
#if UNITY_IOS || UNITY_ANDROID
    //Finger ID to finger number (tracks current finger and when it was placed)
    Dictionary<int, int> activeTouches = new Dictionary<int, int>();
    
    //Number of the touch (if 2 fingers are touching, then 1 & 2 are in the hashset. If you lift your first finger, then just 2 is in the hashset)
    HashSet<int> touchNums = new HashSet<int>();
    
    //Subscribable event for others to listen to.
    public static event TouchInputHandler TouchInput;
    
    // Start is called before the first frame update
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            //Add to managed finger information
            if (touch.phase == TouchPhase.Began)
            {
                for(int i = 1; i <= Input.touchCount; i++)
                {
                    //Find the finger value that's not in use
                    if(touchNums.Add(i))
                    {
                        activeTouches.Add(touch.fingerId, i);
                        break;
                    }
                }
            }
            //Broadcast touch input to all listeners
            TouchInput(activeTouches[touch.fingerId], touch);
            
            //Remove from managed finger information
            if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                touchNums.Remove(activeTouches[touch.fingerId]);
                activeTouches.Remove(touch.fingerId);
            }
        }
    }
#endif
    }

public delegate void TouchInputHandler(int fingerNum, Touch touch);
//Something that wants to subscribe to this would use TouchManger.instance.TouchInput += MethodToProcess; MethodToProcess should take in 1 parameter for finger number

