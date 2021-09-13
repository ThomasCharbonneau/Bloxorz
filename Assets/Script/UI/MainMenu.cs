using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public Button NewGameButton;
    [SerializeField]
    public Button ContinueGameButton;

    // Start is called before the first frame update
    void Start()
    {
        int currentLevelIndex = SaveController.GetCurrentLevel();
        ContinueGameButton.interactable = currentLevelIndex != 0;
        NewGameButton.onClick.AddListener(StartNewGame);
        ContinueGameButton.onClick.AddListener(ContinueGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartNewGame()
    {
        SaveController.UpdateCurrentLevel(1);
    }

    private void ContinueGame()
    {

    }
}
