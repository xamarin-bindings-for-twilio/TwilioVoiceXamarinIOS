#!/usr/bin/env bash

PARENT_PATH=$( cd "$(dirname "${BASH_SOURCE[0]}")" ; pwd -P )
URL="https://github.com/twilio/twilio-voice-ios/releases/download/4.2.1/libTwilioVoice.zip"
ZIP_NAME="libTwilioVoice.zip"
LIB_DIR="libTwilioVoice"

cd "$PARENT_PATH"
curl -L $URL > $ZIP_NAME
tar -xf $ZIP_NAME
mv $LIB_DIR/lib/libTwilioVoice.a libTwilioVoice.a
rm -rf $LIB_DIR
rm $ZIP_NAME 