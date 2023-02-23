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
		double FirebaseProxyVersionNumber { get; }

		// extern const unsigned char[] FirebaseProxyVersionString;
		[Field ("FirebaseProxyVersionString", "__Internal")]
		byte[] FirebaseProxyVersionString { get; }
	}

	// @interface AnalyticsManagerSlim : NSObject
	[BaseType (typeof(NSObject))]
	interface AnalyticsManagerSlim
	{
		// @property (readonly, nonatomic, strong, class) AnalyticsManagerSlim * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		AnalyticsManagerSlim Shared { get; }
	}

	// @interface DynamicLinkSlim : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface DynamicLinkSlim
	{
		// @property (readonly, copy, nonatomic) NSURL * _Nullable url;
		[NullAllowed, Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		// @property (readonly, nonatomic) enum DynamicLinkMatchTyperEnum matchType;
		[Export ("matchType")]
		DynamicLinkMatchTyperEnum MatchType { get; }
	}

	// @interface DynamicLinksManagerSlim : NSObject
	[BaseType (typeof(NSObject))]
	interface DynamicLinksManagerSlim
	{
		// @property (readonly, nonatomic, strong, class) DynamicLinksManagerSlim * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		DynamicLinksManagerSlim Shared { get; }

		// -(BOOL)shouldHandleDynamicLinkFromCustomSchemeUrlFromCustomSchemeURL:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
		[Export ("shouldHandleDynamicLinkFromCustomSchemeUrlFromCustomSchemeURL:")]
		bool ShouldHandleDynamicLinkFromCustomSchemeUrlFromCustomSchemeURL (NSUrl url);

		// -(DynamicLinkSlim * _Nullable)fromCustomSchemeUrlFromCustomSchemeURL:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
		[Export ("fromCustomSchemeUrlFromCustomSchemeURL:")]
		[return: NullAllowed]
		DynamicLinkSlim FromCustomSchemeUrlFromCustomSchemeURL (NSUrl url);

		// -(void)performDiagnosticsWithCompletion:(void (^ _Nonnull)(NSString * _Nullable, BOOL))completion;
		[Export ("performDiagnosticsWithCompletion:")]
		void PerformDiagnosticsWithCompletion (Action<NSString, bool> completion);
	}
}
