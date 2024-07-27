using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    public string cutsceneID { get; }
    public string nextCutsceneID { get; }
    public int cutsceneSetID { get; }
    public string currentSpeaker { get; }
    public string leftSpeaker { get; }
    public string rightSpeaker { get; }
    public string speech { get; }

    public Dialogue(string cutsceneID, string nextCutsceneID, int cutsceneSetID,string currentSpeaker,string leftSpeaker, string rightSpeaker, string speech)
    {
        this.cutsceneID = cutsceneID;
        this.nextCutsceneID = nextCutsceneID;
        this.cutsceneSetID = cutsceneSetID;
        this.currentSpeaker = currentSpeaker;
        this.leftSpeaker = leftSpeaker;
        this.rightSpeaker = rightSpeaker;
        this.speech = speech;
    }

    public string GetCharacterName()
    {
        string name = string.Empty;

        if (currentSpeaker == "left")
        {
            name = leftSpeaker;
        }
        else
        {
            name = rightSpeaker;
        }

        return name;
    }

}
