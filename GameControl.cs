using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {
    public static GameControl m_Control;
    public string m_SavingPath = Application.persistentDataPath + "/playerInofo.dat";

    public float m_Health;
    public float m_Experience;


    void Awake() {
        if (m_Control == null)
        {
            DontDestroyOnLoad(gameObject);
            m_Control = this;
        }
        else if(m_Control != this) {
            Destroy(gameObject);
        }
    }

    void OnGUI() {
        GUI.Label(new Rect(10,10,100,30),"Health: " + m_Health);
        GUI.Label(new Rect(10, 40, 150, 30), "EXP: " + m_Experience);
    }

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(m_SavingPath);

        //Instanate player data
        PlayerData playerData = new PlayerData();
        playerData.experience = m_Experience;
        playerData.health = m_Health;

        //Write data to file.
        bf.Serialize(file,playerData);
        file.Close();
    }

    public void Load() {
        if (File.Exists(m_SavingPath)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(m_SavingPath,FileMode.Open);
            PlayerData playerData = (PlayerData)bf.Deserialize(file);

            m_Health = playerData.health;
            m_Experience = playerData.experience;

        }
    }
}

[Serializable]
class PlayerData
{
    public float health;
    public float experience;
}
