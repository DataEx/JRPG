using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoController : MonoBehaviour {

    public Text playerNameText;
    public Player owner;
    public InputController inputController;

    [Serializable]
    public class Bar
    {
        public Transform fill;
        public Text text;
        public uint MaxValue { set; get; }
        public uint CurrentValue { set; get; }

        public void Update() {
            UpdateText();
            UpdateBar();
        }

        public void UpdateText() {
            text.text = CurrentValue.ToString() + "/" + MaxValue.ToString();
        }

        public void UpdateBar() {
            float percentageFill = (float)CurrentValue / MaxValue;
            Vector3 fillScale = fill.localScale;
            fillScale.x = percentageFill;
            fill.localScale = fillScale;
        }
    }

    public Bar healthBar;
    public Bar manaBar;

    void Awake()
    {
        Image image = GetComponent<Image>();
        Color color = image.color;
        color.a = 0.65f;
        image.color = color;

        healthBar.MaxValue = owner.initialHealth;
        healthBar.CurrentValue = owner.GetCurrentHealth();
        manaBar.MaxValue = owner.initialMana;
        manaBar.CurrentValue = owner.GetCurrentMana();
        healthBar.Update();
        manaBar.Update();
    }

    public void IncreaseHealth(uint healthGained) {
        healthBar.CurrentValue = (uint)Mathf.Min(healthBar.CurrentValue + healthGained, healthBar.MaxValue);
        healthBar.Update();
    }
    public void DecreaseHealth(uint healthLost) {
        healthBar.CurrentValue = healthBar.CurrentValue - healthLost;
        if (healthBar.CurrentValue > healthBar.MaxValue)
            healthBar.CurrentValue = 0;
        healthBar.Update();
    }
    public void IncreaseMana(uint manaGained) {
        manaBar.CurrentValue = (uint)Mathf.Min(manaBar.CurrentValue + manaGained, manaBar.MaxValue);
        manaBar.Update();
    }
    public void DecreaseMana(uint manaLost)
    {
        manaBar.CurrentValue = manaBar.CurrentValue - manaLost;
        if (manaBar.CurrentValue > manaBar.MaxValue)
            manaBar.CurrentValue = 0;
        manaBar.Update();
    }
}
