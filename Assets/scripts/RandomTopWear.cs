using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Utils = AvatarSysUtil.Utils;


public class RandomTopWear : MonoBehaviour
{

    [SerializeField] private Button btnRandomTopWear;

    [SerializeField] private SkinnedMeshRenderer top;
    
    // Start is called before the first frame update
    void Start()
    {
        btnRandomTopWear.onClick.AddListener(() => Execute());
    }

    private void Execute()
    {
        var randomID = Utils.ID2String(Random.Range(1, 20));
        btnRandomTopWear.GetComponentInChildren<Text>().text = randomID;
        var meshPath = String.Format("res/{0}/mesh_Top", randomID);
        top.sharedMesh = Resources.Load<Mesh>(meshPath);
        var materialPath = String.Format("res/{0}/mat_Top", randomID);
        top.sharedMaterial = Resources.Load<Material>(materialPath);
    }
}
