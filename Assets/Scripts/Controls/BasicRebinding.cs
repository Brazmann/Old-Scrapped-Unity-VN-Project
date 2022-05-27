using UnityEngine;
using UnityEngine.InputSystem;

public class BasicRebinding : MonoBehaviour
{
    public PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
        ChangeBinding();
    }
    void ChangeBinding()
    {
        Debug.Log("ChangeBinding has been run!");
        InputBinding binding = playerControls.Player.Interaction.bindings[0];
        binding.overridePath = "<Keyboard>/#(g)";
        playerControls.Player.Interaction.ApplyBindingOverride(0, binding);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}