using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CursorController : MonoBehaviour {

    AudioSource moveSoundPlayer;

    void Awake() {
        moveSoundPlayer = GetComponent<AudioSource>();
    }

    public int GetCursorIndex() {
        return transform.parent.GetSiblingIndex();
    }

    public void SetCursorPosition(Transform parentText) {
        Vector3 relativePosition = this.transform.localPosition;
        this.transform.SetParent(parentText);
        this.transform.localPosition = relativePosition;

        PlaySound();
    }
    public void PlaySound() {
        moveSoundPlayer.Play();
    }
}
