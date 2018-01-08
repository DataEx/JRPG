using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Action {

    public override void UseAction(Character target, Character caster)
    {
        // InputController.staticCharacterPointer.SetTarget(target);
        this.caster = caster;
        this.target = target;
        targetIsDestroyed = false;

        damageDealt = GetDamage();
        damageDealt = (uint)(damageDealt * (1f / target.GetDefenseMultiplier()));
        ActionDetails.AttackDisplayDetails(caster, target);
        AnimateAction();
    }

    public override void AnimateAction()
    {
        StartCoroutine(ActionAnimationCoroutine());
    }

    IEnumerator ActionAnimationCoroutine()
    {
        Character player = GetComponent<Character>();
        Animator animator = GetComponent<Animator>();

        animator.SetTrigger("StartAttack");
        while (animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.RUN00_F"))
        {
            yield return null;
        }
        Quaternion originalRotation = player.transform.rotation;
        Vector2 startPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 endPos = new Vector2(target.transform.position.x, target.transform.position.z);
        Vector2 v = endPos - startPos;
        v = v * 0.85f;
        endPos = v + startPos;
        Vector3 originalPos = player.transform.position;
        float distToTarget = Vector2.Distance(startPos, endPos);
        float timeToMove = 1.5f;
        float timeElapsed = 0f;

        player.transform.LookAt(target.transform);
        player.transform.eulerAngles = new Vector3(0, player.transform.rotation.eulerAngles.y, 0);

        while (timeElapsed < timeToMove)
        {
            timeElapsed += Time.deltaTime;
            Vector2 newPos = Vector2.Lerp(startPos, endPos, timeElapsed / timeToMove);
            player.transform.position = new Vector3(newPos.x, originalPos.y, newPos.y);
            // movetowards
            yield return null;
        }
        animator.SetTrigger("ReachTarget");
        yield return new WaitForSeconds(2f);
        timeElapsed = 0f;
        float timeToRotate = 0.5f;
        float amountRotated = 0;
        while (timeElapsed < timeToRotate)
        {
            timeElapsed += Time.deltaTime;
            float additoinalRotation = (timeElapsed / timeToRotate) * 180f - amountRotated;
            player.transform.Rotate(0, additoinalRotation, 0);
            amountRotated += additoinalRotation;
            yield return null;
        }
        DamageVisualizer.SpawnDamageText(target, damageDealt, isHealing);
        animator.SetTrigger("EndAttack");
        timeElapsed = 0f;

        while (timeElapsed < timeToMove)
        {
            timeElapsed += Time.deltaTime;
            Vector2 newPos = Vector2.Lerp(endPos, startPos, timeElapsed / timeToMove);
            player.transform.position = new Vector3(newPos.x, originalPos.y, newPos.y);
            // movetowards
            yield return null;
        }
        player.transform.position = originalPos;
        amountRotated = 0f;
        timeElapsed = 0f;
        while (timeElapsed < timeToRotate)
        {
            timeElapsed += Time.deltaTime;
            float additoinalRotation = (timeElapsed / timeToRotate) * 180f - amountRotated;
            player.transform.Rotate(0, additoinalRotation, 0);
            amountRotated += additoinalRotation;
            yield return null;
        }

        player.transform.rotation = originalRotation;
        animator.SetTrigger("Return");
        FinishAction(caster);
    }
}
