using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GameUtil
{
    public bool InScream(Vector3 pos)
    {
        return Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(pos));
    }
}
