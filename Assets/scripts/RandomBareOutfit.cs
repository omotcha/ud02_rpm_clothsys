using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Utils = AvatarSysUtil.Utils;

public class RandomBareOutfit : MonoBehaviour
{
    
	[SerializeField] private Button btnRandomOutfit;

	[SerializeField] private SkinnedMeshRenderer body;
    
	[SerializeField] private SkinnedMeshRenderer top;

	[SerializeField] private SkinnedMeshRenderer bottom;

	// Start is called before the first frame update
	void Start()
	{
		btnRandomOutfit.onClick.AddListener(() => Execute());
	}

	private void Execute()
	{
		var randomID = "br" + Utils.ID2String(Random.Range(1, 3));
		btnRandomOutfit.GetComponentInChildren<Text>().text = "outfit: " + randomID;

		var meshPath = String.Format("res/{0}/mesh_Top", randomID);
		top.sharedMesh = Resources.Load<Mesh>(meshPath);
		var materialPath = String.Format("res/{0}/mat_Top", randomID);
		top.sharedMaterial = Resources.Load<Material>(materialPath);

		meshPath = String.Format("res/{0}/mesh_Bottom", randomID);
		bottom.sharedMesh = Resources.Load<Mesh>(meshPath);
		materialPath = String.Format("res/{0}/mat_Bottom", randomID);
		bottom.sharedMaterial = Resources.Load<Material>(materialPath);
		
		// GameObject newObj = Resources.Load<GameObject>(String.Format("models/{0}", randomID));
		// top.bones = Utils.GetNewBones(top, newObj.GetComponentInChildren<SkinnedMeshRenderer>());
		// bottom.bones = Utils.GetNewBones(bottom, newObj.GetComponentInChildren<SkinnedMeshRenderer>());
		
	}

	private void Update()
	{
		Mesh mesh1 = new Mesh();
		top.BakeMesh(mesh1);

		Mesh mesh2 = new Mesh();
		body.BakeMesh(mesh2);
	}
}