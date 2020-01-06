using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class LevelInfo : MonoBehaviour
    {
        [SerializeField] Transform basePosition = null;
        [SerializeField] int level = 1;
        [SerializeField] List<LevelTemplate> levelTemplates = null;
        Dictionary<int, LevelTemplate> templateDictionary = null;
        int maxLevel = 0;

        public Transform BasePosition { get => basePosition; }
        public int Level { get => level; }
        public LevelTemplate LevelTemplate
        {
            get
            {
                LevelTemplate levelTemplate;
                templateDictionary.TryGetValue(level, out levelTemplate);
                return levelTemplate;
            }
        }

        public Action OnInfoChange;

        public void Awake()
        {
            templateDictionary = new Dictionary<int, LevelTemplate>();
            foreach(LevelTemplate template in levelTemplates)
            {
                templateDictionary.Add(template.levelNum, template);
            }
            maxLevel = levelTemplates.Max(lt => lt.levelNum);
        }

        public void ChangeLevel(int changeAmount)
        {
            level += changeAmount;
            if(level > maxLevel)
            {
                level = maxLevel;
            }
            OnInfoChange?.Invoke();
        }
    }
}