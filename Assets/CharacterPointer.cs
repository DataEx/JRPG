using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPointer : MonoBehaviour {

    public GameObject pointerObject;
    public Camera mainCamera;
    public Player[] players;
    public Enemy[] enemies;
    public float heightAbovePlayer;
    
    Character target;

    public CameraMovement cameraMovement;

    /*
    void Update () {
        this.transform.LookAt(mainCamera.transform);
        this.transform.Rotate(0, 0, -90);
	}
    */

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
        int currentIndex = Array.IndexOf(players, target);
        currentIndex = (currentIndex + 1) % players.Length;
        SetTarget(players[currentIndex]);
    }
    void AdvancePointerBackwardPlayer()
    {
        int currentIndex = Array.IndexOf(players, target);
        currentIndex = currentIndex - 1;
        if (currentIndex < 0)
            currentIndex = players.Length - 1;
        SetTarget(players[currentIndex]);
    }
    void AdvancePointerForwardEnemy()
    {
        int currentIndex = Array.IndexOf(enemies, target);
        currentIndex = (currentIndex + 1) % enemies.Length;
        SetTarget(enemies[currentIndex]);
    }
    void AdvancePointerBackwardEnemy()
    {
        int currentIndex = Array.IndexOf(enemies, target);
        currentIndex = currentIndex - 1;
        if (currentIndex < 0)
            currentIndex = enemies.Length - 1;
        SetTarget(enemies[currentIndex]);
    }
    
    public void SetTarget(Character newTarget) {
        //    this.transform.position = newTarget.transform.position + Vector3.up * heightAbovePlayer;
        cameraMovement.MoveToCharacter(newTarget);
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
    public Character GetTarget() {
        return target;
    }
}
