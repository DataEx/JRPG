using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoController : MonoBehaviour {

    public Text playerNameText;

    [Serializable]
    public class Bar
    {
        public Transform fill;
        public Text text;
    }

    public Bar healthBar;
    public Bar manaBar;



}
