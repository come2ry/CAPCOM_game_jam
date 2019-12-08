using UnityEngine;

/// <summary> 隕石の死亡処理 </summary>
public class MeteoriteDestoryProcess : MonoBehaviour
{
    public GameObject EffectPrefab;
    public void Dead()
    {
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        SoundMng.Instance?.PlaySE(SoundMng.SETag.Bomb);
        Destroy(gameObject.GetComponent<MeteoriteShooter>().RayInstance);
        Destroy(gameObject);
        // foreach ( Transform child in transform )
        // {
        //     Destroy(child.gameObject);
        // }
    }
}
