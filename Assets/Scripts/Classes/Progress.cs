using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Progress
{
    public List<MechanicClass> mechanics;
    public SceneEnum currentScene;
    public SceneEnum previousScene;

    public Progress(List<MechanicClass> mechanics, SceneEnum currentScene, SceneEnum previousScene) { 
        this.mechanics = mechanics;
        this.currentScene = currentScene;
        this.previousScene = previousScene;
    }
}
