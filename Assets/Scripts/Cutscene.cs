using TMPro;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Animator cameraAnim;
    public Animator doorAnim;
    public Animator ladyAnim;
    public Animator uiAnim;

    public GameObject textBox;
    public TextMeshProUGUI dialogueText;

    public AudioSource doorSound;
    public AudioClip knockSound;
    public AudioClip doorOpeningSound;
    
    //enable the script in interact()
    private void Start()
    {
        dialogueText = textBox.GetComponent<TextMeshProUGUI>();
        CutsceneManager.Instance.StartCutscene(this);
    }

    public void LookCamera()
    {
        cameraAnim.enabled = true;
        cameraAnim.SetTrigger("Focus");
    }
    public void OpenDoor()
    {
        doorAnim.enabled = true;
    }
    public void OldLady()
    {
        ladyAnim.enabled = true;
    }
    public void ShowUI()
    {
        uiAnim.SetTrigger("Show UI");
    }
    public void HideUI()
    {
        uiAnim.enabled = true;
    }
    public void ShowDialogue()
    {
        textBox.SetActive(true);
    }
    public void HideDialogue()
    {
        dialogueText.text = "";
        textBox.SetActive(false);
    }
    public void KnockSound()
    {
        doorSound.PlayOneShot(knockSound);
    }
    public void OpeningSound()
    {
        doorSound.PlayOneShot(doorOpeningSound);
    }
    public void DialogueOne(string text)
    {
        dialogueText.text = text;
    }
    public void DialogueTwo(string text)
    {
        dialogueText.text = text;
    }
    public void DialogueThree(string text)
    {
        dialogueText.text = text;
    }
}
