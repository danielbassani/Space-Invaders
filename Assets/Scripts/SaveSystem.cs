using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveStats(int money, int exp)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/stats.spc";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(money, exp);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveUpgrades(byte damageRate, byte livesUpgraded, byte moneyRate, byte expRate)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/upgrades.spc";
        FileStream stream = new FileStream(path, FileMode.Create);

        UpgradeData data = new UpgradeData(damageRate, livesUpgraded, moneyRate, expRate);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SavePlayerCard(int kills, int livesLost, int bulletsFired, int moneyEarned)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playercard.spc";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerCard data = new PlayerCard(kills, livesLost, bulletsFired, moneyEarned);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveLevelUnlock(int levelUnlock)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/levelUnlock.spc";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(levelUnlock);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadStats()
    {
        string path = Application.persistentDataPath + "/stats.spc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = (SaveData)formatter.Deserialize(stream);
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    public static UpgradeData LoadUpgrades()
    {
        string path = Application.persistentDataPath + "/upgrades.spc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UpgradeData data = (UpgradeData)formatter.Deserialize(stream);
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    public static PlayerCard LoadPlayerCard()
    {
        string path = Application.persistentDataPath + "/playercard.spc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerCard data = (PlayerCard)formatter.Deserialize(stream);
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    public static LevelData LoadLevelUnlock()
    {
        string path = Application.persistentDataPath + "/levelUnlock.spc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = (LevelData)formatter.Deserialize(stream);
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    public static void DeleteSaveData()
    {
        string path = Application.persistentDataPath + "/playercard.spc";
        string path2 = Application.persistentDataPath + "/stats.spc";
        string path3 = Application.persistentDataPath + "/upgrades.spc";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        if (File.Exists(path2))
        {
            File.Delete(path2);
        }

        if (File.Exists(path3))
        {
            File.Delete(path3);
        }
    }
}
