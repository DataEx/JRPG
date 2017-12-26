using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionAnimation : MonoBehaviour {

    //    public Animation animation;
    //    public ParticleSystem particleSystem;
    protected Action caller;

    public abstract void DisplayAction(Character target, Action caller);


}
