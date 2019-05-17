#!/usr/bin/env bash

PARENT_PATH=$( cd "$(dirname "${BASH_SOURCE[0]}")" ; pwd -P )
URL="https://media.twiliocdn.com/sdk/ios/voice/releases/3.0.0/twilio-voice-ios-static-3.0.0.tar.bz2"
ZIP_NAME="twilio-voice-ios-static-3.0.0.tar.bz2"
LIB_DIR="twilio-voice-ios"

cd "$PARENT_PATH"
curl -L $URL > $ZIP_NAME
tar -xf $ZIP_NAME
mv $LIB_DIR/lib/libboringssl.a libboringssl.a
mv $LIB_DIR/lib/libTwilioVoice.a libTwilioVoice.a
rm -rf $LIB_DIR
rm $ZIP_NAME 