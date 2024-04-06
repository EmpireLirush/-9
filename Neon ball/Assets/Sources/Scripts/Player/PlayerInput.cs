using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{
    private IInput _input;

    [Inject]
    public void Constructor(IInput input)
    {
        _input = input;
    }

    public Vector3 Direction => _input.Direction();
}