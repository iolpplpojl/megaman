using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput input;

    public static InputManager instance;

    private void Awake()
    {
       instance = this;   
        input = GetComponent<PlayerInput>();
    }

}
