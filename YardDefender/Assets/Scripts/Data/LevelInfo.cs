using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
	public class LevelInfo : MonoBehaviour
	{
        [SerializeField] Transform basePosition = null;
        [SerializeField] int level = 1;

        public Transform BasePosition { get => basePosition; }
        public int Level { get => level; }
    }
}
