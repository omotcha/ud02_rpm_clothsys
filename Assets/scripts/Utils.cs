using System.Collections;
using UnityEngine;

namespace AvatarSysUtil
{
	/// <summary>
	/// Function-wise utils
	/// </summary>
	public class Utils
	{
		/// <summary>
		/// convert an integer (ranging from 1-20) to a string
		/// if it is less than 10, add a zero in front of it
		/// </summary>
		/// <param name="id">the id of resource files</param>
		/// <returns></returns>
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