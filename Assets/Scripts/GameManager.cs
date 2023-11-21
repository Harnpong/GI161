using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private int playerScore;

    public int PlayerScore
    {
        get { return playerScore;  }
        set { playerScore = value;  }
    }

    [SerializeField] private int score = 0;
    void Start()
    {
        var instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
