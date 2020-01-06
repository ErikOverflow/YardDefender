using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class ExplosionInfo : MonoBehaviour
    {
        int damage = int.MaxValue;

        public int Damage { get => damage; }
    }
}