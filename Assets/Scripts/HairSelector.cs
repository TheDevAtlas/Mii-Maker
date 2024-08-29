using UnityEngine;

public class HairSelector : MonoBehaviour
{
    public int buttonIndex;

    public GameObject[] buttons;

    public GameObject selector;

    public Changer changer;

    public Vector2 offset;

    private void Start()
    {
        SwitchPart(0);
    }

    public void SwitchPart(int targetIndex)
    {
        //buttons[buttonIndex].chil.SetActive(false);

        // -1109.2  75.0002

        buttonIndex = targetIndex;

        //selector.transform.position = buttons[buttonIndex].transform.position ; /// 35 15
        selector.GetComponent<RectTransform>().anchoredPosition = buttons[buttonIndex].GetComponent<RectTransform>().anchoredPosition + offset;

        //buttons[buttonIndex].SetActive(true);

        //changer.Change(targetIndex);
    }
}
