using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class Cutscene : MonoBehaviour
{
    public Animator hauntedDoorAnim;
    public AudioClip hauntedDoorSound;
    public Animator mazeDoorAnim;
    public AudioClip mazeDoorSound;
    public TextMeshProUGUI cutsceneDialogue;
    [Header("OutsideScene")]
    public List<string> outsideDialogues = new List<string>();
    [Header("HauntedHouseScene")]
    public List<string> hauntedHouseDialogues = new List<string>();
    [Header("MazeStartingScene")]
    public List<string> mazeStartingDialogues = new List<string>();
    [Header("MazeDoorScene")]
    public List<string> mazeDoorDialogues = new List<string>();

    public void OpenHauntedDoor()
    {
        hauntedDoorAnim.SetTrigger("OpenHaunted");
        SoundManager.Instance.PlayOneShot(hauntedDoorAnim.GetComponent<AudioSource>(), hauntedDoorSound);
    }
    public void OpenMazeDoor()
    {
        mazeDoorAnim.SetTrigger("OpenMaze");
        SoundManager.Instance.PlayOneShot(mazeDoorAnim.GetComponent<AudioSource>(), mazeDoorSound);
    }
    public void OutsideOne()
    {
        cutsceneDialogue.text = outsideDialogues[0];
    }
    public void OutsideTwo()
    {
        cutsceneDialogue.text = outsideDialogues[1];
    }
    public void OutsideThree()
    {
        cutsceneDialogue.text = outsideDialogues[2];
    }
    public void OutsideFour()
    {
        cutsceneDialogue.text = outsideDialogues[3];
    }
    public void OutsideFive()
    {
        cutsceneDialogue.text = outsideDialogues[4];
    }
    public void OutsideSix()
    {
        cutsceneDialogue.text = outsideDialogues[5];
    }
    public void HauntedOne()
    {
        cutsceneDialogue.text = hauntedHouseDialogues[0];
    }
    public void HauntedTwo()
    {
        cutsceneDialogue.text = hauntedHouseDialogues[1];
    }
    public void HauntedThree()
    {
        cutsceneDialogue.text = hauntedHouseDialogues[2];
    }
    public void HauntedFour()
    {
        cutsceneDialogue.text = hauntedHouseDialogues[3];
    }
    public void HauntedFive()
    {
        cutsceneDialogue.text = hauntedHouseDialogues[4];
    }
    public void MazeOne()
    {
        cutsceneDialogue.text = mazeStartingDialogues[0];
    }
    public void MazeTwo()
    {
        cutsceneDialogue.text = mazeStartingDialogues[1];
    }
    public void MazeThree()
    {
        cutsceneDialogue.text = mazeStartingDialogues[2];
    }
    public void MazeFour()
    {
        cutsceneDialogue.text = mazeStartingDialogues[3];
    }
    public void MazeFive()
    {
        cutsceneDialogue.text = mazeStartingDialogues[4];
    }
    public void MazeDoorOne()
    {
        cutsceneDialogue.text = mazeDoorDialogues[0];
    }
    public void MazeDoorTwo()
    {
        cutsceneDialogue.text = mazeDoorDialogues[1];
    }
    public void MazeDoorThree()
    {
        cutsceneDialogue.text = mazeDoorDialogues[2];
    }
    public void DisablePlayer()
    {
        GameManager.Instance.PlayerCutscene();
    }
    public void EnablePlayerOutside()
    {
        GameManager.Instance.PlayerCutsceneEndOutside();
    }
    public void EnablePlayerMaze()
    {
        GameManager.Instance.PlayerCutsceneEnd();
    }
    public void StartTutorial()
    {
        TutorialManager.Instance.ShowMazeTutorial();
    }
}
