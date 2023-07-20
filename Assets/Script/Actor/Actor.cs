using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StatsActor;

public class Actor : MonoBehaviour {
    public BaseStatsActors a = new BaseStatsActors();

    void start() {
        a.Strength = 2;
    }
}