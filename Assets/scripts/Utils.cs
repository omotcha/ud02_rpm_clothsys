using UnityEngine;

namespace AvatarSysUtil
{
	public class Utils
	{
		public static string ID2String(int id)
		{
			if (id < 0)
			{
				Debug.LogErrorFormat("Error: ID should be integer that greater than 0.");
				return null;
			}
			if (id < 10)
			{
				return "0" + id;
			}
			else
			{
				return id.ToString();
			}
		}
	}
}