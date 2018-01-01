using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Magic {

    public GameObject actionPrefab;
    GameObject instantiatedAction;
    bool actionActive = false;

    public override void AnimateAction()
    {
        instantiatedAction = Instantiate(actionPrefab);
        instantiatedAction.transform.position = target.transform.position;
        actionActive = true;
        StartCoroutine(DestroyAfterTime(caster, target));
    }

    IEnumerator DestroyAfterTime(Character caster, Character target)
    {
        float timeToDestroy = 2.5f;
        yield return new WaitForSeconds(timeToDestroy / 2f);
        DamageVisualizer.SpawnDamageText(target, damageDealt, isHealing);
        yield return new WaitForSeconds(timeToDestroy / 2f);

        Destroy(instantiatedAction);
        instantiatedAction = null;
        actionActive = false;
        FinishAction(caster);
    }
}
