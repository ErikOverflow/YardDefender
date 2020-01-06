using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    Rigidbody2D rb2d = null;
    [SerializeField] float moveSpeed = 1f;

    [Header("Finger to listen to")]
#pragma warning disable 414
    [SerializeField]
    int touchNum = 1;

    Camera mainCamera = null;
    Vector3 moveDir = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
#if UNITY_IOS || UNITY_ANDROID
        TouchManager.TouchInput += HandleTouch;
#endif
    }

#if UNITY_IOS || UNITY_ANDROID
    void HandleTouch(int fingerNum, Touch touch)
    {
        if(touchNum != fingerNum)
            return;
        Vector3 tapPosition = mainCamera.ScreenToWorldPoint(touch.position);
        moveDir = (tapPosition - transform.position).normalized;
        if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
        {
            moveDir = Vector3.zero;
        }
    }
#endif

#if !UNITY_IOS && !UNITY_ANDROID
    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
#endif

    private void FixedUpdate()
    {
        rb2d.velocity = moveDir * moveSpeed;
    }

#if UNITY_IOS || UNITY_ANDROID
    void OnDestroy()
    {
        TouchManager.TouchInput -= HandleTouch;
    }
#endif
}
