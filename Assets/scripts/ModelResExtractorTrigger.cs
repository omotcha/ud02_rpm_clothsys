using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AvatarSysUtil;
using Utils = AvatarSysUtil.Utils;

public class ModelResExtractorTrigger : MonoBehaviour
{
    private string[] _ids;

    private string[] _components = { "Wolf3D_Outfit_Top_WaiTao" };
    // {
    //     "Wolf3D_Head", "Wolf3D_Body", "Wolf3D_Outfit_Top", "Wolf3D_Outfit_Bottom", "Wolf3D_Outfit_Footwear",
    //     "Wolf3D_Glasses", "Wolf3D_Hair", "Wolf3D_Headwear"
    // };

    // Start is called before the first frame update
    void Start()
    {
        // for (var i = 0; i < 20; i++)
        // {
        //     _ids[i] = Utils.ID2String(i + 1);
        // }
        _ids = new[] { "wk" };

        foreach(var id in _ids){
            var extractor = new ModelResExtractor(id,string.Format("models/{0}", id));
            foreach (var component in _components)
            {
                extractor.Extract(component);
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
