using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject[] windows;
    public GameObject[] buttonSelected;
    public int windowIndex;

    public void SwitchWindow(int targetIndex)
    {
        windows[windowIndex].SetActive(false);
        buttonSelected[windowIndex].SetActive(false);

        windowIndex = targetIndex;

        windows[windowIndex].SetActive(true);
        buttonSelected[windowIndex].SetActive(true);
    }
}
