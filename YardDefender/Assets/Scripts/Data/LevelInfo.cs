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
        bool loading = false;

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

        public bool Loading { get => loading; }

        public Action OnInfoChange;
        public Action OnLevelChange;

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
            loading = true;
            OnLevelChange?.Invoke();
            //wait for a few seconds,then enable
            StartCoroutine(ActivateAfterAnimation());
        }

        IEnumerator ActivateAfterAnimation()
        {
            yield return new WaitForSeconds(3);
            loading = false;
            OnInfoChange?.Invoke();
        }
    }
}