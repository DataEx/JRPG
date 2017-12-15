using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Camera camera;
	public float timeToMove = 0.5f;
	bool canMove = true;
    public Vector3 cameraOffset;

	public void MoveToCharacter(Character character)
    {
        print(character);
        StartCoroutine(MoveToCharacterCoroutine(character));
	}

	IEnumerator MoveToCharacterCoroutine(Character character){
		canMove = false;
		float timeElapsed = 0f;
		Transform lookAtObj = character.transform;
		Vector3 initialPosition = camera.transform.position;
		Vector3 finalPosition = lookAtObj.position + 
            (lookAtObj.transform.right * cameraOffset.x + 
            lookAtObj.transform.up * cameraOffset.y + 
            lookAtObj.transform.forward * cameraOffset.z);
		camera.transform.position = finalPosition;
		Vector3 relativePos = lookAtObj.position - camera.transform.position;
		Quaternion initialRotation = camera.transform.rotation;
		Quaternion finalRotation = Quaternion.LookRotation (relativePos);
		camera.transform.position = initialPosition;
		while (timeElapsed < timeToMove) {
			timeElapsed += Time.deltaTime;
			camera.transform.position = Vector3.Lerp (initialPosition, finalPosition, timeElapsed / timeToMove);
			camera.transform.rotation = Quaternion.Lerp(initialRotation, finalRotation, timeElapsed / timeToMove);
			yield return null;
		}
		camera.transform.position = finalPosition;
		canMove = true;
	}
    /*
	void MoveToNext(){
		pointIndex = (pointIndex + 1) % points.Length; 
		StartCoroutine(MoveToCharacter (pointIndex));
	}
	void MoveToPrev(){
		pointIndex--;
		if (pointIndex < 0)
			pointIndex = points.Length - 1;
		StartCoroutine(MoveToObject (pointIndex));
	}
    */
}
