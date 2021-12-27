using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cameo;
using Sirenix.OdinInspector;
using System;

public class UnitTester : MonoBehaviour
{
    [SerializeField]
    private BehaviourDefine.BehaviourType eventType;

    void Start()
    {
        initTestData();
    }

    private void initTestData()
    {
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.answer_content, "[回答內容]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.custom_character_name, "[選擇角色名字]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.custom_user_name, "[使用者暱稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.level_name, "[主題名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.mission_name, "[任務名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.nmns_member_id, "[會員帳號]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.quest_name, "[Quest名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.selected_ar_name, "[AR體驗名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.selected_clue_name, "[線索名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.selected_hint_name, "[提示名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.selected_illustration_hall, "[廳館名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.selected_illustration_name, "[圖鑑物件名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.selected_mr_anchor, "[Anchor名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.selected_mr_name, "[MR名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.select_tutorial_image_id, "[圖片ID]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.team_name, "[隊伍名稱]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.team_score, "[分數]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.user_account_id, "[訪客帳號]");
        BehaviourDataCenter.SetData(BehaviourDataCenter.DataType.select_map_image_id, "[地圖圖片ID]");
    }

    [Button("Send Data")]
    private void sendData()
    {
        BehaviourLoggerManager.Instance.SendData(eventType);
    }

    [Button("Send All Data")]
    private void sendAllData()
    {
        Type enumType = typeof(BehaviourDefine.BehaviourType);

        foreach (string typeName in Enum.GetNames(enumType))
        {
            try
            {
                BehaviourLoggerManager.Instance.SendData((BehaviourDefine.BehaviourType)Enum.Parse(enumType, typeName));
                Debug.LogFormat("Test {0} ok", typeName);
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("Test {0} error!", typeName);
            }
        }
    }
}
