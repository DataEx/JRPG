using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageVisualizer : MonoBehaviour {
    public DamageText textPrefab;
    static DamageText staticTextPrefab;
    public Camera mainCamera;
    static Camera staticMainCamera;
    static Transform canvas;

    void Awake()
    {
        staticMainCamera = mainCamera;
        staticTextPrefab = textPrefab;
        canvas = this.transform;
    }

    public static void SpawnDamageText(Character character, uint amount, bool isHealing) {
        DamageText text = Instantiate(staticTextPrefab, canvas) as DamageText;
        text.SetCamera(staticMainCamera);
        text.SetCharacter(character);
        text.SetValue(amount);
        if (isHealing)
        {
            text.IsHealing();
        }
        else
        {
            character.AnimateCharacter(Character.CharacterPoses.Damaged);
        }
    }
}
