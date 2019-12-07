using UnityEngine;

/// <summary> 隕石の死亡処理 </summary>
public class MeteoriteDestoryProcess : MonoBehaviour
{
   public void Dead()
    {
        Destroy(gameObject);
    }
}
