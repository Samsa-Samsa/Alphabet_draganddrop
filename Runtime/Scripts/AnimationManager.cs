using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void delete()
    {

    }
}
