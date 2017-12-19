using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DamageText : MonoBehaviour {
    public Camera facingCamera;
    public Character attachedCharacter;
    public Vector3 characterOffset;
    public float timeVisible = 2f;
    public float heightRaised = 1f;


    public void SetCamera(Camera camera) {
        facingCamera = camera;
    }
    public void SetCharacter(Character character) {
        attachedCharacter = character;
    }
    public void SetValue(uint value) {
        this.GetComponent<TextMeshProUGUI>().text = value.ToString();
    }
    public void IsHealing() {
        this.GetComponent<TextMeshProUGUI>().color = Color.green;
    }
    void Start() {
        this.transform.position = attachedCharacter.transform.position;
        StartCoroutine(RaiseText());
    }

    void Update() {
        this.transform.LookAt(facingCamera.transform);
        this.transform.Rotate(0, 180, 0);
    }

    IEnumerator RaiseText() {
        float timeElapsed = 0f;
        Vector3 startingPosition = this.transform.position + characterOffset;
        Vector3 endingPosition = startingPosition + Vector3.up * heightRaised;
        while (timeElapsed <= timeVisible) {
            timeElapsed += Time.deltaTime;
            this.transform.position = Vector3.Lerp(startingPosition, 
                endingPosition, timeElapsed / timeVisible);
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
