using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    [CreateAssetMenu(fileName = "New Item Table", menuName = "Create New Item Table", order = 0)]
    public class ItemTable : ScriptableObject
    {
        public ItemTemplate[] itemTemplates = null;
    }
}