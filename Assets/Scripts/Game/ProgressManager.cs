using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public List<MechanicClass> mechanics;
    public SceneEnum currentScene = SceneEnum.StartScene;
    private Animator animator;
    private Queue<MechanicClass> mNotifyQueue = new Queue<MechanicClass>();
    private bool notificationAnimating;

    private void Start() {
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
}
