using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using tekill;

public class Actor : MonoBehaviour {
    public StatsActor a = new StatsActor();

    void start() {
        a.Strength = 2;
    }
    void Update() {
        
        
        Debug.Log("Strength " + a.Strength);
        a.Strength += 1;
    }
}