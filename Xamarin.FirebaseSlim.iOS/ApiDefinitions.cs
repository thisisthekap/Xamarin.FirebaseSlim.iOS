using System;
using FirebaseProxy;
using Foundation;
using ObjCRuntime;

namespace Xamarin.FirebaseSlim.iOS
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double FirebaseProxyVersionNumber;
		[Field ("FirebaseProxyVersionNumber", "__Internal")]
		double VersionNumber { get; }

		// extern const unsigned char[] FirebaseProxyVersionString;
		[Field ("FirebaseProxyVersionString", "__Internal")]
		NSString VersionString { get; }
	}

	// @interface AnalyticsManagerSlim : NSObject
	[BaseType (typeof(NSObject))]
	interface AnalyticsManagerSlim
	{
		// @property (readonly, nonatomic, strong, class) AnalyticsManagerSlim * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		AnalyticsManagerSlim Shared { get; }

		// -(void)logEvent:(NSString * _Nonnull)name parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters;
		[Export ("logEvent:parameters:")]
		void LogEvent (string name, NSDictionary<NSString, NSObject> parameters);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull appInstanceId;
		[Export ("appInstanceId")]
		string AppInstanceId { get; }

		// -(void)setUserId:(NSString * _Nonnull)userId;
		[Export ("setUserId:")]
		void SetUserId (string userId);

		// -(void)setUserProperty:(NSString * _Nonnull)value forName:(NSString * _Nonnull)name;
		[Export ("setUserProperty:forName:")]
		void SetUserProperty (string value, string name);
	}

	// @interface DynamicLinkSlim : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface DynamicLinkSlim
	{
		// @property (readonly, copy, nonatomic) NSURL * _Nullable url;
		[NullAllowed, Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		// @property (readonly, nonatomic) enum DynamicLinkMatchTypeEnum matchType;
		[Export ("matchType")]
		DynamicLinkMatchTypeEnum MatchType { get; }
	}

	// @interface DynamicLinksManagerSlim : NSObject
	[BaseType (typeof(NSObject))]
	interface DynamicLinksManagerSlim
	{
		// @property (readonly, nonatomic, strong, class) DynamicLinksManagerSlim * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		DynamicLinksManagerSlim Shared { get; }

		// -(BOOL)shouldHandleDynamicLinkFromCustomSchemeURL:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
		[Export ("shouldHandleDynamicLinkFromCustomSchemeURL:")]
		bool ShouldHandleDynamicLinkFromCustomSchemeURL (NSUrl url);

		// -(DynamicLinkSlim * _Nullable)fromCustomSchemeUrlFromCustomSchemeURL:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
		[Export ("fromCustomSchemeUrlFromCustomSchemeURL:")]
		[return: NullAllowed]
		DynamicLinkSlim FromCustomSchemeUrlFromCustomSchemeURL (NSUrl url);

		// -(void)performDiagnosticsWithCompletion:(void (^ _Nonnull)(NSString * _Nullable, BOOL))completion;
		[Export ("performDiagnosticsWithCompletion:")]
		void PerformDiagnosticsWithCompletion (Action<NSString, bool> completion);

		// -(void)handleUniversalLink:(NSUserActivity * _Nonnull)userActivity withCompletion:(void (^ _Nonnull)(DynamicLinkSlim * _Nullable, NSError * _Nullable))completion;
		[Export ("handleUniversalLink:withCompletion:")]
		void HandleUniversalLink (NSUserActivity userActivity, Action<DynamicLinkSlim, NSError> completion);

		// -(void)createShortenedDynamicLinkWithDataLink:(NSURL * _Nonnull)dataLink appIdentifier:(NSString * _Nonnull)appIdentifier domain:(NSString * _Nonnull)domain appStoreId:(NSString * _Nullable)appStoreId title:(NSString * _Nullable)title text:(NSString * _Nullable)text imageUrl:(NSURL * _Nullable)imageUrl completion:(void (^ _Nonnull)(NSURL * _Nullable))completion;
		[Export ("createShortenedDynamicLinkWithDataLink:appIdentifier:domain:appStoreId:title:text:imageUrl:completion:")]
		void CreateShortenedDynamicLinkWithDataLink (NSUrl dataLink, string appIdentifier, string domain, [NullAllowed] string appStoreId, [NullAllowed] string title, [NullAllowed] string text, [NullAllowed] NSUrl imageUrl, Action<NSURL> completion);
	}
}
