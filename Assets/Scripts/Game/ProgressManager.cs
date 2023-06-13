using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private SceneEnum defaultStartScene = SceneEnum.Ad;
    public List<MechanicClass> mechanics;
    public SceneEnum currentScene = SceneEnum.Ad;
    public SceneEnum previousScene = SceneEnum.Ad;
    private Animator animator;
    private Queue<MechanicClass> mNotifyQueue = new Queue<MechanicClass>();
    private bool notificationAnimating;
    private string filePath = "/progress.geraldai";

    private void Start() {
        currentScene = GetComponent<SceneHandler>().getCurrentScene();
    }

    public void DiscoverMechanic(MechanicEnum mechanic) {
        MechanicClass discoveredMechanic = mechanics.Where(r => r.mechanic == mechanic).First();
        if (!discoveredMechanic.discovered) {
            mNotifyQueue.Enqueue(discoveredMechanic);
            if (!notificationAnimating) {
                notificationAnimating = true;
                StartCoroutine(notify(discoveredMechanic));
            }
            discoveredMechanic.discovered = true;
            if (mechanics.Where(r => r.discoverOrder != 0).Count() > 0)
                discoveredMechanic.discoverOrder = mechanics.OrderByDescending(r => r.discoverOrder).First().discoverOrder + 1;
            else
                discoveredMechanic.discoverOrder = 1;
        }
    }

    public void ResetMechanics() {
        foreach (MechanicClass mechanic in mechanics) {
            mechanic.discovered = false;
            mechanic.discoverOrder = 0;
        }
    }

    private IEnumerator notify(MechanicClass mechanic) {
        if (FindObjectOfType<GeneralUIManager>()) {
            animator = FindObjectOfType<GeneralUIManager>().transform.GetChild(0).GetChild(2).GetComponent<Animator>();
            animator.transform.GetChild(0).GetComponent<TMP_Text>().text = "Mechanic Discovered\n" + SpaceString(mechanic.mechanicName.ToString());
            animator.SetBool("FlyIn", true);
            yield return new WaitForSeconds(6);
            if (FindObjectOfType<GeneralUIManager>()) {
                animator = FindObjectOfType<GeneralUIManager>().transform.GetChild(0).GetChild(2).GetComponent<Animator>();
                animator.transform.GetChild(0).GetComponent<TMP_Text>().text = "Mechanic Discovered\n" + SpaceString(mechanic.mechanicName.ToString());
                animator.SetBool("FlyIn", false);
                yield return new WaitForSeconds(1);
                mNotifyQueue.Dequeue();
                if (mNotifyQueue.Count() > 0) {
                    StartCoroutine(notify(mNotifyQueue.First()));
                } else {
                    notificationAnimating = false;
                }
            }
        }

    }

    private string SpaceString(string input) {
        string output = "";
        foreach (char c in input) {
            if (char.IsUpper(c) && output.Length > 0) {
                output += " ";
            }
            output += c;
        }
        return output;
    }

    public void saveProgress()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + filePath;
        FileStream stream = new FileStream(path, FileMode.Create);

        Progress data = new Progress(mechanics, currentScene, previousScene);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public void loadProgress()
    {
        string path = Application.persistentDataPath + filePath;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Progress data = formatter.Deserialize(stream) as Progress;
            stream.Close();

            mechanics = data.mechanics;
            currentScene = data.currentScene;
            previousScene = data.previousScene;
        }
    }

    public bool checkProgress()
    {
        string path = Application.persistentDataPath + filePath;
        if (File.Exists(path))
        {
            return true;
        }
        return false;
    }

    public void resetProgress()
    {
        ResetMechanics();
        currentScene = defaultStartScene;
        previousScene = defaultStartScene;
        saveProgress();
    }
}
