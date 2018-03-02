using UnityEngine;

public class tower_input : MonoBehaviour
{
    GameObject menu;

    void Start()
    {
        menu = GameObject.Find("Menus");
    }

    void OnMouseDown()
    {
        try
        {
            menu.SetActive(true);
        }
        catch
        {
            menu.SetActive(false);
        }
        
    }
}
