﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SQLite4Unity3d;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class DataService : MonoBehaviour
    {
        public static DataService instance;
        private SQLiteConnection _connection;
        [SerializeField] string databaseName = "gameRestructuring.db";

        private void Awake()
        {
            instance = this;

            string databasePath = string.Format("{0}/{1}", Application.persistentDataPath, databaseName);
            if (!File.Exists(databasePath))
            {
                using (FileStream fs = File.Create(databasePath))
                {
                    fs.Close();
                }
            }
            _connection = new SQLiteConnection(databasePath);
            CreateDB();
        }

        private void CreateDB()
        {
            _connection.CreateTable<SaveData>();
            _connection.CreateTable<PlayerData>();
            _connection.CreateTable<EquipmentData>();
            _connection.CreateTable<ItemData>();
            _connection.CreateTable<WeaponData>();
        }

        //Generic CRUD
        public T CreateRow<T>() where T : Data, new()
        {
            T newData = new T();
            _connection.Insert(newData);
            return newData;
        }

        public void InsertRow<T>(T newData) where T:Data, new()
        {
            _connection.Insert(newData, typeof(T));
        }

        public T ReadRowById<T>(int id) where T : Data, new()
        {
            return _connection.Table<T>().Where(row => row.Id == id).FirstOrDefault();
        }

        public T ReadRowByGameId<T>(int saveId) where T : GameData, new()
        {
            return _connection.Table<T>().Where(row => row.SaveId == saveId).FirstOrDefault();
        }

        public IEnumerable<T> ReadRowsByGameId<T>(int saveId) where T : GameData, new()
        {
            return _connection.Table<T>().Where(row => row.SaveId == saveId);
        }

        public IEnumerable<T> ReadAllRows<T>() where T : new()
        {
            return _connection.Table<T>();
        }

        public void UpdateRow<T>(T dataToUpdate)
        {
            _connection.Update(dataToUpdate, typeof(T));
        }

        public void DeleteRow<T>(T dataToDelete)
        {
            _connection.Delete(dataToDelete);
        }

        private void OnDestroy()
        {
            _connection?.Close();
        }
    }
}