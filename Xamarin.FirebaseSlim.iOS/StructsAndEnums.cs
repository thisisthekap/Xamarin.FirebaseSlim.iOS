using ObjCRuntime;

namespace Xamarin.FirebaseSlim.iOS
{
    [Native]
	public enum DynamicLinkMatchTyperEnum : long
	{
		None = 0,
		Weak = 1,
		DefaultMatch = 2,
		Unique = 3
	}
}