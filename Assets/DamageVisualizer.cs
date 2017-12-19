using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageVisualizer : MonoBehaviour {
    public DamageText textPrefab;
    public Camera mainCamera;

    public void SpawnDamageText(Character character, uint amount, bool isHealing) {
        DamageText text = Instantiate(textPrefab, this.transform) as DamageText;
        text.SetCamera(mainCamera);
        text.SetCharacter(character);
        text.SetValue(amount);
        if (isHealing)
            text.IsHealing();
    }
}
