using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_HyperLink : MonoBehaviour
{
    public void GotoLink(string _link)
    {
        Application.OpenURL(_link);
    }
}
