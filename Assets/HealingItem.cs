using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : Item {

    public GameObject actionPrefab;
    GameObject instantiatedAction;
    bool actionActive = false;

    public override void AnimateAction(Character target)
    {
        instantiatedAction = Instantiate(actionPrefab);
        instantiatedAction.transform.position = target.transform.position;
        actionActive = true;
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        float timeToDestroy = 1.5f;
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(instantiatedAction);
        instantiatedAction = null;
        actionActive = false;
        FinishAction();
    }
}
