using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public static string PHASE_STATE = "phase_state";
    public Dictionary<string, string> config;

    // Enum for state
    public class PhaseState {
        public static string NONE = "none";
        public static string PHASE_1 = "phase1";
        public static string PHASE_2 = "phase2";
        public static string PHASE_3 = "phase3";
    }
    
    // Start is called before the first frame update
    void Start()
    {
        config = new Dictionary<string, string>();
        config[PHASE_STATE] = PhaseState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void UpdateScore()
    {
        score += 1;
        // TODO : update screen 
    }
    
    public void UpdateLive()
    {
        lives -= 1;
        // TODO : update screen 
    }
}
