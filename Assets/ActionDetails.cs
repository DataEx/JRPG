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

    public static void DisplayDetails(Character caster, Character target, Action action)
    {
        panel.SetActive(true);
        string details = "";
        string targetName = caster == target ? "self" : target.name;
        details = String.Format("{0} casts {1} on {2}", caster.name, action.actionName, targetName);
        textBox.text = details;
    }
    public static void ResetDetails()
    {
        panel.SetActive(false);
        textBox.text = "";
    }

}
