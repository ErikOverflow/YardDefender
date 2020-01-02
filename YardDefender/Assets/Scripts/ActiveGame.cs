using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveGame : MonoBehaviour
{
    public static ActiveGame instance;
    [SerializeField] int saveId = 0;
    [SerializeField] PlayerStats playerStats = null;
    [SerializeField] bool newGamePlus = false;

    public int GameId { get => saveId; }
    public bool NewGamePlus { get => newGamePlus; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SetPlayerStats(PlayerStats _playerStats)
    {
        playerStats = _playerStats;
    }

    public void SetSaveId(int id)
    {
        saveId = id;
    }

    public void LoadGame()
    {
        SaveData saveData = DataService.instance.ReadSaveData(saveId);
        if(saveData == null)
        {
            //This should not be reached during regular gameplay
            return;
        }
        //Get all playerdatas related to the save
        newGamePlus = saveData.NewGamePlus;
        IEnumerable<PlayerData> playerDatas = DataService.instance.ReadPlayerDatas(saveData);
        PlayerData playerData = playerDatas.FirstOrDefault();
        IEnumerable<WeaponData> weaponDatas = DataService.instance.ReadWeaponDatas(playerData.Id);
        //Update playerstats with the first one in the playerdatas list
        playerStats?.Initialize(playerDatas.FirstOrDefault(), saveData, weaponDatas);
    }

    public void SaveGame()
    {
        //Update SaveData
        SaveData saveData = DataService.instance.ReadSaveData(saveId);
        saveData.Gold = playerStats.Gold;
        DataService.instance.UpdateSaveData(saveData);

        //Save player data
        IEnumerable<PlayerData> playerDatas = DataService.instance.ReadPlayerDatas(saveData);
        foreach(PlayerData playerData in playerDatas)
        {
            //If there were more than one playerData, you would need to fetch from the respective playerStats here.
            playerData.Level = playerStats.Level;
            playerData.Experience = playerStats.Experience;
            playerData.AttackLevel = playerStats.AttackLevel;
            DataService.instance.UpdatePlayerData(playerData);

            //Save weapon data
            //Get all weapons currently belonging to that player
            IEnumerable<WeaponData> storedWeapons = DataService.instance.ReadWeaponDatas(playerData.Id);
            IEnumerable<WeaponData> inventoryWeapons = playerStats.PlayerWeapons;
            IEnumerable<int> storedWeaponIds = storedWeapons.Select(w => w.Id);
            IEnumerable<int> inventoryWeaponIds = inventoryWeapons.Select(w => w.Id);
            //Any weapon Ids that are in DB, but not in the inventory anymore
            IEnumerable<int> deletedWeaponIds = storedWeaponIds.Except(inventoryWeaponIds);
            //Any weapon Ids that are in the inventory, but not in storage previously
            IEnumerable<int> newWeaponIds = inventoryWeaponIds.Except(storedWeaponIds);
            //Weapons that existed in both, but might need updating
            IEnumerable<int> updateWeaponIds = inventoryWeaponIds.Intersect(storedWeaponIds);

            IEnumerable<WeaponData> deleteWeapons = storedWeapons.Where(w => deletedWeaponIds.Contains(w.Id));
            IEnumerable<WeaponData> newWeapons = inventoryWeapons.Where(w => newWeaponIds.Contains(w.Id));
            IEnumerable<WeaponData> updateWeapons = inventoryWeapons.Where(w => updateWeaponIds.Contains(w.Id));
            DataService.instance.DeleteWeaponDatas(deleteWeapons);
            foreach(WeaponData weaponData in newWeapons)
            {
                weaponData.Id = DataService.instance.CreateWeaponData();
                DataService.instance.UpdateWeaponData(weaponData);
            }
            DataService.instance.UpdateWeaponDatas(updateWeapons);
        }
    }
}
