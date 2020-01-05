using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class ItemDictionary : MonoBehaviour
    {
        [SerializeField] ItemTable itemTable = null;

        static Dictionary<string, ItemTemplate> instance;

        public static Dictionary<string, ItemTemplate> Instance { get => instance; }

        private void Awake()
        {
            instance = new Dictionary<string, ItemTemplate>();
            foreach (ItemTemplate itemTemplate in itemTable.itemTemplates)
            {
                instance.Add(itemTemplate.TemplateId, itemTemplate);
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}