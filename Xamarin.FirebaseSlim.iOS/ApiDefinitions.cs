using System;
using Foundation;
using ObjCRuntime;

namespace Xamarin.FirebaseSlim.iOS
{
	[Static]
	partial interface FirebaseSlimConstants
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

	// @interface DynamicLinkCreationParameters : NSObject
	[BaseType (typeof(NSObject))]
	interface DynamicLinkCreationParameters
	{
		// @property (copy, nonatomic) NSString * _Nonnull dataLink;
		[Export ("dataLink")]
		string DataLink { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull domain;
		[Export ("domain")]
		string Domain { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable appStoreId;
		[NullAllowed, Export ("appStoreId")]
		string AppStoreId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull appIdentifier;
		[Export ("appIdentifier")]
		string AppIdentifier { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull title;
		[Export ("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull imageUrl;
		[Export ("imageUrl")]
		string ImageUrl { get; set; }
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
		DynamicLinkSlim FromCustomSchemeUrl (NSUrl url);

		// -(void)performDiagnosticsWithCompletion:(void (^ _Nonnull)(NSString * _Nullable, BOOL))completion;
		[Export ("performDiagnosticsWithCompletion:")]
		void PerformDiagnosticsWithCompletion (Action<NSString, bool> completion);

		// -(BOOL)handleUniversalLink:(NSUserActivity * _Nonnull)userActivity withCompletion:(void (^ _Nonnull)(DynamicLinkSlim * _Nullable, NSError * _Nullable))completion __attribute__((warn_unused_result("")));
		[Export ("handleUniversalLink:withCompletion:")]
		bool HandleUniversalLink (NSUserActivity userActivity, Action<DynamicLinkSlim, NSError> completion);

		// -(void)createShortenedUrlWithCompletionWithDynamicLinkComponents:(DynamicLinkCreationParameters * _Nonnull)dynamicLinkComponents completion:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))completion;
		[Export ("createShortenedUrlWithCompletionWithDynamicLinkComponents:completion:")]
		void CreateShortenedUrl (DynamicLinkCreationParameters dynamicLinkComponents, Action<NSString, NSError> completion);
	}

	// @interface FirebaseCoreSlim : NSObject
	[BaseType (typeof(NSObject))]
	interface FirebaseCoreSlim
	{
		// @property (readonly, nonatomic, strong, class) FirebaseCoreSlim * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		FirebaseCoreSlim Shared { get; }

		// -(void)configure;
		[Export ("configure")]
		void Configure ();
	}
}
