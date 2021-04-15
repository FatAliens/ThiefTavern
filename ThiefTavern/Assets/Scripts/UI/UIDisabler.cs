using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisabler : MonoBehaviour
{
    //не используется
    //[SerializeField]
    //private  bool ArrowIsPressed = false; // кнопка нажата

    [SerializeField]
    public GameObject UIToHide; //UI для скрытия
    public GameObject UIToShow; //UI для показа
    public Button ArrowToPress; // кнопка для нажатия


    void Start()
    {
        Button btn = ArrowToPress.GetComponent<Button>();
        btn.onClick.AddListener(Activation);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Activation()
    {
        UIToHide.SetActive(false);
        UIToShow.SetActive(true);
    }
}
