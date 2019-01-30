using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text finalScoreLabel;
    public Text highScoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        finalScoreLabel.text = "" + GameController.instance.score;
        highScoreLabel.text = "" + GameController.instance.highScore;
    }

    void RestartGame()
    {
        GameController.instance.ResetGame();
        //SceneManager.LoadScene("Level1");

    }


}
