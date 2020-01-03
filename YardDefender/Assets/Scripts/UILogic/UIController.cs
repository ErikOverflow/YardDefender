using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance = null;
    [SerializeField] GameObject MobHealthBar = null;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    public GameObject CreateMobHealthBar(HealthController hc)
    {
        GameObject go = ObjectPooler.instance.GetPooledObject(MobHealthBar);
        go.transform.SetParent(transform);
        UIMobHealth uimh = go.GetComponent<UIMobHealth>();
        uimh.Initialize(hc);
        return go;
    }
}
