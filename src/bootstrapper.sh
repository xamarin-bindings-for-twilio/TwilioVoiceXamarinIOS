#!/usr/bin/env bash

PARENT_PATH=$( cd "$(dirname "${BASH_SOURCE[0]}")" ; pwd -P )
URL="https://github.com/twilio/twilio-voice-ios/releases/download/5.0.0/libTwilioVoice.zip"
ZIP_NAME="libTwilioVoice.zip"
LIB_DIR="libTwilioVoice"

cd "$PARENT_PATH"
mkdir $LIB_DIR
cd $PARENT_PATH/$LIB_DIR
curl -L $URL > $ZIP_NAME
tar -xf $ZIP_NAME
mv lib/libTwilioVoice.a ../libTwilioVoice.a
cd "$PARENT_PATH"
rm -rf $LIB_DIR