using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject particlesGameObject;

    private void Start() {
        stoveCounter.OnStateChagned += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChagnedEventArgs e) {
        bool show = e.state == StoveCounter.State.Frying ||e.state == StoveCounter.State.Fried;

        stoveOnGameObject.SetActive(show);
        particlesGameObject.SetActive(show);
    }


}
