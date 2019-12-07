using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonBase<Type> : MonoBehaviour where Type :MonoBehaviour
{
    private static Type _SingleInstance;

    public static Type Instance
    {
        get
        {
            if (_SingleInstance == null)
            {
                //Scene内のSceneDirectorを取得
                foreach (var obj in SceneManager.GetActiveScene().GetRootGameObjects())
                {
                    var component = obj.GetComponent<Type>();
                    if (component == null) continue;
                    _SingleInstance = component;
                }
                if(_SingleInstance == null)
                {
                    GameObject gameObject = new GameObject("SingletonObject");
                    gameObject.AddComponent<Type>();
                }
            }
            return _SingleInstance;
        }

        private set
        {
            _SingleInstance = value;
        }
    }

    public virtual void Awake()
    {
        //重複をなくす
        if(Instance != this.GetComponent<Type>())
        {
            if (_SingleInstance != null)
                Destroy(this.gameObject);
            else
                _SingleInstance = this.GetComponent<Type>();
        }

        Debug.Log("Log:"+this.ToString() + " is Singleton");
        DontDestroyOnLoad(this);
    }
}
