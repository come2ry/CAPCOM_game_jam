/// <summary> 衝突対象をマスクする際に使用するレイヤー列挙型 </summary>
[System.Flags]
public enum CollisionLayer
{
    Untagged = 1 << 0,

    /// <summary> 隕石 </summary>
    Meteorite = 1 << 1,

    /// <summary> 惑星 </summary>
    Planet = 1 << 2,
}