using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private const string CUT = "Cut";

    [SerializeField] private CuttingCounter cuttingCounter;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void Start() {
        cuttingCounter.OnCut += CuttongCounter_OnCut;
    }

    private void CuttongCounter_OnCut(object sender ,EventArgs e){
        animator.SetTrigger(CUT);
    }

}
