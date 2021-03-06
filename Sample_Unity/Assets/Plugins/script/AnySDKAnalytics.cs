using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace anysdk {
	public enum AccountType
	{
		ANONYMOUS,/**< enum value is anonymous typek. */
		REGISTED,/**< enum value is registed type. */
		SINA_WEIBO,/**< enum value is sineweibo type. */
		TENCENT_WEIBO,/**< enum value is tecentweibo type */
		QQ,/**< enum value is qq type */
		QQ_WEIBO,/**< enum value is qqweibo type. */
		ND91,/**< enum value is nd91 type. */

	} ;
	public enum AccountOperate
	{
		LOGIN,/**< enum value is the login operate. */
		LOGOUT,/**< enum value is the logout operate. */
		REGISTER,/**< enum value is the register operate. */

	} ;
	public enum AccountGender
	{
		MALE,/**< enum value is male. */
		FEMALE,/**< enum value is female. */
		UNKNOWN,/**< enum value is unknow. */

		
	} ;
	public enum TaskType
	{
		GUIDE_LINE,/**< enum value is the guideline type.. */
		MAIN_LINE,/**< enum value is the mainline type.. */
		BRANCH_LINE,/**<enum value is the branchline type.. */
		DAILY,/**< enum value is the daily type.. */
		ACTIVITY,/**< enum value is the activity type.  */
		OTHER,/**< enum value is other type. */

	} ;
	public class AnySDKAnalytics
	{
		private static AnySDKAnalytics _instance;
		
		public static AnySDKAnalytics getInstance() {
			if( null == _instance ) {
				_instance = new AnySDKAnalytics();
			}
			return _instance;
		}

		/**
     	@brief Start a new session.
    	 */

		public  void startSession()
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKAnalytics_nativeStartSession ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief Stop a session.
    	 @warning This interface only worked on android
    	 */

		public  void stopSession()
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKAnalytics_nativeStopSession ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief Set the timeout for expiring a session.
    	 @param millis In milliseconds as the unit of time.
    	 @note It must be invoked before calling startSession.
    	 */

		public  void setSessionContinueMillis(long millis)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKAnalytics_nativeSetSessionContinueMillis (millis);
#else
			Debug.Log("This platform does not support!");
#endif

		}

		/**
     	@brief log an error
     	@param errorId The identity of error
     	@param message Extern message for the error
     	*/

		public  void  logError(string errorId, string message)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKAnalytics_nativeLogError (errorId, message);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief log an event.
     	 @param eventId The identity of event
    	 @param paramMap Extern parameters of the event, use NULL if not needed.
     	*/

		public  void  logEvent (string errorId,Dictionary<string,string> paramMap = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			string value;
			if (paramMap == null) value = null; 
			else value = AnySDKUtil.dictionaryToString (paramMap);
			AnySDKAnalytics_nativeLogEvent (errorId,value);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief Track an event begin.
     	@param eventId The identity of event
     	*/

		public  void  logTimedEventBegin (string errorId)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKAnalytics_nativeLogTimedEventBegin (errorId);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief Track an event end.
     	@param eventId The identity of event
    	 */

		public  void  logTimedEventEnd (string eventId)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKAnalytics_nativeLogTimedEventEnd (eventId);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief Whether to catch uncaught exceptions to server.
    	 @warning This interface only worked on android.
     	*/

		public  void  setCaptureUncaughtException (bool enabled)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKAnalytics_nativeSetCaptureUncaughtException (enabled);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief Check function the plugin support or not
     	*/

		public  bool  isFunctionSupported (string functionName)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			return AnySDKAnalytics_nativeIsFunctionSupported (functionName);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
		 * set debugmode for plugin
		 * 
		 */

		public  void setDebugMode(bool bDebug)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKAnalytics_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		
		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/

		public  string getPluginVersion()
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKAnalytics_nativeGetPluginVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
		 * Get SDK version
		 * 
		 * @return string
	 	*/

		public  string getSDKVersion()
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKAnalytics_nativeGetSDKVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, AnySDKParam param)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			AnySDKAnalytics_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			if (param == null) 
			{
				AnySDKAnalytics_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				AnySDKAnalytics_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return int
    	 */
		public  int callIntFuncWithParam(string functionName, AnySDKParam param)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKAnalytics_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return int
    	 */
		public  int  callIntFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			if (param == null)
			{
				return AnySDKAnalytics_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKAnalytics_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, AnySDKParam param)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKAnalytics_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}
		

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			if (param == null)
			{
				return AnySDKAnalytics_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKAnalytics_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return string
    	 */
		public  bool callBoolFuncWithParam(string functionName, AnySDKParam param)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKAnalytics_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return string
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			if (param == null)
			{
				return AnySDKAnalytics_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKAnalytics_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, AnySDKParam param)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKAnalytics_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			if (param == null)
			{
				AnySDKAnalytics_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				AnySDKAnalytics_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeStartSession();
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeStopSession();
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeSetSessionContinueMillis(long milli);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeLogError(string errorId, string message);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeLogEvent(string eventId, string message);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeLogTimedEventBegin(string eventId);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeLogTimedEventEnd(string eventId);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeSetCaptureUncaughtException(bool enabled);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKAnalytics_nativeIsFunctionSupported(string functionName);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeSetDebugMode(bool bDebug);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeGetPluginVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeGetSDKVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeCallFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern int AnySDKAnalytics_nativeCallIntFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern float AnySDKAnalytics_nativeCallFloatFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKAnalytics_nativeCallBoolFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAnalytics_nativeCallStringFuncWithParam(string functionName, AnySDKParam[] param,int count,StringBuilder value);
	}
	
}


