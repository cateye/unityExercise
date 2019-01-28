using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This is a class that are going to control all the variables that are changing across the game
//let say in a up level

public class GameController : MonoBehaviour
{
    //declare varialbles
    public int score;
    public int highScore = 3; //START at 3 so I can see if this actually works
    //Current level, start at level 1
    public int currentLevel = 1;
    //hightest level max num of levels in the game
    public int highestLevel = 2;

    HudManager hm;


    //we create a instance of this class, is stactic because we need it across the game.
    public static GameController instance;

    // we are going to use here Awake because we need to run this Before everything start
    void Awake()
    {
        //if we don't have any instance of GameController we create a new one.
        if (instance == null) {
            instance = this;
        }
        //if we a GameController instance that is diferente than this one, we destroy it, we only need one.
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        hm = FindObjectOfType<HudManager>();

        //In order to keep this object between the Game we avoid to distroy this instance
        DontDestroyOnLoad(gameObject);


    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        if (hm != null)
            hm.resetHub();
        if (score > highScore)
        {
            highScore = score;
            print("New HiScore: " + highScore);
        }
    }

    public void ResetGame()
    {
        //reset score
        score = 0;
        if(hm != null)
            hm.resetHub();
        //change current level
        currentLevel = 1;
        //load level 1 scene
        SceneManager.LoadScene("Level1");

    }

    public void increaseLevel()
    {
        if(currentLevel < highestLevel)
        {
            currentLevel++;
        }
        else
        {
            //tratar de poner a los enemigos mas rapidos
            currentLevel = 1;
        }
        SceneManager.LoadScene("Level" + currentLevel);
    }


}
