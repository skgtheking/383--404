using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QandAManager : MonoBehaviour
{
    // Start is called before the first frame update
    private QandA qAndA;
    private Button submit;
    

    void Start()
    {
        submit = GameObject.FindWithTag("SubmitButton").GetComponent<Button>();
        submit.onClick.AddListener(OnButtonClick);
        IQuestionGenerator questionGenerator = new QuestionGenerator();
        qAndA = new QandA(questionGenerator);
        qAndA.Start();
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("object") && !ChallengeManager.quizStatus())
        {
            Debug.Log(ChallengeManager.quizStatus());
            qAndA.DisplayQuestion();
        }
    }
    public void OnButtonClick()
    {
        Debug.Log("Button Clicked");
        qAndA.CheckQuestion();
    }
}
