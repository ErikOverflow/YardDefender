//using System.Collections;//using System.Collections.Generic;//using TMPro;//using UnityEngine;//namespace ErikOverflow.YardDefender
//{
//    public class UIPlayerStats : MonoBehaviour
//    {
//        [SerializeField] PlayerInfo playerInfo = null;
//        [SerializeField] UIEquipment uiEquipment = null;
//        [SerializeField] TextMeshProUGUI goldText = null;
//        [SerializeField] TextMeshProUGUI levelText = null;
//        [SerializeField] TextMeshProUGUI experienceText = null;
//        [SerializeField] TextMeshProUGUI attackText = null;

//        void Start()
//        {
//            playerInfo.OnInfoChange += UpdateUI;
//            UpdateUI();
//        }

//        void UpdateUI()
//        {
//            goldText.text = playerInfo.PlayerData.Gold.ToString();
//            levelText.text = playerInfo.PlayerData.Level.ToString();
//            experienceText.text = playerInfo.PlayerData.Experience.ToString();
//            //attackText.text = playerInfo.Damage.ToString();
//            throw new System.Exception("Have not handled player damage calculation yet");
//            uiEquipment.RenderEquipment();
//        }

//        private void OnDestroy()
//        {
//            playerInfo.OnInfoChange -= UpdateUI;
//        }
//    }//}