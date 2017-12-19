using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoController : MonoBehaviour {

    public Text playerNameText;
    public Player owner;

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
        healthBar.MaxValue = owner.initialHealth;
        healthBar.CurrentValue = owner.GetCurrentHealth();
        manaBar.MaxValue = owner.initialMana;
        manaBar.CurrentValue = owner.GetCurrentMana();
        healthBar.Update();
        manaBar.Update();
    }

    public void IncreaseHealth(uint healthGained) {
        healthBar.CurrentValue = (uint)Mathf.Min(healthBar.CurrentValue + healthGained, healthBar.MaxValue);\
        healthBar.Update();
    }
    public void DecreaseHealth(uint healthLost) {
        //
    }
    public void IncreaseMana(uint manaGained) {
        manaBar.CurrentValue = (uint)Mathf.Min(manaBar.CurrentValue + manaGained, manaBar.MaxValue);
        manaBar.Update();
    }
    public void DecreaseMana(uint manaLost) { }

}
