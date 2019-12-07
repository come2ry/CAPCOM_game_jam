using UnityEngine;

/// <summary> 隕石の死亡処理 </summary>
public class PlanetDestoryProcess : MonoBehaviour
{
    public void Dead()
    {
        Destroy(gameObject);
    }
}