using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialStrike : Action
{
    public GameObject actionPrefab;
    GameObject instantiatedAction;
    bool actionActive = false;

    public override void AnimateAction(Character target)
    {
        instantiatedAction = Instantiate(actionPrefab);
        instantiatedAction.transform.position = target.transform.position + Vector3.up * 10;
        actionActive = true;
    }

    void Update() {

        if (actionActive && instantiatedAction == null)
        {
            actionActive = false;
            FinishAction();
        }
    } 
}
