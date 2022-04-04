using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveData
{
    public static void SaveGame(Save save)
    {
        var obj = JsonUtility.ToJson(save);
        File.WriteAllText(Application.persistentDataPath + "data.json", obj);
    }

    public static Save LoadLastGame()
    {
        var obj = File.ReadAllText(Application.persistentDataPath + "data.json");
        return JsonUtility.FromJson<Save>(obj);
    }
}

[Serializable]
public class Save
{
    public int level;
    public float score;
    public int levelAxe;
    public Vector3 positionPlayer;
    public Quaternion rotatePlayer;
    public List<Vector3> positionsStones;

    public Save(int level, float score, int levelAxe, Vector3 positionPlayer, Quaternion rotatePlayer, List<Vector3> positionsStones)
    {
        this.level = level;
        this.score = score;
        this.levelAxe = levelAxe;
        this.positionPlayer = positionPlayer;
        this.rotatePlayer = rotatePlayer;
        this.positionsStones = positionsStones;
    }
}