using UnityEngine;

/// <summary> 隕石の死亡処理 </summary>
public class MeteoriteDestoryProcess : MonoBehaviour
{
    public GameObject BulletPrefab;
    public void Dead()
    {
        Instantiate(BulletPrefab);
        Destroy(gameObject);
    }
}
