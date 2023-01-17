using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarSysUtil
{
	public class OutfitCreator
	{
		private string _id;
		private GameObject _gameObject;

		public OutfitCreator(string id)
		{
			_id = id;
			_gameObject = null;
		}
	}
}
