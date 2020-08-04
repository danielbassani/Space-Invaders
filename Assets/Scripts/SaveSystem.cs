using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveStats(int money)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/stats.spc";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(money);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveUpgrades(byte damageRate, byte livesUpgraded, byte moneyRate, byte expRate, byte maxBombs, short bombDamage)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/upgrades.spc";
        FileStream stream = new FileStream(path, FileMode.Create);

        UpgradeData data = new UpgradeData(damageRate, livesUpgraded, moneyRate, expRate, maxBombs, bombDamage);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SavePlayerCard(int kills, int livesLost, int bulletsFired, int moneyEarned, int expEarned, int expToNextLevel, byte rank)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playercard.spc";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerCard data = new PlayerCard(kills, livesLost, bulletsFired, moneyEarned, expEarned, expToNextLevel, rank);

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

    public static void SaveSettings(float volume)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/settings.spc";
        FileStream stream = new FileStream(path, FileMode.Create);

        SettingsData data = new SettingsData(volume);

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
            //Debug.LogError("Save file not found in" + path);
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
            //Debug.LogError("Save file not found in" + path);
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
            //Debug.LogError("Save file not found in" + path);
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
            //Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    public static SettingsData LoadSettings()
    {
        string path = Application.persistentDataPath + "/settings.spc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SettingsData data = (SettingsData)formatter.Deserialize(stream);
            stream.Close();

            return data;
        }
        else
        {
            //Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    public static void DeleteSaveData()
    {
        string path = Application.persistentDataPath + "/playercard.spc";
        string path2 = Application.persistentDataPath + "/stats.spc";
        string path3 = Application.persistentDataPath + "/upgrades.spc";
        string path4 = Application.persistentDataPath + "/levelUnlock.spc";
        string path5 = Application.persistentDataPath + "/settings.spc";

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

        if (File.Exists(path4))
        {
            File.Delete(path4);
        }

        if (File.Exists(path5))
        {
            File.Delete(path5);
        }
    }
}
