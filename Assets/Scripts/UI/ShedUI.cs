using UnityEngine;

public class ShedUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform shedPanel = null;

    private PlayerController playerController = null;
    private Shed currentShed = null;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        playerController.AddShedClickListener(SelectShed);
    }

    public void OpenWindow()
    {
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
}
