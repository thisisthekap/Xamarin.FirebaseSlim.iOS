#!/bin/bash

cd "${0%/*}"

./carthage.sh update --use-xcframeworks 

cd ios
cp -r ../Carthage/Build/*.xcframework .
cd ..

xcodebuild archive -sdk iphoneos -project ios/FirebaseProxy.xcodeproj -scheme FirebaseProxy -configuration Release -archivePath Output/Output-iphoneos SKIP_INSTALL=NO
xcodebuild archive -sdk iphonesimulator -project ios/FirebaseProxy.xcodeproj -scheme FirebaseProxy -configuration Release -archivePath Output/Output-iphonesimulator SKIP_INSTALL=NO

xcodebuild -create-xcframework -framework Output/Output-iphonesimulator.xcarchive/Products/Library/Frameworks/FirebaseProxy.framework -framework Output/Output-iphoneos.xcarchive/Products/Library/Frameworks/FirebaseProxy.framework -output Output/FirebaseProxy.xcframework
