using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AvatarSysUtil
{
	public class ModelResExtractor
	{

		private string _id;
		private GameObject _gameObject;

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="path"> model path</param>
		/// <param name="id"> model id</param>
		public ModelResExtractor(string id, string path)
		{
			_id = id;
			_gameObject = Resources.Load<GameObject>(path);
			if (_gameObject == null)
			{
				Debug.LogErrorFormat(
					"Error: GameObject not loaded successfully."
				);
			}
		}

		/// <summary>
		/// extract model resources in component: meshes, materials, textures
		/// </summary>
		/// <param name="component">component name</param>
		public void Extract(string component)
		{
			if (!_gameObject.activeSelf) return;
			Transform target = _gameObject.transform.Find(component);
			if (target != null)
			{
				// omotcha: the component should be Wolf3D_XXXX and i want only XXXX
				component = component.Split("_")[1];
				CollectComponent(target.GetComponent<SkinnedMeshRenderer>(), component);
			}
			else
			{
				Debug.LogWarningFormat(
					"Warning: Component not found."
				);
			}
			AssetDatabase.Refresh();
		}

		/// <summary>
		/// collect resources like meshes, store them 
		/// </summary>
		/// <param name="smr"></param>
		/// <param name="tag"></param>
		private void CollectComponent(SkinnedMeshRenderer smr, string tag)
		{
			
			if (!AssetDatabase.IsValidFolder(string.Format("Assets/res/{0}", _id)))
			{
				AssetDatabase.CreateFolder("Assets/res", _id);
			}
			AssetDatabase.CreateAsset(Object.Instantiate(smr.sharedMesh), string.Format("Assets/res/{0}/mesh_{1}.asset", _id, tag));
		}
	}
}
