﻿using JustChores.MobileApp.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustChores.MobileApp.Services
{
    public class MainRepository
    {
        string FilePath => $"{FileSystem.Current.AppDataDirectory}/main.db";

        public bool InsertChore(Chore newChore)
        {
            using var db = new LiteDatabase(FilePath);
            var collection = db.GetCollection<Chore>();
            return collection.Insert(newChore) != null;
        }

        public IEnumerable<Chore> GetChores()
        {
            using var db = new LiteDatabase(FilePath);
            return db.GetCollection<Chore>().FindAll();
        }

        public bool UpdateChore(Chore updatedChore)
        {
            using var db = new LiteDatabase(FilePath);
            var collection = db.GetCollection<Chore>();
            return collection.Update(updatedChore);
        }

        public bool DeleteChore(int choreId)
        {
            using var db = new LiteDatabase(FilePath);
            var collection = db.GetCollection<Chore>();
            return collection.Delete(choreId);
        }
    }

}
