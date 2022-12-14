using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI nameText;
    [SerializeField] public TextMeshProUGUI dialogueText;
    [SerializeField] public Animator animator;
    [SerializeField] public Animator shopAnimator;
    [SerializeField] public Image image;
    private Queue<string> sentences;
    private IEnumerator coroutine;
    public bool talking;


    // Start is called before the first frame update
    private void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialogue (Dialogue dialogue)
    {
        talking = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        image.sprite = dialogue.NPCimage;
        if (dialogue.name == "shopKeeper")
        {
            shopAnimator.SetBool("IsShopOpen", true);
        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        //working next dialogue code
        //DisplayNextSentence();

           //DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }   

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        shopAnimator.SetBool("IsShopOpen", false);
        talking = false;

    }


}

