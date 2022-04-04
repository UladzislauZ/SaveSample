using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject generator;
    [SerializeField] private GameObject shop;
    [SerializeField] private CharacterController player;

    void Start()
    {
        EventBus.Generate += LoadEvent;
        EventBus.NewGame += NewGameEvent;
        EventBus.LoadLastGame += LastGameEvent;
    }

    private void NewGameEvent()
    {
        player.model = new CharacterModel();
    }

    private void LastGameEvent()
    {
        var save = SaveData.LoadLastGame();
        player.gameObject.transform.position = save.positionPlayer;
        player.gameObject.transform.rotation = save.rotatePlayer;
        generator.GetComponent<Generator>().LoadStones(save.positionsStones);
        player.model = new CharacterModel(save.level, save.score, save.levelAxe);
    }

    private void LoadEvent()
    {
        generator.SetActive(true);
        shop.SetActive(true);
    }

    // private void OnApplicationQuit()
    // {
    //     var transformPlayer = player.gameObject.transform;
    //     SaveData.SaveGame(new Save(player.model.Level(),player.model.Score(),player.model.LevelAxe(), transformPlayer.position, transformPlayer.rotation, GetStonesOnScene()));
    // }

    private List<Vector3> GetStonesOnScene()
    {
        var stones = new List<Vector3>();
        foreach (var stone in generator.GetComponentsInChildren<Stone>())
        {
            stones.Add(stone.transform.position);
        }

        return stones;
    }
    

    public void ExitScene()
    {
        EventBus.Generate -= LoadEvent;
        EventBus.NewGame -= NewGameEvent;
        EventBus.LoadLastGame -= LastGameEvent;
        var transformPlayer = player.gameObject.transform;
        SaveData.SaveGame(new Save(player.model.Level(),player.model.Score(),player.model.LevelAxe(), transformPlayer.position, transformPlayer.rotation, GetStonesOnScene()));
        SceneManager.LoadScene(0);
    }
}
