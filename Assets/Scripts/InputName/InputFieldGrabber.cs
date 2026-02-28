using TMPro;
using UnityEngine;

public class InputFieldGrabber : MonoBehaviour
{
    [SerializeField]
    private string inputText;
    [SerializeField] private GameObject reactionGroup;
    [SerializeField] private TMP_Text reactionTextBox;

    public void GrabFromInputField(string input)
    {
        inputText = input;
    }

    private void DisplayReactionToInput()
    {
        reactionTextBox.text = "Welcome" + inputText;
        reactionGroup.SetActive(true);
    }

}
