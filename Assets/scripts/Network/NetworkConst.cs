using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scripts.Network
{
    public class NetworkConst
    {
        public const string HOST = "http://54.150.176.132";

		//cms
        public const string URL_SIGN_UP = HOST + "/api/v2/cms/signUp"; 
        public const string URL_SIGN_IN = HOST + "/api/v2/cms/signIn"; 
        public const string URL_CONFIRM_OTP = HOST + "/api/v2/cms/confirmEmailOtp"; 
        public const string URL_SEND_OTP = HOST + "/api/v2/cms/sendEmailOrPhoneOTP"; 
        public const string URL_SEND_CHANGE_PWD = HOST + "/api/v2/cms/confirmChangePasswordOtp"; 

		//admins
        public const string URL_GET_ALL_ACCS = HOST + "/api/v2/account"; 
        public const string URL_GET_PLAYER_INFO = HOST + "/api/v2/account/queryMe/info"; 

		//points
        public const string URL_PUT_UPDATE_POINT = HOST + "/api/v2/point/update"; 
        public const string URL_PUT_FINISH_LEVEL = HOST + "/api/v2/account/finishLevel"; 
        public const string URL_POST_CONVERT_POINT = HOST + "/api/v2/game/convert"; 
        public const string URL_POST_BUY_POINT = HOST + "/api/v2/game/buy-points"; 
        
        public const string URL_POST_USE_LIFE = HOST + "/api/v2/game/useLife"; 
        public const string URL_POST_CLAIM_DAILY = HOST + "/api/v2/account/claimPointsDailyWeek"; 
        public const string URL_POST_SPIN = HOST + "/api/v2/account/luckyWheel"; 
        
        //buy
        public const string URL_POST_BUY_LIFE = HOST + "/api/v2/game/buy-life";
        public const string URL_POST_BUY_SPIN = HOST + "/api/v2/game/buy-luckyWheel";
        public const string URL_POST_BUY_BOOSTER = HOST + "/api/v2/game/buy-skill";

        //withdraw
        public const string URL_POST_ADD_NEW_WD_ADDRESS = HOST + "/api/v2/account/add/withdrawAddress";
        public const string URL_POST_WITHDRAW = HOST + "/api/v2/account/withdraw/";
        
        //deposit

        public const string URL_GET_QR = HOST + "/api/v2/account/qrCode/scan";

		//toolkit
		public const string URL_GET_ALL_TOOLKITS = HOST + "/api/v2/account/all/toolkits"; 
		
		//leader board
		public const string URL_GET_RANKING_LIST = HOST + "/api/v2/game//leaderboard/3";

    }  
}

