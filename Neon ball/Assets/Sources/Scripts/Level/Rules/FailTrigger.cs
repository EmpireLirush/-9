using System;
using UnityEngine;

public class FailTrigger : PlayerTrigger
{
    public Action OnFail;

    private void Awake()
    {
        PlayerEnter += Fail;
    }

    private void Fail()
    {
        OnFail?.Invoke();
    }
}
