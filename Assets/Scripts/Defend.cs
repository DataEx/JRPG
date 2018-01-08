using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : Action {

    public GameObject actionPrefab;
    GameObject instantiatedAction;
    bool actionActive = false;


    public override void UseAction(Character target, Character caster)
    {
        base.UseAction(target, caster);
        ActionDetails.DefendDisplayDetails(caster);
    }

    public override void AnimateAction()
    {
        instantiatedAction = Instantiate(actionPrefab);
        instantiatedAction.transform.position = target.transform.position;
        instantiatedAction.transform.rotation = target.transform.rotation;
        instantiatedAction.transform.position += Vector3.up * 0.6f + instantiatedAction.transform.forward;
        actionActive = true;
        StartCoroutine(DestroyAfterTime(caster, target));
    }

    IEnumerator DestroyAfterTime(Character caster, Character target)
    {
        float totalTime = 1.5f;
        Vector3 upwardMovement = Vector3.up * 0.5f;
        Vector3 originalPosition = instantiatedAction.transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < totalTime) {
            elapsedTime += Time.deltaTime;
            instantiatedAction.transform.position = Vector3.Lerp(originalPosition, originalPosition + upwardMovement, elapsedTime / totalTime);
            yield return null;
        }
        Destroy(instantiatedAction);
        instantiatedAction = null;
        actionActive = false;
        FinishAction(caster);
    }
}
