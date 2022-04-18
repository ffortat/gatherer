using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI speedUI = null;

    private PlayerController playerController = null;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        speedUI.text = playerController.Mover.Speed.ToString("F2");
    }
}
