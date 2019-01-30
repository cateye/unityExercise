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
        print("HudManager Started");
        ResetHub();

    }

    public void ResetHub()
    {
        scoreLabel.text = "Score: " + GameController.instance.score;
    }
}
