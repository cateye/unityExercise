using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreLabel;

    void Start()
    {
        resetHub();
    }

    public void resetHub()
    {
        scoreLabel.text = "Score: " + GameController.instance.score;
    }
}
