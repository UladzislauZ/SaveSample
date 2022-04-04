using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject gameScreen;
    
    void Start()
    {
        startScreen.SetActive(true);
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameScreen.SetActive(true);
        EventBus.StartNewGame();
    }

    public void StartLastGame()
    {
        startScreen.SetActive(false);
        gameScreen.SetActive(true);
        EventBus.StartLastGame();
    }
}
