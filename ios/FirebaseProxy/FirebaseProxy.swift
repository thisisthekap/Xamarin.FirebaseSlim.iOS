//

import Foundation
import UIKit
import FirebaseAnalytics
import FirebaseDynamicLinks
import FirebaseCore

@objc public enum DynamicLinkMatchTypeEnum : Int {
    case none = 0
    case weak = 1
    case defaultMatch = 2
    case unique = 3
}

@objc(DynamicLinkSlim)
public class DynamicLinkSlim: NSObject {
    @objc public let url: URL?
    @objc public let matchType: DynamicLinkMatchTypeEnum
    
    
    init(url: URL?, matchType: DynamicLinkMatchTypeEnum) {
        self.url = url
        self.matchType = matchType
    }
}


@objc(FirebaseCoreSlim)
public class FirebaseCoreSlim: NSObject {
    @objc
    public static let shared  = FirebaseCoreSlim()
    
    @objc
    public func Configure() {
        FirebaseApp.configure()
    }
}

@objc(AnalyticsManagerSlim)
public class AnalyticsManagerSlim : NSObject {
    
    @objc
    public static let shared = AnalyticsManagerSlim()
    
    @objc
    public func logEvent(_ name: String, parameters: [String: Any]) {
        Analytics.logEvent(name, parameters: parameters)
    }
    
    @objc
    public var appInstanceId: String {
        return Analytics.appInstanceID() ?? ""
    }
    
    @objc
    public func setUserId(_ userId: String) {
        Analytics.setUserID(userId)
    }
    
    @objc
    public func setUserProperty(_ value: String, forName name: String) {
        Analytics.setUserProperty(value, forName: name)
    }
}

@objc(DynamicLinkComponentsSim)
public class DynamicLinkComponentsSlim: NSObject {
    @objc public var dataLink: String = ""
        @objc public var domain: String = ""
        @objc public var appStoreId: String?
        @objc public var appIdentifier: String = ""
        @objc public var title: String = ""
        @objc public var text: String = ""
        @objc public var imageUrl: String = ""
}

@objc(DynamicLinksManagerSlim)
public class DynamicLinksManagerSlim : NSObject {
    
    @objc
    public static let shared = DynamicLinksManagerSlim()
    
    @objc
    public func shouldHandleDynamicLink(fromCustomSchemeURL url: URL) -> Bool {
        let dynamicLinks = DynamicLinks.dynamicLinks()
        return dynamicLinks.shouldHandleDynamicLink(fromCustomSchemeURL: url)
    }
    
    @objc
    public func fromCustomSchemeUrl(fromCustomSchemeURL url: URL) -> DynamicLinkSlim? {
        let dynamicLinks = DynamicLinks.dynamicLinks()
        if let dynamicLink = dynamicLinks.dynamicLink(fromCustomSchemeURL: url) {
            var matchType = DynamicLinkMatchTypeEnum.none
            
            switch dynamicLink.matchType {
            case .unique:
                matchType = DynamicLinkMatchTypeEnum.unique
            case .default:
                matchType = DynamicLinkMatchTypeEnum.defaultMatch
            case .weak:
                matchType = DynamicLinkMatchTypeEnum.weak
            case .none:
                matchType = DynamicLinkMatchTypeEnum.none
            @unknown default:
                matchType = DynamicLinkMatchTypeEnum.none
            }
            return DynamicLinkSlim(url: dynamicLink.url,
                                   matchType: matchType)
        } else {
            return nil
        }
    }
    
    @objc
    public func performDiagnostics(withCompletion completion: @escaping (String?, Bool) -> Void) {
        DynamicLinks.performDiagnostics { (diagnostic, error) in
            completion(diagnostic, error)
        }
    }
    
    @objc
    public func handleUniversalLink(_ userActivity: NSUserActivity, withCompletion completion: @escaping (DynamicLinkSlim?, NSError?) -> Void) {
        DynamicLinks.dynamicLinks().handleUniversalLink(userActivity.webpageURL!) { (dynamicLink, error) in
            if let dynamicLink = dynamicLink {
                
                var matchType = DynamicLinkMatchTypeEnum.none
                
                switch dynamicLink.matchType {
                case .unique:
                    matchType = DynamicLinkMatchTypeEnum.unique
                case .default:
                    matchType = DynamicLinkMatchTypeEnum.defaultMatch
                case .weak:
                    matchType = DynamicLinkMatchTypeEnum.weak
                case .none:
                    matchType = DynamicLinkMatchTypeEnum.none
                @unknown default:
                    matchType = DynamicLinkMatchTypeEnum.none
                }
                
                let dynamicLinkSlim = DynamicLinkSlim(url: dynamicLink.url,
                                                      matchType: matchType)
                completion(dynamicLinkSlim, nil)
            } else {
                let nsError = error as NSError? ?? NSError(domain: "Unknown error", code: 0, userInfo: nil)
                completion(nil, nsError)
            }
        }
    }
    
    @objc
    public func GetShortenUrlWithCompletion(dynamicLinkComponents: DynamicLinkComponentsSlim, completion: @escaping (String?) -> Void) {
     
        let link = URL(string: dynamicLinkComponents.dataLink)
        let domain = dynamicLinkComponents.domain
        
        var linkBuilder = DynamicLinkComponents(link: link!, domainURIPrefix: domain)
                
                linkBuilder?.iOSParameters = DynamicLinkIOSParameters(bundleID: dynamicLinkComponents.appIdentifier)
                linkBuilder?.androidParameters = DynamicLinkAndroidParameters(packageName: dynamicLinkComponents.appIdentifier)
                
                if let appStoreId = dynamicLinkComponents.appStoreId {
                    linkBuilder?.iOSParameters?.appStoreID = appStoreId
                }
                
                linkBuilder?.socialMetaTagParameters = DynamicLinkSocialMetaTagParameters()
                linkBuilder?.socialMetaTagParameters?.title = dynamicLinkComponents.title
                linkBuilder?.socialMetaTagParameters?.descriptionText = dynamicLinkComponents.text
                linkBuilder?.socialMetaTagParameters?.imageURL = URL(string: dynamicLinkComponents.imageUrl)
                
                linkBuilder?.shorten { (url, _, error) in
                    if let error = error {
                        print("Error getting shortened URL: \(error.localizedDescription)")
                        completion(nil)
                    } else if let urlValid = url {
                        completion(urlValid.absoluteString)
                    } else {
                        completion(nil)
                    }
                }
    }
}
