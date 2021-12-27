using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cameo
{
	public static class BehaviourDataCenter
	{
		public enum DataType
		{
            user_account_id,
            nmns_member_id,
			level_name,
			mission_name,
			quest_name,
			answer_content,
			custom_user_name,
			custom_character_name,
			selected_illustration_name,
			selected_illustration_hall,
			selected_ar_name,
			selected_clue_name,
			selected_hint_name,
			team_name,
			team_score,
            select_map_image_id,
			select_tutorial_image_id,
			selected_mr_name,
			selected_mr_anchor,
        }

		private static Dictionary<DataType, string> runtimeDataMapping = new Dictionary<DataType, string>();

        public static void SetData(DataType dataType, string data)
		{
            if(!runtimeDataMapping.ContainsKey(dataType))
			{
				runtimeDataMapping.Add(dataType, data);
			}
            else
			{
				runtimeDataMapping[dataType] = data;
			}
		}

        public static string GetData(DataType dataType)
		{
			if (!runtimeDataMapping.ContainsKey(dataType))
			{
				Debug.LogErrorFormat("Behaviour log data: {0} is not set", dataType.ToString());
				return null;
			}
			else
			{
				return runtimeDataMapping[dataType];
			}
		}
	}
}

