using System;
using UnityEngine;

public class Factory : PollutingUnit
{
    void Start()
    {
        GameManager.instance.sound.PlayFactorySound();
    }
}
