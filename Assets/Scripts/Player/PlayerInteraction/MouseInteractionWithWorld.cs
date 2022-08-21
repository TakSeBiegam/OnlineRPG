using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MouseInteractionWithWorld : NetworkBehaviour
{
    //variables to interact with enemy upper bar
    [SerializeField]
    private GameObject EnemyUpperBar;
    private bool BarShowed;
    private RaycastHit hit;
    public bool inOtherWindow; //Prevent to close-up bar when use esc in inventory or another window
    [SerializeField] private GameObject selectedObject;

    //variables to interact with attacks
    void Start()
    {
        EnemyUpperBar = FindInActiveObjectByName("EnemyUpperBar");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null && hit.transform.gameObject.tag == "Enemy")
                {
                    gameObject.GetComponent<SimpleAttack>().target = hit.transform.gameObject;
                    selectedObject = hit.transform.gameObject;
                    EnemyUpperBar.gameObject.GetComponent<EUB_BarManager>().monster = selectedObject;
                    EnemyUpperBar.SetActive(true);
                    BarShowed = true;
                }
                if (hit.transform != null && hit.transform.gameObject.tag == "NPC")
                {
                    selectedObject = hit.transform.gameObject;
                    selectedObject.gameObject.GetComponent<NPC_REFORGED>().startDialogue(this.gameObject);
                }
            }
        }
        else if (Input.GetKey(KeyCode.Escape) && !inOtherWindow)
        {
            killUpperBar();
            //OR KILL ANY OPENED WINDOW
        }
    }



    public void killUpperBar()
    {
        EnemyUpperBar.SetActive(false);
        gameObject.GetComponent<SimpleAttack>().setTargetToNull();
    }

    private GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
