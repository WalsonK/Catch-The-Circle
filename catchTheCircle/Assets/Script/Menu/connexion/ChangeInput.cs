using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeInput : MonoBehaviour
{

    EventSystem system;
    public Button submitBtn;

    //To avoid error of no first input selected :
    public Selectable firstInput;

    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;
        firstInput.Select();
    }

    // Update is called once per frame
    void Update()
    {
        //Shit to go Up
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (previous != null)
            {
                previous.Select();
            }
        }
        //Tab to go down 
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }
        //Enter to submit form !
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            submitBtn.onClick.Invoke();
            Debug.Log("Btn pressed !");
        }
    }
}
