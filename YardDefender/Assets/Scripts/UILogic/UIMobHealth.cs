//using System.Collections;//using System.Collections.Generic;//using UnityEngine;//using UnityEngine.UI;//public class UIMobHealth : MonoBehaviour//{//    [SerializeField] Slider slider = null;//    //HealthController healthController = null;//    Transform trackingObject = null;//    private void Awake()
//    {
//        System.Exception("have not connected mob health controller yet");
//    }

//    //public void Initialize(HealthController trackedController)
//    //{
//    //    gameObject.SetActive(true);
//    //    healthController = trackedController;
//    //    HealthChange();
//    //    trackingObject = healthController.transform;
//    //    healthController.OnDamage += HealthChange;
//    //}

//    //public void HealthChange()
//    //{
//    //    slider.value = healthController.GetPercent();
//    //}

//    //void LateUpdate()
//    //{
//    //    transform.position = trackingObject.position + new Vector3(0, -0.6f, 0);
//    //    if (!healthController.isActiveAndEnabled)
//    //        gameObject.SetActive(false);
//    //}

//    //private void OnDisable()
//    //{
//    //    healthController.OnDamage -= HealthChange;
//    //}
//}