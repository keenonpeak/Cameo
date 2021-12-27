using System.Collections.Generic;

namespace Cameo
{
    public class BehaviourInfo
    {
        public string Name;
        public string Desc;
        public string Reference;
    }
    public class BehaviourDefine
    {
        public enum BehaviourType
        {
            user_login,
            level_start,
            level_completed,
            back_to_main_menu_from_level,
            mission_start,
            mission_completed,
            switch_map_layer,
            switch_level_page,
            resize_image,
            team_member_added,
            character_selected,
            illustration_from_main_menu,
            illustration_click_item,
            back_to_main_menu_from_illustration,
            switch_illustration_hall,
            start_vr,
            vr_intro_not_show_again,
            ar_intro_not_show_again,
            start_ar_dinosour,
            play_ar_dinosour,
            take_photo_in_ar,
            take_photo_level_completed,
            open_story,
            skip_story,
            quest_start,
            quest_correct,
            quest_error,
            quest_completed,
            open_clue,
            close_clue,
            open_hint_name,
            close_hint_name,
            open_leaderboard,
            painting_open,
            painting_clear,
            painting_save,
            note_open_in_mission,
            note_open_in_map,
            note_open_when_completed,
            note_close,
            photo_save,
            photo_share,
            tutorial_mainmenu,
            tutorial_map,
            tutorial_mission,
            call_help,
            mr_start,
            mr_marker_success,
            mr_marker_failed,
            mr_interact_success,
            mr_interact_failed,
            mr_end,
            none
        }

        private static Dictionary<BehaviourType, BehaviourInfo> infoMapping = new Dictionary<BehaviourType, BehaviourInfo>()
        {
            {
                BehaviourType.user_login,
                new BehaviourInfo()
                {
                    Name = "使用者登入",
                    Desc = "使用者使用會員/訪客帳號登入",
                    Reference = "使用者登入::{0}/{1}::{2}" //會員帳號, 訪客帳號, 時間
                }
            },
            {
                BehaviourType.level_start,
                new BehaviourInfo()
                {
                    Name = "開始主題",
                    Desc = "使用者開始主題(Level)",
                    Reference = "主題列表::{0}::開始::{1}" //主題名稱, 時間
                }
            },
            {
                BehaviourType.level_completed,
                new BehaviourInfo()
                {
                    Name = "完成主題",
                    Desc = "使用者完成主題(Level)",
                    Reference = "主題列表::{0}::完成::{1}" //主題名稱, 時間
                }
            },
            {
                BehaviourType.back_to_main_menu_from_level,
                new BehaviourInfo()
                {
                    Name = "從主題選擇頁面返回單人版主頁面",
                    Desc = "使用者點擊返回主選單",
                    Reference = "首頁::返回主選單::{0}" //時間
                }
            },
            {
                BehaviourType.mission_start,
                new BehaviourInfo()
                {               
                    Name = "開始任務",
                    Desc = "使用者開始任務(Mission)",
                    Reference = "任務列表::{0}::{1}::開始::{2}" //主題名稱, 任務名稱, 時間
                }
            },
            {
                BehaviourType.mission_completed,
                new BehaviourInfo()
                {               
                    Name = "完成任務",
                    Desc = "使用者完成任務(Mission)",
                    Reference = "任務列表::{0}::{1}::完成::{2}" //主題名稱, 任務名稱, 時間
                }
            },
            {
                BehaviourType.switch_map_layer,
                new BehaviourInfo()
                {
                    Name = "左右切換地圖",
                    Desc = "使用者點擊左、右切換地圖。",
                    Reference = "任務列表::{0}::切換地圖_左/右::{1}" //主題名稱, 時間
                }
            },
            {
                BehaviourType.switch_level_page,
                new BehaviourInfo()
                {
                    Name = "左右切換主題",
                    Desc = "往左或往右選擇該遊戲主題",
                    Reference = "主題列表::{0}::切換至主題::{1}" //主題名稱, 時間
                }
            },
            {
                BehaviourType.resize_image,
                new BehaviourInfo()
                {
                    Name = "縮放地圖圖片",
                    Desc = "使用者點選地圖圖片放大縮小",
                    Reference = "任務列表::{0}::{1}::縮放地圖圖片::{2}" //主題名稱, 地圖圖片ID, 時間
                }
            },
            {
                BehaviourType.team_member_added,
                new BehaviourInfo()
                {
                    Name = "隊員加入",
                    Desc = "組隊時，誰加入組隊",
                    Reference = "隊伍頁面::{0}::{1}::{2}" //使用者暱稱, 隊伍名稱, 時間
                }
            },
            {
                BehaviourType.character_selected,
                new BehaviourInfo()
                {
                    Name = "選擇角色",
                    Desc = "使用者選了哪個角色",
                    Reference = "隊伍頁面::{0}::{1}::{2}::{3}" //使用者暱稱, 隊伍名稱, 選擇角色名字, 時間
                }
            },
            {
                BehaviourType.open_story,
                new BehaviourInfo()
                {
                    Name = "開始對話演出",
                    Desc = "任務前導對話演出",
                    Reference = "對話演出::{0}::{1}::任務前導::{2}" //主題名稱, 任務名稱, 時間
                }
            },
            {
                BehaviourType.skip_story,
                new BehaviourInfo()
                {
                    Name = "略過對話演出",
                    Desc = "使用者按下略過",
                    Reference = "對話演出::{0}::{1}::略過::{2}" //主題名稱, 任務名稱, 時間
                }
            },
            {
                BehaviourType.illustration_from_main_menu,
                new BehaviourInfo()
                {
                    Name = "從主頁面打開圖鑑",
                    Desc = "使用者點選主介面之解謎互動圖鑑(點擊時機)",
                    Reference = "互動圖鑑::開啟::{0}" //時間
                }
            },
            {
                BehaviourType.illustration_click_item,
                new BehaviourInfo()
                {
                    Name = "點選圖鑑頁面物件",
                    Desc = "使用者點選收集物件(點擊時機)",
                    Reference = "互動圖鑑::{0}::{1}" //圖鑑物建名稱, 時間
                }
            },
            {
                BehaviourType.back_to_main_menu_from_illustration,
                new BehaviourInfo()
                {
                    Name = "從圖鑑頁面返回單人版主頁面",
                    Desc = "使用者點選返回按鈕返回選單",
                    Reference = "互動圖鑑::返回主選單::{0}" //時間
                }
            },
            {
                BehaviourType.switch_illustration_hall,
                new BehaviourInfo()
                {
                    Name = "切換圖鑑頁面館廳",
                    Desc = "使用者點選左右切換主題圖鑑選單",
                    Reference = "互動圖鑑::{0}::左右切換:{1}" //廳館名稱,時間
                }
            },
            {
                BehaviourType.start_vr,
                new BehaviourInfo()
                {
                    Name = "開啟VR",
                    Desc = "使用者點選vr體驗(點擊時機)",
                    Reference = "互動圖鑑::vr體驗::開啟::{0}" //時間
                }
            },
            {
                BehaviourType.vr_intro_not_show_again,
                new BehaviourInfo()
                {
                    Name = "勾選VR說明不再顯示",
                    Desc = "使用者勾選下次不再顯示",
                    Reference = "互動圖鑑::VR勾選下次不再顯示說明::{0}" //時間
                }
            },
            {
                BehaviourType.ar_intro_not_show_again,
                new BehaviourInfo()
                {
                    Name = "勾選AR說明不再顯示",
                    Desc = "使用者勾選下次不再顯示",
                    Reference = "互動圖鑑::AR勾選下次不再顯示說明::{0}" //時間
                }
            },
            {
                BehaviourType.start_ar_dinosour,
                new BehaviourInfo()
                {
                    Name = "開啟恐龍AR",
                    Desc = "使用者點擊ar迅掠龍或竊蛋龍按鈕(點擊時機)",
                    Reference = "互動圖鑑::{0}::{1}::開啟AR::{2}" //廳館名稱,AR體驗名稱,時間
                }
            },
            {
                BehaviourType.play_ar_dinosour,
                new BehaviourInfo()
                {
                    Name = "播放恐龍AR",
                    Desc = "使用者點選播放(點擊時機)",
                    Reference = "互動圖鑑::{0}::{1}::播放AR::{2}" //廳館名稱,AR體驗名稱,時間
                }
            },
            {
                BehaviourType.take_photo_in_ar,
                new BehaviourInfo()
                {
                    Name = "AR拍照",
                    Desc = "使用者點擊ar拍照(點擊時機)",
                    Reference = "互動圖鑑::{0}::{1}::AR拍照::{2}" //廳館名稱,AR體驗名稱,時間
                }
            },
            {
                BehaviourType.take_photo_level_completed,
                new BehaviourInfo()
                {
                    Name = "過關拍照",
                    Desc = "使用者點選拍照(點擊時間)",
                    Reference = "互動圖鑑::{0}::過關拍照::{1}" //廳館名稱,時間
                }
            },
            {
                BehaviourType.quest_start,
                new BehaviourInfo()
                {
                    Name = "開始回答",
                    Desc = "Quest開始",
                    Reference = "答題::{0}::{1}::開始::{2}" //主題名稱,Quest名稱,時間
                }
            },
            {
                BehaviourType.quest_correct,
                new BehaviourInfo()
                {
                    Name = "回答正確",
                    Desc = "使用者答對",
                    Reference = "答題::{0}::{1}::{2}::回答正確::{3}" //主題名稱,Quest名稱,回答內容,時間
                }
            },
            {
                BehaviourType.quest_error,
                new BehaviourInfo()
                {
                    Name = "回答錯誤",
                    Desc = "使用者答錯",
                    Reference = "答題::{0}::{1}::{2}::回答錯誤::{3}" //主題名稱,Quest名稱,回答內容,時間
                }
            },
            {
                BehaviourType.quest_completed,
                new BehaviourInfo()
                {
                    Name = "回答完成",
                    Desc = "Quest完成",
                    Reference = "答題::{0}::{1}::{2}::完成::{3}" //主題名稱,Quest名稱,回答內容,時間
                }
            },
            {
                BehaviourType.open_clue,
                new BehaviourInfo()
                {
                    Name = "開啟線索",
                    Desc = "線索，使用者開啟線索",
                    Reference = "線索::{0}::開啟::{1}" //線索名稱,時間
                }
            },
            {
                BehaviourType.close_clue,
                new BehaviourInfo()
                {
                    Name = "關閉線索",
                    Desc = "線索，使用者關閉線索",
                    Reference = "線索::{0}::關閉::{1}" //線索名稱,時間
                }
            },
            {
                BehaviourType.open_hint_name,
                new BehaviourInfo()
                {
                    Name = "開啟提示",
                    Desc = "提示，使用者開啟提示",
                    Reference = "提示::{0}::開啟::{1}" //提示名稱,時間
                }
            },
            {
                BehaviourType.close_hint_name,
                new BehaviourInfo()
                {
                    Name = "關閉提示",
                    Desc = "提示，使用者關閉提示",
                    Reference = "提示::{0}::關閉::{1}" //提示名稱,時間
                }
            },
            {
                BehaviourType.open_leaderboard,
                new BehaviourInfo()
                {
                    Name = "開啟排行榜",
                    Desc = "組隊的總計分。總時間",
                    Reference = "排行榜::{0}::{1}::開啟::{2}" //分數,隊伍名稱,時間
                }
            },
            {
                BehaviourType.painting_open,
                new BehaviourInfo()
                {
                    Name = "開啟手繪",
                    Desc = "使用者開啟手繪功能",
                    Reference = "手繪功能::{0}::{1}::開啟::{2}" //主題名稱,Quest名稱,時間
                }
            },
            {
                BehaviourType.painting_clear,
                new BehaviourInfo()
                {
                    Name = "清除手繪",
                    Desc = "使用者點擊清除重劃(點擊時機)",
                    Reference = "手繪功能::{0}::{1}::清除::{2}" //主題名稱,Quest名稱,時間
                }
            },
            {
                BehaviourType.painting_save,
                new BehaviourInfo()
                {
                    Name = "儲存手繪",
                    Desc = "使用者點擊儲存塗鴉(點擊時機)",
                    Reference = "手繪功能::{0}::{1}::儲存::{2}" //主題名稱,Quest名稱,時間
                }
            },
            {
                BehaviourType.note_open_in_mission,
                new BehaviourInfo()
                {
                    Name = "題目頁面內開啟筆記",
                    Desc = "從任務題目頁面內開啟筆記",
                    Reference = "筆記::{0}::{1}::在任務頁面開啟::{2}" //主題名稱,任務名稱,時間
                }
            },
            {
                BehaviourType.note_open_in_map,
                new BehaviourInfo()
                {
                    Name = "地圖頁面內開啟筆記",
                    Desc = "從地圖頁面內開啟筆記",
                    Reference = "筆記::{0}::{1}::在地圖頁面開啟::{2}" //主題名稱,任務名稱,時間
                }
            },
            {
                BehaviourType.note_open_when_completed,
                new BehaviourInfo()
                {
                    Name = "任務完成後開啟筆記",
                    Desc = "任務完成後自動開啟筆記",
                    Reference = "筆記::{0}::{1}::任務完成後開啟::{2}" //主題名稱,任務名稱,時間
                }
            },
            {
                BehaviourType.note_close,
                new BehaviourInfo()
                {
                    Name = "關閉筆記",
                    Desc = "關閉筆記",
                    Reference = "筆記::{0}::{1}::關閉筆記::{2}" //主題名稱,任務名稱,時間
                }
            },
            {
                BehaviourType.photo_save,
                new BehaviourInfo()
                {
                    Name = "儲存過關拍照",
                    Desc = "點選儲存",
                    Reference = "過關拍照::{0}::儲存" //拍照圖片ID
                }
            },
            {
                BehaviourType.photo_share,
                new BehaviourInfo()
                {
                    Name = "分享過關拍照",
                    Desc = "點選分享",
                    Reference = "過關拍照::{0}::分享" //拍照圖片ID
                }
            },
            {
                BehaviourType.tutorial_mainmenu,
                new BehaviourInfo()
                {
                    Name = "主頁面內開啟新手教學",
                    Desc = "主頁面內開啟新手教學",
                    Reference = "新手教學::{0}::於選擇館廳時開啟::{1}" //圖片ID,時間
                }
            },
            {
                BehaviourType.tutorial_map,
                new BehaviourInfo()
                {
                    Name = "地圖頁面內開啟新手教學",
                    Desc = "地圖頁面內開啟新手教學",
                    Reference = "新手教學::{0}::於地圖頁面開啟::{1}" //圖片ID,時間
                }
            },
            {
                BehaviourType.tutorial_mission,
                new BehaviourInfo()
                {
                    Name = "任務頁面內開啟新手教學",
                    Desc = "任務頁面內開啟新手教學",
                    Reference = "新手教學::{0}::於任務頁面開啟::{1}" //圖片ID,時間
                }
            },
            {
                BehaviourType.call_help,
                new BehaviourInfo()
                {
                    Name = "呼叫隊友",
                    Desc = "在任務內按下呼叫隊友",
                    Reference = "呼叫隊友::{0}::{1}::開啟" //主題名稱,Quest名稱
                }
            },
            {
                BehaviourType.mr_start,
                new BehaviourInfo()
                {
                    Name = "開啟MR道具",
                    Desc = "使用者開啟MR線索",
                    Reference = "MR道具::{0}::開啟MR::{1}" //MR名稱,時間
                }
            },
            {
                BehaviourType.mr_marker_success,
                new BehaviourInfo()
                {
                    Name = "MR掃描成功",
                    Desc = "辨識場景成功",
                    Reference = "MR道具::{0}::{1}::辨識成功::{2}" //MR名稱,Anchor名稱,時間
                }
            },
            {
                BehaviourType.mr_marker_failed,
                new BehaviourInfo()
                {
                    Name = "MR掃描失敗",
                    Desc = "辨識場景失敗",
                    Reference = "MR道具::{0}::{1}::辨識失敗::{2}" //MR名稱,Anchor名稱,時間
                }
            },
            {
                BehaviourType.mr_interact_success,
                new BehaviourInfo()
                {
                    Name = "MR互動成功",
                    Desc = "使用者操作MR互動成功",
                    Reference = "MR道具::{0}::{1}::互傳成功::{2}" //MR名稱,Anchor名稱,時間
                }
            },
            {
                BehaviourType.mr_interact_failed,
                new BehaviourInfo()
                {
                    Name = "MR互動失敗",
                    Desc = "使用者操作MR互動失敗",
                    Reference = "MR道具::{0}::{1}::互傳失敗::{2}" //MR名稱,Anchor名稱,時間
                }
            },
            {
                BehaviourType.mr_end,
                new BehaviourInfo()
                {
                    Name = "MR結束",
                    Desc = "使用者結束MR",
                    Reference = "MR道具::{0}::結束MR::{1}" //MR名稱,時間
                }
            },
        };

        public static string GetBehaviourName(BehaviourType behaviourType)
        {
            return infoMapping[behaviourType].Name;
        }

        public static string GetBehaviourDescription(BehaviourType behaviourType)
        {
            return infoMapping[behaviourType].Desc;
        }

        public static string GetBehaviourReferenceFormat(BehaviourType behaviourType)
        {
            return infoMapping[behaviourType].Reference;
        }
    }
}
