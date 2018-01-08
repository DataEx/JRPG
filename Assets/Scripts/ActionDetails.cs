using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionDetails : MonoBehaviour {

    public GameObject publicPanel;
    public Text publicTextBox;
    static GameObject panel;
    static Text textBox;

    void Awake()
    {
        panel = publicPanel;
        textBox = publicTextBox;
    }

    void Update() {
        Image image = panel.GetComponent<Image>();
        Color color = image.color;
        color.a = 0.65f;
        image.color = color;
    }

    public static void DisplayDetails(Character caster, Character target, Action action)
    {
        panel.SetActive(true);
        string details = "";
        string targetName = caster == target ? "self" : target.name;
        details = String.Format("{0} casts {1} on {2}", caster.name, action.actionName, targetName);
        textBox.text = details;
    }
    public static void MagicDisplayDetails(Character caster, Character target, Action action)
    {
        panel.SetActive(true);
        string details = "";
        string targetName = caster == target ? "self" : target.name;
        details = String.Format("{0} casts {1} on {2}", caster.name, action.actionName, targetName);
        textBox.text = details;
    }
    public static void ItemDisplayDetails(Character caster, Character target, Action action)
    {
        panel.SetActive(true);
        string details = "";
        string targetName = caster == target ? "self" : target.name;
        details = String.Format("{0} uses {1} on {2}", caster.name, action.actionName, targetName);
        textBox.text = details;
    }
    public static void AttackDisplayDetails(Character caster, Character target)
    {
        panel.SetActive(true);
        string details = "";
        string targetName = caster == target ? "self" : target.name;
        details = String.Format("{0} attacks {1}", caster.name, targetName);
        textBox.text = details;
    }
    public static void DefendDisplayDetails(Character caster)
    {
        panel.SetActive(true);
        string details = String.Format("{0} uses Defend", caster.name);
        textBox.text = details;
    }
    public static void VictoryDisplayDetails() {
        panel.SetActive(true);
        textBox.text = "Victory!";
    }
    public static void GameOverDisplayDetails() {
        panel.SetActive(true);
        textBox.text = "Game Over...";
    }
    public static void TargetDisplayDetails(Character target) {
        panel.SetActive(true);
        string details = String.Format("Target: {0} \t HP: {1} / {2}", 
            target.name, target.GetCurrentHealth().ToString(), target.GetInitialHealth().ToString());
        textBox.text = details;
    }
    public static void ActionDescription(string description)
    {
        panel.SetActive(true);
        textBox.text = description;
    }
    public static void ResetDetails()
    {
        panel.SetActive(false);
        textBox.text = "";
    }

}
