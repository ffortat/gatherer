using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShedUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform shedPanel = null;
    [SerializeField]
    private TextMeshProUGUI cubeCounter = null;
    [SerializeField]
    private Button takeButton = null;
    [SerializeField]
    private Button putButton = null;
    [SerializeField]
    private Button leaveButton = null;

    private PlayerController playerController = null;
    private Shed currentShed = null;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        takeButton.onClick.AddListener(OnTakeButtonClick);
        putButton.onClick.AddListener(OnPutButtonClick);
        leaveButton.onClick.AddListener(CloseWindow);

        playerController.AddShedClickListener(SelectShed);
    }

    public void OpenWindow()
    {
        UpdateUI();
        shedPanel.gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        shedPanel.gameObject.SetActive(false);
        currentShed = null;
    }

    private void SelectShed(Shed shed)
    {
        currentShed = shed;
        OpenWindow();
    }

    private void UpdateUI()
    {
        takeButton.interactable = currentShed && currentShed.HasCube();
        putButton.interactable = currentShed && playerController.Carrier.HasCube();
    }

    private void OnTakeButtonClick()
    {
        if (currentShed && currentShed.HasCube())
        {
            playerController.Carrier.CarryCube(currentShed.TakeCube());
            UpdateUI();
        }
    }

    private void OnPutButtonClick()
    {
        if (currentShed && playerController.Carrier.HasCube())
        {
            currentShed.PutCube(playerController.Carrier.DropCube());
            UpdateUI();
        }
    }
}
