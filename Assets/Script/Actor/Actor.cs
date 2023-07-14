using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StatsActor;

public class Actor : MonoBehaviour {
    public BaseStatsActors a = new BaseStatsActors();

    void start() {
        a.Strength = 2;
    }
    void Update() {
        
        
        Debug.Log("Strength " + a.Strength);
        a.Strength += 1;
    }
}