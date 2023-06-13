using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Progress
{
    public List<MechanicClass> mechanics;
    public SceneEnum currentScene;
    public SceneEnum previousScene;
    public float RotationSpeed;

    public Progress(List<MechanicClass> mechanics, SceneEnum currentScene, SceneEnum previousScene, float RotationSpeed) { 
        this.mechanics = mechanics;
        this.currentScene = currentScene;
        this.previousScene = previousScene;
        this.RotationSpeed = RotationSpeed;
    }
}
