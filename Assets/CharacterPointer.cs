using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPointer : MonoBehaviour {

    public GameObject pointerObject;
    public Camera mainCamera;
    List<Player> players;
    List<Enemy> enemies;
    public float heightAbovePlayer;
    Character target;

    Vector3 defaultPosition;
    Quaternion defaultRotation;

    public float timeToMove = 0.5f;
    bool canMove = true;
    public Vector3 cameraOffset;

    void Start () {
        defaultPosition = mainCamera.transform.position;
        defaultRotation = mainCamera.transform.rotation;
        players = BattleQueue.players;
        enemies = BattleQueue.enemies;

    }

    public void SetInitialTargetPlayer() {
        EnablePointer();
        SetTarget(players[0]);
    }
    public void SetInitialTargetEnemy() {
        EnablePointer();
        SetTarget(enemies[0]);
    }
    public void AdvancePointerForward() {
        if (target is Player)
            AdvancePointerBackwardPlayer();
        else if (target is Enemy)
            AdvancePointerBackwardEnemy();
    }
    public void AdvancePointerBackward() {
        if (target is Player)
            AdvancePointerForwardPlayer();
        else if (target is Enemy)
            AdvancePointerForwardEnemy();
    }

    void AdvancePointerForwardPlayer() {
        int currentIndex = players.IndexOf((Player)target);
        currentIndex = (currentIndex + 1) % players.Count;
        SetTarget(players[currentIndex]);
    }
    void AdvancePointerBackwardPlayer()
    {
        int currentIndex = players.IndexOf((Player)target);
        currentIndex = currentIndex - 1;
        if (currentIndex < 0)
            currentIndex = players.Count - 1;
        SetTarget(players[currentIndex]);
    }
    void AdvancePointerForwardEnemy()
    {
        int currentIndex = enemies.IndexOf((Enemy)target);
        currentIndex = (currentIndex + 1) % enemies.Count;
        SetTarget(enemies[currentIndex]);
    }
    void AdvancePointerBackwardEnemy()
    {
        int currentIndex = enemies.IndexOf((Enemy)target);
        currentIndex = currentIndex - 1;
        if (currentIndex < 0)
            currentIndex = enemies.Count - 1;
        SetTarget(enemies[currentIndex]);
    }
    
    public void SetTarget(Character newTarget) {
        MoveToCharacter(newTarget);
        target = newTarget;
    }

    public void EnablePointer() {
        pointerObject.SetActive(true);
    }
    public void DisablePointer() {
        pointerObject.SetActive(false);
    }
    public bool IsPointerActive() {
        return pointerObject.activeSelf;
    }
    public void ResetCameraTransform() {
        mainCamera.transform.position = defaultPosition;
        mainCamera.transform.rotation = defaultRotation;
    }
    public Character GetTarget() {
        return target;
    }

    public void MoveToCharacter(Character character)
    {
        StartCoroutine(MoveToCharacterCoroutine(character));
    }

    IEnumerator MoveToCharacterCoroutine(Character character)
    {
        canMove = false;
        float timeElapsed = 0f;
        Transform lookAtObj = character.transform;
        Vector3 initialPosition = mainCamera.transform.position;
        Vector3 finalPosition = lookAtObj.position +
            (lookAtObj.transform.right * cameraOffset.x +
            lookAtObj.transform.up * cameraOffset.y +
            lookAtObj.transform.forward * cameraOffset.z);
        mainCamera.transform.position = finalPosition;
        Vector3 relativePos = lookAtObj.position - mainCamera.transform.position;
        Quaternion initialRotation = mainCamera.transform.rotation;
        Quaternion finalRotation = Quaternion.LookRotation(relativePos);
        mainCamera.transform.position = initialPosition;
        while (timeElapsed < timeToMove)
        {
            timeElapsed += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(initialPosition, finalPosition, timeElapsed / timeToMove);
            mainCamera.transform.rotation = Quaternion.Lerp(initialRotation, finalRotation, timeElapsed / timeToMove);
            yield return null;
        }
        mainCamera.transform.position = finalPosition;
        canMove = true;
    }
}
