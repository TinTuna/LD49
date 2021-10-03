using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;

    public GameObject StartScreen;
    public GameObject EndScreen;
    public GameObject ScorePanel;

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<Player>().EndGame) {
            EndScreen.SetActive(true);
            ScorePanel.SetActive(false);
        }
    }

    public void NewGame() {
        Camera.GetComponent<CameraScript>().ResetScore();
        StartScreen.SetActive(false);
        ScorePanel.SetActive(true);

        Camera.GetComponent<CameraScript>().resetPosition();
        Player.GetComponent<Player>().resetPosition();
    }

    public void EndGame() {
        Player.GetComponent<Player>().EndGame = false;
        EndScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
}
